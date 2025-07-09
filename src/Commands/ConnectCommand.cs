using System.CommandLine;
using Microsoft.Extensions.Logging;
using McpCli.Services;

namespace McpCli.Commands;

public class ConnectCommand
{
    private readonly ILogger<ConnectCommand> _logger;
    private readonly IGitService _gitService;
    private readonly IMcpServerService _mcpServerService;
    private readonly IAzureAiService _azureAiService;
    private readonly IConfigurationService _configurationService;
    private readonly IRepositoryRootService _repositoryRootService;

    public ConnectCommand(
        ILogger<ConnectCommand> logger,
        IGitService gitService,
        IMcpServerService mcpServerService,
        IAzureAiService azureAiService,
        IConfigurationService configurationService,
        IRepositoryRootService repositoryRootService)
    {
        _logger = logger;
        _gitService = gitService;
        _mcpServerService = mcpServerService;
        _azureAiService = azureAiService;
        _configurationService = configurationService;
        _repositoryRootService = repositoryRootService;
    }

    public Command CreateCommand()
    {
        var repositoryOption = new Option<string>(
            name: "--repository",
            description: "Azure DevOps Git repository URL containing the MCP server")
        {
            IsRequired = true
        };
        repositoryOption.AddAlias("-r");

        var promptOption = new Option<string>(
            name: "--prompt",
            description: "The prompt to send to the MCP server")
        {
            IsRequired = true
        };
        promptOption.AddAlias("-p");

        var portOption = new Option<int>(
            name: "--port",
            description: "Port to run the MCP server on (default: 3000)",
            getDefaultValue: () => 3000);

        var workingDirOption = new Option<string>(
            name: "--working-dir",
            description: "Working directory for cloned repositories (default: ./mcp-servers)",
            getDefaultValue: () => "./mcp-servers");

        var forceCloneOption = new Option<bool>(
            name: "--force-clone",
            description: "Force re-clone the repository even if it already exists",
            getDefaultValue: () => false);

        var command = new Command("connect", "Clone an MCP server repository and send a prompt")
        {
            repositoryOption,
            promptOption,
            portOption,
            workingDirOption,
            forceCloneOption
        };

        command.SetHandler(async (repository, prompt, port, workingDir, forceClone) =>
        {
            await ExecuteAsync(repository, prompt, port, workingDir, forceClone);
        }, repositoryOption, promptOption, portOption, workingDirOption, forceCloneOption);

        return command;
    }

    private async Task ExecuteAsync(string repository, string prompt, int port, string workingDir, bool forceClone)
    {
        try
        {
            _logger.LogInformation("Starting MCP CLI connection process...");

            // Load configuration
            var config = await _configurationService.LoadConfigurationAsync();
            
            // Validate configuration
            if (!await _configurationService.IsConfigurationValidAsync())
            {
                Console.WriteLine("Configuration is invalid. Please run 'mcpcli config' to set up your credentials.");
                return;
            }

            // Set up Git service with Azure DevOps credentials
            if (config.AzureDevOps.UseManagedIdentity)
            {
                _gitService.SetAzureDevOpsCredentials(config.AzureDevOps.Organization, true);
            }
            else
            {
                _gitService.SetAzureDevOpsCredentials(config.AzureDevOps.Organization, config.AzureDevOps.PersonalAccessToken);
            }

            // Resolve working directory relative to repository root
            var resolvedWorkingDir = _repositoryRootService.IsRelativePath(workingDir) 
                ? _repositoryRootService.ResolvePath(workingDir) 
                : workingDir;

            // Get repository name and local path
            var repoName = _gitService.GetRepositoryNameFromUrl(repository);
            var localPath = Path.Combine(resolvedWorkingDir, repoName);

            // Clone or update repository
            if (forceClone || !await _gitService.IsRepositoryClonedAsync(localPath))
            {
                Console.WriteLine($"Cloning repository: {repository}");
                var progress = new Progress<string>(message => Console.WriteLine($"  {message}"));
                await _gitService.CloneRepositoryAsync(repository, localPath, progress);
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
            serverInfo.Port = port;

            Console.WriteLine($"Starting MCP server on port {port}...");
            var runningServer = await _mcpServerService.StartServerAsync(localPath, port);
            
            if (!runningServer.IsRunning)
            {
                Console.WriteLine("Failed to start MCP server.");
                return;
            }

            Console.WriteLine("MCP server started successfully.");

            try
            {
                // Send prompt to MCP server
                Console.WriteLine($"Sending prompt: {prompt}");
                var response = await _mcpServerService.SendPromptAsync(runningServer, prompt);
                
                Console.WriteLine("\n--- MCP Server Response ---");
                Console.WriteLine(response);
                Console.WriteLine("--- End Response ---\n");

                // Optionally send to Azure AI for further processing
                if (!string.IsNullOrEmpty(config.AzureAi.Endpoint))
                {
                    Console.WriteLine("Processing response with Azure AI...");
                    var aiResponse = await _azureAiService.SendPromptAsync($"Process this MCP server response: {response}");
                    Console.WriteLine("\n--- Azure AI Response ---");
                    Console.WriteLine(aiResponse);
                    Console.WriteLine("--- End AI Response ---");
                }
            }
            finally
            {
                // Clean up - stop the server
                Console.WriteLine("Stopping MCP server...");
                await _mcpServerService.StopServerAsync(runningServer);
                Console.WriteLine("MCP server stopped.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during connect operation");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
} 