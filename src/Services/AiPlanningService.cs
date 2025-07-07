using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class AiPlanningService : IAiPlanningService
{
    private readonly ILogger<AiPlanningService> _logger;
    private readonly IMcpServerService _mcpServerService;
    private readonly IAzureAiService _azureAiService;
    private readonly ISystemPromptService _systemPromptService;

    public AiPlanningService(
        ILogger<AiPlanningService> logger,
        IMcpServerService mcpServerService,
        IAzureAiService azureAiService,
        ISystemPromptService systemPromptService)
    {
        _logger = logger;
        _mcpServerService = mcpServerService;
        _azureAiService = azureAiService;
        _systemPromptService = systemPromptService;
    }

    public async Task<string> ProcessPromptWithAIAsync(McpServerInfo serverInfo, string userPrompt, MarkdownConfig config)
    {
        try
        {
            // Step 1: Get available tools from MCP server
            var availableTools = await _mcpServerService.SendPromptAsync(serverInfo, userPrompt);
            
            if (availableTools.StartsWith("MCP server error"))
            {
                return availableTools;
            }

            // Step 2: Use AI to determine which tools to call and how
            var aiPlanningPrompt = await GetAiPlanningPromptAsync(config, userPrompt, availableTools);

            var aiResponse = await _azureAiService.SendPromptAsync(aiPlanningPrompt);
            
            // Step 3: Parse AI response and execute tools
            var toolResults = await ExecuteAIToolPlanAsync(serverInfo, aiResponse, config);
            
            // Step 4: Send results back to AI for final processing
            var finalPrompt = $@"
User's original request: {userPrompt}

Tool execution results: {toolResults}

Please provide a helpful, natural language response to the user based on these results.
";

            return await _azureAiService.SendPromptAsync(finalPrompt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing prompt with AI");
            return $"Error processing request: {ex.Message}";
        }
    }

    public async Task<string> ProcessPromptWithAIAsync(McpServerInfo serverInfo, string userPrompt, MarkdownConfig config, ExecutionSummary executionSummary)
    {
        try
        {
            // Step 1: Get available tools from MCP server
            var availableTools = await _mcpServerService.SendPromptAsync(serverInfo, userPrompt);
            
            if (availableTools.StartsWith("MCP server error"))
            {
                return availableTools;
            }

            // Step 2: Use AI to determine which tools to call and how
            var aiPlanningPrompt = await GetAiPlanningPromptAsync(config, userPrompt, availableTools);

            var aiResponse = await _azureAiService.SendPromptAsync(aiPlanningPrompt);
            
            // Step 3: Parse AI response and execute tools with execution summary tracking
            var toolResults = await ExecuteAIToolPlanAsync(serverInfo, aiResponse, config, executionSummary);
            
            // Step 4: Send results back to AI for final processing
            var finalPrompt = $@"
User's original request: {userPrompt}

Tool execution results: {toolResults}

Please provide a helpful, natural language response to the user based on these results.
";

            return await _azureAiService.SendPromptAsync(finalPrompt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing prompt with AI");
            return $"Error processing request: {ex.Message}";
        }
    }

    public async Task<string> ExecuteAIToolPlanAsync(McpServerInfo serverInfo, string aiResponse, MarkdownConfig config)
    {
        return await ExecuteAIToolPlanAsync(serverInfo, aiResponse, config, null);
    }

    public async Task<string> ExecuteAIToolPlanAsync(McpServerInfo serverInfo, string aiResponse, MarkdownConfig config, ExecutionSummary? executionSummary)
    {
        try
        {
            Console.WriteLine("AI Execution Plan:");
            Console.WriteLine(aiResponse);
            Console.WriteLine("\n--- Executing Plan ---\n");

            var toolResults = new List<string>();
            var contextLibrary = new Models.ContextLibrary(); // New generic context management
            var lines = aiResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            
            string? currentToolName = null;
            var currentParameters = new Dictionary<string, object>();
            string? currentPurpose = null;
            int currentStep = 0;
            int previousStep = 0;

            var executedTools = new HashSet<string>(); // Track executed tools to avoid duplicates
            
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                
                // Look for step numbers to track context
                if (trimmedLine.StartsWith("Step ") || trimmedLine.StartsWith("step "))
                {
                    var stepMatch = System.Text.RegularExpressions.Regex.Match(trimmedLine, @"(?i)step\s+(\d+)");
                    if (stepMatch.Success)
                    {
                        previousStep = currentStep; // Store the previous step number
                        currentStep = int.Parse(stepMatch.Groups[1].Value);
                    }
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(trimmedLine, @"^\d+\."))
                {
                    var numberMatch = System.Text.RegularExpressions.Regex.Match(trimmedLine, @"^(\d+)\.");
                    if (numberMatch.Success)
                    {
                        previousStep = currentStep; // Store the previous step number
                        currentStep = int.Parse(numberMatch.Groups[1].Value);
                    }
                }
                
                // Look for tool name (handle multiple formats)
                if (trimmedLine.StartsWith("- Tool name:", StringComparison.OrdinalIgnoreCase) ||
                    trimmedLine.StartsWith("- **Tool name**:", StringComparison.OrdinalIgnoreCase) ||
                    trimmedLine.StartsWith("- **Tool Name**:", StringComparison.OrdinalIgnoreCase))
                {
                    // Execute previous tool if we have one and haven't executed it yet
                    if (!string.IsNullOrEmpty(currentToolName))
                    {
                        var stepNumberForExecution = previousStep > 0 ? previousStep : currentStep - 1; // Use the correct step number
                        var toolKey = $"{stepNumberForExecution}_{currentToolName}_{string.Join(",", currentParameters.Select(p => $"{p.Key}={p.Value}"))}";
                        if (!executedTools.Contains(toolKey))
                        {
                            executedTools.Add(toolKey);
                            await ExecuteToolFromPlan(serverInfo, currentToolName, currentParameters, currentPurpose, stepNumberForExecution, toolResults, contextLibrary, config, executionSummary);
                        }
                    }
                    
                    // Start new tool
                    currentToolName = ExtractToolName(trimmedLine);
                    
                    // Skip invalid tool names that contain placeholders or forbidden names
                    if (!string.IsNullOrEmpty(currentToolName) && IsInvalidToolName(currentToolName))
                    {
                        Console.WriteLine($"Skipping invalid tool name: {currentToolName}");
                        currentToolName = string.Empty;
                        continue;
                    }
                    
                    currentParameters = new Dictionary<string, object>();
                    currentPurpose = null;
                }
                else if (trimmedLine.StartsWith("- Parameters:", StringComparison.OrdinalIgnoreCase) ||
                         trimmedLine.StartsWith("- **Parameters**:", StringComparison.OrdinalIgnoreCase))
                {
                    var parametersText = ExtractParameters(trimmedLine);
                    currentParameters = ParseParameters(parametersText, contextLibrary);
                    
                    // Auto-resolve missing list parameters for iteration patterns
                    foreach (var param in currentParameters.ToList())
                    {
                        if (param.Value.ToString()?.Contains("{") == true && param.Value.ToString()?.Contains("_FROM_LIST}") == true)
                        {
                            var pattern = param.Value.ToString();
                            var listReference = pattern?.Replace("{", "").Replace("_FROM_LIST}", "");
                            var listParameterName = $"_LIST_{listReference}";
                            
                            // If the list parameter is missing, try to auto-add it
                            if (!currentParameters.ContainsKey(listParameterName))
                            {
                                // Try to find a reference to the list in previous steps
                                var possibleListValue = $"ALL_{listReference}S_FROM_STEP_{currentStep - 1}";
                                currentParameters[listParameterName] = possibleListValue;
                                Console.WriteLine($"Auto-added missing list parameter: {listParameterName} = {possibleListValue}");
                            }
                        }
                    }
                }
                else if (trimmedLine.StartsWith("- Purpose:", StringComparison.OrdinalIgnoreCase) ||
                         trimmedLine.StartsWith("- **Purpose**:", StringComparison.OrdinalIgnoreCase))
                {
                    currentPurpose = ExtractPurpose(trimmedLine);
                }
            }
            
            // Execute the last tool if we have one and haven't executed it yet
            if (!string.IsNullOrEmpty(currentToolName))
            {
                var toolKey = $"{currentStep}_{currentToolName}_{string.Join(",", currentParameters.Select(p => $"{p.Key}={p.Value}"))}";
                if (!executedTools.Contains(toolKey))
                {
                    executedTools.Add(toolKey);
                    await ExecuteToolFromPlan(serverInfo, currentToolName, currentParameters, currentPurpose, currentStep, toolResults, contextLibrary, config, executionSummary);
                }
            }
            
            if (toolResults.Count == 0)
            {
                return "No tools were executed based on the AI plan.";
            }
            
            return string.Join("\n\n", toolResults);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing AI tool plan");
            return $"Error executing tools: {ex.Message}";
        }
    }

    public async Task<string> ExecuteToolWithPatternRecognitionAsync(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, MarkdownConfig config)
    {
        // Check for common patterns that need special handling
        
        // Pattern 1: Multiple IDs for batch processing
        if (parameters.ContainsKey("_MULTIPLE_IDS"))
        {
            return await HandleBatchExecution(serverInfo, toolName, parameters, "_MULTIPLE_IDS", "id", config);
        }
        
        if (parameters.ContainsKey("_MULTIPLE_PR_IDS"))
        {
            return await HandleBatchExecution(serverInfo, toolName, parameters, "_MULTIPLE_PR_IDS", "pullRequestId", config);
        }
        
        // Pattern 2: List iteration (when AI generates plans with {ID_FROM_LIST} pattern)
        if (parameters.Values.Any(v => v.ToString()?.Contains("{") == true && v.ToString()?.Contains("_FROM_LIST}") == true))
        {
            return await HandleListIteration(serverInfo, toolName, parameters, config);
        }
        
        // Pattern 3: Conditional execution (when AI generates plans with conditions)
        if (parameters.ContainsKey("_IF_NOT_EMPTY") || parameters.ContainsKey("_IF_EXISTS"))
        {
            return await HandleConditionalExecution(serverInfo, toolName, parameters, config);
        }
        
        // Default: Execute normally
        var cleanParameters = new Dictionary<string, object>(parameters);
        RemoveSpecialParameters(cleanParameters);
        
        return await _mcpServerService.CallToolAsync(serverInfo, toolName, cleanParameters, config.ToolDefaults);
    }

    private Dictionary<string, object> ParseParameters(string parametersText, ContextLibrary contextLibrary)
    {
        var parameters = new Dictionary<string, object>();
        
        if (string.IsNullOrEmpty(parametersText))
        {
            return parameters;
        }
        
        // Clean up markdown formatting
        parametersText = parametersText.Trim('`', ' ', '*');
        
        // Simple parameter parsing - split by comma and then by =
        var parts = parametersText.Split(',', StringSplitOptions.RemoveEmptyEntries);
        foreach (var part in parts)
        {
            var keyValue = part.Split('=', 2, StringSplitOptions.RemoveEmptyEntries);
            if (keyValue.Length == 2)
            {
                var key = keyValue[0].Trim();
                var value = keyValue[1].Trim();
                
                // Handle dynamic values that reference previous step results
                // Clean up the value by removing explanatory text in parentheses
                var cleanValue = value;
                var parenIndex = value.IndexOf('(');
                if (parenIndex > 0)
                {
                    cleanValue = value.Substring(0, parenIndex).Trim();
                    Console.WriteLine($"Cleaned parameter value from '{value}' to '{cleanValue}'");
                }
                
                // Strip curly braces if present (e.g., {ID_FROM_STEP_4} -> ID_FROM_STEP_4)
                if (cleanValue.StartsWith("{") && cleanValue.EndsWith("}"))
                {
                    cleanValue = cleanValue.Substring(1, cleanValue.Length - 2).Trim();
                    Console.WriteLine($"Stripped curly braces from parameter value: '{value}' -> '{cleanValue}'");
                }
                
                // Check for any dynamic reference patterns
                if (cleanValue.StartsWith("RESULT_FROM_STEP_", StringComparison.OrdinalIgnoreCase) ||
                    cleanValue.StartsWith("PULL_REQUEST_ID_FROM_STEP_", StringComparison.OrdinalIgnoreCase) ||
                    cleanValue.StartsWith("PR_ID_FROM_STEP_", StringComparison.OrdinalIgnoreCase) ||
                    cleanValue.StartsWith("DATE_FROM_STEP_", StringComparison.OrdinalIgnoreCase) ||
                    cleanValue.StartsWith("ALL_", StringComparison.OrdinalIgnoreCase) ||
                    cleanValue.StartsWith("ID_FROM_STEP_", StringComparison.OrdinalIgnoreCase) ||
                    cleanValue.StartsWith("TARGET_REPO_FROM_STEP_", StringComparison.OrdinalIgnoreCase) ||
                    cleanValue.StartsWith("REPO_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Processing dynamic value: {cleanValue}");
                    
                    // For step-based references, prioritize manual extraction for better accuracy
                    var stepNumber = ExtractStepNumber(cleanValue);
                    bool useManualExtraction = true;
                    
                    // Only use context library for non-step references or as fallback
                    if (stepNumber == 0)
                    {
                        var resolvedValue = contextLibrary.ResolveVariable(cleanValue);
                        if (!string.IsNullOrEmpty(resolvedValue))
                        {
                            Console.WriteLine($"Resolved '{cleanValue}' to: {resolvedValue}");
                            value = resolvedValue;
                            useManualExtraction = false;
                        }
                    }
                    
                    if (useManualExtraction && stepNumber > 0)
                    {
                        // Manual extraction for step-based references
                        var step = contextLibrary.GetStep(stepNumber);
                        if (step != null)
                        {
                            Console.WriteLine($"Found step result for step {stepNumber}, raw result: {step.RawResult?.Substring(0, Math.Min(200, step.RawResult?.Length ?? 0))}...");
                            
                            // Determine what type of value to extract based on the dynamic value name
                            if (cleanValue.Contains("DATE"))
                            {
                                Console.WriteLine("Extracting date from step result");
                                
                                // Try to extract date directly from the raw result
                                var extractedDate = ExtractDateFromResult(step.RawResult ?? "");
                                if (!string.IsNullOrEmpty(extractedDate))
                                {
                                    Console.WriteLine($"Successfully extracted date from step {stepNumber}: {extractedDate}");
                                    value = extractedDate;
                                }
                                else
                                {
                                    Console.WriteLine("No date found in step result");
                                    // Check if date was previously extracted and stored
                                    if (step.ExtractedValues.ContainsKey("date"))
                                    {
                                        var storedDate = step.ExtractedValues["date"].FirstOrDefault();
                                        if (!string.IsNullOrEmpty(storedDate))
                                        {
                                            Console.WriteLine($"Using previously stored date: {storedDate}");
                                            value = storedDate;
                                        }
                                    }
                                }
                            }
                            else if (cleanValue.Contains("PULL_REQUEST_ID") || cleanValue.Contains("PR_ID") || cleanValue.StartsWith("PR_ID_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Extracting pull request IDs from result");
                                
                                // Try to extract PR IDs directly from the raw result
                                var extractedIds = ExtractPullRequestIdsFromResult(step.RawResult ?? "");
                                if (extractedIds.Count > 0)
                                {
                                    // Store all IDs for multiple tool calls
                                    parameters["_MULTIPLE_PR_IDS"] = extractedIds;
                                    
                                    // For single PR ID parameter, use the first ID as string
                                    value = extractedIds[0];
                                    Console.WriteLine($"Successfully extracted {extractedIds.Count} pull request IDs from step {stepNumber}, using first: {value}");
                                }
                                else
                                {
                                    // Check if IDs were previously extracted and stored
                                    if (step.ExtractedValues.ContainsKey("id"))
                                    {
                                        var storedIds = step.ExtractedValues["id"];
                                        if (storedIds.Count > 0)
                                        {
                                            parameters["_MULTIPLE_PR_IDS"] = storedIds;
                                            value = storedIds[0];
                                            Console.WriteLine($"Using previously stored PR IDs: {storedIds.Count}, using first: {value}");
                                        }
                                    }
                                }
                            }
                            else if (cleanValue.Contains("TARGET_REPO") || cleanValue.Contains("REPO"))
                            {
                                Console.WriteLine("Extracting repository name from result");
                                
                                // Try to extract repository name from the raw result
                                var repositoryName = ExtractRepositoryNameFromResult(step.RawResult ?? "");
                                if (!string.IsNullOrEmpty(repositoryName))
                                {
                                    Console.WriteLine($"Successfully extracted repository name from step {stepNumber}: {repositoryName}");
                                    value = repositoryName;
                                }
                                else
                                {
                                    Console.WriteLine("No repository name found in step result");
                                    // Check if repository name was previously extracted and stored
                                    if (step.ExtractedValues.ContainsKey("repository"))
                                    {
                                        var storedRepo = step.ExtractedValues["repository"].FirstOrDefault();
                                        if (!string.IsNullOrEmpty(storedRepo))
                                        {
                                            Console.WriteLine($"Using previously stored repository name: {storedRepo}");
                                            value = storedRepo;
                                        }
                                    }
                                }
                            }
                            else if (cleanValue.StartsWith("ALL_PR_IDS_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Extracting all PR IDs for batch processing");
                                
                                // Try to extract PR IDs directly from the raw result
                                var extractedIds = ExtractPullRequestIdsFromResult(step.RawResult ?? "");
                                if (extractedIds.Count > 0)
                                {
                                    // Store all IDs for multiple tool calls
                                    parameters["_MULTIPLE_PR_IDS"] = extractedIds;
                                    Console.WriteLine($"Successfully extracted {extractedIds.Count} pull request IDs from step {stepNumber} for batch processing");
                                    // For ALL_PR_IDS pattern, we don't set a single value since it's meant for batch processing
                                    value = string.Join(",", extractedIds);
                                }
                                else
                                {
                                    // Check if IDs were previously extracted and stored
                                    if (step.ExtractedValues.ContainsKey("id"))
                                    {
                                        var storedIds = step.ExtractedValues["id"];
                                        if (storedIds.Count > 0)
                                        {
                                            parameters["_MULTIPLE_PR_IDS"] = storedIds;
                                            value = string.Join(",", storedIds);
                                            Console.WriteLine($"Using previously stored PR IDs for batch processing: {storedIds.Count}");
                                        }
                                    }
                                }
                            }
                            else if (cleanValue.StartsWith("ID_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Extracting generic ID from step result (treating as pull request ID)");
                                
                                // Try to extract PR IDs directly from the raw result
                                var extractedIds = ExtractPullRequestIdsFromResult(step.RawResult ?? "");
                                if (extractedIds.Count > 0)
                                {
                                    // For single ID parameter, use the first ID as string
                                    value = extractedIds[0];
                                    Console.WriteLine($"Successfully extracted {extractedIds.Count} IDs from step {stepNumber}, using first: {value}");
                                }
                                else
                                {
                                    Console.WriteLine("No IDs found in step result, trying to extract from JSON");
                                    // Check if IDs were previously extracted and stored
                                    if (step.ExtractedValues.ContainsKey("id"))
                                    {
                                        var storedIds = step.ExtractedValues["id"];
                                        if (storedIds.Count > 0)
                                        {
                                            value = storedIds[0];
                                            Console.WriteLine($"Using previously stored ID: {value}");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No step result found for step {stepNumber}");
                        }
                    }
                    else if (useManualExtraction)
                    {
                        Console.WriteLine($"Could not extract step number from: {cleanValue}");
                    }
                }
                
                parameters[key] = value;
            }
        }
        
        return parameters;
    }

    private int ExtractStepNumber(string dynamicValue)
    {
        // Extract step number from various patterns:
        // - "RESULT_FROM_STEP_2_COMPLETION_DATE" 
        // - "PULL_REQUEST_ID_FROM_STEP_3"
        // - "DATE_FROM_STEP_2"
        // - "ID_FROM_STEP_1"
        Console.WriteLine($"Extracting step number from: {dynamicValue}");
        
        var parts = dynamicValue.Split('_');
        
        // Handle different formats
        if (dynamicValue.StartsWith("RESULT_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
        {
            // Format: RESULT_FROM_STEP_2_COMPLETION_DATE
            if (parts.Length >= 4 && int.TryParse(parts[3], out int stepNumber))
            {
                Console.WriteLine($"Extracted step number: {stepNumber}");
                return stepNumber;
            }
        }
        else if (dynamicValue.StartsWith("PULL_REQUEST_ID_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
        {
            // Format: PULL_REQUEST_ID_FROM_STEP_3
            if (parts.Length >= 6 && int.TryParse(parts[5], out int stepNumber))
            {
                Console.WriteLine($"Extracted step number: {stepNumber}");
                return stepNumber;
            }
        }
        else if (dynamicValue.StartsWith("PR_ID_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
        {
            // Format: PR_ID_FROM_STEP_3
            if (parts.Length >= 5 && int.TryParse(parts[4], out int stepNumber))
            {
                Console.WriteLine($"Extracted step number: {stepNumber}");
                return stepNumber;
            }
        }
        else if (dynamicValue.StartsWith("DATE_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
        {
            // Format: DATE_FROM_STEP_2
            if (parts.Length >= 4 && int.TryParse(parts[3], out int stepNumber))
            {
                Console.WriteLine($"Extracted step number: {stepNumber}");
                return stepNumber;
            }
        }
        else if (dynamicValue.StartsWith("ID_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
        {
            // Format: ID_FROM_STEP_1
            if (parts.Length >= 4 && int.TryParse(parts[3], out int stepNumber))
            {
                Console.WriteLine($"Extracted step number: {stepNumber}");
                return stepNumber;
            }
        }
        else if (dynamicValue.StartsWith("TARGET_REPO_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
        {
            // Format: TARGET_REPO_FROM_STEP_3
            if (parts.Length >= 4 && int.TryParse(parts[3], out int stepNumber))
            {
                Console.WriteLine($"Extracted step number: {stepNumber}");
                return stepNumber;
            }
        }
        else if (dynamicValue.StartsWith("REPO_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
        {
            // Format: REPO_FROM_STEP_3
            if (parts.Length >= 4 && int.TryParse(parts[3], out int stepNumber))
            {
                Console.WriteLine($"Extracted step number: {stepNumber}");
                return stepNumber;
            }
        }
        else if (dynamicValue.StartsWith("ALL_PR_IDS_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
        {
            // Format: ALL_PR_IDS_FROM_STEP_5
            if (parts.Length >= 5 && int.TryParse(parts[4], out int stepNumber))
            {
                Console.WriteLine($"Extracted step number: {stepNumber}");
                return stepNumber;
            }
        }
        
        Console.WriteLine("Could not extract step number");
        return 0;
    }

    private string ExtractDateFromResult(string result)
    {
        // Try to extract a date from the result JSON
        try
        {
            Console.WriteLine($"Extracting date from result: {result.Substring(0, Math.Min(200, result.Length))}...");
            
            // First try to decode Unicode escapes like the PR ID extraction does
            var decodedResult = Regex.Unescape(result);
            
            // Try to parse as JSON first for more accurate extraction
            try
            {
                using var document = JsonDocument.Parse(decodedResult);
                if (document.RootElement.TryGetProperty("content", out var contentArray) && contentArray.ValueKind == JsonValueKind.Array)
                {
                    foreach (var contentItem in contentArray.EnumerateArray())
                    {
                        if (contentItem.TryGetProperty("text", out var textProperty))
                        {
                            var textContent = textProperty.GetString();
                            if (!string.IsNullOrEmpty(textContent))
                            {
                                // Parse the nested JSON in the text content
                                try
                                {
                                    using var innerDocument = JsonDocument.Parse(textContent);
                                    var date = ExtractDateFromJsonElement(innerDocument.RootElement);
                                    if (!string.IsNullOrEmpty(date))
                                    {
                                        Console.WriteLine($"Found date in JSON: {date}");
                                        return date;
                                    }
                                }
                                catch (JsonException)
                                {
                                    // If inner JSON parsing fails, fall back to regex on this text
                                    var date = ExtractDateWithRegex(textContent);
                                    if (!string.IsNullOrEmpty(date))
                                    {
                                        return date;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (JsonException)
            {
                Console.WriteLine("JSON parsing failed, falling back to regex approach");
            }
            
            // Fall back to regex patterns on the full result
            var extractedDate = ExtractDateWithRegex(decodedResult);
            if (!string.IsNullOrEmpty(extractedDate))
            {
                return extractedDate;
            }
            
            Console.WriteLine("No date pattern matched in result");
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to extract date from result: {Result}", result);
        }
        
        return string.Empty;
    }

    private string ExtractDateFromJsonElement(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            // Look for common date field names in priority order (completed/closed dates first for production deployments)
            var dateFields = new[] { "completedDate", "closedDate", "finishedDate", "mergedDate", "lastMergeCommitDate", "createdDate", "creationDate", "date" };
            
            foreach (var fieldName in dateFields)
            {
                if (element.TryGetProperty(fieldName, out var dateProperty) && dateProperty.ValueKind == JsonValueKind.String)
                {
                    var dateValue = dateProperty.GetString();
                    if (!string.IsNullOrEmpty(dateValue))
                    {
                        Console.WriteLine($"Found date in JSON field '{fieldName}': {dateValue}");
                        
                        // Format the date for Azure DevOps API compatibility
                        if (DateTime.TryParse(dateValue, out DateTime parsedDate))
                        {
                            return parsedDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                        }
                        return dateValue;
                    }
                }
            }
            
            // Recursively search nested objects and arrays
            foreach (var property in element.EnumerateObject())
            {
                var date = ExtractDateFromJsonElement(property.Value);
                if (!string.IsNullOrEmpty(date))
                {
                    return date;
                }
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
            {
                var date = ExtractDateFromJsonElement(item);
                if (!string.IsNullOrEmpty(date))
                {
                    return date;
                }
            }
        }
        
        return string.Empty;
    }

    private string ExtractDateWithRegex(string text)
    {
        var datePatterns = new[]
        {
            @"""completedDate"":\s*""([^""]+)""", // JSON completedDate field (priority for production deployments)
            @"""closedDate"":\s*""([^""]+)""", // JSON closedDate field
            @"""finishedDate"":\s*""([^""]+)""", // JSON finishedDate field
            @"""mergedDate"":\s*""([^""]+)""", // JSON mergedDate field
            @"""lastMergeCommitDate"":\s*""([^""]+)""", // JSON lastMergeCommitDate field
            @"""creationDate"":\s*""([^""]+)""", // JSON creationDate field
            @"""createdDate"":\s*""([^""]+)""", // JSON createdDate field
            @"""date"":\s*""([^""]+)""", // JSON date field
            @"(\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}[.\d]*Z?)", // ISO datetime with optional milliseconds
            @"(\d{4}-\d{2}-\d{2})" // ISO date
        };

        foreach (var pattern in datePatterns)
        {
            var match = Regex.Match(text, pattern);
            if (match.Success)
            {
                var dateValue = match.Groups.Count > 1 ? match.Groups[1].Value : match.Value;
                Console.WriteLine($"Found date pattern: {pattern} -> {dateValue}");
                
                // Format the date for Azure DevOps API compatibility
                if (DateTime.TryParse(dateValue, out DateTime parsedDate))
                {
                    var formattedDate = parsedDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    Console.WriteLine($"Converted to Azure DevOps date format: {formattedDate}");
                    return formattedDate;
                }
                
                return dateValue;
            }
        }
        
        return string.Empty;
    }

    private string ExtractRepositoryNameFromResult(string result)
    {
        // Try to extract a repository name from the result JSON
        try
        {
            Console.WriteLine($"Extracting repository name from result: {result.Substring(0, Math.Min(200, result.Length))}...");
            
            // First try to decode Unicode escapes
            var decodedResult = Regex.Unescape(result);
            
            // Try to parse as JSON first for more accurate extraction
            try
            {
                using var document = JsonDocument.Parse(decodedResult);
                if (document.RootElement.TryGetProperty("content", out var contentArray) && contentArray.ValueKind == JsonValueKind.Array)
                {
                    foreach (var contentItem in contentArray.EnumerateArray())
                    {
                        if (contentItem.TryGetProperty("text", out var textProperty))
                        {
                            var textContent = textProperty.GetString();
                            if (!string.IsNullOrEmpty(textContent))
                            {
                                // Parse the nested JSON in the text content
                                try
                                {
                                    using var innerDocument = JsonDocument.Parse(textContent);
                                    var repoName = ExtractRepositoryNameFromJsonElement(innerDocument.RootElement);
                                    if (!string.IsNullOrEmpty(repoName))
                                    {
                                        Console.WriteLine($"Found repository name in JSON: {repoName}");
                                        return repoName;
                                    }
                                }
                                catch (JsonException)
                                {
                                    // If inner JSON parsing fails, fall back to regex on this text
                                    var repoName = ExtractRepositoryNameWithRegex(textContent);
                                    if (!string.IsNullOrEmpty(repoName))
                                    {
                                        return repoName;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (JsonException)
            {
                Console.WriteLine("JSON parsing failed, falling back to regex approach");
            }
            
            // Fall back to regex patterns on the full result
            var extractedRepoName = ExtractRepositoryNameWithRegex(decodedResult);
            if (!string.IsNullOrEmpty(extractedRepoName))
            {
                return extractedRepoName;
            }
            
            Console.WriteLine("No repository name pattern matched in result");
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to extract repository name from result: {Result}", result);
        }
        
        return "";
    }

    private string ExtractRepositoryNameFromJsonElement(JsonElement element)
    {
        // Look for repository name in various JSON structures
        if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
            {
                // Check if this is a repository object
                if (item.TryGetProperty("name", out var nameProperty))
                {
                    var name = nameProperty.GetString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        // For release notes, prioritize repositories that might contain deployments
                        if (name.Contains("internal", StringComparison.OrdinalIgnoreCase) || 
                            name.Contains("main", StringComparison.OrdinalIgnoreCase) ||
                            name.Contains("prod", StringComparison.OrdinalIgnoreCase))
                        {
                            return name;
                        }
                    }
                }
            }
            
            // If no prioritized repository found, return the first one with a name
            foreach (var item in element.EnumerateArray())
            {
                if (item.TryGetProperty("name", out var nameProperty))
                {
                    var name = nameProperty.GetString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        return name;
                    }
                }
            }
        }
        else if (element.ValueKind == JsonValueKind.Object)
        {
            if (element.TryGetProperty("name", out var nameProperty))
            {
                var name = nameProperty.GetString();
                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
            }
        }
        
        return "";
    }

    private string ExtractRepositoryNameWithRegex(string text)
    {
        // Repository name patterns in Azure DevOps responses
        var patterns = new[]
        {
            @"""name""\s*:\s*""([^""]+)""",
            @"""Name""\s*:\s*""([^""]+)""",
            @"name:\s*([^\s,}]+)",
            @"repository[^\w]*name[^\w]*[:=]\s*([^\s,}]+)"
        };
        
        foreach (var pattern in patterns)
        {
            var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
            if (match.Success && match.Groups.Count > 1)
            {
                var repoName = match.Groups[1].Value.Trim();
                if (!string.IsNullOrEmpty(repoName))
                {
                    Console.WriteLine($"Found repository name with regex pattern '{pattern}': {repoName}");
                    return repoName;
                }
            }
        }
        
        return "";
    }

    private List<string> ExtractPullRequestIdsFromResult(string result)
    {
        var pullRequestIds = new List<string>();
        
        try
        {
            Console.WriteLine($"Extracting pull request IDs from result: {result.Substring(0, Math.Min(500, result.Length))}...");
            
            // First try to decode Unicode escapes
            var decodedResult = Regex.Unescape(result);
            Console.WriteLine($"Decoded result: {decodedResult.Substring(0, Math.Min(500, decodedResult.Length))}...");
            
            // Try to parse as JSON first
            try
            {
                using var document = JsonDocument.Parse(decodedResult);
                if (document.RootElement.TryGetProperty("content", out var contentArray) && contentArray.ValueKind == JsonValueKind.Array)
                {
                    foreach (var contentItem in contentArray.EnumerateArray())
                    {
                        if (contentItem.TryGetProperty("text", out var textProperty))
                        {
                            var textContent = textProperty.GetString();
                            if (!string.IsNullOrEmpty(textContent))
                            {
                                // Parse the nested JSON in the text content
                                try
                                {
                                    using var innerDocument = JsonDocument.Parse(textContent);
                                    ExtractIdsFromJsonElement(innerDocument.RootElement, pullRequestIds);
                                }
                                catch (JsonException)
                                {
                                    // If inner JSON parsing fails, fall back to regex
                                    ExtractIdsWithRegex(textContent, pullRequestIds);
                                }
                            }
                        }
                    }
                }
            }
            catch (JsonException)
            {
                Console.WriteLine("JSON parsing failed, falling back to regex approach");
                // Fall back to regex approach
                ExtractIdsWithRegex(decodedResult, pullRequestIds);
            }
            
            Console.WriteLine($"Extracted {pullRequestIds.Count} pull request IDs: {string.Join(", ", pullRequestIds)}");
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to extract pull request IDs from result: {Result}", result);
        }
        
        return pullRequestIds;
    }

    private void ExtractIdsFromJsonElement(JsonElement element, List<string> pullRequestIds)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            // Look for common PR ID field names
            var idFields = new[] { "pullRequestId", "id", "PullRequestId", "Id" };
            
            foreach (var fieldName in idFields)
            {
                if (element.TryGetProperty(fieldName, out var idProperty) && idProperty.ValueKind == JsonValueKind.Number)
                {
                    var idValue = idProperty.GetInt32().ToString();
                    Console.WriteLine($"Found PR ID in JSON field '{fieldName}': {idValue}");
                    if (!pullRequestIds.Contains(idValue))
                    {
                        pullRequestIds.Add(idValue);
                    }
                }
            }
            
            // Recursively search nested objects and arrays
            foreach (var property in element.EnumerateObject())
            {
                ExtractIdsFromJsonElement(property.Value, pullRequestIds);
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
            {
                ExtractIdsFromJsonElement(item, pullRequestIds);
            }
        }
    }

    private void ExtractIdsWithRegex(string text, List<string> pullRequestIds)
    {
        var idPatterns = new[]
        {
            @"""pullRequestId"":\s*(\d+)", // JSON pullRequestId field
            @"""id"":\s*(\d+)", // JSON id field
            @"""PullRequestId"":\s*(\d+)", // JSON PullRequestId field (capitalized)
            @"""Id"":\s*(\d+)", // JSON Id field (capitalized)
            @"#(\d+)", // PR reference like #12345
            @"PR\s*(\d+)", // PR reference like PR 12345
            @"Pull\s*Request\s*(\d+)" // Pull Request 12345
        };

        foreach (var pattern in idPatterns)
        {
            var matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1)
                {
                    var idValue = match.Groups[1].Value;
                    Console.WriteLine($"Found PR ID with regex pattern '{pattern}': {idValue}");
                    
                    if (!pullRequestIds.Contains(idValue))
                    {
                        pullRequestIds.Add(idValue);
                    }
                }
            }
        }
    }

    private async Task<string> HandleBatchExecution(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, string listKey, string targetParameterName, MarkdownConfig config)
    {
        // Extract the list of IDs from the parameter value
        var listValue = parameters[listKey];
        List<string> allIds;
        
        if (listValue is List<string> list)
        {
            allIds = list;
        }
        else if (listValue is string stringValue)
        {
            // Try to parse as comma-separated values or extract from previous step results
            if (stringValue.Contains(','))
            {
                allIds = stringValue.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
            }
            else
            {
                // This might be a reference to a previous step - try to extract IDs from it
                allIds = ExtractPullRequestIdsFromResult(stringValue);
                if (allIds.Count == 0)
                {
                    // Try to extract any numeric IDs
                    var matches = Regex.Matches(stringValue, @"\d+");
                    allIds = matches.Cast<Match>().Select(m => m.Value).ToList();
                }
            }
        }
        else
        {
            _logger.LogWarning("Unable to convert {ListKey} to list of IDs, skipping batch execution", listKey);
            return $"Skipped {toolName} - unable to extract IDs from {listKey}";
        }
        
        if (allIds.Count == 0)
        {
            Console.WriteLine($"No items found for batch execution of {toolName}");
            return $"No items found for {toolName}";
        }
        
        var allResults = new List<string>();
        Console.WriteLine($"Executing {toolName} for {allIds.Count} items");
        
        foreach (var id in allIds)
        {
            var itemParameters = new Dictionary<string, object>(parameters);
            itemParameters[targetParameterName] = id;
            RemoveSpecialParameters(itemParameters);
            
            Console.WriteLine($"  Processing item: {id}");
            
            try
            {
                var itemResult = await _mcpServerService.CallToolAsync(serverInfo, toolName, itemParameters, config.ToolDefaults);
                allResults.Add($"Item {id}: {itemResult}");
                Console.WriteLine($"  Successfully processed item: {id}");
            }
            catch (Exception ex)
            {
                var error = $"Item {id}: Error - {ex.Message}";
                allResults.Add(error);
                Console.WriteLine($"  Error processing item {id}: {ex.Message}");
            }
        }
        
        return string.Join("\n\n", allResults);
    }

    private async Task<string> HandleListIteration(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, MarkdownConfig config)
    {
        // Find the parameter with list iteration pattern
        var listParam = parameters.FirstOrDefault(p => p.Value.ToString()?.Contains("{") == true && p.Value.ToString()?.Contains("_FROM_LIST}") == true);
        
        if (listParam.Key == null)
        {
            throw new InvalidOperationException("List iteration pattern detected but no list parameter found");
        }
        
        // Extract the list reference (e.g., "{ID_FROM_LIST}" -> "ID")
        var pattern = listParam.Value.ToString();
        var listReference = pattern?.Replace("{", "").Replace("_FROM_LIST}", "");
        
        // Look for the list in other parameters or context - try multiple variations
        List<string> possibleListKeys = new List<string>
        {
            $"_LIST_{listReference}",
            $"ALL_{listReference}S_FROM_STEP_3", // Try common pattern like ALL_REPOS_FROM_STEP_3
            $"ALL_{listReference}S_FROM_STEP_2", // Try step 2 as well
            $"ALL_{listReference}S_FROM_STEP_1"  // Try step 1 as well
        };
        
        foreach (var listKey in possibleListKeys)
        {
            if (parameters.ContainsKey(listKey))
            {
                var listValue = parameters[listKey];
                List<string> list;
                
                if (listValue is List<string> stringList)
                {
                    list = stringList;
                }
                else if (listValue is string stringValue)
                {
                    // Try to parse as comma-separated values or extract from previous step results
                    if (stringValue.Contains(','))
                    {
                        list = stringValue.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
                    }
                    else
                    {
                        // This might be a reference to a previous step - try to extract items from it
                        var matches = Regex.Matches(stringValue, @"[\w\-\.]+");
                        list = matches.Cast<Match>().Select(m => m.Value).Where(v => !string.IsNullOrEmpty(v)).ToList();
                    }
                }
                else
                {
                    continue; // Try next possible list key
                }
                
                if (list.Count == 0)
                {
                    continue; // Try next possible list key
                }
                
                var results = new List<string>();
                Console.WriteLine($"Iterating {toolName} over {list.Count} items from list");
                
                foreach (var item in list)
                {
                    var iterationParameters = new Dictionary<string, object>(parameters);
                    iterationParameters[listParam.Key] = item; // Replace the pattern with actual value
                    RemoveSpecialParameters(iterationParameters);
                    
                    try
                    {
                        var result = await _mcpServerService.CallToolAsync(serverInfo, toolName, iterationParameters, config.ToolDefaults);
                        results.Add($"{item}: {result}");
                    }
                    catch (Exception ex)
                    {
                        results.Add($"{item}: Error - {ex.Message}");
                    }
                }
                
                return string.Join("\n\n", results);
            }
        }
        
        // If we can't find a proper list, let's try to extract from the current context
        // This is a fallback approach - just run the tool once without iteration
        Console.WriteLine($"No list found for iteration pattern {pattern}, running tool once without iteration");
        var fallbackParameters = new Dictionary<string, object>(parameters);
        fallbackParameters[listParam.Key] = "default"; // Use a default value
        RemoveSpecialParameters(fallbackParameters);
        
        try
        {
            var result = await _mcpServerService.CallToolAsync(serverInfo, toolName, fallbackParameters, config.ToolDefaults);
            return $"Fallback execution: {result}";
        }
        catch (Exception ex)
        {
            return $"Failed to execute {toolName} with fallback: {ex.Message}";
        }
    }

    private async Task<string> HandleConditionalExecution(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, MarkdownConfig config)
    {
        var cleanParameters = new Dictionary<string, object>(parameters);
        
        // Check conditions
        if (parameters.ContainsKey("_IF_NOT_EMPTY"))
        {
            var checkValue = parameters["_IF_NOT_EMPTY"].ToString();
            if (string.IsNullOrWhiteSpace(checkValue))
            {
                Console.WriteLine($"Skipping {toolName} - condition _IF_NOT_EMPTY failed");
                return $"Skipped {toolName} - condition not met";
            }
            cleanParameters.Remove("_IF_NOT_EMPTY");
        }
        
        if (parameters.ContainsKey("_IF_EXISTS"))
        {
            var checkValue = parameters["_IF_EXISTS"].ToString();
            if (string.IsNullOrWhiteSpace(checkValue) || checkValue == "null")
            {
                Console.WriteLine($"Skipping {toolName} - condition _IF_EXISTS failed");
                return $"Skipped {toolName} - condition not met";
            }
            cleanParameters.Remove("_IF_EXISTS");
        }
        
        return await _mcpServerService.CallToolAsync(serverInfo, toolName, cleanParameters, config.ToolDefaults);
    }

    public async Task<string> GetAiPlanningPromptAsync(MarkdownConfig config, string userPrompt, string availableTools)
    {
        try
        {
            // Determine the AI planning prompt file path
            string promptFilePath;
            
            if (!string.IsNullOrEmpty(config.AiPlanningPromptFile))
            {
                // Use configured prompt file (relative to config file or absolute)
                promptFilePath = Path.IsPathRooted(config.AiPlanningPromptFile) 
                    ? config.AiPlanningPromptFile 
                    : FindSystemPromptFile(config.AiPlanningPromptFile);
            }
            else
            {
                // Use default system prompt
                promptFilePath = FindSystemPromptFile(Path.Combine("system-prompts", "ai-planning-prompt.md"));
            }

            // Check if the prompt file exists
            if (await _systemPromptService.ValidatePromptFileAsync(promptFilePath))
            {
                var variables = new Dictionary<string, string>
                {
                    ["USER_PROMPT"] = userPrompt,
                    ["AVAILABLE_TOOLS"] = availableTools
                };

                var processedPrompt = await _systemPromptService.ProcessPromptAsync(promptFilePath, variables);
                _logger.LogInformation("Using AI planning prompt from: {PromptFilePath}", promptFilePath);
                return processedPrompt;
            }
            else
            {
                _logger.LogWarning("AI planning prompt file not found or invalid: {PromptFilePath}, using fallback", promptFilePath);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error loading AI planning prompt file, using fallback");
        }

        // Fallback to hardcoded prompt
        return GetFallbackAiPlanningPrompt(userPrompt, availableTools);
    }

    private string FindSystemPromptFile(string relativePath)
    {
        var currentDir = Environment.CurrentDirectory;
        var searchDir = currentDir;
        
        // Search up the directory tree for the system-prompts directory
        for (int i = 0; i < 5; i++) // Limit search to 5 levels up
        {
            var candidatePath = Path.Combine(searchDir, relativePath);
            
            _logger.LogDebug("Searching for system prompt at: {Path}", candidatePath);
            
            if (File.Exists(candidatePath))
            {
                _logger.LogDebug("Found system prompt at: {Path}", candidatePath);
                return candidatePath;
            }
            
            // Also check if we're looking for system-prompts directory specifically
            if (relativePath.StartsWith("system-prompts") && Directory.Exists(Path.Combine(searchDir, "system-prompts")))
            {
                var systemPromptsPath = Path.Combine(searchDir, relativePath);
                _logger.LogDebug("Found system-prompts directory, checking: {Path}", systemPromptsPath);
                if (File.Exists(systemPromptsPath))
                {
                    return systemPromptsPath;
                }
            }
            
            var parentDir = Path.GetDirectoryName(searchDir);
            if (parentDir == null || parentDir == searchDir)
            {
                break; // Reached root or can't go further up
            }
            
            searchDir = parentDir;
        }
        
        // If not found, return the original relative path from current directory
        var fallbackPath = Path.Combine(currentDir, relativePath);
        _logger.LogDebug("System prompt not found in directory tree, using fallback: {Path}", fallbackPath);
        return fallbackPath;
    }

    private string GetFallbackAiPlanningPrompt(string userPrompt, string availableTools)
    {
        return $@"
You are an AI assistant that helps users interact with MCP (Model Context Protocol) servers.

User's request: {userPrompt}

Available MCP tools: {availableTools}

CRITICAL INSTRUCTIONS:
1. You must analyze the user's request and create a COMPLETE, DETAILED execution plan
2. Your plan should be sophisticated enough to handle complex scenarios WITHOUT requiring custom server code
3. Use special parameter patterns for advanced operations (see ADVANCED PATTERNS below)
4. Each step that requires a tool call must follow the exact format shown below
5. Parameters must be formatted as: key1=value1, key2=value2, key3=value3
6. Use the exact tool names from the available tools list above
7. For sequential steps that depend on previous results, clearly indicate the dependency
8. If you need more information to complete a task, create SUB-PLANS or ITERATIVE steps

EXECUTION PLAN FORMAT:
1. [First action description]
   - Tool name: [exact tool name from available tools]
   - Parameters: [key1=value1, key2=value2, etc.]
   - Purpose: [why this tool call is needed]

2. [Second action description]
   - Tool name: [exact tool name from available tools]
   - Parameters: [key1=value1, key2=value2, etc.]
   - Purpose: [why this tool call is needed]

ADVANCED PATTERNS FOR COMPLEX SCENARIOS:

### Batch Processing (Multiple IDs):
When you need to process multiple items, use these patterns:
- Parameters: organizationName=dnceng, _MULTIPLE_PR_IDS=ALL_IDS_FROM_STEP_X
- Parameters: organizationName=dnceng, _MULTIPLE_IDS=ALL_IDS_FROM_STEP_X

### List Iteration:
When you need to iterate over a list of items, you MUST include BOTH the iteration pattern AND the list parameter:
- Parameters: organizationName=dnceng, pullRequestId={{ID_FROM_LIST}}, _LIST_ID=ALL_IDS_FROM_STEP_X
- Parameters: organizationName=dnceng, repositoryName={{REPO_FROM_LIST}}, _LIST_REPO=ALL_REPOS_FROM_STEP_X

CRITICAL: When using {{FIELD_FROM_LIST}} patterns, you MUST also include the corresponding _LIST_FIELD parameter that contains the actual list data!

### Conditional Execution:
When execution depends on conditions:
- Parameters: organizationName=dnceng, projectName=internal, _IF_NOT_EMPTY=RESULT_FROM_STEP_X
- Parameters: organizationName=dnceng, projectName=internal, _IF_EXISTS=ID_FROM_STEP_X

### Sub-Plan Generation:
If you need more information, create investigative steps:
Example:
1. Investigate available repositories
   - Tool name: get_repositories
   - Parameters: organizationName=dnceng, projectName=internal
   - Purpose: Determine which repositories exist before proceeding

2. FOR EACH repository found in step 1, get pull requests
   - Tool name: get_pull_requests
   - Parameters: organizationName=dnceng, projectName=internal, repositoryName={{REPO_FROM_LIST}}, _LIST_REPO=ALL_REPOS_FROM_STEP_1
   - Purpose: Get pull requests for each repository

CRITICAL: Only use ACTUAL tool names from the available tools list. Do NOT create placeholder tool names like ""[determined dynamically]"" or ""analyze_completeness"". If you need additional analysis, use existing tools with different parameters or create multiple steps with real tools.

CRITICAL FORMAT REQUIREMENTS:
- Use EXACTLY this format: ""- Tool name: toolname"" (no bold, no markdown)
- Use EXACTLY this format: ""- Parameters: key1=value1, key2=value2""
- Use EXACTLY this format: ""- Purpose: description""
- Do NOT use **bold** formatting in the tool specification lines
- Do NOT use backticks around tool names

IMPORTANT DATE HANDLING:
- If looking for items ""before"" a completion date, use: beforeClosedDate=2025-07-01
- If looking for items ""after"" a completion date, use: afterClosedDate=2025-07-01
- Always use ISO date format: YYYY-MM-DD

EXAMPLE 1: Azure DevOps workflow with proper tool usage:
EXECUTION PLAN:
1. Initialize Azure DevOps connection
   - Tool name: InitializeAzureDevOpsClient
   - Parameters: organizationUrl=https://dev.azure.com/dnceng
   - Purpose: Enable access to Azure DevOps APIs

2. Get available projects
   - Tool name: get_projects
   - Parameters: organizationName=dnceng
   - Purpose: Identify available projects in the organization

3. Get repositories for the internal project
   - Tool name: get_repositories
   - Parameters: organizationName=dnceng, projectName=internal
   - Purpose: Identify all repositories to analyze

4. Get recent pull requests for specific repository
   - Tool name: get_pull_requests_by_creation_date
   - Parameters: organizationName=dnceng, projectName=internal, repositoryName=dotnet-helix-service, status=completed, maxCount=10
   - Purpose: Get recent changes for analysis

5. Get descriptions for the pull requests found
   - Tool name: get_pull_request_description
   - Parameters: organizationName=dnceng, projectName=internal, _MULTIPLE_PR_IDS=ALL_PR_IDS_FROM_STEP_4
   - Purpose: Retrieve detailed descriptions for batch processing

EXAMPLE 2: Release Notes workflow (finding changes after production deployment):
EXECUTION PLAN:
1. Initialize Azure DevOps connection
   - Tool name: InitializeAzureDevOpsClient
   - Parameters: organizationUrl=https://dev.azure.com/dnceng
   - Purpose: Enable access to Azure DevOps APIs

2. Find latest production deployment
   - Tool name: get_pull_requests_by_closed_date
   - Parameters: organizationName=dnceng, projectName=internal, repositoryName=dotnet-helix-service, targetBranch=production, status=completed, maxCount=1, beforeClosedDate=2025-01-20
   - Purpose: Find the most recent production deployment to use as baseline

3. Get changes merged after production deployment
   - Tool name: get_pull_requests_by_closed_date
   - Parameters: organizationName=dnceng, projectName=internal, repositoryName=dotnet-helix-service, targetBranch=main, status=completed, afterClosedDate=DATE_FROM_STEP_2, maxCount=20
   - Purpose: Find all changes merged to main after the production deployment

4. Get descriptions for the changes found
   - Tool name: get_pull_request_description
   - Parameters: organizationName=dnceng, projectName=internal, _MULTIPLE_PR_IDS=ALL_PR_IDS_FROM_STEP_3
   - Purpose: Retrieve detailed descriptions for release notes

CRITICAL DATE FILTERING RULES:
- For release notes: ALWAYS find the latest production deployment FIRST, then get changes AFTER that date
- Use beforeClosedDate to limit the search for production deployments
- Use afterClosedDate with the production deployment date to find subsequent changes
- NEVER mix ""before"" and ""after"" dates in the same query unless intentionally creating a date range

Your job is to create plans that are detailed and intelligent enough to handle any complexity without requiring custom server-specific code.
";
    }

    // Helper methods - will be implemented by extracting from RunCommand
    private async Task ExecuteToolFromPlan(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, string? purpose, int stepNumber, List<string> toolResults, ContextLibrary contextLibrary, MarkdownConfig config, ExecutionSummary? executionSummary)
    {
        var stepContext = new StepContext
        {
            StepNumber = stepNumber,
            ToolName = toolName,
            Parameters = new Dictionary<string, object>(parameters),
            Purpose = purpose ?? string.Empty
        };

        try
        {
            Console.WriteLine($"Executing: {toolName}");
            if (!string.IsNullOrEmpty(purpose))
            {
                Console.WriteLine($"Purpose: {purpose}");
            }
            
            // Debug: Show all parameters being passed
            Console.WriteLine($"Parameters being passed to {toolName}:");
            foreach (var param in parameters)
            {
                Console.WriteLine($"  {param.Key} = {param.Value}");
            }
            
            // Track tool execution
            executionSummary?.AddToolExecuted(toolName);
            
            // Execute the tool with intelligent pattern recognition
            var result = await ExecuteToolWithPatternRecognitionAsync(serverInfo, toolName, parameters, config);
            
            // Store the successful result in context
            stepContext.RawResult = result;
            stepContext.IsSuccess = true;
            contextLibrary.AddStepResult(stepContext);
            
            // Add to tool results for final output
            toolResults.Add($"{toolName}: {result}");
            
            Console.WriteLine($"Stored result for step {stepNumber}: {result.Substring(0, Math.Min(100, result.Length))}...");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing tool {ToolName}", toolName);
            var errorResult = $"{toolName}: Error - {ex.Message}";
            
            // Store the error result in context
            stepContext.RawResult = errorResult;
            stepContext.IsSuccess = false;
            stepContext.ErrorMessage = ex.Message;
            contextLibrary.AddStepResult(stepContext);
            
            toolResults.Add(errorResult);
            Console.WriteLine($"Stored error for step {stepNumber}: {ex.Message}");
        }
    }

    private string ExtractValue(string line, string prefix)
    {
        var index = line.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
        if (index >= 0)
        {
            return line.Substring(index + prefix.Length).Trim();
        }
        return string.Empty;
    }

    private string ExtractToolName(string line)
    {
        // Handle multiple formats: "- Tool name:", "- **Tool name**:", "- **Tool Name**:"
        if (line.Contains("**Tool Name**:"))
        {
            var value = ExtractValue(line, "**Tool Name**:");
            // Remove markdown formatting like backticks
            return value.Trim('`', ' ', '*');
        }
        else if (line.Contains("**Tool name**:"))
        {
            var value = ExtractValue(line, "**Tool name**:");
            // Remove markdown formatting like backticks
            return value.Trim('`', ' ', '*');
        }
        else
        {
            return ExtractValue(line, "Tool name:");
        }
    }

    private bool IsInvalidToolName(string toolName)
    {
        if (string.IsNullOrWhiteSpace(toolName))
            return true;

        var lowerToolName = toolName.ToLower();
        
        // Check for placeholder patterns
        if (toolName.Contains("[") || toolName.Contains("]") || 
            toolName.Contains("{") || toolName.Contains("}"))
            return true;
            
        // Check for forbidden keywords
        var forbiddenKeywords = new[]
        {
            "none",
            "manual",
            "determined dynamically",
            "analyze_completeness",
            "manual step",
            "manual formatting",
            "manual formatting based on retrieved data",
            "manual analysis",
            "analyze data",
            "compile",
            "aggregate",
            "format",
            "process manually"
        };
        
        foreach (var keyword in forbiddenKeywords)
        {
            if (lowerToolName.Contains(keyword))
                return true;
        }
        
        // Check for parenthetical descriptions that indicate manual work
        if (toolName.Contains("(") && (
            lowerToolName.Contains("manual") || 
            lowerToolName.Contains("based on") ||
            lowerToolName.Contains("formatting") ||
            lowerToolName.Contains("retrieved data")))
            return true;
            
        return false;
    }

    private string ExtractParameters(string line)
    {
        // Handle both "- Parameters:" and "- **Parameters**:" formats
        if (line.Contains("**Parameters**:"))
        {
            var value = ExtractValue(line, "**Parameters**:");
            // Remove markdown formatting like backticks
            return value.Trim('`', ' ', '*');
        }
        else
        {
            return ExtractValue(line, "Parameters:");
        }
    }

    private string ExtractPurpose(string line)
    {
        // Handle both "- Purpose:" and "- **Purpose**:" formats
        if (line.Contains("**Purpose**:"))
        {
            var value = ExtractValue(line, "**Purpose**:");
            // Remove markdown formatting
            return value.Trim('`', ' ', '*');
        }
        else
        {
            return ExtractValue(line, "Purpose:");
        }
    }

    private void RemoveSpecialParameters(Dictionary<string, object> parameters)
    {
        var specialKeys = parameters.Keys.Where(k => k.StartsWith("_")).ToList();
        foreach (var key in specialKeys)
        {
            parameters.Remove(key);
        }
    }
} 