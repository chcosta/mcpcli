using Microsoft.Extensions.Logging;
using McpCli.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace McpCli.Services;

public class AdvancedContextManager
{
    private readonly ILogger<AdvancedContextManager> _logger;
    private readonly IPlanPersistenceService _planPersistenceService;
    private readonly IAzureAiService _azureAiService;
    private readonly Dictionary<string, ContextCache> _contextCache = new();
    private readonly Dictionary<string, object> _typeValidators = new();
    private readonly object _cacheLock = new();

    // Cache configuration
    private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
    private readonly int _maxCacheSize = 1000;

    public AdvancedContextManager(
        ILogger<AdvancedContextManager> logger,
        IPlanPersistenceService planPersistenceService,
        IAzureAiService azureAiService)
    {
        _logger = logger;
        _planPersistenceService = planPersistenceService;
        _azureAiService = azureAiService;
        InitializeTypeValidators();
    }

    /// <summary>
    /// Reads context from specific steps in a plan
    /// </summary>
    public async Task<Dictionary<string, object>> ReadContextFromStepsAsync(
        string planId, 
        string currentStepId, 
        List<string> stepIds, 
        Dictionary<string, string> extractionRules,
        Models.ExecutionSummary? executionSummary = null)
    {
        try
        {
            var cacheKey = $"{planId}_{currentStepId}_{string.Join("_", stepIds.OrderBy(s => s))}";
            
            // Check cache first
            var cachedContext = GetCachedContext(cacheKey);
            if (cachedContext != null)
            {
                _logger.LogDebug("Using cached context for plan {PlanId}, step {StepId}", planId, currentStepId);
                return cachedContext;
            }

            var context = new Dictionary<string, object>();
            
            // Load step results
            var stepResults = await _planPersistenceService.LoadStepResultsAsync(planId, executionSummary);
            var relevantSteps = stepResults.Where(s => stepIds.Contains(s.Id)).ToList();

            foreach (var step in relevantSteps)
            {
                var stepContext = await ExtractStepContextAsync(step, extractionRules);
                foreach (var kvp in stepContext)
                {
                    var key = $"step_{step.Id}_{kvp.Key}";
                    context[key] = kvp.Value;
                }
            }

            // Cache the result
            CacheContext(cacheKey, context);

            _logger.LogDebug("Extracted context from {StepCount} steps for plan {PlanId}, step {StepId}", 
                relevantSteps.Count, planId, currentStepId);

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
    /// Extracts specific data from step outputs using advanced parsing
    /// </summary>
    public async Task<Dictionary<string, object>> ExtractDataFromStepOutputsAsync(
        PlanStep step, 
        Dictionary<string, string> extractionRules)
    {
        var extractedData = new Dictionary<string, object>();

        try
        {
            if (step.ActualOutputs == null || !step.ActualOutputs.ContainsKey("raw_result"))
            {
                _logger.LogWarning("No raw result found for step {StepId}", step.Id);
                return extractedData;
            }

            var rawResult = step.ActualOutputs["raw_result"]?.ToString() ?? "";
            var parsedResults = step.ActualOutputs.GetValueOrDefault("parsed_results", new Dictionary<string, object>()) as Dictionary<string, object>;

            foreach (var rule in extractionRules)
            {
                var extractedValue = await ExtractValueUsingRuleAsync(rawResult, parsedResults, rule.Value);
                if (extractedValue != null)
                {
                    extractedData[rule.Key] = extractedValue;
                }
            }

            _logger.LogDebug("Extracted {Count} values from step {StepId} using {RuleCount} rules", 
                extractedData.Count, step.Id, extractionRules.Count);

            return extractedData;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error extracting data from step {StepId} outputs", step.Id);
            return extractedData;
        }
    }

    /// <summary>
    /// Injects context into step inputs with validation and type checking
    /// </summary>
    public async Task<Dictionary<string, object>> InjectContextIntoInputsAsync(
        Dictionary<string, object> inputs, 
        Dictionary<string, object> context, 
        string stepId)
    {
        var enhancedInputs = new Dictionary<string, object>(inputs);

        try
        {
            foreach (var kvp in inputs)
            {
                var enhancedValue = await ProcessInputValueAsync(kvp.Value, context, stepId);
                enhancedInputs[kvp.Key] = enhancedValue;
            }

            // Validate inputs after context injection
            var validationResult = await ValidateInputsAsync(enhancedInputs, stepId);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Input validation failed for step {StepId}: {Errors}", 
                    stepId, string.Join(", ", validationResult.Errors));
            }

            _logger.LogDebug("Injected context into {InputCount} inputs for step {StepId}", 
                inputs.Count, stepId);

            return enhancedInputs;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error injecting context into inputs for step {StepId}", stepId);
            return enhancedInputs;
        }
    }

    /// <summary>
    /// Validates step results with type checking and format validation
    /// </summary>
    public async Task<ContextValidationResult> ValidateStepResultsAsync(PlanStep step, Dictionary<string, object> expectedOutputs)
    {
        var errors = new List<string>();
        var warnings = new List<string>();

        try
        {
            if (step.ActualOutputs == null)
            {
                errors.Add("No actual outputs found");
                return new ContextValidationResult { IsValid = false, Errors = errors, Warnings = warnings };
            }

            foreach (var expected in expectedOutputs)
            {
                if (step.ActualOutputs.TryGetValue(expected.Key, out var actualValue))
                {
                    var validation = await ValidateValueAsync(actualValue, expected.Value, expected.Key);
                    errors.AddRange(validation.Errors);
                    warnings.AddRange(validation.Warnings);
                }
                else
                {
                    warnings.Add($"Expected output '{expected.Key}' not found in actual outputs");
                }
            }

            // Validate data types and formats
            var typeValidation = await ValidateDataTypesAsync(step.ActualOutputs);
            errors.AddRange(typeValidation.Errors);
            warnings.AddRange(typeValidation.Warnings);

            _logger.LogDebug("Validated {OutputCount} outputs for step {StepId}: {ErrorCount} errors, {WarningCount} warnings", 
                expectedOutputs.Count, step.Id, errors.Count, warnings.Count);

            return new ContextValidationResult 
            { 
                IsValid = errors.Count == 0, 
                Errors = errors, 
                Warnings = warnings 
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating step results for step {StepId}", step.Id);
            return new ContextValidationResult 
            { 
                IsValid = false, 
                Errors = new List<string> { $"Validation error: {ex.Message}" }, 
                Warnings = warnings 
            };
        }
    }

    /// <summary>
    /// Optimizes context for performance with intelligent caching
    /// </summary>
    public void OptimizeContextPerformance(string planId, List<string> stepIds)
    {
        try
        {
            // Pre-warm cache for frequently accessed contexts
            var cacheKey = $"{planId}_{string.Join("_", stepIds)}";
            
            lock (_cacheLock)
            {
                // Clean up expired cache entries
                var expiredKeys = _contextCache.Keys
                    .Where(k => _contextCache[k].ExpiresAt < DateTime.UtcNow)
                    .ToList();

                foreach (var key in expiredKeys)
                {
                    _contextCache.Remove(key);
                }

                // Limit cache size
                if (_contextCache.Count > _maxCacheSize)
                {
                    var oldestKeys = _contextCache.OrderBy(kvp => kvp.Value.CreatedAt)
                        .Take(_contextCache.Count - _maxCacheSize)
                        .Select(kvp => kvp.Key)
                        .ToList();

                    foreach (var key in oldestKeys)
                    {
                        _contextCache.Remove(key);
                    }
                }
            }

            _logger.LogDebug("Optimized context performance for plan {PlanId}, cache size: {CacheSize}", 
                planId, _contextCache.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error optimizing context performance for plan {PlanId}", planId);
        }
    }

    /// <summary>
    /// Gets context statistics for monitoring and optimization
    /// </summary>
    public ContextStatistics GetContextStatistics()
    {
        lock (_cacheLock)
        {
            return new ContextStatistics
            {
                CacheSize = _contextCache.Count,
                MaxCacheSize = _maxCacheSize,
                CacheHitRate = CalculateCacheHitRate(),
                AverageContextSize = CalculateAverageContextSize(),
                ExpiredEntries = _contextCache.Count(kvp => kvp.Value.ExpiresAt < DateTime.UtcNow)
            };
        }
    }

    private async Task<Dictionary<string, object>> ExtractStepContextAsync(PlanStep step, Dictionary<string, string> extractionRules)
    {
        var context = new Dictionary<string, object>();

        try
        {
            // Extract from raw result
            if (step.ActualOutputs?.ContainsKey("raw_result") == true)
            {
                var rawResult = step.ActualOutputs["raw_result"]?.ToString() ?? "";
                var extractedData = await ExtractDataFromStepOutputsAsync(step, extractionRules);
                foreach (var kvp in extractedData)
                {
                    context[kvp.Key] = kvp.Value;
                }
            }

            // Extract from parsed results
            if (step.ActualOutputs?.ContainsKey("parsed_results") == true)
            {
                var parsedResults = step.ActualOutputs["parsed_results"] as Dictionary<string, object>;
                if (parsedResults != null)
                {
                    foreach (var kvp in parsedResults)
                    {
                        context[$"parsed_{kvp.Key}"] = kvp.Value;
                    }
                }
            }

            // Add metadata
            context["step_id"] = step.Id;
            context["step_name"] = step.Name;
            context["step_status"] = step.Status.ToString();
            context["step_duration"] = step.Duration?.TotalSeconds ?? 0;
            context["step_started"] = step.StartedAt;
            context["step_completed"] = step.CompletedAt;

            return context;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error extracting context from step {StepId}", step.Id);
            return context;
        }
    }

    private async Task<object?> ExtractValueUsingRuleAsync(string rawResult, Dictionary<string, object> parsedResults, string rule)
    {
        try
        {
            // Try JSON path extraction first
            if (rule.StartsWith("$."))
            {
                return ExtractJsonPathValue(rawResult, rule);
            }

            // Try regex extraction
            if (rule.StartsWith("regex:"))
            {
                var regexPattern = rule.Substring(6);
                return ExtractRegexValue(rawResult, regexPattern);
            }

            // Try AI-powered extraction
            if (rule.StartsWith("ai:"))
            {
                var aiPrompt = rule.Substring(3);
                return await ExtractAiValueAsync(rawResult, aiPrompt);
            }

            // Try direct key access from parsed results
            if (parsedResults.ContainsKey(rule))
            {
                return parsedResults[rule];
            }

            // Try simple text extraction
            return ExtractTextValue(rawResult, rule);

        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error extracting value using rule: {Rule}", rule);
            return null;
        }
    }

    private object? ExtractJsonPathValue(string json, string jsonPath)
    {
        try
        {
            var document = JsonDocument.Parse(json);
            var path = jsonPath.Substring(2); // Remove "$."
            var pathParts = path.Split('.');

            var current = document.RootElement;
            foreach (var part in pathParts)
            {
                if (current.TryGetProperty(part, out var property))
                {
                    current = property;
                }
                else
                {
                    return null;
                }
            }

            return ConvertJsonElement(current);
        }
        catch
        {
            return null;
        }
    }

    private object? ExtractRegexValue(string text, string pattern)
    {
        try
        {
            var regex = new Regex(pattern);
            var match = regex.Match(text);
            return match.Success ? match.Value : null;
        }
        catch
        {
            return null;
        }
    }

    private async Task<object?> ExtractAiValueAsync(string text, string prompt)
    {
        try
        {
            var aiPrompt = $@"
Extract specific information from the following text based on this instruction: {prompt}

Text: {text}

Respond with only the extracted value, nothing else.
";

            var response = await _azureAiService.SendPromptAsync(aiPrompt);
            return response.Trim();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error extracting value using AI for prompt: {Prompt}", prompt);
            return null;
        }
    }

    private object? ExtractTextValue(string text, string key)
    {
        try
        {
            // Simple key-value extraction
            var pattern = $@"{key}[:=]\s*([^\n\r,}}]+)";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var match = regex.Match(text);
            return match.Success ? match.Groups[1].Value.Trim() : null;
        }
        catch
        {
            return null;
        }
    }

    private async Task<object> ProcessInputValueAsync(object value, Dictionary<string, object> context, string stepId)
    {
        if (value is string stringValue)
        {
            // Process template variables
            if (stringValue.Contains("{{") && stringValue.Contains("}}"))
            {
                return await ProcessTemplateAsync(stringValue, context, stepId);
            }

            // Process context references
            if (stringValue.StartsWith("context:"))
            {
                var contextKey = stringValue.Substring(8);
                return context.GetValueOrDefault(contextKey, value);
            }
        }

        return value;
    }

    private async Task<string> ProcessTemplateAsync(string template, Dictionary<string, object> context, string stepId)
    {
        try
        {
            var processedTemplate = template;

            // Replace context variables
            foreach (var kvp in context)
            {
                var placeholder = $"{{{{{kvp.Key}}}}}";
                if (processedTemplate.Contains(placeholder))
                {
                    processedTemplate = processedTemplate.Replace(placeholder, kvp.Value?.ToString() ?? "");
                }
            }

            // Use AI for complex template processing
            if (processedTemplate.Contains("{{") && processedTemplate.Contains("}}"))
            {
                var aiPrompt = $@"
Process this template by replacing any remaining placeholders with appropriate values from the context:

Template: {processedTemplate}
Context: {JsonSerializer.Serialize(context, new JsonSerializerOptions { WriteIndented = true })}

Return only the processed template with all placeholders replaced.
";

                processedTemplate = await _azureAiService.SendPromptAsync(aiPrompt);
            }

            return processedTemplate;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing template for step {StepId}: {Template}", stepId, template);
            return template;
        }
    }

    private async Task<ContextValidationResult> ValidateInputsAsync(Dictionary<string, object> inputs, string stepId)
    {
        var errors = new List<string>();
        var warnings = new List<string>();

        try
        {
            foreach (var kvp in inputs)
            {
                var validation = await ValidateValueAsync(kvp.Value, null, kvp.Key);
                errors.AddRange(validation.Errors);
                warnings.AddRange(validation.Warnings);
            }

            return new ContextValidationResult { IsValid = errors.Count == 0, Errors = errors, Warnings = warnings };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating inputs for step {StepId}", stepId);
            return new ContextValidationResult { IsValid = false, Errors = new List<string> { ex.Message }, Warnings = warnings };
        }
    }

    private async Task<ContextValidationResult> ValidateValueAsync(object value, object? expectedValue, string fieldName)
    {
        var errors = new List<string>();
        var warnings = new List<string>();

        try
        {
            // Type validation
            if (expectedValue != null)
            {
                var expectedType = expectedValue.GetType();
                if (!expectedType.IsInstanceOfType(value))
                {
                    errors.Add($"Type mismatch for {fieldName}: expected {expectedType.Name}, got {value.GetType().Name}");
                }
            }

            // Format validation
            if (value is string stringValue)
            {
                var formatValidation = ValidateStringFormat(stringValue, fieldName);
                errors.AddRange(formatValidation.Errors);
                warnings.AddRange(formatValidation.Warnings);
            }

            // AI-powered validation for complex cases
            if (value is string complexValue && complexValue.Length > 100)
            {
                var aiValidation = await ValidateWithAiAsync(complexValue, fieldName);
                errors.AddRange(aiValidation.Errors);
                warnings.AddRange(aiValidation.Warnings);
            }

            return new ContextValidationResult { IsValid = errors.Count == 0, Errors = errors, Warnings = warnings };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating value for field {FieldName}", fieldName);
            return new ContextValidationResult { IsValid = false, Errors = new List<string> { ex.Message }, Warnings = warnings };
        }
    }

    private ContextValidationResult ValidateStringFormat(string value, string fieldName)
    {
        var errors = new List<string>();
        var warnings = new List<string>();

        // Email validation
        if (fieldName.Contains("email", StringComparison.OrdinalIgnoreCase))
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(value))
            {
                errors.Add($"Invalid email format for {fieldName}");
            }
        }

        // URL validation
        if (fieldName.Contains("url", StringComparison.OrdinalIgnoreCase))
        {
            if (!Uri.TryCreate(value, UriKind.Absolute, out _))
            {
                errors.Add($"Invalid URL format for {fieldName}");
            }
        }

        // Date validation
        if (fieldName.Contains("date", StringComparison.OrdinalIgnoreCase))
        {
            if (!DateTime.TryParse(value, out _))
            {
                errors.Add($"Invalid date format for {fieldName}");
            }
        }

        return new ContextValidationResult { IsValid = errors.Count == 0, Errors = errors, Warnings = warnings };
    }

    private async Task<ContextValidationResult> ValidateWithAiAsync(string value, string fieldName)
    {
        var errors = new List<string>();
        var warnings = new List<string>();

        try
        {
            var aiPrompt = $@"
Validate the following value for the field '{fieldName}':

Value: {value}

Check for:
1. Appropriate content and format
2. Sensible values and ranges
3. Potential issues or inconsistencies

Respond with 'VALID' if the value is appropriate, or describe any issues found.
";

            var response = await _azureAiService.SendPromptAsync(aiPrompt);
            
            if (!response.Trim().Equals("VALID", StringComparison.OrdinalIgnoreCase))
            {
                warnings.Add($"AI validation warning for {fieldName}: {response.Trim()}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error performing AI validation for field {FieldName}", fieldName);
        }

        return new ContextValidationResult { IsValid = errors.Count == 0, Errors = errors, Warnings = warnings };
    }

    private async Task<ContextValidationResult> ValidateDataTypesAsync(Dictionary<string, object> outputs)
    {
        var errors = new List<string>();
        var warnings = new List<string>();

        try
        {
            foreach (var kvp in outputs)
            {
                var typeValidation = ValidateDataType(kvp.Value, kvp.Key);
                errors.AddRange(typeValidation.Errors);
                warnings.AddRange(typeValidation.Warnings);
            }

            return new ContextValidationResult { IsValid = errors.Count == 0, Errors = errors, Warnings = warnings };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating data types");
            return new ContextValidationResult { IsValid = false, Errors = new List<string> { ex.Message }, Warnings = warnings };
        }
    }

    private ContextValidationResult ValidateDataType(object value, string fieldName)
    {
        var errors = new List<string>();
        var warnings = new List<string>();

        try
        {
            // Check for null values
            if (value == null)
            {
                warnings.Add($"Null value found for {fieldName}");
                return new ContextValidationResult { IsValid = true, Errors = errors, Warnings = warnings };
            }

            // Check for empty strings
            if (value is string stringValue && string.IsNullOrWhiteSpace(stringValue))
            {
                warnings.Add($"Empty string found for {fieldName}");
            }

            // Check for empty collections
            if (value is System.Collections.ICollection collection && collection.Count == 0)
            {
                warnings.Add($"Empty collection found for {fieldName}");
            }

            return new ContextValidationResult { IsValid = true, Errors = errors, Warnings = warnings };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating data type for field {FieldName}", fieldName);
            return new ContextValidationResult { IsValid = false, Errors = new List<string> { ex.Message }, Warnings = warnings };
        }
    }

    private void InitializeTypeValidators()
    {
        _typeValidators["email"] = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        _typeValidators["url"] = new Func<string, bool>(s => Uri.TryCreate(s, UriKind.Absolute, out _));
        _typeValidators["date"] = new Func<string, bool>(s => DateTime.TryParse(s, out _));
        _typeValidators["number"] = new Func<string, bool>(s => double.TryParse(s, out _));
        _typeValidators["integer"] = new Func<string, bool>(s => int.TryParse(s, out _));
    }

    private object ConvertJsonElement(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => element.GetString() ?? "",
            JsonValueKind.Number => element.TryGetInt32(out var intValue) ? intValue : element.GetDouble(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null!,
            JsonValueKind.Array => element.EnumerateArray().Select(ConvertJsonElement).ToList(),
            JsonValueKind.Object => element.EnumerateObject().ToDictionary(p => p.Name, p => ConvertJsonElement(p.Value)),
            _ => element.ToString()
        };
    }

    private Dictionary<string, object>? GetCachedContext(string cacheKey)
    {
        lock (_cacheLock)
        {
            if (_contextCache.TryGetValue(cacheKey, out var cacheEntry))
            {
                if (cacheEntry.ExpiresAt > DateTime.UtcNow)
                {
                    cacheEntry.AccessCount++;
                    cacheEntry.LastAccessed = DateTime.UtcNow;
                    return cacheEntry.Context;
                }
                else
                {
                    _contextCache.Remove(cacheKey);
                }
            }
            return null;
        }
    }

    private void CacheContext(string cacheKey, Dictionary<string, object> context)
    {
        lock (_cacheLock)
        {
            _contextCache[cacheKey] = new ContextCache
            {
                Context = context,
                CreatedAt = DateTime.UtcNow,
                LastAccessed = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.Add(_cacheExpiration),
                AccessCount = 1
            };
        }
    }

    private double CalculateCacheHitRate()
    {
        lock (_cacheLock)
        {
            if (_contextCache.Count == 0) return 0;

            var totalAccesses = _contextCache.Values.Sum(c => c.AccessCount);
            var totalRequests = totalAccesses + _contextCache.Count; // Assuming each cache entry was requested once
            return totalRequests > 0 ? (double)totalAccesses / totalRequests : 0;
        }
    }

    private double CalculateAverageContextSize()
    {
        lock (_cacheLock)
        {
            if (_contextCache.Count == 0) return 0;
            return _contextCache.Values.Average(c => c.Context.Count);
        }
    }
}

public class ContextCache
{
    public Dictionary<string, object> Context { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime LastAccessed { get; set; }
    public DateTime ExpiresAt { get; set; }
    public int AccessCount { get; set; }
}

public class ContextValidationResult
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; } = new();
    public List<string> Warnings { get; set; } = new();
}

public class ContextStatistics
{
    public int CacheSize { get; set; }
    public int MaxCacheSize { get; set; }
    public double CacheHitRate { get; set; }
    public double AverageContextSize { get; set; }
    public int ExpiredEntries { get; set; }
} 