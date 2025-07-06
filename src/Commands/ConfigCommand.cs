using System.CommandLine;
using Microsoft.Extensions.Logging;
using McpCli.Services;

namespace McpCli.Commands;

public class ConfigCommand
{
    private readonly ILogger<ConfigCommand> _logger;
    private readonly IConfigurationService _configurationService;

    public ConfigCommand(
        ILogger<ConfigCommand> logger,
        IConfigurationService configurationService)
    {
        _logger = logger;
        _configurationService = configurationService;
    }

    public Command CreateCommand()
    {
        var command = new Command("config", "Manage configuration settings");

        // Add subcommands
        command.AddCommand(CreateSetCommand());
        command.AddCommand(CreateGetCommand());
        command.AddCommand(CreateShowCommand());
        command.AddCommand(CreateInitCommand());

        return command;
    }

    private Command CreateSetCommand()
    {
        var keyOption = new Option<string>(
            name: "--key",
            description: "Configuration key to set")
        {
            IsRequired = true
        };

        var valueOption = new Option<string>(
            name: "--value",
            description: "Configuration value to set")
        {
            IsRequired = true
        };

        var command = new Command("set", "Set a configuration value")
        {
            keyOption,
            valueOption
        };

        command.SetHandler(async (key, value) =>
        {
            await SetConfigurationAsync(key, value);
        }, keyOption, valueOption);

        return command;
    }

    private Command CreateGetCommand()
    {
        var keyOption = new Option<string>(
            name: "--key",
            description: "Configuration key to get")
        {
            IsRequired = true
        };

        var command = new Command("get", "Get a configuration value")
        {
            keyOption
        };

        command.SetHandler(async (key) =>
        {
            await GetConfigurationAsync(key);
        }, keyOption);

        return command;
    }

    private Command CreateShowCommand()
    {
        var command = new Command("show", "Show all configuration settings");

        command.SetHandler(async () =>
        {
            await ShowConfigurationAsync();
        });

        return command;
    }

    private Command CreateInitCommand()
    {
        var command = new Command("init", "Initialize configuration with default values");

        command.SetHandler(async () =>
        {
            await InitializeConfigurationAsync();
        });

        return command;
    }

    private async Task SetConfigurationAsync(string key, string value)
    {
        try
        {
            await _configurationService.SetConfigurationValueAsync(key, value);
            Console.WriteLine($"Configuration '{key}' set successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting configuration");
            Console.WriteLine($"Error setting configuration: {ex.Message}");
        }
    }

    private async Task GetConfigurationAsync(string key)
    {
        try
        {
            var value = await _configurationService.GetConfigurationValueAsync<string>(key);
            Console.WriteLine($"{key}: {value}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting configuration");
            Console.WriteLine($"Error getting configuration: {ex.Message}");
        }
    }

    private async Task ShowConfigurationAsync()
    {
        try
        {
            var config = await _configurationService.LoadConfigurationAsync();
            var configPath = await _configurationService.GetConfigurationPathAsync();
            
            Console.WriteLine($"Configuration file: {configPath}");
            Console.WriteLine();
            Console.WriteLine("Azure AI Configuration:");
            Console.WriteLine($"  Endpoint: {MaskSensitiveValue(config.AzureAi.Endpoint)}");
            Console.WriteLine($"  API Key: {MaskSensitiveValue(config.AzureAi.ApiKey)}");
            Console.WriteLine($"  Deployment Name: {config.AzureAi.DeploymentName}");
            Console.WriteLine($"  Model Name: {config.AzureAi.ModelName}");
            Console.WriteLine($"  Use Managed Identity: {config.AzureAi.UseManagedIdentity}");
            Console.WriteLine();
            Console.WriteLine("Azure DevOps Configuration:");
            Console.WriteLine($"  Organization: {config.AzureDevOps.Organization}");
            Console.WriteLine($"  Personal Access Token: {MaskSensitiveValue(config.AzureDevOps.PersonalAccessToken)}");
            Console.WriteLine($"  Default Project: {config.AzureDevOps.DefaultProject}");
            Console.WriteLine($"  Use Managed Identity: {config.AzureDevOps.UseManagedIdentity}");
            Console.WriteLine();
            Console.WriteLine("MCP Configuration:");
            Console.WriteLine($"  Working Directory: {config.Mcp.WorkingDirectory}");
            Console.WriteLine($"  Default Port: {config.Mcp.DefaultPort}");
            Console.WriteLine($"  Timeout (seconds): {config.Mcp.TimeoutSeconds}");
            Console.WriteLine($"  Auto Cleanup: {config.Mcp.AutoCleanup}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error showing configuration");
            Console.WriteLine($"Error showing configuration: {ex.Message}");
        }
    }

    private async Task InitializeConfigurationAsync()
    {
        try
        {
            await _configurationService.InitializeDefaultConfigurationAsync();
            var configPath = await _configurationService.GetConfigurationPathAsync();
            Console.WriteLine($"Configuration initialized at: {configPath}");
            Console.WriteLine("Please edit the configuration file to add your credentials.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error initializing configuration");
            Console.WriteLine($"Error initializing configuration: {ex.Message}");
        }
    }

    private static string MaskSensitiveValue(string value)
    {
        if (string.IsNullOrEmpty(value))
            return "[not set]";
        
        if (value.Length <= 8)
            return "***";
        
        return value[..4] + "***" + value[^4..];
    }
} 