using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class BasicPlanExecutor : IPlanExecutor
{
    private readonly ILogger<BasicPlanExecutor> _logger;
    private readonly IMultiMcpServerService _multiMcpServerService;
    private readonly IPlanPersistenceService _planPersistenceService;

    public BasicPlanExecutor(
        ILogger<BasicPlanExecutor> logger,
        IMultiMcpServerService multiMcpServerService,
        IPlanPersistenceService planPersistenceService)
    {
        _logger = logger;
        _multiMcpServerService = multiMcpServerService;
        _planPersistenceService = planPersistenceService;
    }

    public async Task<PlanExecutionResult> ExecutePlanAsync(Plan plan, List<RunningServerInfo> runningServers, ServerToolMapping toolMapping)
    {
        try
        {
            _logger.LogInformation("Executing plan {PlanId} with {StepCount} steps", plan.Id, plan.Steps.Count);

            var results = new List<string>();
            var context = new Dictionary<string, object>();

            // Execute steps in order
            foreach (var step in plan.Steps)
            {
                try
                {
                    _logger.LogDebug("Executing step {StepId}: {StepName}", step.Id, step.Name);
                    
                    // Update step status
                    step.Status = StepStatus.InProgress;
                    step.StartedAt = DateTime.UtcNow;
                    await _planPersistenceService.SaveStepResultAsync(plan.Id, step);

                    string result;
                    
                    if (step.IsPromptBased)
                    {
                        // Execute prompt-based step using simple mode
                        _logger.LogDebug("Executing prompt-based step: {Prompt}", step.Prompt);
                        result = await ExecutePromptStepAsync(step.Prompt, runningServers, toolMapping, context);
                    }
                    else
                    {
                        // Execute tool-based step (legacy)
                        _logger.LogDebug("Executing tool-based step: {Server}.{Tool}", step.ServerName, step.ToolName);
                        var parameters = ResolveParameters(step.Inputs, context);
                        result = await _multiMcpServerService.CallToolAsync(
                            step.ToolName, 
                            parameters, 
                            runningServers, 
                            toolMapping, 
                            null);
                    }

                    // Update step with results
                    step.Status = StepStatus.Completed;
                    step.CompletedAt = DateTime.UtcNow;
                    step.ActualOutputs = new Dictionary<string, object>
                    {
                        ["result"] = result
                    };

                    // Save step result
                    await _planPersistenceService.SaveStepResultAsync(plan.Id, step);

                    // Add to context for future steps
                    context[$"step_{step.Id}_result"] = result;
                    results.Add($"Step {step.Id}: {result}");

                    _logger.LogDebug("Step {StepId} completed successfully", step.Id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error executing step {StepId}", step.Id);
                    
                    // Update step with error
                    step.Status = StepStatus.Failed;
                    step.CompletedAt = DateTime.UtcNow;
                    step.ErrorMessage = ex.Message;
                    
                    await _planPersistenceService.SaveStepResultAsync(plan.Id, step);

                    return new PlanExecutionResult
                    {
                        PlanId = plan.Id,
                        FinalStatus = PlanStatus.Failed,
                        TotalSteps = plan.Steps.Count,
                        CompletedSteps = plan.Steps.TakeWhile(s => s.Id != step.Id).Count(),
                        FailedSteps = 1,
                        ErrorMessage = $"Step {step.Id} failed: {ex.Message}",
                        StartedAt = DateTime.UtcNow,
                        CompletedAt = DateTime.UtcNow
                    };
                }
            }

            // Generate final response
            var finalResponse = await GenerateFinalResponseAsync(plan.Goal, results);

            var totalDuration = TimeSpan.FromTicks(plan.Steps
                .Where(s => s.Duration.HasValue)
                .Sum(s => s.Duration!.Value.Ticks));

            _logger.LogInformation("Plan {PlanId} executed successfully", plan.Id);

            return new PlanExecutionResult
            {
                PlanId = plan.Id,
                FinalStatus = PlanStatus.Completed,
                TotalSteps = plan.Steps.Count,
                CompletedSteps = plan.Steps.Count,
                FailedSteps = 0,
                TotalDuration = totalDuration,
                StartedAt = DateTime.UtcNow,
                CompletedAt = DateTime.UtcNow,
                FinalOutputs = new Dictionary<string, object> { ["response"] = finalResponse },
                StepResults = plan.Steps
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing plan {PlanId}", plan.Id);
            return new PlanExecutionResult
            {
                PlanId = plan.Id,
                FinalStatus = PlanStatus.Failed,
                TotalSteps = plan.Steps.Count,
                CompletedSteps = 0,
                FailedSteps = 0,
                ErrorMessage = ex.Message,
                StartedAt = DateTime.UtcNow,
                CompletedAt = DateTime.UtcNow
            };
        }
    }

    private Dictionary<string, object> ResolveParameters(Dictionary<string, object> inputs, Dictionary<string, object> context)
    {
        var resolved = new Dictionary<string, object>();
        
        foreach (var input in inputs)
        {
            var value = input.Value?.ToString() ?? "";
            
            // Check if this is a context reference
            if (value.StartsWith("{{") && value.EndsWith("}}"))
            {
                var contextKey = value.Trim('{', '}');
                if (context.ContainsKey(contextKey))
                {
                    resolved[input.Key] = context[contextKey];
                }
                else
                {
                    // Keep original value if context not found
                    resolved[input.Key] = input.Value;
                }
            }
            else
            {
                resolved[input.Key] = input.Value;
            }
        }
        
        return resolved;
    }

    private async Task<string> GenerateFinalResponseAsync(string goal, List<string> results)
    {
        if (results.Count == 0)
        {
            return "No steps were executed.";
        }

        var response = $"Goal: {goal}\n\n";
        response += "Execution Results:\n";
        response += string.Join("\n", results);
        
        return response;
    }

    private async Task<string> ExecutePromptStepAsync(string prompt, List<RunningServerInfo> runningServers, ServerToolMapping toolMapping, Dictionary<string, object> context)
    {
        try
        {
            // Build a list of available tools for the AI
            var toolList = BuildToolListWithServerInfo(toolMapping);
            var aiPrompt = $@"
You are an AI assistant. The user wants to: {prompt}

Available tools:
{toolList}

Your job is to select the single best tool (from the list above) to accomplish the user's request, and provide the tool name and any required parameters as JSON:

{{
  ""tool"": ""tool_name"",
  ""parameters"": {{ ... }}
}}

If the request requires multiple steps, only return the first tool to call. Do not invent tool names. Only use tools from the list above. If you cannot answer, return an empty JSON object.
";

            // Use the AI to select the tool and parameters
            var aiResponse = await SendPromptAsync(aiPrompt, runningServers, toolMapping);
            _logger.LogInformation("AI tool selection response: {Response}", aiResponse);

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
                    }
                    if (doc.RootElement.TryGetProperty("parameters", out var paramsProp) && paramsProp.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        foreach (var prop in paramsProp.EnumerateObject())
                        {
                            parameters[prop.Name] = prop.Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to parse AI tool selection response as JSON");
            }

            if (string.IsNullOrEmpty(toolName))
            {
                _logger.LogWarning("AI did not select a tool for prompt: {Prompt}", prompt);
                return "[AI did not select a tool for this prompt]";
            }

            _logger.LogInformation("Executing tool selected by AI: {ToolName} with parameters: {Parameters}", toolName!, System.Text.Json.JsonSerializer.Serialize(parameters));
            var result = await _multiMcpServerService.CallToolAsync(toolName!, parameters, runningServers, toolMapping, null);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing prompt step: {Prompt}", prompt);
            throw;
        }
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

    private Task<string> SendPromptAsync(string prompt, List<RunningServerInfo> runningServers, ServerToolMapping toolMapping)
    {
        try
        {
            // Use AI to analyze the prompt and determine which tools to call
            var aiPrompt = $@"
{prompt}

Please analyze the request and determine which tools to call with what parameters to fulfill the request.

IMPORTANT RULES:
1. Only use the EXACT tool names listed above. Do not make up tool names or use variations.
2. Tool defaults are configured for common parameters. DO NOT provide placeholder values like '<YourValue>' or similar.
3. Only specify parameters when you need to override a default or when no default exists.
4. If a tool needs parameters but you don't know the specific values, call the tool without parameters - defaults will be used.

To call a tool, respond with just the tool name, or the tool name followed by a colon and parameters.

Examples:
- To initialize Azure DevOps: initialize_azure_dev_ops_client
- To get all projects: get_projects  
- To get repositories for a project: get_repositories: projectName=MyProject

If you can answer the question without calling any tools, provide a direct answer.
";

            // For now, we'll use a simple approach - in a real implementation, this would use Azure AI
            // to analyze the prompt and determine which tools to call
            _logger.LogInformation("Analyzing prompt for tool selection: {Prompt}", prompt);
            
            // This is a simplified implementation - in practice, you'd want to use Azure AI here
            // to intelligently select tools based on the prompt
            return Task.FromResult("Prompt analysis completed. Tool selection would be implemented here.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending prompt for tool analysis");
            throw;
        }
    }
} 