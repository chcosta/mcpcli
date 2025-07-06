using System.CommandLine;
using Microsoft.Extensions.Logging;
using McpCli.Services;
using McpCli.Models;

namespace McpCli.Commands;

public class RunCommand
{
    private readonly ILogger<RunCommand> _logger;
    private readonly IMarkdownConfigService _markdownConfigService;
    private readonly IConfigurationService _configurationService;
    private readonly IGitService _gitService;
    private readonly IMcpServerService _mcpServerService;
    private readonly IAzureAiService _azureAiService;
    private readonly IPromptFileService _promptFileService;
    private readonly ISystemPromptService _systemPromptService;

    public RunCommand(
        ILogger<RunCommand> logger,
        IMarkdownConfigService markdownConfigService,
        IConfigurationService configurationService,
        IGitService gitService,
        IMcpServerService mcpServerService,
        IAzureAiService azureAiService,
        IPromptFileService promptFileService,
        ISystemPromptService systemPromptService)
    {
        _logger = logger;
        _markdownConfigService = markdownConfigService;
        _configurationService = configurationService;
        _gitService = gitService;
        _mcpServerService = mcpServerService;
        _azureAiService = azureAiService;
        _promptFileService = promptFileService;
        _systemPromptService = systemPromptService;
    }

    public Command CreateCommand()
    {
        var configFileOption = new Option<string>(
            name: "--config",
            description: "Path to the Markdown configuration file")
        {
            IsRequired = true
        };
        configFileOption.AddAlias("-c");

        var promptOption = new Option<string>(
            name: "--prompt",
            description: "The prompt to send (if not provided, will use default prompts from config)");
        promptOption.AddAlias("-p");

        var promptFileOption = new Option<string>(
            name: "--prompt-file",
            description: "Path to a markdown file containing a complex prompt with sequential steps");
        promptFileOption.AddAlias("-pf");

        var listPromptsOption = new Option<bool>(
            name: "--list-prompts",
            description: "List available default prompts from the configuration file",
            getDefaultValue: () => false);

        var promptIndexOption = new Option<int>(
            name: "--prompt-index",
            description: "Index of the default prompt to use (0-based)",
            getDefaultValue: () => -1);

        var workingDirOption = new Option<string>(
            name: "--working-dir",
            description: "Working directory for cloned repositories (default: ./mcp-servers)",
            getDefaultValue: () => "./mcp-servers");

        var command = new Command("run", "Run MCP CLI using a Markdown configuration file")
        {
            configFileOption,
            promptOption,
            promptFileOption,
            listPromptsOption,
            promptIndexOption,
            workingDirOption
        };

        command.SetHandler(async (configFile, prompt, promptFile, listPrompts, promptIndex, workingDir) =>
        {
            await ExecuteAsync(configFile, prompt, promptFile, listPrompts, promptIndex, workingDir);
        }, configFileOption, promptOption, promptFileOption, listPromptsOption, promptIndexOption, workingDirOption);

        return command;
    }

    private async Task ExecuteAsync(string configFile, string? prompt, string? promptFile, bool listPrompts, int promptIndex, string workingDir)
    {
        try
        {
            _logger.LogInformation("Loading configuration from {ConfigFile}", configFile);

            // Parse the Markdown configuration
            var markdownConfig = await _markdownConfigService.ParseMarkdownConfigAsync(configFile);
            
            Console.WriteLine($"Loaded configuration: {markdownConfig.Name}");
            if (!string.IsNullOrEmpty(markdownConfig.Description))
            {
                Console.WriteLine($"Description: {markdownConfig.Description}");
            }

            // Validate the configuration
            if (!await _markdownConfigService.ValidateMarkdownConfigAsync(configFile))
            {
                Console.WriteLine("Configuration validation failed. Please check your configuration file.");
                return;
            }

            // Handle list prompts request
            if (listPrompts)
            {
                Console.WriteLine("\nAvailable default prompts:");
                for (int i = 0; i < markdownConfig.DefaultPrompts.Count; i++)
                {
                    var promptPreview = markdownConfig.DefaultPrompts[i];
                    if (promptPreview.Length > 100)
                    {
                        promptPreview = promptPreview.Substring(0, 100) + "...";
                    }
                    Console.WriteLine($"  {i}: {promptPreview}");
                }
                return;
            }

            // Determine which prompt to use
            string selectedPrompt;
            if (!string.IsNullOrEmpty(promptFile))
            {
                // Use prompt file
                Console.WriteLine($"Loading prompt from file: {promptFile}");
                var promptFileObj = await _promptFileService.ParsePromptFileAsync(promptFile);
                selectedPrompt = await _promptFileService.ProcessPromptFileAsync(promptFileObj);
                Console.WriteLine($"Loaded complex prompt: {promptFileObj.Title}");
                if (!string.IsNullOrEmpty(promptFileObj.Description))
                {
                    Console.WriteLine($"Description: {promptFileObj.Description}");
                }
            }
            else if (!string.IsNullOrEmpty(prompt))
            {
                selectedPrompt = prompt;
            }
            else if (promptIndex >= 0 && promptIndex < markdownConfig.DefaultPrompts.Count)
            {
                selectedPrompt = markdownConfig.DefaultPrompts[promptIndex];
                Console.WriteLine($"Using default prompt {promptIndex}: {selectedPrompt.Substring(0, Math.Min(50, selectedPrompt.Length))}...");
            }
            else if (markdownConfig.DefaultPrompts.Count > 0)
            {
                selectedPrompt = markdownConfig.DefaultPrompts[0];
                Console.WriteLine($"Using first default prompt: {selectedPrompt.Substring(0, Math.Min(50, selectedPrompt.Length))}...");
            }
            else
            {
                Console.WriteLine("No prompt provided and no default prompts available in configuration.");
                return;
            }

            // Apply configuration to services
            await ApplyConfigurationAsync(markdownConfig);

            // Execute the main workflow
            await ExecuteWorkflowAsync(markdownConfig, selectedPrompt, workingDir);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing run command");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async Task ApplyConfigurationAsync(Models.MarkdownConfig markdownConfig)
    {
        try
        {
            // Update Azure AI service configuration
            _azureAiService.UpdateConfiguration(markdownConfig.AzureAi);

            // Load and update main configuration with Azure DevOps settings
            var mainConfig = await _configurationService.LoadConfigurationAsync();
            
            // Apply Azure AI settings to main config
            mainConfig.AzureAi = markdownConfig.AzureAi;
            
            // Save the updated configuration
            await _configurationService.SaveConfigurationAsync(mainConfig);

            // Set up Git service with credentials from main config
            if (mainConfig.AzureDevOps.UseManagedIdentity)
            {
                _gitService.SetAzureDevOpsCredentials(mainConfig.AzureDevOps.Organization, true);
            }
            else
            {
                _gitService.SetAzureDevOpsCredentials(mainConfig.AzureDevOps.Organization, mainConfig.AzureDevOps.PersonalAccessToken);
            }

            _logger.LogInformation("Configuration applied successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error applying configuration");
            throw;
        }
    }

    private async Task ExecuteWorkflowAsync(Models.MarkdownConfig markdownConfig, string prompt, string workingDir)
    {
        try
        {
            // Get repository name and local path
            var repoName = _gitService.GetRepositoryNameFromUrl(markdownConfig.RepositoryUrl);
            var localPath = Path.Combine(workingDir, repoName);

            // Clone or update repository
            if (!await _gitService.IsRepositoryClonedAsync(localPath))
            {
                Console.WriteLine($"Cloning repository: {markdownConfig.RepositoryUrl}");
                var progress = new Progress<string>(message => Console.WriteLine($"  {message}"));
                await _gitService.CloneRepositoryAsync(markdownConfig.RepositoryUrl, localPath, progress);
                Console.WriteLine("Repository cloned successfully.");
            }
            else
            {
                Console.WriteLine($"Repository already exists at: {localPath}");
                Console.WriteLine("Updating repository...");
                await _gitService.UpdateRepositoryAsync(localPath);
                Console.WriteLine("Repository updated successfully.");
            }

            // Discover and start MCP server
            Console.WriteLine("Discovering MCP server configuration...");
            var serverInfo = await _mcpServerService.DiscoverServerConfigurationAsync(localPath);
            
            // Apply configuration overrides
            if (!string.IsNullOrEmpty(markdownConfig.McpServer.StartCommand))
            {
                serverInfo.StartCommand = markdownConfig.McpServer.StartCommand;
                serverInfo.StartArguments = markdownConfig.McpServer.StartArguments;
            }
            
            serverInfo.Port = markdownConfig.McpServer.Port;
            serverInfo.Environment = markdownConfig.McpServer.Environment;

            if (markdownConfig.McpServer.AutoStart)
            {
                Console.WriteLine($"Starting MCP server on port {serverInfo.Port}...");
                var runningServer = await _mcpServerService.StartServerAsync(localPath, serverInfo.Port);
                
                if (!runningServer.IsRunning)
                {
                    Console.WriteLine("Failed to start MCP server.");
                    return;
                }

                Console.WriteLine("MCP server started successfully.");

                try
                {
                    // Use AI to intelligently interact with MCP server
                    Console.WriteLine($"Sending prompt: {prompt}");
                    var finalResponse = await ProcessPromptWithAIAsync(runningServer, prompt, markdownConfig);
                    
                    Console.WriteLine("\n--- Final Response ---");
                    Console.WriteLine(finalResponse);
                    Console.WriteLine("--- End Response ---");
                }
                finally
                {
                    // Clean up - stop the server
                    Console.WriteLine("Stopping MCP server...");
                    await _mcpServerService.StopServerAsync(runningServer);
                    Console.WriteLine("MCP server stopped.");
                }
            }
            else
            {
                Console.WriteLine("MCP server auto-start is disabled in configuration.");
                Console.WriteLine("You can manually start the server using the 'connect' command.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing workflow");
            throw;
        }
    }

    private async Task<string> ProcessPromptWithAIAsync(McpServerInfo serverInfo, string userPrompt, Models.MarkdownConfig config)
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
            var toolResults = await ExecuteAIToolPlanAsync(serverInfo, aiResponse);
            
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

    private async Task<string> ExecuteAIToolPlanAsync(McpServerInfo serverInfo, string aiResponse)
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

            var executedTools = new HashSet<string>(); // Track executed tools to avoid duplicates
            
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                
                // Look for step numbers to track context
                if (trimmedLine.StartsWith("1.") || trimmedLine.StartsWith("2.") || trimmedLine.StartsWith("3.") || 
                    trimmedLine.StartsWith("4.") || trimmedLine.StartsWith("5."))
                {
                    currentStep = int.Parse(trimmedLine.Substring(0, 1));
                }
                
                // Look for tool name (handle multiple formats)
                if (trimmedLine.StartsWith("- Tool name:", StringComparison.OrdinalIgnoreCase) ||
                    trimmedLine.StartsWith("- **Tool name**:", StringComparison.OrdinalIgnoreCase) ||
                    trimmedLine.StartsWith("- **Tool Name**:", StringComparison.OrdinalIgnoreCase))
                {
                    // Execute previous tool if we have one and haven't executed it yet
                    if (!string.IsNullOrEmpty(currentToolName))
                    {
                        var previousStep = currentStep; // Store the step number for the tool we're about to execute
                        var toolKey = $"{previousStep}_{currentToolName}_{string.Join(",", currentParameters.Select(p => $"{p.Key}={p.Value}"))}";
                        if (!executedTools.Contains(toolKey))
                        {
                            executedTools.Add(toolKey);
                            await ExecuteToolFromPlan(serverInfo, currentToolName, currentParameters, currentPurpose, previousStep, toolResults, contextLibrary);
                        }
                    }
                    
                    // Start new tool
                    currentToolName = ExtractToolName(trimmedLine);
                    currentParameters = new Dictionary<string, object>();
                    currentPurpose = null;
                }
                else if (trimmedLine.StartsWith("- Parameters:", StringComparison.OrdinalIgnoreCase) ||
                         trimmedLine.StartsWith("- **Parameters**:", StringComparison.OrdinalIgnoreCase))
                {
                    var parametersText = ExtractParameters(trimmedLine);
                    currentParameters = ParseParameters(parametersText, contextLibrary);
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
                    await ExecuteToolFromPlan(serverInfo, currentToolName, currentParameters, currentPurpose, currentStep, toolResults, contextLibrary);
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

    private async Task ExecuteToolFromPlan(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, string? purpose, int stepNumber, List<string> toolResults, Models.ContextLibrary contextLibrary)
    {
        var stepContext = new Models.StepContext
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
            
            string result;
            
            // Check if this is a get_pull_request_description call with multiple PR IDs
            if (toolName == "get_pull_request_description" && parameters.ContainsKey("_MULTIPLE_PR_IDS"))
            {
                var allPrIds = (List<string>)parameters["_MULTIPLE_PR_IDS"];
                var allResults = new List<string>();
                
                Console.WriteLine($"Executing {toolName} for {allPrIds.Count} pull requests");
                
                foreach (var prId in allPrIds)
                {
                    // Create a copy of parameters with the current PR ID
                    var prParameters = new Dictionary<string, object>(parameters);
                    prParameters["pullRequestId"] = prId;
                    prParameters.Remove("_MULTIPLE_PR_IDS"); // Remove the special key
                    
                    Console.WriteLine($"  Fetching description for PR #{prId}");
                    
                    try
                    {
                        var prResult = await _mcpServerService.CallToolAsync(serverInfo, toolName, prParameters);
                        allResults.Add($"PR #{prId}: {prResult}");
                        Console.WriteLine($"  Successfully fetched description for PR #{prId}");
                    }
                    catch (Exception prEx)
                    {
                        var prError = $"PR #{prId}: Error - {prEx.Message}";
                        allResults.Add(prError);
                        Console.WriteLine($"  Error fetching description for PR #{prId}: {prEx.Message}");
                    }
                }
                
                result = string.Join("\n\n", allResults);
            }
            else
            {
                // Regular single tool call
                var cleanParameters = new Dictionary<string, object>(parameters);
                cleanParameters.Remove("_MULTIPLE_PR_IDS"); // Remove special key if present
                
                result = await _mcpServerService.CallToolAsync(serverInfo, toolName, cleanParameters);
            }
            
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

    private Dictionary<string, object> ParseParameters(string parametersText, Models.ContextLibrary contextLibrary)
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
                
                if (cleanValue.StartsWith("RESULT_FROM_STEP_", StringComparison.OrdinalIgnoreCase) ||
                    cleanValue.StartsWith("PULL_REQUEST_ID_FROM_STEP_", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Processing dynamic value: {cleanValue}");
                    
                    // Try new context library first
                    var resolvedValue = contextLibrary.ResolveVariable(cleanValue);
                    if (!string.IsNullOrEmpty(resolvedValue))
                    {
                        Console.WriteLine($"Resolved '{cleanValue}' to: {resolvedValue}");
                        value = resolvedValue;
                    }
                    else
                    {
                        // Fall back to legacy resolution for backward compatibility
                        var stepNumber = ExtractStepNumber(cleanValue);
                        if (stepNumber > 0)
                        {
                            var step = contextLibrary.GetStep(stepNumber);
                            if (step != null)
                            {
                                Console.WriteLine($"Found step result for step {stepNumber}");
                                
                                // Determine what type of value to extract based on the dynamic value name
                                if (cleanValue.Contains("COMPLETION_DATE") || cleanValue.Contains("CLOSED_DATE") || cleanValue.Contains("DATE"))
                                {
                                    Console.WriteLine("Extracting date from result");
                                    if (step.ExtractedValues.ContainsKey("date"))
                                    {
                                        var extractedDate = step.ExtractedValues["date"].FirstOrDefault();
                                        if (!string.IsNullOrEmpty(extractedDate))
                                        {
                                            value = extractedDate;
                                        }
                                    }
                                }
                                else if (cleanValue.Contains("PULL_REQUEST_ID"))
                                {
                                    Console.WriteLine("Extracting pull request IDs from result");
                                    if (step.ExtractedValues.ContainsKey("id"))
                                    {
                                        var extractedIds = step.ExtractedValues["id"];
                                        if (extractedIds.Count > 0)
                                        {
                                            // Store all IDs for multiple tool calls
                                            parameters["_MULTIPLE_PR_IDS"] = extractedIds;
                                            value = extractedIds[0]; // Use first ID for the initial call
                                            Console.WriteLine($"Found {extractedIds.Count} pull request IDs, using first: {value}");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"No step result found for step {stepNumber}");
                            }
                        }
                    }
                }
                
                parameters[key] = value;
            }
        }
        
        return parameters;
    }

    private int ExtractStepNumber(string dynamicValue)
    {
        // Extract step number from "RESULT_FROM_STEP_2_COMPLETION_DATE" or "PULL_REQUEST_ID_FROM_STEP_3"
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
        
        Console.WriteLine("Could not extract step number");
        return 0;
    }

    private string ExtractDateFromResult(string result)
    {
        // Try to extract a date from the result JSON
        try
        {
            Console.WriteLine($"Extracting date from result: {result.Substring(0, Math.Min(200, result.Length))}...");
            
            // Look for common date patterns in the result
            var datePatterns = new[]
            {
                @"""closedDate"":\s*""([^""]+)""", // JSON closedDate field
                @"""completedDate"":\s*""([^""]+)""", // JSON completedDate field  
                @"""creationDate"":\s*""([^""]+)""", // JSON creationDate field
                @"""createdDate"":\s*""([^""]+)""", // JSON createdDate field
                @"""lastMergeCommitDate"":\s*""([^""]+)""", // JSON lastMergeCommitDate field
                @"\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}", // ISO datetime
                @"\d{4}-\d{2}-\d{2}" // ISO date
            };

            foreach (var pattern in datePatterns)
            {
                var match = System.Text.RegularExpressions.Regex.Match(result, pattern);
                if (match.Success)
                {
                    var dateValue = match.Groups.Count > 1 ? match.Groups[1].Value : match.Value;
                    Console.WriteLine($"Found date pattern: {pattern} -> {dateValue}");
                    
                    // Convert to ISO date format if needed
                    if (DateTime.TryParse(dateValue, out DateTime parsedDate))
                    {
                        var isoDate = parsedDate.ToString("yyyy-MM-dd");
                        Console.WriteLine($"Converted to ISO date: {isoDate}");
                        return isoDate;
                    }
                }
            }
            
            Console.WriteLine("No date pattern matched in result");
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to extract date from result: {Result}", result);
        }
        
        return string.Empty;
    }

    private List<string> ExtractPullRequestIdsFromResult(string result)
    {
        var pullRequestIds = new List<string>();
        
        try
        {
            Console.WriteLine($"Extracting pull request IDs from result: {result.Substring(0, Math.Min(500, result.Length))}...");
            
            // First try to decode Unicode escapes
            var decodedResult = System.Text.RegularExpressions.Regex.Unescape(result);
            Console.WriteLine($"Decoded result: {decodedResult.Substring(0, Math.Min(500, decodedResult.Length))}...");
            
            // Try to parse as JSON first
            try
            {
                using var document = System.Text.Json.JsonDocument.Parse(decodedResult);
                if (document.RootElement.TryGetProperty("content", out var contentArray) && contentArray.ValueKind == System.Text.Json.JsonValueKind.Array)
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
                                    using var innerDocument = System.Text.Json.JsonDocument.Parse(textContent);
                                    ExtractIdsFromJsonElement(innerDocument.RootElement, pullRequestIds);
                                }
                                catch (System.Text.Json.JsonException)
                                {
                                    // If inner JSON parsing fails, fall back to regex
                                    ExtractIdsWithRegex(textContent, pullRequestIds);
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Text.Json.JsonException)
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

    private void ExtractIdsFromJsonElement(System.Text.Json.JsonElement element, List<string> pullRequestIds)
    {
        if (element.ValueKind == System.Text.Json.JsonValueKind.Object)
        {
            // Look for common PR ID field names
            var idFields = new[] { "pullRequestId", "id", "PullRequestId", "Id" };
            
            foreach (var fieldName in idFields)
            {
                if (element.TryGetProperty(fieldName, out var idProperty) && idProperty.ValueKind == System.Text.Json.JsonValueKind.Number)
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
        else if (element.ValueKind == System.Text.Json.JsonValueKind.Array)
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
            var matches = System.Text.RegularExpressions.Regex.Matches(text, pattern);
            foreach (System.Text.RegularExpressions.Match match in matches)
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

    private async Task<string> GetAiPlanningPromptAsync(Models.MarkdownConfig config, string userPrompt, string availableTools)
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
                    : Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory) ?? "", config.AiPlanningPromptFile);
            }
            else
            {
                // Use default system prompt
                promptFilePath = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory) ?? "", "system-prompts", "ai-planning-prompt.md");
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

    private string GetFallbackAiPlanningPrompt(string userPrompt, string availableTools)
    {
        return $@"
You are an AI assistant that helps users interact with MCP (Model Context Protocol) servers.

User's request: {userPrompt}

Available MCP tools: {availableTools}

CRITICAL INSTRUCTIONS:
1. You must analyze the user's request and create a COMPLETE execution plan
2. If the request involves multiple sequential steps, you must plan ALL of them
3. Each step that requires a tool call must follow the exact format shown below
4. Parameters must be formatted as: key1=value1, key2=value2, key3=value3
5. Use the exact tool names from the available tools list above
6. Pay special attention to DATE CONSTRAINTS - if the request mentions ""before"" a specific date, you MUST include that constraint
7. For sequential steps that depend on previous results, clearly indicate the dependency

EXECUTION PLAN:
1. [First action description]
   - Tool name: [exact tool name from available tools]
   - Parameters: [key1=value1, key2=value2, etc.]
   - Purpose: [why this tool call is needed]

2. [Second action description]
   - Tool name: [exact tool name from available tools]
   - Parameters: [key1=value1, key2=value2, etc.]
   - Purpose: [why this tool call is needed]

CRITICAL FORMAT REQUIREMENTS:
- Use EXACTLY this format: ""- Tool name: toolname"" (no bold, no markdown)
- Use EXACTLY this format: ""- Parameters: key1=value1, key2=value2""
- Use EXACTLY this format: ""- Purpose: description""
- Do NOT use **bold** formatting in the tool specification lines
- Do NOT use backticks around tool names

IMPORTANT DATE HANDLING:
- If looking for items ""before"" a completion date, use: beforeClosedDate=2025-07-01
- If looking for items ""after"" a completion date, use: afterClosedDate=2025-07-01
- If looking for items ""before"" a creation date, use: beforeCreatedDate=2025-07-01
- Always use ISO date format: YYYY-MM-DD
- For completion date filtering, use: get_pull_requests_by_closed_date
- For creation date filtering, use: get_pull_requests_by_creation_date
- Check available tools list for exact parameter names

Example for Azure DevOps workflow with date constraints:
EXECUTION PLAN:
1. Initialize Azure DevOps connection
   - Tool name: initialize_azure_dev_ops_client
   - Parameters: organizationUrl=https://dev.azure.com/dnceng
   - Purpose: Enable access to Azure DevOps APIs

2. Get latest production deployment before cutoff date
   - Tool name: get_pull_requests_by_closed_date
   - Parameters: projectName=internal, repositoryName=dotnet-helix-service, targetBranch=production, status=completed, beforeClosedDate=2025-07-01, maxCount=1
   - Purpose: Find the most recent production deployment that was completed before the cutoff date

3. Analyze recent main branch changes after production deployment
   - Tool name: get_pull_requests_by_closed_date
   - Parameters: projectName=internal, repositoryName=dotnet-helix-service, targetBranch=main, status=completed, afterClosedDate=RESULT_FROM_STEP_2_COMPLETION_DATE, maxCount=10
   - Purpose: Find all changes merged to main after the production deployment completion date

Create a complete plan that addresses the full user request. Make sure to include ALL necessary steps and handle date constraints properly.
";
    }
} 