using Microsoft.Extensions.Logging;
using McpCli.Models;
using System.Threading;

namespace McpCli.Services;

public class AdvancedPlanExecutor : IPlanExecutor
{
    private readonly ILogger<AdvancedPlanExecutor> _logger;
    private readonly IMultiMcpServerService _multiMcpServerService;
    private readonly IPlanPersistenceService _planPersistenceService;
    private readonly IAzureAiService _azureAiService;
    private readonly StepContextManager _stepContextManager;

    // Configuration
    private readonly int _maxRetries = 3;
    private readonly TimeSpan _stepTimeout = TimeSpan.FromMinutes(5);
    private readonly TimeSpan _retryDelay = TimeSpan.FromSeconds(2);

    public AdvancedPlanExecutor(
        ILogger<AdvancedPlanExecutor> logger,
        IMultiMcpServerService multiMcpServerService,
        IPlanPersistenceService planPersistenceService,
        IAzureAiService azureAiService,
        StepContextManager stepContextManager)
    {
        _logger = logger;
        _multiMcpServerService = multiMcpServerService;
        _planPersistenceService = planPersistenceService;
        _azureAiService = azureAiService;
        _stepContextManager = stepContextManager;
    }

    public async Task<PlanExecutionResult> ExecutePlanAsync(Plan plan, List<RunningServerInfo> runningServers, ServerToolMapping toolMapping)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var executionStart = DateTime.UtcNow;
        
        try
        {
            _logger.LogInformation("Starting advanced plan execution for plan {PlanId} with {StepCount} steps", plan.Id, plan.Steps.Count);

            // Initialize execution context
            var executionContext = new ExecutionContext
            {
                PlanId = plan.Id,
                StartTime = executionStart,
                CancellationToken = cancellationTokenSource.Token,
                ProgressCallback = CreateProgressCallback(plan.Id)
            };

            // Execute the plan
            var result = await ExecutePlanWithRetryAsync(plan, runningServers, toolMapping, executionContext, plan.Goal);

            _logger.LogInformation("Advanced plan execution completed for plan {PlanId}", plan.Id);
            return result;
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Plan execution was cancelled for plan {PlanId}", plan.Id);
            return CreateCancelledResult(plan, executionStart);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during plan execution for plan {PlanId}", plan.Id);
            return CreateErrorResult(plan, ex, executionStart);
        }
    }

    private async Task<PlanExecutionResult> ExecutePlanWithRetryAsync(
        Plan plan, 
        List<RunningServerInfo> runningServers, 
        ServerToolMapping toolMapping, 
        ExecutionContext executionContext,
        string originalUserPrompt) // Add original user prompt parameter
    {
        var results = new List<string>();
        var context = new Dictionary<string, object>();
        var executedSteps = new List<PlanStep>();
        var skippedSteps = new List<string>();
        var failedSteps = new List<string>();

        // Update plan status
        plan.Status = PlanStatus.InProgress;
        await _planPersistenceService.SavePlanAsync(plan);

        // Execute steps in order with dependency resolution
        foreach (var step in plan.Steps)
        {
            try
            {
                // Check for cancellation
                executionContext.CancellationToken.ThrowIfCancellationRequested();

                // Validate and adjust the step before execution
                var validatedStep = await ValidateAndAdjustStepAsync(step, plan, executedSteps, toolMapping, context);
                if (validatedStep == null)
                {
                    _logger.LogWarning("Skipping step {StepId} due to failed validation.", step.Id);
                    step.Status = StepStatus.Skipped;
                    skippedSteps.Add(step.Id);
                    await _planPersistenceService.SaveStepResultAsync(plan.Id, step);
                    continue;
                }

                // Check if step should be executed based on dependencies
                if (!await ShouldExecuteStepAsync(validatedStep, executedSteps, context, executionContext))
                {
                    _logger.LogDebug("Skipping step {StepId} due to dependencies or conditions", validatedStep.Id);
                    validatedStep.Status = StepStatus.Skipped;
                    skippedSteps.Add(validatedStep.Id);
                    await _planPersistenceService.SaveStepResultAsync(plan.Id, validatedStep);
                    continue;
                }

                // Execute step with retry logic
                var stepResult = await ExecuteStepWithRetryAsync(validatedStep, context, runningServers, toolMapping, executionContext, originalUserPrompt);
                
                if (stepResult.Success)
                {
                    executedSteps.Add(stepResult.Step);
                    results.Add($"Step {step.Id}: {step.Name} - Completed");
                    
                    // Update context with step results
                    UpdateExecutionContext(context, stepResult.Step);
                }
                else
                {
                    failedSteps.Add(step.Id);
                    results.Add($"Step {step.Id}: {step.Name} - Failed: {stepResult.ErrorMessage}");
                    
                    // Check if we should continue or stop on failure
                    if (step.StopOnFailure)
                    {
                        _logger.LogError("Step {StepId} failed and StopOnFailure is true, stopping execution", step.Id);
                        break;
                    }
                }

                // Report progress
                executionContext.ProgressCallback?.Invoke(new ExecutionProgress
                {
                    PlanId = plan.Id,
                    CurrentStep = step.Id,
                    TotalSteps = plan.Steps.Count,
                    CompletedSteps = executedSteps.Count,
                    FailedSteps = failedSteps.Count,
                    SkippedSteps = skippedSteps.Count,
                    Status = failedSteps.Count > 0 ? "Failed" : "In Progress"
                });

            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Step {StepId} execution was cancelled", step.Id);
                step.Status = StepStatus.Cancelled;
                await _planPersistenceService.SaveStepResultAsync(plan.Id, step);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error executing step {StepId}", step.Id);
                step.Status = StepStatus.Failed;
                step.ErrorMessage = ex.Message;
                step.CompletedAt = DateTime.UtcNow;
                await _planPersistenceService.SaveStepResultAsync(plan.Id, step);
                failedSteps.Add(step.Id);
            }
        }

        // Generate final response using AI
        var finalResponse = await GenerateFinalResponseAsync(plan.Goal, results, context, executedSteps, executionContext);
        var detailedResponse = await GenerateDetailedResponseAsync(plan.Goal, results, context, executedSteps, executionContext);

        var totalDuration = DateTime.UtcNow - executionContext.StartTime;

        // Determine final status
        var finalStatus = failedSteps.Count > 0 ? PlanStatus.Failed : 
                         executionContext.CancellationToken.IsCancellationRequested ? PlanStatus.Cancelled : 
                         PlanStatus.Completed;

        _logger.LogInformation("Plan {PlanId} execution completed with status {Status}", plan.Id, finalStatus);

        // Save detailed response to plan
        plan.ActualOutputs = new Dictionary<string, object>
        {
            ["detailed_response"] = detailedResponse,
            ["execution_summary"] = results,
            ["context_data"] = context,
            ["step_results"] = executedSteps.Select(s => new
            {
                StepId = s.Id,
                StepName = s.Name,
                Status = s.Status,
                Result = s.ActualOutputs?.GetValueOrDefault("raw_result", ""),
                StartedAt = s.StartedAt,
                CompletedAt = s.CompletedAt
            }).ToList()
        };
        await _planPersistenceService.SavePlanAsync(plan);

        return new PlanExecutionResult
        {
            PlanId = plan.Id,
            FinalStatus = finalStatus,
            TotalSteps = plan.Steps.Count,
            CompletedSteps = executedSteps.Count,
            FailedSteps = failedSteps.Count,
            SkippedSteps = skippedSteps.Count,
            TotalDuration = totalDuration,
            StartedAt = executionContext.StartTime,
            CompletedAt = DateTime.UtcNow,
            FinalOutputs = new Dictionary<string, object> { ["response"] = finalResponse },
            StepResults = executedSteps,
            ErrorMessage = failedSteps.Count > 0 ? $"Failed steps: {string.Join(", ", failedSteps)}" : null
        };
    }

    private async Task<StepExecutionResult> ExecuteStepWithRetryAsync(
        PlanStep step, 
        Dictionary<string, object> context, 
        List<RunningServerInfo> runningServers, 
        ServerToolMapping toolMapping, 
        ExecutionContext executionContext,
        string originalUserPrompt) // Add original user prompt parameter
    {
        var retryCount = 0;
        Exception? lastException = null;

        while (retryCount <= _maxRetries)
        {
            try
            {
                _logger.LogDebug("Executing step {StepId} (attempt {Attempt})", step.Id, retryCount + 1);

                // Update step status
                step.Status = StepStatus.InProgress;
                step.StartedAt = DateTime.UtcNow;
                await _planPersistenceService.SaveStepResultAsync(executionContext.PlanId, step);

                // Log detailed step information
                _logger.LogInformation("=== STEP EXECUTION START ===");
                _logger.LogInformation("Plan ID: {PlanId}", executionContext.PlanId);
                _logger.LogInformation("Step ID: {StepId}", step.Id);
                _logger.LogInformation("Step Name: {StepName}", step.Name);
                _logger.LogInformation("Status: {Status}", step.Status);
                _logger.LogInformation("Goal: {Goal}", step.Description);
                _logger.LogInformation("=== STEP EXECUTION START ===");
                
                // Prompt Section (moved out of execution details)
                _logger.LogInformation("=== PROMPT ===");
                _logger.LogInformation("Prompt: {Prompt}", step.Prompt);
                _logger.LogInformation("=== PROMPT ===");
                
                // Build context from previous steps
                var previousStepContext = BuildPreviousStepContext(context, step.Id);
                if (!string.IsNullOrEmpty(previousStepContext))
                {
                    _logger.LogInformation("Previous Step Context: {Context}", previousStepContext);
                }

                // Create timeout cancellation token for this step
                using var stepTimeoutCts = CancellationTokenSource.CreateLinkedTokenSource(executionContext.CancellationToken);
                stepTimeoutCts.CancelAfter(_stepTimeout);

                string result;
                string? selectedTool = null;
                string? selectedServer = null;
                Dictionary<string, object>? toolParameters = null;
                
                if (step.IsPromptBased)
                {
                    // Prompt-based step: use AI to select and execute the tool
                    var toolList = await BuildToolListWithServerInfoAsync(toolMapping, runningServers);
                    var aiPrompt = $@"
You are an AI assistant executing a step in a larger plan.

ORIGINAL USER REQUEST: {originalUserPrompt}

CURRENT STEP GOAL: {step.Prompt}

{(!string.IsNullOrEmpty(previousStepContext) ? $"IMPORTANT - Previous step results (use this data to extract required parameters):\n{previousStepContext}\n" : "")}

Available tools:
{toolList}

INSTRUCTIONS:
1. CONSIDER the original user request above to understand the broader context and intent
2. FOCUS on the current step goal while keeping the original request in mind
3. EXTRACT required parameter values from BOTH the current step goal AND previous step results:
   - First, look for parameter values directly mentioned in the CURRENT STEP GOAL (e.g., project names, repository names, branch names, counts, etc.)
   - Then, supplement with any additional parameter values from previous step results
   - Use actual values from either source - do NOT use placeholder values like ""Specify the project name""
4. EXAMPLES of parameter extraction from current step goal:
   - ""Get repositories in the internal project"" -> projectName: ""internal""
   - ""Get repositories from the internal project"" -> projectName: ""internal""
   - ""Get all repositories from the internal project in the Azure DevOps organization"" -> projectName: ""internal""
   - ""List 5 recent pull requests"" -> maxCount: 5
   - ""Get pull requests targeting main branch"" -> targetBranch: ""main""
   - ""Find pull requests in dotnet-helix-service repository"" -> repositoryName: ""dotnet-helix-service""
   - ""Get builds for the public project"" -> projectName: ""public""
   - ""Show repositories in dnceng organization"" -> organizationName: ""dnceng""
5. If previous steps contain additional data (project lists, repository lists, etc.), use those actual names/values to supplement
6. Select the single best tool from the list above to accomplish the current step goal
7. Use the exact parameter names shown in the tool descriptions above
8. Provide the tool name and parameters with REAL VALUES (not placeholders) as JSON

Response format:
{{
  ""tool"": ""tool_name"",
  ""parameters"": {{ ""param1"": ""actual_value_from_step_goal_or_previous_results"", ""param2"": ""another_real_value"" }}
}}

If you cannot extract the required parameters from either the current step goal or previous step results, return an empty JSON object {{}}.
Do not invent tool names. Only use tools from the list above.
";

                    _logger.LogInformation("Sending AI prompt for tool selection...");
                    var aiResponse = await _azureAiService.SendPromptAsync(aiPrompt);
                    _logger.LogInformation("AI tool selection response: {Response}", aiResponse);

                    // Store AI response in step
                    step.ActualOutputs = new Dictionary<string, object>
                    {
                        ["ai_tool_selection_response"] = aiResponse
                    };

                    // Try to parse the AI response as JSON
                    string? toolName = null;
                    Dictionary<string, object> parameters = new();
                    try
                    {
                        var jsonStart = aiResponse.IndexOf('{');
                        var jsonEnd = aiResponse.LastIndexOf('}');
                        if (jsonStart >= 0 && jsonEnd > jsonStart)
                        {
                            var jsonContent = aiResponse.Substring(jsonStart, jsonEnd - jsonStart + 1);
                            var doc = System.Text.Json.JsonDocument.Parse(jsonContent);
                            if (doc.RootElement.TryGetProperty("tool", out var toolProp))
                            {
                                toolName = toolProp.GetString();
                                selectedTool = toolName;
                            }
                            if (doc.RootElement.TryGetProperty("parameters", out var paramsProp) && paramsProp.ValueKind == System.Text.Json.JsonValueKind.Object)
                            {
                                foreach (var prop in paramsProp.EnumerateObject())
                                {
                                    parameters[prop.Name] = prop.Value.ToString();
                                }
                                toolParameters = parameters;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Failed to parse AI tool selection response as JSON");
                    }

                    if (string.IsNullOrEmpty(toolName))
                    {
                        _logger.LogWarning("AI did not select a tool for prompt: {Prompt}", step.Prompt);
                        result = "[AI did not select a tool for this prompt]";
                    }
                    else
                    {
                        // Determine which server the tool will be executed on
                        selectedServer = toolMapping.ToolToServer.GetValueOrDefault(toolName, "unknown");
                        
                        _logger.LogInformation("Executing tool selected by AI: {ToolName} with parameters: {Parameters}", toolName, System.Text.Json.JsonSerializer.Serialize(parameters));
                        result = await _multiMcpServerService.CallToolAsync(toolName, parameters, runningServers, toolMapping, null);
                    }
                }
                else
                {
                    // Tool-based step (legacy)
                    selectedTool = step.ToolName;
                    selectedServer = toolMapping.ToolToServer.GetValueOrDefault(step.ToolName, "unknown");
                    
                    var resolvedInputs = await _stepContextManager.InjectContextIntoInputsAsync(step.Inputs, context, step.Id);
                    toolParameters = resolvedInputs;
                    result = await _multiMcpServerService.CallToolAsync(
                        step.ToolName, 
                        resolvedInputs, 
                        runningServers, 
                        toolMapping, 
                        null);
                }

                // Parse and store results
                var parsedResults = await ParseStepResultsAsync(result, step);
                context[$"step_{step.Id}_result"] = result;
                context[$"step_{step.Id}_parsed"] = parsedResults;

                step.Status = StepStatus.Completed;
                step.CompletedAt = DateTime.UtcNow;
                step.ActualOutputs = step.ActualOutputs ?? new Dictionary<string, object>();
                step.ActualOutputs["raw_result"] = result;
                step.ActualOutputs["parsed_results"] = parsedResults;
                
                // Update step with actual server and tool used during execution
                if (!string.IsNullOrEmpty(selectedServer))
                {
                    step.ServerName = selectedServer;
                }
                if (!string.IsNullOrEmpty(selectedTool))
                {
                    step.ToolName = selectedTool;
                }
                
                await _planPersistenceService.SaveStepResultAsync(executionContext.PlanId, step);

                _logger.LogInformation("=== STEP EXECUTION COMPLETE ===");
                _logger.LogInformation("Step ID: {StepId}", step.Id);
                _logger.LogInformation("Status: {Status}", step.Status);
                
                // Tool and Server Information (added after completion)
                _logger.LogInformation("=== TOOL & SERVER DETAILS ===");
                _logger.LogInformation("Tool: {ToolName}", selectedTool ?? "N/A");
                _logger.LogInformation("Server: {ServerName}", selectedServer ?? "N/A");
                if (toolParameters != null && toolParameters.Count > 0)
                {
                    _logger.LogInformation("Parameters: {Parameters}", System.Text.Json.JsonSerializer.Serialize(toolParameters));
                }
                _logger.LogInformation("=== TOOL & SERVER DETAILS ===");
                
                // Execution Details (Response moved here)
                _logger.LogInformation("=== EXECUTION DETAILS ===");
                _logger.LogInformation("Response: {Result}", result.Substring(0, Math.Min(200, result.Length)) + (result.Length > 200 ? "..." : ""));
                _logger.LogInformation("=== EXECUTION DETAILS ===");
                
                _logger.LogInformation("=== STEP EXECUTION COMPLETE ===");

                return new StepExecutionResult
                {
                    Step = step,
                    Success = true,
                    Result = result
                };
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                lastException = ex;
                retryCount++;
                _logger.LogWarning(ex, "Error executing step {StepId} (attempt {Attempt})", step.Id, retryCount);
                if (retryCount > _maxRetries)
                {
                    step.Status = StepStatus.Failed;
                    step.CompletedAt = DateTime.UtcNow;
                    step.ErrorMessage = ex.Message;
                    await _planPersistenceService.SaveStepResultAsync(executionContext.PlanId, step);
                    return new StepExecutionResult
                    {
                        Step = step,
                        Success = false,
                        Result = ex.Message
                    };
                }
                await Task.Delay(_retryDelay);
            }
        }

        // If we get here, all retries failed
        throw lastException ?? new Exception("Unknown error executing step");
    }

    private async Task<string> BuildToolListWithServerInfoAsync(ServerToolMapping serverToolMapping, List<RunningServerInfo> runningServers)
    {
        var toolsInfo = new List<string>();
        
        foreach (var tool in serverToolMapping.AllTools)
        {
            var serverName = serverToolMapping.ToolToServer.GetValueOrDefault(tool, "unknown");
            var serverInfo = runningServers.FirstOrDefault(s => s.Name == serverName);
            
            if (serverInfo != null)
            {
                try
                {
                    // Get tool schemas to provide parameter information
                    _logger.LogInformation("Getting tool schemas for server {ServerName}", serverName);
                    var toolSchemas = await _multiMcpServerService.GetToolSchemasAsync(serverInfo);
                    _logger.LogInformation("Retrieved {SchemaCount} tool schemas for server {ServerName}", toolSchemas.Count, serverName);
                    
                    if (toolSchemas.TryGetValue(tool, out var schema) && schema is Dictionary<string, object> schemaDict)
                    {
                        _logger.LogInformation("Found schema for tool {ToolName}: {Schema}", tool, System.Text.Json.JsonSerializer.Serialize(schemaDict));
                        
                        var description = schemaDict.GetValueOrDefault("description", "").ToString();
                        var parameterInfo = "";
                        
                        // Extract parameter information from input schema
                        if (schemaDict.TryGetValue("inputSchema", out var inputSchemaObj))
                        {
                            Dictionary<string, object>? inputSchema = null;
                            
                            // Handle different types of input schema objects
                            if (inputSchemaObj is Dictionary<string, object> directDict)
                            {
                                inputSchema = directDict;
                            }
                            else if (inputSchemaObj is System.Text.Json.JsonElement jsonElement)
                            {
                                try
                                {
                                    var jsonString = jsonElement.GetRawText();
                                    var tempDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
                                    inputSchema = tempDict;
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogDebug("Could not parse input schema as Dictionary for tool {ToolName}: {Error}", tool, ex.Message);
                                }
                            }
                            
                            if (inputSchema != null)
                            {
                                _logger.LogInformation("Found input schema for tool {ToolName}: {InputSchema}", tool, System.Text.Json.JsonSerializer.Serialize(inputSchema));
                                
                                if (inputSchema.TryGetValue("properties", out var propertiesObj))
                                {
                                    Dictionary<string, object>? properties = null;
                                    
                                    // Handle different types of properties objects
                                    if (propertiesObj is Dictionary<string, object> directPropsDict)
                                    {
                                        properties = directPropsDict;
                                    }
                                    else if (propertiesObj is System.Text.Json.JsonElement propsJsonElement)
                                    {
                                        try
                                        {
                                            var propsJsonString = propsJsonElement.GetRawText();
                                            properties = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(propsJsonString);
                                        }
                                        catch (Exception ex)
                                        {
                                            _logger.LogDebug("Could not parse properties as Dictionary for tool {ToolName}: {Error}", tool, ex.Message);
                                        }
                                    }
                                    
                                    if (properties != null)
                                    {
                                        var paramNames = properties.Keys.ToList();
                                        if (paramNames.Any())
                                        {
                                            // Create detailed parameter information
                                            var paramDetails = new List<string>();
                                            foreach (var paramName in paramNames)
                                            {
                                                if (properties.TryGetValue(paramName, out var paramSchemaObj))
                                                {
                                                    var paramType = "string"; // default
                                                    var isRequired = false;
                                                    var hasDefault = false;
                                                    
                                                    // Try to extract parameter type
                                                    if (paramSchemaObj is Dictionary<string, object> paramSchema)
                                                    {
                                                        paramType = paramSchema.GetValueOrDefault("type", "string").ToString() ?? "string";
                                                    }
                                                    else if (paramSchemaObj is System.Text.Json.JsonElement paramJsonElement)
                                                    {
                                                        try
                                                        {
                                                            if (paramJsonElement.TryGetProperty("type", out var typeElement))
                                                            {
                                                                paramType = typeElement.GetString() ?? "string";
                                                            }
                                                        }
                                                        catch { /* ignore */ }
                                                    }
                                                    
                                                    // Check if parameter is required
                                                    if (inputSchema.TryGetValue("required", out var requiredObj))
                                                    {
                                                        if (requiredObj is System.Text.Json.JsonElement requiredElement && requiredElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                                                        {
                                                            isRequired = requiredElement.EnumerateArray().Any(e => e.GetString() == paramName);
                                                        }
                                                        else if (requiredObj is List<object> requiredList)
                                                        {
                                                            isRequired = requiredList.Any(r => r.ToString() == paramName);
                                                        }
                                                    }
                                                    
                                                    // Check if parameter has a default value in the server configuration
                                                    if (serverInfo.ToolDefaults.TryGetValue(tool, out var toolDefaults) && 
                                                        toolDefaults.ContainsKey(paramName))
                                                    {
                                                        hasDefault = true;
                                                        var defaultValue = toolDefaults[paramName];
                                                        paramDetails.Add($"{paramName}({paramType}){(isRequired ? " [REQUIRED]" : "")} [DEFAULT: {defaultValue}]");
                                                    }
                                                    else
                                                    {
                                                        paramDetails.Add($"{paramName}({paramType}){(isRequired ? " [REQUIRED]" : "")}");
                                                    }
                                                }
                                                else
                                                {
                                                    paramDetails.Add($"{paramName}(string)");
                                                }
                                            }
                                            parameterInfo = $"\n    Parameters: {string.Join(", ", paramDetails)}";
                                            _logger.LogInformation("Extracted parameter names for tool {ToolName}: {ParameterNames}", tool, string.Join(", ", paramNames));
                                        }
                                    }
                                }
                            }
                        }
                        
                        toolsInfo.Add($"- {tool} [Server: {serverName}] - {description}{parameterInfo}");
                    }
                    else
                    {
                        _logger.LogInformation("No schema found for tool {ToolName} on server {ServerName}", tool, serverName);
                        // Fallback to basic tool info if schema not available
                        toolsInfo.Add($"- {tool} [Server: {serverName}]");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Error getting schema for tool {ToolName}", tool);
                    toolsInfo.Add($"- {tool} [Server: {serverName}]");
                }
            }
            else
            {
                // Handle conflicting tools
                if (serverToolMapping.ConflictingTools.ContainsKey(tool))
                {
                    var conflictServers = string.Join(", ", serverToolMapping.ConflictingTools[tool]);
                    toolsInfo.Add($"- {tool} [Available on: {conflictServers}]");
                }
                else
                {
                    toolsInfo.Add($"- {tool} [Server: {serverName}]");
                }
            }
        }
        
        return string.Join("\n", toolsInfo);
    }

    private string BuildToolListWithServerInfo(ServerToolMapping serverToolMapping)
    {
        var toolsInfo = new List<string>();
        foreach (var tool in serverToolMapping.AllTools)
        {
            var serverName = serverToolMapping.ToolToServer.GetValueOrDefault(tool, "unknown");
            if (serverToolMapping.ConflictingTools.ContainsKey(tool))
            {
                var conflictServers = string.Join(", ", serverToolMapping.ConflictingTools[tool]);
                toolsInfo.Add($"- {tool} [Available on: {conflictServers}]");
            }
            else
            {
                toolsInfo.Add($"- {tool} [Server: {serverName}]");
            }
        }
        return string.Join("\n", toolsInfo);
    }

    private async Task<bool> ShouldExecuteStepAsync(PlanStep step, List<PlanStep> executedSteps, Dictionary<string, object> context, ExecutionContext executionContext)
    {
        // Check for cancellation
        executionContext.CancellationToken.ThrowIfCancellationRequested();

        // Check dependencies
        foreach (var dependencyId in step.Dependencies)
        {
            var dependency = executedSteps.FirstOrDefault(s => s.Id == dependencyId);
            if (dependency == null || dependency.Status != StepStatus.Completed)
            {
                _logger.LogDebug("Step {StepId} waiting for dependency {DependencyId}", step.Id, dependencyId);
                return false;
            }
        }

        // Check conditional logic
        if (!string.IsNullOrEmpty(step.ContextFromPreviousSteps))
        {
            var shouldExecute = await EvaluateConditionAsync(step.ContextFromPreviousSteps, context, executionContext);
            if (!shouldExecute)
            {
                _logger.LogDebug("Step {StepId} skipped due to condition: {Condition}", step.Id, step.ContextFromPreviousSteps);
                return false;
            }
        }

        return true;
    }

    private async Task<bool> EvaluateConditionAsync(string condition, Dictionary<string, object> context, ExecutionContext executionContext)
    {
        try
        {
            // Check for cancellation
            executionContext.CancellationToken.ThrowIfCancellationRequested();

            var conditionPrompt = $@"
Evaluate the following condition based on the context:

**Condition**: {condition}

**Context**: {System.Text.Json.JsonSerializer.Serialize(context, new System.Text.Json.JsonSerializerOptions { WriteIndented = true })}

**Task**: Determine if the condition is true or false based on the context.

Respond with only 'true' or 'false'.
";

            var response = await _azureAiService.SendPromptAsync(conditionPrompt);
            return response.Trim().ToLowerInvariant() == "true";
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error evaluating condition: {Condition}", condition);
            return true; // Default to executing if condition evaluation fails
        }
    }

    private async Task<Dictionary<string, object>> ParseStepResultsAsync(string result, PlanStep step)
    {
        try
        {
            // Try to parse JSON results
            if (result.Trim().StartsWith("{") || result.Trim().StartsWith("["))
            {
                var jsonElement = System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(result);
                return ParseJsonElement(jsonElement);
            }
            
            // For text results, create a simple structure
            return new Dictionary<string, object>
            {
                ["text"] = result,
                ["length"] = result.Length,
                ["has_content"] = !string.IsNullOrWhiteSpace(result)
            };
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Could not parse results for step {StepId}", step.Id);
            return new Dictionary<string, object>
            {
                ["raw_text"] = result,
                ["parse_error"] = ex.Message
            };
        }
    }

    private Dictionary<string, object> ParseJsonElement(System.Text.Json.JsonElement element)
    {
        var result = new Dictionary<string, object>();
        
        switch (element.ValueKind)
        {
            case System.Text.Json.JsonValueKind.Object:
                foreach (var property in element.EnumerateObject())
                {
                    result[property.Name] = ParseJsonValue(property.Value);
                }
                break;
            case System.Text.Json.JsonValueKind.Array:
                var array = new List<object>();
                foreach (var item in element.EnumerateArray())
                {
                    array.Add(ParseJsonValue(item));
                }
                result["items"] = array;
                result["count"] = array.Count;
                break;
            default:
                result["value"] = ParseJsonValue(element);
                break;
        }
        
        return result;
    }

    private object ParseJsonValue(System.Text.Json.JsonElement element)
    {
        return element.ValueKind switch
        {
            System.Text.Json.JsonValueKind.String => element.GetString() ?? "",
            System.Text.Json.JsonValueKind.Number => element.TryGetInt32(out var intValue) ? intValue : element.GetDouble(),
            System.Text.Json.JsonValueKind.True => true,
            System.Text.Json.JsonValueKind.False => false,
            System.Text.Json.JsonValueKind.Null => null!,
            System.Text.Json.JsonValueKind.Object => ParseJsonElement(element),
            System.Text.Json.JsonValueKind.Array => ParseJsonElement(element),
            _ => element.ToString()
        };
    }

    private void UpdateExecutionContext(Dictionary<string, object> context, PlanStep step)
    {
        context[$"step_{step.Id}_result"] = step.ActualOutputs.GetValueOrDefault("raw_result", "");
        context[$"step_{step.Id}_parsed"] = step.ActualOutputs.GetValueOrDefault("parsed_results", new Dictionary<string, object>());
        context[$"step_{step.Id}_name"] = step.Name;
        context[$"step_{step.Id}_tool"] = step.ToolName;
        context[$"step_{step.Id}_server"] = step.ServerName;
        context[$"step_{step.Id}_duration"] = step.Duration?.TotalSeconds ?? 0;
        context[$"step_{step.Id}_started"] = step.StartedAt;
        context[$"step_{step.Id}_completed"] = step.CompletedAt;
    }

    private async Task<string> GenerateFinalResponseAsync(string goal, List<string> results, Dictionary<string, object> context, List<PlanStep> executedSteps, ExecutionContext executionContext)
    {
        try
        {
            // Check for cancellation
            executionContext.CancellationToken.ThrowIfCancellationRequested();

            // For console display, return only the final step's results
            if (executedSteps.Any())
            {
                var finalStep = executedSteps.Last();
                var finalResult = finalStep.ActualOutputs?.GetValueOrDefault("raw_result", "")?.ToString() ?? "";
                
                // If the final result is JSON, try to extract meaningful content
                if (finalResult.StartsWith("{") || finalResult.StartsWith("["))
                {
                    try
                    {
                        var jsonDoc = System.Text.Json.JsonDocument.Parse(finalResult);
                        if (jsonDoc.RootElement.TryGetProperty("content", out var content))
                        {
                            if (content.ValueKind == System.Text.Json.JsonValueKind.Array && content.GetArrayLength() > 0)
                            {
                                var firstContent = content[0];
                                if (firstContent.TryGetProperty("text", out var text))
                                {
                                    return text.GetString() ?? finalResult;
                                }
                            }
                        }
                    }
                    catch
                    {
                        // If JSON parsing fails, return the raw result
                    }
                }
                
                return finalResult;
            }

            // Fallback: return a simple success message
            return $"Plan executed successfully. {executedSteps.Count} steps completed. Goal: {goal}";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating final response");
            return $"Plan executed successfully. {executedSteps.Count} steps completed. Goal: {goal}";
        }
    }

    private async Task<string> GenerateDetailedResponseAsync(string goal, List<string> results, Dictionary<string, object> context, List<PlanStep> executedSteps, ExecutionContext executionContext)
    {
        try
        {
            // Check for cancellation
            executionContext.CancellationToken.ThrowIfCancellationRequested();

            var finalPrompt = $@"
Based on the execution results, provide a comprehensive response to the user's original goal.

**Original Goal**: {goal}

**Execution Summary**:
{string.Join("\n", results)}

**Context Data**: {System.Text.Json.JsonSerializer.Serialize(context, new System.Text.Json.JsonSerializerOptions { WriteIndented = true })}

**Task**: Provide a helpful, natural language response that addresses the user's original goal based on the execution results. Consolidate information from different steps where appropriate and provide insights or recommendations if relevant.

Make the response informative, well-structured, and directly relevant to what the user asked for.
";

            return await _azureAiService.SendPromptAsync(finalPrompt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating detailed response");
            return $"Plan executed successfully. {executedSteps.Count} steps completed. Goal: {goal}";
        }
    }

    private Action<ExecutionProgress> CreateProgressCallback(string planId)
    {
        return progress =>
        {
            _logger.LogInformation("Plan {PlanId} Progress: {Completed}/{Total} steps completed, {Failed} failed, {Skipped} skipped - Status: {Status}", 
                planId, progress.CompletedSteps, progress.TotalSteps, progress.FailedSteps, progress.SkippedSteps, progress.Status);
        };
    }

    private PlanExecutionResult CreateCancelledResult(Plan plan, DateTime startTime)
    {
        return new PlanExecutionResult
        {
            PlanId = plan.Id,
            FinalStatus = PlanStatus.Cancelled,
            TotalSteps = plan.Steps.Count,
            CompletedSteps = 0,
            FailedSteps = 0,
            SkippedSteps = 0,
            ErrorMessage = "Plan execution was cancelled",
            StartedAt = startTime,
            CompletedAt = DateTime.UtcNow
        };
    }

    private PlanExecutionResult CreateErrorResult(Plan plan, Exception ex, DateTime startTime)
    {
        return new PlanExecutionResult
        {
            PlanId = plan.Id,
            FinalStatus = PlanStatus.Failed,
            TotalSteps = plan.Steps.Count,
            CompletedSteps = 0,
            FailedSteps = 0,
            SkippedSteps = 0,
            ErrorMessage = ex.Message,
            StartedAt = startTime,
            CompletedAt = DateTime.UtcNow
        };
    }

    private async Task<PlanStep?> ValidateAndAdjustStepAsync(PlanStep step, Plan plan, List<PlanStep> executedSteps, ServerToolMapping toolMapping, Dictionary<string, object> previousOutputs)
    {
        // For prompt-based steps, skip tool validation
        if (step.IsPromptBased)
        {
            _logger.LogInformation("Step {StepId}: Validating prompt-based step '{StepName}'", step.Id, step.Name);
            
            // Check dependencies are satisfied
            if (step.Dependencies != null && step.Dependencies.Any(dep => !executedSteps.Any(s => s.Id == dep && s.Status == StepStatus.Completed)))
            {
                _logger.LogWarning("Step {StepId}: Dependencies not satisfied. Skipping step.", step.Id);
                return null;
            }
            
            // Check parameters (inputs) are present if required (basic check)
            if (step.Inputs != null)
            {
                foreach (var input in step.Inputs)
                {
                    if (input.Value is string strVal && strVal.StartsWith("{") && strVal.EndsWith("}"))
                    {
                        var refKey = strVal.Trim('{', '}');
                        if (!previousOutputs.ContainsKey(refKey))
                        {
                            _logger.LogWarning("Step {StepId}: Input '{InputKey}' references missing output '{RefKey}'. Skipping step.", step.Id, input.Key, refKey);
                            return null;
                        }
                    }
                }
            }
            
            // Prompt-based step validation passed
            _logger.LogInformation("Step {StepId}: Prompt-based step validation passed", step.Id);
            return step;
        }
        
        // For tool-based steps, perform full validation
        // Check tool exists and is available
        if (!toolMapping.ToolToServer.ContainsKey(step.ToolName))
        {
            _logger.LogWarning("Step {StepId}: Tool '{ToolName}' not found in available tools. Skipping step.", step.Id, step.ToolName);
            return null;
        }
        
        // Check dependencies are satisfied
        if (step.Dependencies != null && step.Dependencies.Any(dep => !executedSteps.Any(s => s.Id == dep && s.Status == StepStatus.Completed)))
        {
            _logger.LogWarning("Step {StepId}: Dependencies not satisfied. Skipping step.", step.Id);
            return null;
        }
        
        // Check parameters (inputs) are present if required (basic check)
        if (step.Inputs != null)
        {
            foreach (var input in step.Inputs)
            {
                if (input.Value is string strVal && strVal.StartsWith("{") && strVal.EndsWith("}"))
                {
                    var refKey = strVal.Trim('{', '}');
                    if (!previousOutputs.ContainsKey(refKey))
                    {
                        _logger.LogWarning("Step {StepId}: Input '{InputKey}' references missing output '{RefKey}'. Skipping step.", step.Id, input.Key, refKey);
                        return null;
                    }
                }
            }
        }
        
        // If all checks pass, return the step as-is
        return step;
    }

    private string BuildPreviousStepContext(Dictionary<string, object> context, string currentStepId)
    {
        var contextParts = new List<string>();
        
        // Get all previous step results, ordered by step number (most recent first)
        var stepResults = new List<(int stepNum, string stepId, string result, object? parsed)>();
        
        foreach (var kvp in context)
        {
            if (kvp.Key.StartsWith("step_") && kvp.Key.EndsWith("_result"))
            {
                var stepId = kvp.Key.Replace("step_", "").Replace("_result", "");
                if (int.TryParse(stepId, out var stepNum) && int.TryParse(currentStepId, out var currentStepNum) && stepNum < currentStepNum)
                {
                    var result = kvp.Value?.ToString() ?? "";
                    var parsedKey = $"step_{stepId}_parsed";
                    var parsed = context.ContainsKey(parsedKey) ? context[parsedKey] : null;
                    stepResults.Add((stepNum, stepId, result, parsed));
                }
            }
        }
        
        // Sort by step number descending (most recent first)
        stepResults.Sort((a, b) => b.stepNum.CompareTo(a.stepNum));
        
        // Build context with full results and parsed data
        foreach (var (stepNum, stepId, result, parsed) in stepResults)
        {
            contextParts.Add($"Step {stepId} Result: {result}");
            
            // Add parsed data if available
            if (parsed != null)
            {
                try
                {
                    var parsedJson = System.Text.Json.JsonSerializer.Serialize(parsed, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                    contextParts.Add($"Step {stepId} Parsed Data: {parsedJson}");
                }
                catch
                {
                    contextParts.Add($"Step {stepId} Parsed Data: {parsed}");
                }
            }
        }
        
        return string.Join("\n", contextParts);
    }

    // Helper classes
    private class ExecutionContext
    {
        public string PlanId { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public Action<ExecutionProgress>? ProgressCallback { get; set; }
    }

    private class StepExecutionResult
    {
        public bool Success { get; set; }
        public string? Result { get; set; }
        public PlanStep Step { get; set; } = new();
        public string? ErrorMessage { get; set; }
        [Obsolete("Use Success instead")] public bool IsSuccess { get => Success; set => Success = value; }
    }
}

public class ExecutionProgress
{
    public string PlanId { get; set; } = string.Empty;
    public string CurrentStep { get; set; } = string.Empty;
    public int TotalSteps { get; set; }
    public int CompletedSteps { get; set; }
    public int FailedSteps { get; set; }
    public int SkippedSteps { get; set; }
    public string Status { get; set; } = string.Empty;
} 