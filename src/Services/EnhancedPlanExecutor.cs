using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class EnhancedPlanExecutor : IPlanExecutor
{
    private readonly ILogger<EnhancedPlanExecutor> _logger;
    private readonly IMultiMcpServerService _multiMcpServerService;
    private readonly IPlanPersistenceService _planPersistenceService;
    private readonly IAzureAiService _azureAiService;

    public EnhancedPlanExecutor(
        ILogger<EnhancedPlanExecutor> logger,
        IMultiMcpServerService multiMcpServerService,
        IPlanPersistenceService planPersistenceService,
        IAzureAiService azureAiService)
    {
        _logger = logger;
        _multiMcpServerService = multiMcpServerService;
        _planPersistenceService = planPersistenceService;
        _azureAiService = azureAiService;
    }

    public async Task<PlanExecutionResult> ExecutePlanAsync(Plan plan, List<RunningServerInfo> runningServers, ServerToolMapping toolMapping)
    {
        try
        {
            _logger.LogInformation("Executing enhanced plan {PlanId} with {StepCount} steps", plan.Id, plan.Steps.Count);

            var results = new List<string>();
            var context = new Dictionary<string, object>();
            var executedSteps = new List<PlanStep>();
            var skippedSteps = new List<string>();

            // Execute steps in order with dependency resolution
            foreach (var step in plan.Steps)
            {
                try
                {
                    // Check if step should be executed based on dependencies
                    if (!await ShouldExecuteStepAsync(step, executedSteps, context))
                    {
                        _logger.LogDebug("Skipping step {StepId} due to dependencies or conditions", step.Id);
                        step.Status = StepStatus.Skipped;
                        skippedSteps.Add(step.Id);
                        await _planPersistenceService.SaveStepResultAsync(plan.Id, step);
                        continue;
                    }

                    _logger.LogDebug("Executing step {StepId}: {StepName}", step.Id, step.Name);
                    
                    // Update step status
                    step.Status = StepStatus.InProgress;
                    step.StartedAt = DateTime.UtcNow;
                    await _planPersistenceService.SaveStepResultAsync(plan.Id, step);

                    // Resolve inputs with context
                    var resolvedInputs = await ResolveInputsWithContextAsync(step.Inputs, context, step);

                    // Execute the tool
                    var result = await _multiMcpServerService.CallToolAsync(
                        step.ToolName, 
                        resolvedInputs, 
                        runningServers, 
                        toolMapping, 
                        null);

                    // Parse and store results
                    var parsedResults = await ParseStepResultsAsync(result, step);
                    context[$"step_{step.Id}_result"] = result;
                    context[$"step_{step.Id}_parsed"] = parsedResults;

                    // Update step with results
                    step.Status = StepStatus.Completed;
                    step.CompletedAt = DateTime.UtcNow;
                    step.ActualOutputs = new Dictionary<string, object>
                    {
                        ["raw_result"] = result,
                        ["parsed_results"] = parsedResults
                    };

                    // Save step result
                    await _planPersistenceService.SaveStepResultAsync(plan.Id, step);
                    executedSteps.Add(step);

                    results.Add($"Step {step.Id}: {step.Name} - Completed");
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
                        CompletedSteps = executedSteps.Count,
                        FailedSteps = 1,
                        SkippedSteps = skippedSteps.Count,
                        ErrorMessage = $"Step {step.Id} failed: {ex.Message}",
                        StartedAt = DateTime.UtcNow,
                        CompletedAt = DateTime.UtcNow,
                        StepResults = executedSteps
                    };
                }
            }

            // Generate final response using AI
            var finalResponse = await GenerateFinalResponseAsync(plan.Goal, results, context, executedSteps);

            var totalDuration = TimeSpan.FromTicks(executedSteps
                .Where(s => s.Duration.HasValue)
                .Sum(s => s.Duration.Value.Ticks));

            _logger.LogInformation("Plan {PlanId} executed successfully", plan.Id);

            return new PlanExecutionResult
            {
                PlanId = plan.Id,
                FinalStatus = PlanStatus.Completed,
                TotalSteps = plan.Steps.Count,
                CompletedSteps = executedSteps.Count,
                FailedSteps = 0,
                SkippedSteps = skippedSteps.Count,
                TotalDuration = totalDuration,
                StartedAt = DateTime.UtcNow,
                CompletedAt = DateTime.UtcNow,
                FinalOutputs = new Dictionary<string, object> { ["response"] = finalResponse },
                StepResults = executedSteps
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
                SkippedSteps = 0,
                ErrorMessage = ex.Message,
                StartedAt = DateTime.UtcNow,
                CompletedAt = DateTime.UtcNow
            };
        }
    }

    private async Task<bool> ShouldExecuteStepAsync(PlanStep step, List<PlanStep> executedSteps, Dictionary<string, object> context)
    {
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

        // Check conditional logic (if implemented)
        if (!string.IsNullOrEmpty(step.ContextFromPreviousSteps))
        {
            var shouldExecute = await EvaluateConditionAsync(step.ContextFromPreviousSteps, context);
            if (!shouldExecute)
            {
                _logger.LogDebug("Step {StepId} skipped due to condition: {Condition}", step.Id, step.ContextFromPreviousSteps);
                return false;
            }
        }

        return true;
    }

    private async Task<Dictionary<string, object>> ResolveInputsWithContextAsync(
        Dictionary<string, object> inputs, 
        Dictionary<string, object> context, 
        PlanStep step)
    {
        var resolved = new Dictionary<string, object>();
        
        foreach (var input in inputs)
        {
            var value = input.Value?.ToString() ?? "";
            
            // Check for context references
            if (value.StartsWith("{{") && value.EndsWith("}}"))
            {
                var contextKey = value.Trim('{', '}');
                if (context.ContainsKey(contextKey))
                {
                    resolved[input.Key] = context[contextKey];
                }
                else
                {
                    // Try to extract from previous step results
                    var extractedValue = await ExtractValueFromContextAsync(contextKey, context);
                    if (extractedValue != null)
                    {
                        resolved[input.Key] = extractedValue;
                    }
                    else
                    {
                        // Keep original value if context not found
                        resolved[input.Key] = input.Value;
                    }
                }
            }
            else
            {
                resolved[input.Key] = input.Value;
            }
        }
        
        return resolved;
    }

    private async Task<object?> ExtractValueFromContextAsync(string contextKey, Dictionary<string, object> context)
    {
        // Handle patterns like "step_1_result.property" or "step_2_parsed.field"
        var parts = contextKey.Split('.');
        if (parts.Length >= 2)
        {
            var baseKey = parts[0];
            var propertyPath = string.Join(".", parts.Skip(1));
            
            if (context.ContainsKey(baseKey))
            {
                var baseValue = context[baseKey];
                return await ExtractPropertyAsync(baseValue, propertyPath);
            }
        }
        
        return null;
    }

    private async Task<object?> ExtractPropertyAsync(object value, string propertyPath)
    {
        try
        {
            // Simple property extraction - could be enhanced with JSON path parsing
            if (value is Dictionary<string, object> dict)
            {
                return dict.GetValueOrDefault(propertyPath);
            }
            
            // For now, return the value as-is
            return value;
        }
        catch
        {
            return null;
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

    private async Task<bool> EvaluateConditionAsync(string condition, Dictionary<string, object> context)
    {
        try
        {
            // Simple condition evaluation - could be enhanced with a proper expression parser
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

    private async Task<string> GenerateFinalResponseAsync(string goal, List<string> results, Dictionary<string, object> context, List<PlanStep> executedSteps)
    {
        try
        {
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
            _logger.LogError(ex, "Error generating final response");
            return $"Plan executed successfully. {results.Count} steps completed. Goal: {goal}";
        }
    }
} 