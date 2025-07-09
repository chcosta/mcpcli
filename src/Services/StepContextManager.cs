using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class StepContextManager
{
    private readonly ILogger<StepContextManager> _logger;
    private readonly IPlanPersistenceService _planPersistenceService;

    public StepContextManager(
        ILogger<StepContextManager> logger,
        IPlanPersistenceService planPersistenceService)
    {
        _logger = logger;
        _planPersistenceService = planPersistenceService;
    }

    /// <summary>
    /// Reads context from previous steps in a plan
    /// </summary>
    public async Task<Dictionary<string, object>> ReadStepContextAsync(string planId, string currentStepId, Models.ExecutionSummary? executionSummary = null)
    {
        try
        {
            var context = new Dictionary<string, object>();
            
            // Load all step results for the plan
            var stepResults = await _planPersistenceService.LoadStepResultsAsync(planId, executionSummary);
            
            // Find the current step to determine which steps are "previous"
            var currentStep = stepResults.FirstOrDefault(s => s.Id == currentStepId);
            if (currentStep == null)
            {
                _logger.LogWarning("Current step {StepId} not found in plan {PlanId}", currentStepId, planId);
                return context;
            }
            
            // Get previous steps
            var previousSteps = GetPreviousSteps(stepResults, currentStep);
            
            // Extract context from previous steps
            foreach (var step in previousSteps)
            {
                if (step.ActualOutputs != null)
                {
                    foreach (var output in step.ActualOutputs)
                    {
                        var key = $"step_{step.Id}_{output.Key}";
                        context[key] = output.Value;
                    }
                }
                
                // Also add step metadata
                context[$"step_{step.Id}_name"] = step.Name ?? string.Empty;
                context[$"step_{step.Id}_description"] = step.Description ?? string.Empty;
                context[$"step_{step.Id}_status"] = step.Status.ToString();
                context[$"step_{step.Id}_started_at"] = step.StartedAt;
                context[$"step_{step.Id}_completed_at"] = step.CompletedAt;
            }
            
            _logger.LogDebug("Extracted context from {StepCount} previous steps for plan {PlanId}, step {StepId}", 
                previousSteps.Count, planId, currentStepId);
            
            return context;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reading context from previous steps for plan {PlanId}, step {StepId}", 
                planId, currentStepId);
            return new Dictionary<string, object>();
        }
    }

    /// <summary>
    /// Extracts specific data from step results based on patterns
    /// </summary>
    public async Task<object?> ExtractDataFromContextAsync(Dictionary<string, object> context, string pattern)
    {
        try
        {
            // Handle different extraction patterns
            if (pattern.StartsWith("step_") && pattern.Contains("."))
            {
                return await ExtractFromStepResultAsync(context, pattern);
            }
            else if (pattern.StartsWith("find_"))
            {
                return await FindDataInContextAsync(context, pattern);
            }
            else if (pattern.StartsWith("aggregate_"))
            {
                return await AggregateDataFromContextAsync(context, pattern);
            }

            // Default: direct lookup
            return context.GetValueOrDefault(pattern);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error extracting data with pattern {Pattern}", pattern);
            return null;
        }
    }

    /// <summary>
    /// Injects context data into step inputs
    /// </summary>
    public async Task<Dictionary<string, object>> InjectContextIntoInputsAsync(
        Dictionary<string, object> inputs, 
        Dictionary<string, object> context,
        string stepId)
    {
        var injectedInputs = new Dictionary<string, object>();
        
        foreach (var input in inputs)
        {
            var value = input.Value?.ToString() ?? "";
            
            // Check for context injection patterns
            if (value.StartsWith("{{") && value.EndsWith("}}"))
            {
                var contextKey = value.Trim('{', '}');
                var injectedValue = await ExtractDataFromContextAsync(context, contextKey);
                
                if (injectedValue != null)
                {
                    injectedInputs[input.Key] = injectedValue;
                    _logger.LogDebug("Injected context value for {InputKey}: {ContextKey}", input.Key, contextKey);
                }
                else
                {
                    // Keep original value if context not found
                    injectedInputs[input.Key] = input.Value;
                    _logger.LogWarning("Context key {ContextKey} not found for input {InputKey}", contextKey, input.Key);
                }
            }
            else
            {
                injectedInputs[input.Key] = input.Value;
            }
        }
        
        return injectedInputs;
    }

    /// <summary>
    /// Validates that required context data is available
    /// </summary>
    public Task<StepContextValidationResult> ValidateContextAsync(
        Dictionary<string, object> context, 
        List<string> requiredKeys)
    {
        var missingKeys = new List<string>();
        var availableKeys = new List<string>();
        
        foreach (var requiredKey in requiredKeys)
        {
            if (context.ContainsKey(requiredKey))
            {
                availableKeys.Add(requiredKey);
            }
            else
            {
                missingKeys.Add(requiredKey);
            }
        }
        
        var result = new StepContextValidationResult
        {
            IsValid = missingKeys.Count == 0,
            MissingKeys = missingKeys,
            AvailableKeys = availableKeys,
            TotalContextKeys = context.Count
        };
        
        return Task.FromResult(result);
    }

    /// <summary>
    /// Caches context data for performance optimization
    /// </summary>
    public async Task<Dictionary<string, object>> GetCachedContextAsync(string planId, string stepId)
    {
        // For now, we'll read from storage each time
        // In the future, this could implement caching with TTL
        return await ReadStepContextAsync(planId, stepId);
    }

    private List<PlanStep> GetPreviousSteps(List<PlanStep> allSteps, PlanStep currentStep)
    {
        // Get steps that come before the current step
        var currentIndex = allSteps.FindIndex(s => s.Id == currentStep.Id);
        if (currentIndex <= 0)
        {
            return new List<PlanStep>();
        }
        
        return allSteps.Take(currentIndex).ToList();
    }

    private async Task<object?> ExtractFromStepResultAsync(Dictionary<string, object> context, string pattern)
    {
        // Pattern: step_X.result.field or step_X.parsed.field
        var parts = pattern.Split('.');
        if (parts.Length < 3)
        {
            return null;
        }
        
        var stepKey = $"{parts[0]}_{parts[1]}";
        var dataType = parts[2]; // "result" or "parsed"
        var fieldPath = parts.Length > 3 ? string.Join(".", parts.Skip(3)) : null;
        
        var baseKey = $"{stepKey}_{dataType}";
        if (!context.ContainsKey(baseKey))
        {
            return null;
        }
        
        var baseValue = context[baseKey];
        
        if (fieldPath != null)
        {
            return await ExtractPropertyAsync(baseValue, fieldPath);
        }
        
        return baseValue;
    }

    private Task<object?> FindDataInContextAsync(Dictionary<string, object> context, string pattern)
    {
        // Pattern: find_X where X is a search term
        var searchTerm = pattern.Substring(5); // Remove "find_"
        
        foreach (var kvp in context)
        {
            if (kvp.Key.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult<object?>(kvp.Value);
            }
        }
        
        return Task.FromResult<object?>(null);
    }

    private Task<object?> AggregateDataFromContextAsync(Dictionary<string, object> context, string pattern)
    {
        // Pattern: aggregate_X where X is the aggregation type
        var aggregationType = pattern.Substring(10); // Remove "aggregate_"
        
        object? result = aggregationType.ToLowerInvariant() switch
        {
            "count" => context.Count,
            "keys" => context.Keys.ToList(),
            "values" => context.Values.ToList(),
            "completed_steps" => context.GetValueOrDefault("total_completed_steps", 0),
            "failed_steps" => context.GetValueOrDefault("total_failed_steps", 0),
            _ => null
        };
        
        return Task.FromResult<object?>(result);
    }

    private Task<object?> ExtractPropertyAsync(object value, string propertyPath)
    {
        try
        {
            if (value is Dictionary<string, object> dict)
            {
                var parts = propertyPath.Split('.');
                var current = dict;
                
                foreach (var part in parts)
                {
                    if (current.ContainsKey(part))
                    {
                        var nextValue = current[part];
                        if (nextValue is Dictionary<string, object> nextDict)
                        {
                            current = nextDict;
                        }
                        else
                        {
                            return Task.FromResult<object?>(nextValue);
                        }
                    }
                    else
                    {
                        return Task.FromResult<object?>(null);
                    }
                }
                
                return Task.FromResult<object?>(current);
            }
            
            return Task.FromResult<object?>(value);
        }
        catch
        {
            return Task.FromResult<object?>(null);
        }
    }
}

public class StepContextValidationResult
{
    public bool IsValid { get; set; }
    public List<string> MissingKeys { get; set; } = new();
    public List<string> AvailableKeys { get; set; } = new();
    public int TotalContextKeys { get; set; }
} 