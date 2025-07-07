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
    private readonly IAiPlanningService? _aiPlanningService;
    private readonly IMultiMcpServerService _multiMcpServerService;

    public RunCommand(
        ILogger<RunCommand> logger,
        IMarkdownConfigService markdownConfigService,
        IConfigurationService configurationService,
        IGitService gitService,
        IMcpServerService mcpServerService,
        IAzureAiService azureAiService,
        IPromptFileService promptFileService,
        ISystemPromptService systemPromptService,
        IMultiMcpServerService multiMcpServerService,
        IAiPlanningService? aiPlanningService = null)
    {
        _logger = logger;
        _markdownConfigService = markdownConfigService;
        _configurationService = configurationService;
        _gitService = gitService;
        _mcpServerService = mcpServerService;
        _azureAiService = azureAiService;
        _promptFileService = promptFileService;
        _systemPromptService = systemPromptService;
        _multiMcpServerService = multiMcpServerService;
        _aiPlanningService = aiPlanningService;
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

        var previewFeaturesOption = new Option<bool>(
            name: "--preview-features",
            description: "Enable preview features like AI planning (overrides config setting)",
            getDefaultValue: () => false);

        var command = new Command("run", "Run MCP CLI using a Markdown configuration file")
        {
            configFileOption,
            promptOption,
            promptFileOption,
            listPromptsOption,
            promptIndexOption,
            workingDirOption,
            previewFeaturesOption
        };

        command.SetHandler(async (configFile, prompt, promptFile, listPrompts, promptIndex, workingDir, previewFeatures) =>
        {
            await ExecuteAsync(configFile, prompt, promptFile, listPrompts, promptIndex, workingDir, previewFeatures);
        }, configFileOption, promptOption, promptFileOption, listPromptsOption, promptIndexOption, workingDirOption, previewFeaturesOption);

        return command;
    }

    private async Task ExecuteAsync(string configFile, string? prompt, string? promptFile, bool listPrompts, int promptIndex, string workingDir, bool previewFeatures)
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
            await ExecuteWorkflowAsync(markdownConfig, selectedPrompt, workingDir, previewFeatures, configFile, promptFile);
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

    private async Task ExecuteWorkflowAsync(Models.MarkdownConfig markdownConfig, string prompt, string workingDir, bool previewFeaturesFlag, string configFile, string? promptFile)
    {
        var executionSummary = new Models.ExecutionSummary
        {
            AzureAiEndpoint = markdownConfig.AzureAi.Endpoint,
            AzureAiModel = markdownConfig.AzureAi.ModelName,
            PreviewFeaturesEnabled = previewFeaturesFlag || markdownConfig.PreviewFeatures
        };

        // Track files read during execution
        executionSummary.AddConfigurationFileRead(configFile);
        if (!string.IsNullOrEmpty(promptFile))
        {
            executionSummary.AddPromptFileRead(promptFile);
        }
        
        // Track AI planning prompt file if it exists
        if (!string.IsNullOrEmpty(markdownConfig.AiPlanningPromptFile))
        {
            executionSummary.AddOtherMarkdownFileRead(markdownConfig.AiPlanningPromptFile);
        }

        try
        {
            // Count enabled servers to determine execution mode
            var enabledServers = markdownConfig.Servers.Where(s => s.Enabled).ToList();
            
            if (enabledServers.Count == 0)
            {
                Console.WriteLine("❌ No enabled servers found in configuration.");
                Console.WriteLine("💡 Use 'mcpcli server list' to see available servers.");
                Console.WriteLine("💡 Use 'mcpcli server enable <server-name>' to enable a server.");
                return;
            }

            // Determine if preview features should be used
            bool usePreviewFeatures = previewFeaturesFlag || markdownConfig.PreviewFeatures;

            if (enabledServers.Count == 1)
            {
                // Single server mode - use existing logic for backward compatibility
                await ExecuteSingleServerWorkflowAsync(enabledServers[0], prompt, workingDir, usePreviewFeatures, markdownConfig, executionSummary);
            }
            else
            {
                // Multi-server mode - use new multi-server functionality
                await ExecuteMultiServerWorkflowAsync(enabledServers, prompt, workingDir, usePreviewFeatures, markdownConfig, executionSummary);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing workflow");
            throw;
        }
    }

    private async Task ExecuteSingleServerWorkflowAsync(MultiMcpServerConfig enabledServer, string prompt, string workingDir, bool usePreviewFeatures, MarkdownConfig markdownConfig, ExecutionSummary executionSummary)
    {
        // Ensure we have a git server for single-server mode
        if (enabledServer.Type != "git")
        {
            Console.WriteLine($"❌ Single server mode currently supports only git servers. Server '{enabledServer.Name}' is type '{enabledServer.Type}'.");
            Console.WriteLine("💡 For HTTP servers, enable multiple servers to use multi-server mode.");
            return;
        }

        Console.WriteLine($"🖥️ Using server: {enabledServer.Name} ({enabledServer.Type})");

        // Get repository name and local path
        var repoName = _gitService.GetRepositoryNameFromUrl(enabledServer.Url);
        var localPath = Path.Combine(workingDir, "servers", repoName);

        // Track repository and MCP server usage
        executionSummary.AddRepositoryCloned(enabledServer.Url);
        executionSummary.AddMcpServerUsed(enabledServer.Name);

        // Clone or update repository
        if (!await _gitService.IsRepositoryClonedAsync(localPath))
        {
            Console.WriteLine($"Cloning repository: {enabledServer.Url}");
            var progress = new Progress<string>(message => Console.WriteLine($"  {message}"));
            await _gitService.CloneRepositoryAsync(enabledServer.Url, localPath, progress);
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
        if (!string.IsNullOrEmpty(enabledServer.StartCommand))
        {
            serverInfo.StartCommand = enabledServer.StartCommand;
            if (!string.IsNullOrEmpty(enabledServer.StartArguments))
            {
                serverInfo.StartArguments = enabledServer.StartArguments.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
        
        serverInfo.Port = enabledServer.Port;
        serverInfo.Environment = enabledServer.Environment;

        if (enabledServer.AutoStart)
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
                Console.WriteLine($"Sending prompt: {prompt}");
                
                string finalResponse;
                if (usePreviewFeatures)
                {
                    Console.WriteLine("Using preview features (AI planning mode)");
                    executionSummary.ExecutionMode = "AI Planning Mode (Single Server)";
                    
                    if (_aiPlanningService != null)
                    {
                        Console.WriteLine("Using AI Planning Service");
                        finalResponse = await _aiPlanningService.ProcessPromptWithAIAsync(runningServer, prompt, markdownConfig, executionSummary);
                    }
                    else
                    {
                        Console.WriteLine("AI Planning Service not available, falling back to built-in AI planning");
                        finalResponse = await ProcessPromptWithAIAsync(runningServer, prompt, markdownConfig, executionSummary);
                    }
                }
                else
                {
                    Console.WriteLine("Using simple mode (direct tool execution)");
                    executionSummary.ExecutionMode = "Simple Mode (Direct Tool Execution)";
                    finalResponse = await ProcessPromptDirectlyAsync(runningServer, prompt, markdownConfig, executionSummary, enabledServer.ToolDefaults);
                }
                
                // Complete execution tracking
                executionSummary.CompleteExecution();
                
                FormatAndDisplayFinalResponse(finalResponse, executionSummary);
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

    private async Task ExecuteMultiServerWorkflowAsync(List<MultiMcpServerConfig> enabledServers, string prompt, string workingDir, bool usePreviewFeatures, MarkdownConfig markdownConfig, ExecutionSummary executionSummary)
    {
        Console.WriteLine($"🚀 Multi-Server Mode: Starting {enabledServers.Count} servers");
        
        // Start all enabled servers
        var runningServers = await _multiMcpServerService.StartServersAsync(markdownConfig, workingDir, executionSummary);
        
        var successfulServers = runningServers.Where(s => s.IsRunning).ToList();
        if (successfulServers.Count == 0)
        {
            Console.WriteLine("❌ Failed to start any servers.");
            return;
        }

        Console.WriteLine($"✅ Successfully started {successfulServers.Count} out of {enabledServers.Count} servers");
        foreach (var server in successfulServers)
        {
            Console.WriteLine($"   • {server.Name} ({server.Type}) on port {server.Port}");
        }

        try
        {
            // Discover tools across all servers
            Console.WriteLine("\n🔍 Discovering tools across all servers...");
            var serverToolMapping = await _multiMcpServerService.GetAvailableToolsAsync(successfulServers);
            
            Console.WriteLine($"📊 Found {serverToolMapping.AllTools.Count} tools across {successfulServers.Count} servers");
            
            if (serverToolMapping.ConflictingTools.Count > 0)
            {
                Console.WriteLine($"⚠️  Detected {serverToolMapping.ConflictingTools.Count} conflicting tools (available on multiple servers)");
            }

            Console.WriteLine($"Sending prompt: {prompt}");
            
            string finalResponse;
            if (usePreviewFeatures)
            {
                Console.WriteLine("Using preview features (Multi-Server AI Planning Mode)");
                executionSummary.ExecutionMode = "Multi-Server AI Planning Mode";
                
                if (_aiPlanningService != null)
                {
                    Console.WriteLine("Using Multi-Server AI Planning Service");
                    finalResponse = await _aiPlanningService.ProcessPromptWithMultiServerAIAsync(successfulServers, serverToolMapping, prompt, markdownConfig, executionSummary);
                }
                else
                {
                    Console.WriteLine("AI Planning Service not available, falling back to simple multi-server mode");
                    finalResponse = await ProcessMultiServerPromptDirectlyAsync(successfulServers, serverToolMapping, prompt, markdownConfig, executionSummary);
                }
            }
            else
            {
                Console.WriteLine("Using simple multi-server mode (direct tool execution)");
                executionSummary.ExecutionMode = "Multi-Server Simple Mode";
                finalResponse = await ProcessMultiServerPromptDirectlyAsync(successfulServers, serverToolMapping, prompt, markdownConfig, executionSummary);
            }
            
            // Complete execution tracking
            executionSummary.CompleteExecution();
            
            FormatAndDisplayFinalResponse(finalResponse, executionSummary);
        }
        finally
        {
            // Clean up - stop all servers
            Console.WriteLine("\n🛑 Stopping all servers...");
            await _multiMcpServerService.StopServersAsync(runningServers);
            Console.WriteLine("All servers stopped.");
        }
    }

    private async Task<string> ProcessMultiServerPromptDirectlyAsync(List<RunningServerInfo> runningServers, ServerToolMapping serverToolMapping, string userPrompt, MarkdownConfig config, ExecutionSummary executionSummary)
    {
        try
        {
            Console.WriteLine("Executing prompt directly across multiple servers...");
            
            // Build comprehensive tools list for AI prompt
            var toolsWithServerInfo = BuildToolListWithServerInfo(serverToolMapping);
            
            // Step 1: Use AI to understand the prompt and determine which tools to call
            var aiPrompt = $@"
User's request: {userPrompt}

Available tools across servers:
{toolsWithServerInfo}

Please analyze the user's request and determine which tools to call with what parameters to fulfill their request.

MULTI-SERVER RULES:
1. Tools are automatically routed to the correct server - you don't need to specify which server
2. Use tools from different servers as needed to accomplish the task
3. Tool defaults are configured per-server and applied automatically

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
If you need to call multiple tools, list them one per line.
";

            var aiResponse = await _azureAiService.SendPromptAsync(aiPrompt);
            
            // Step 2: Parse AI response and execute tools across multiple servers
            var toolResults = new List<string>();
            var lines = aiResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                
                // Skip empty lines and lines that look like instructions
                if (string.IsNullOrEmpty(trimmedLine) || 
                    trimmedLine.StartsWith("User's") || 
                    trimmedLine.StartsWith("Available") ||
                    trimmedLine.StartsWith("Examples:") ||
                    trimmedLine.StartsWith("To ") ||
                    trimmedLine.StartsWith("- To "))
                    continue;
                
                string toolName;
                string parametersText = "";
                
                if (trimmedLine.Contains(":"))
                {
                    var parts = trimmedLine.Split(':', 2);
                    toolName = parts[0].Trim();
                    parametersText = parts[1].Trim();
                }
                else
                {
                    toolName = trimmedLine;
                }
                
                // Clean up tool name
                toolName = toolName.TrimStart('-', '*', '•').Trim();
                
                if (IsInvalidToolName(toolName) || !serverToolMapping.AllTools.Contains(toolName))
                    continue;
                
                // Parse parameters
                var parameters = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(parametersText))
                {
                    parameters = ParseParameters(parametersText);
                }
                
                try
                {
                    Console.WriteLine($"Executing: {toolName}");
                    executionSummary.AddToolExecuted(toolName);
                    
                    var result = await _multiMcpServerService.CallToolAsync(toolName, parameters, runningServers, serverToolMapping, executionSummary);
                    toolResults.Add($"{toolName}: {result}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error executing tool {ToolName}", toolName);
                    toolResults.Add($"{toolName}: Error - {ex.Message}");
                }
            }
            
            // Step 3: If we executed tools, send results to AI for final processing
            if (toolResults.Count > 0)
            {
                var finalPrompt = $@"
User's original request: {userPrompt}

Tool execution results from multiple servers: {string.Join("\n", toolResults)}

Please provide a helpful, natural language response to the user based on these results.
Consolidate information from different servers where appropriate.
";
                return await _azureAiService.SendPromptAsync(finalPrompt);
            }
            else
            {
                // No tools were executed, return the AI's direct response
                return aiResponse;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing multi-server prompt directly");
            return $"Error processing request across multiple servers: {ex.Message}";
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

    private async Task<string> ProcessPromptWithAIAsync(McpServerInfo serverInfo, string userPrompt, Models.MarkdownConfig config, Models.ExecutionSummary executionSummary)
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
            var aiPlanningPrompt = await _aiPlanningService!.GetAiPlanningPromptAsync(config, userPrompt, availableTools);

            var aiResponse = await _azureAiService.SendPromptAsync(aiPlanningPrompt);
            
            // Step 3: Parse AI response and execute tools
            var toolResults = await _aiPlanningService!.ExecuteAIToolPlanAsync(serverInfo, aiResponse, config);
            
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

    private async Task<string> ProcessPromptDirectlyAsync(McpServerInfo serverInfo, string userPrompt, Models.MarkdownConfig config, Models.ExecutionSummary executionSummary, Dictionary<string, Dictionary<string, object>>? serverToolDefaults = null)
    {
        try
        {
            Console.WriteLine("Executing prompt directly with MCP server and AI...");
            
            // Step 1: Get available tools from MCP server
            var availableTools = await _mcpServerService.SendPromptAsync(serverInfo, userPrompt);
            
            if (availableTools.StartsWith("MCP server error"))
            {
                return availableTools;
            }
            
            // Step 2: Use AI to understand the prompt and determine which tools to call
            var aiPrompt = $@"
User's request: {userPrompt}

{availableTools}

Please analyze the user's request and determine which tools to call with what parameters to fulfill their request.

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
- To get pull requests: get_pull_requests_by_creation_date: projectName=MyProject,repositoryName=MyRepo

If you can answer the question without calling any tools, provide a direct answer.
If you need to call multiple tools, list them one per line.
";

            var aiResponse = await _azureAiService.SendPromptAsync(aiPrompt);
            
            // Step 3: Parse AI response and execute any tools mentioned
            var toolResults = new List<string>();
            var lines = aiResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                
                // Skip empty lines and lines that look like instructions
                if (string.IsNullOrEmpty(trimmedLine) || 
                    trimmedLine.StartsWith("User's") || 
                    trimmedLine.StartsWith("Available") ||
                    trimmedLine.StartsWith("Examples:") ||
                    trimmedLine.StartsWith("To ") ||
                    trimmedLine.StartsWith("- To "))
                    continue;
                
                string toolName;
                string parametersText = "";
                
                if (trimmedLine.Contains(":"))
                {
                    // Format: "toolname: param=value"
                    var parts = trimmedLine.Split(':', 2);
                    toolName = parts[0].Trim();
                    parametersText = parts[1].Trim();
                }
                else
                {
                    // Format: just "toolname"
                    toolName = trimmedLine;
                }
                
                // Clean up tool name (remove bullet points, dashes, etc.)
                toolName = toolName.TrimStart('-', '*', '•').Trim();
                
                // Validate tool name
                if (IsInvalidToolName(toolName) || string.IsNullOrWhiteSpace(toolName))
                {
                    _logger.LogWarning("Skipping invalid tool name: {ToolName}", toolName);
                    continue;
                }
                
                // Parse parameters
                var parameters = ParseParameters(parametersText);
                
                // Filter out placeholder parameters that would override tool defaults
                var filteredParameters = new Dictionary<string, object>();
                foreach (var param in parameters)
                {
                    var value = param.Value?.ToString() ?? "";
                    // Skip parameters with placeholder patterns
                    if (!IsPlaceholderValue(value))
                    {
                        filteredParameters[param.Key] = param.Value ?? "";
                    }
                    // Skip placeholder parameters silently
                }
                parameters = filteredParameters;
                
                // Execute tool
                Console.WriteLine($"Executing tool: {toolName}");
                // Use server-specific tool defaults if available, otherwise fall back to global ones
                var toolDefaults = serverToolDefaults ?? config.ToolDefaults;
                executionSummary.AddToolExecuted(toolName);
                var toolResult = await _mcpServerService.CallToolAsync(serverInfo, toolName, parameters, toolDefaults);
                
                // Check for tool errors and report them immediately
                if (toolResult.StartsWith("Tool error:") || toolResult.StartsWith("Error calling tool") || toolResult.Contains("error", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"❌ Tool {toolName} failed: {toolResult}");
                    return $"Tool execution failed: {toolResult}";
                }
                
                Console.WriteLine($"✅ Tool {toolName} succeeded");
                toolResults.Add($"{toolName}: {toolResult}");
            }
            
            // Step 4: If tools were executed, send results back to AI for final processing
            if (toolResults.Count > 0)
            {
                var finalPrompt = $@"
User's original request: {userPrompt}

Tool execution results:
{string.Join("\n", toolResults)}

Please provide a helpful, natural language response to the user based on these results.
";
                
                return await _azureAiService.SendPromptAsync(finalPrompt);
            }
            else
            {
                // No tools were executed, return the AI's direct response
                return aiResponse;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing prompt directly");
            return $"Error processing request: {ex.Message}";
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

    private bool IsPlaceholderValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var lowerValue = value.ToLower();
        
        // Check for common placeholder patterns
        if (value.Contains("<") && value.Contains(">"))
            return true;
            
        if (value.Contains("[") && value.Contains("]"))
            return true;
            
        if (value.Contains("{") && value.Contains("}"))
            return true;
        
        // Check for common placeholder keywords
        var placeholderKeywords = new[]
        {
            "your",
            "replace",
            "placeholder",
            "example",
            "sample",
            "todo",
            "tbd",
            "to be determined"
        };
        
        foreach (var keyword in placeholderKeywords)
        {
            if (lowerValue.Contains(keyword))
                return true;
        }
            
        return false;
    }

    private void RemoveSpecialParameters(Dictionary<string, object> parameters)
    {
        var specialKeys = parameters.Keys.Where(k => k.StartsWith("_")).ToList();
        foreach (var key in specialKeys)
        {
            parameters.Remove(key);
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

        private Dictionary<string, object> ParseParameters(string parametersText)
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
                
                // Simple cleanup: remove explanatory text in parentheses
                var parenIndex = value.IndexOf('(');
                if (parenIndex > 0)
                {
                    value = value.Substring(0, parenIndex).Trim();
                }
                
                parameters[key] = value;
            }
        }
        
        return parameters;
    }

    private void FormatAndDisplayFinalResponse(string response, Models.ExecutionSummary executionSummary)
    {
        // Display execution summary first
        DisplayExecutionSummary(executionSummary);
        
        // Then display the final response
        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("\n🔍 No response received.");
            return;
        }

        // Clean up the response
        var cleanedResponse = CleanResponse(response);
        
        // Display with nice formatting
        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("                            📋 RESULT                           ");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine();
        
        // Check if it's an error response
        if (IsErrorResponse(cleanedResponse))
        {
            Console.WriteLine("❌ Error:");
            Console.WriteLine(FormatErrorMessage(cleanedResponse));
        }
        else
        {
            // Format based on content type
            if (IsJsonResponse(cleanedResponse))
            {
                Console.WriteLine("📊 Data:");
                Console.WriteLine(FormatJsonResponse(cleanedResponse));
            }
            else if (IsMarkdownResponse(cleanedResponse))
            {
                Console.WriteLine("📝 Content:");
                Console.WriteLine(FormatMarkdownResponse(cleanedResponse));
            }
            else
            {
                Console.WriteLine("💬 Response:");
                Console.WriteLine(FormatTextResponse(cleanedResponse));
            }
        }
        
        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine();
    }

    private string CleanResponse(string response)
    {
        // Remove common unwanted patterns
        var cleaned = response.Trim();
        
        // Remove leading/trailing quotes if present
        if (cleaned.StartsWith("\"") && cleaned.EndsWith("\""))
        {
            cleaned = cleaned.Substring(1, cleaned.Length - 2);
        }
        
        // Decode common escape sequences
        cleaned = cleaned.Replace("\\n", "\n")
                        .Replace("\\t", "\t")
                        .Replace("\\\"", "\"")
                        .Replace("\\\\", "\\");
        
        return cleaned;
    }

    private bool IsErrorResponse(string response)
    {
        var lowerResponse = response.ToLower();
        return lowerResponse.Contains("error:") || 
               lowerResponse.Contains("exception:") || 
               lowerResponse.Contains("failed") ||
               lowerResponse.StartsWith("error ") ||
               lowerResponse.Contains("mcp server error");
    }

    private bool IsJsonResponse(string response)
    {
        var trimmed = response.Trim();
        return (trimmed.StartsWith("{") && trimmed.EndsWith("}")) ||
               (trimmed.StartsWith("[") && trimmed.EndsWith("]"));
    }

    private bool IsMarkdownResponse(string response)
    {
        return response.Contains("##") || 
               response.Contains("###") || 
               response.Contains("**") || 
               response.Contains("- ") ||
               response.Contains("```");
    }

    private string FormatErrorMessage(string errorResponse)
    {
        var lines = errorResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var formatted = new List<string>();
        
        foreach (var line in lines)
        {
            formatted.Add($"   {line.Trim()}");
        }
        
        return string.Join("\n", formatted);
    }

    private string FormatJsonResponse(string jsonResponse)
    {
        try
        {
            // Try to format JSON nicely
            var parsed = System.Text.Json.JsonDocument.Parse(jsonResponse);
            var formatted = System.Text.Json.JsonSerializer.Serialize(parsed, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });
            
            var lines = formatted.Split('\n');
            var indentedLines = lines.Select(line => $"   {line}");
            return string.Join("\n", indentedLines);
        }
        catch
        {
            // If JSON parsing fails, just indent the raw text
            var lines = jsonResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var formatted = lines.Select(line => $"   {line.Trim()}");
            return string.Join("\n", formatted);
        }
    }

    private string FormatMarkdownResponse(string markdownResponse)
    {
        var lines = markdownResponse.Split('\n');
        var formatted = new List<string>();
        
        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            
            if (trimmedLine.StartsWith("###"))
            {
                formatted.Add($"   🔸 {trimmedLine.Substring(3).Trim()}");
            }
            else if (trimmedLine.StartsWith("##"))
            {
                formatted.Add($"   📌 {trimmedLine.Substring(2).Trim()}");
            }
            else if (trimmedLine.StartsWith("#"))
            {
                formatted.Add($"   📍 {trimmedLine.Substring(1).Trim()}");
            }
            else if (trimmedLine.StartsWith("- "))
            {
                formatted.Add($"   • {trimmedLine.Substring(2).Trim()}");
            }
            else if (trimmedLine.StartsWith("* "))
            {
                formatted.Add($"   • {trimmedLine.Substring(2).Trim()}");
            }
            else if (trimmedLine.StartsWith("```"))
            {
                formatted.Add($"   {trimmedLine}");
            }
            else if (!string.IsNullOrWhiteSpace(trimmedLine))
            {
                formatted.Add($"   {trimmedLine}");
            }
            else
            {
                formatted.Add("");
            }
        }
        
        return string.Join("\n", formatted);
    }

    private string FormatTextResponse(string textResponse)
    {
        var lines = textResponse.Split('\n');
        var formatted = new List<string>();
        
        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (!string.IsNullOrWhiteSpace(trimmedLine))
            {
                // Word wrap long lines
                if (trimmedLine.Length > 80)
                {
                    var wrapped = WrapText(trimmedLine, 77); // 77 to account for 3-space indent
                    foreach (var wrappedLine in wrapped)
                    {
                        formatted.Add($"   {wrappedLine}");
                    }
                }
                else
                {
                    formatted.Add($"   {trimmedLine}");
                }
            }
            else
            {
                formatted.Add("");
            }
        }
        
        return string.Join("\n", formatted);
    }

    private List<string> WrapText(string text, int maxLength)
    {
        var result = new List<string>();
        var words = text.Split(' ');
        var currentLine = new List<string>();
        var currentLength = 0;
        
        foreach (var word in words)
        {
            if (currentLength + word.Length + 1 <= maxLength)
            {
                currentLine.Add(word);
                currentLength += word.Length + (currentLine.Count > 1 ? 1 : 0);
            }
            else
            {
                if (currentLine.Count > 0)
                {
                    result.Add(string.Join(" ", currentLine));
                    currentLine.Clear();
                }
                currentLine.Add(word);
                currentLength = word.Length;
            }
        }
        
        if (currentLine.Count > 0)
        {
            result.Add(string.Join(" ", currentLine));
        }
        
        return result;
    }

    private void DisplayExecutionSummary(Models.ExecutionSummary executionSummary)
    {
        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine("                      📊 EXECUTION SUMMARY");
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine();

        // Azure AI Information
        if (!string.IsNullOrEmpty(executionSummary.AzureAiEndpoint))
        {
            Console.WriteLine($"🔗 Azure AI Endpoint: {executionSummary.AzureAiEndpoint}");
        }
        if (!string.IsNullOrEmpty(executionSummary.AzureAiModel))
        {
            Console.WriteLine($"🤖 AI Model: {executionSummary.AzureAiModel}");
        }

        // Execution Mode
        if (!string.IsNullOrEmpty(executionSummary.ExecutionMode))
        {
            Console.WriteLine($"⚙️  Execution Mode: {executionSummary.ExecutionMode}");
        }

        Console.WriteLine($"🚀 Preview Features: {(executionSummary.PreviewFeaturesEnabled ? "Enabled" : "Disabled")}");

        // Repositories
        if (executionSummary.RepositoriesCloned.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("📁 Repositories Used:");
            foreach (var repo in executionSummary.RepositoriesCloned)
            {
                Console.WriteLine($"   • {repo}");
            }
        }

        // MCP Servers
        if (executionSummary.McpServersUsed.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("🔌 MCP Servers:");
            foreach (var server in executionSummary.McpServersUsed)
            {
                Console.WriteLine($"   • {server}");
            }
        }

        // Tools Executed
        if (executionSummary.ToolsExecuted.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("🔧 Tools Executed:");
            foreach (var tool in executionSummary.ToolsExecuted)
            {
                Console.WriteLine($"   • {tool}");
            }
        }

        // Server Performance Information (if available)
        if (executionSummary.ServerPerformance.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("⚡ Server Performance:");
            foreach (var (serverName, perf) in executionSummary.ServerPerformance)
            {
                var healthIcon = perf.IsHealthy ? "✅" : "❌";
                var startupIcon = perf.StartupSuccessful ? "🚀" : "💥";
                
                Console.WriteLine($"   {healthIcon} **{serverName}** {startupIcon}");
                
                if (perf.StartupTime > TimeSpan.Zero)
                {
                    Console.WriteLine($"      🕐 Startup: {perf.StartupTime.TotalMilliseconds:F0}ms");
                }
                
                if (perf.ToolsExecuted > 0)
                {
                    Console.WriteLine($"      🔧 Tools: {perf.ToolsExecuted} ({perf.SuccessfulToolExecutions} ✅, {perf.FailedToolExecutions} ❌)");
                    Console.WriteLine($"      📊 Success Rate: {perf.SuccessRate:F1}%");
                    Console.WriteLine($"      ⏱️  Avg Time: {perf.AverageToolExecutionTime.TotalMilliseconds:F0}ms");
                    
                    if (!string.IsNullOrEmpty(perf.FastestTool) && perf.FastestToolExecutionTime > TimeSpan.Zero)
                    {
                        Console.WriteLine($"      🏃 Fastest: {perf.FastestTool} ({perf.FastestToolExecutionTime.TotalMilliseconds:F0}ms)");
                    }
                    
                    if (!string.IsNullOrEmpty(perf.SlowestTool) && perf.SlowestToolExecutionTime > TimeSpan.Zero)
                    {
                        Console.WriteLine($"      🐌 Slowest: {perf.SlowestTool} ({perf.SlowestToolExecutionTime.TotalMilliseconds:F0}ms)");
                    }
                }
                
                if (perf.HealthChecks > 0)
                {
                    Console.WriteLine($"      💚 Health: {perf.HealthRate:F1}% ({perf.HealthyChecks}/{perf.HealthChecks})");
                    if (perf.LastResponseTime > TimeSpan.Zero)
                    {
                        Console.WriteLine($"      📡 Response: {perf.LastResponseTime.TotalMilliseconds:F0}ms");
                    }
                }
            }
        }

        // Execution Timing
        if (executionSummary.ExecutionEndTime.HasValue)
        {
            Console.WriteLine();
            Console.WriteLine($"⏱️  Total Execution Time: {executionSummary.TotalExecutionTime.TotalSeconds:F1}s");
        }

        // Tool Execution Details (if available)
        if (executionSummary.ToolExecutions.Count > 0 && executionSummary.ExecutionMode?.Contains("Multi-Server") == true)
        {
            Console.WriteLine();
            Console.WriteLine("🔍 Tool Execution Details:");
            
            var groupedByServer = executionSummary.ToolExecutions.GroupBy(t => t.ServerName);
            foreach (var serverGroup in groupedByServer)
            {
                Console.WriteLine($"   📡 {serverGroup.Key}:");
                foreach (var toolExec in serverGroup.OrderBy(t => t.Timestamp))
                {
                    var statusIcon = toolExec.Successful ? "✅" : "❌";
                    var timeInfo = $"{toolExec.ExecutionTime.TotalMilliseconds:F0}ms";
                    Console.WriteLine($"      {statusIcon} {toolExec.ToolName} ({timeInfo})");
                    
                    if (!toolExec.Successful && !string.IsNullOrEmpty(toolExec.Error))
                    {
                        Console.WriteLine($"         💬 {toolExec.Error}");
                    }
                }
            }
        }

        // Files Read
        var hasFiles = false;
        if (executionSummary.ConfigurationFilesRead.Count > 0)
        {
            if (!hasFiles)
            {
                Console.WriteLine();
                Console.WriteLine("📄 Files Read:");
                hasFiles = true;
            }
            Console.WriteLine("   Configuration Files:");
            foreach (var file in executionSummary.ConfigurationFilesRead)
            {
                Console.WriteLine($"     • {file}");
            }
        }

        if (executionSummary.PromptFilesRead.Count > 0)
        {
            if (!hasFiles)
            {
                Console.WriteLine();
                Console.WriteLine("📄 Files Read:");
                hasFiles = true;
            }
            Console.WriteLine("   Prompt Files:");
            foreach (var file in executionSummary.PromptFilesRead)
            {
                Console.WriteLine($"     • {file}");
            }
        }

        if (executionSummary.OtherMarkdownFilesRead.Count > 0)
        {
            if (!hasFiles)
            {
                Console.WriteLine();
                Console.WriteLine("📄 Files Read:");
                hasFiles = true;
            }
            Console.WriteLine("   Other Markdown Files:");
            foreach (var file in executionSummary.OtherMarkdownFilesRead)
            {
                Console.WriteLine($"     • {file}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine();
    }
}