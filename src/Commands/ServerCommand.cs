using System.CommandLine;
using Microsoft.Extensions.Logging;
using McpCli.Services;
using McpCli.Models;

namespace McpCli.Commands;

public class ServerCommand
{
    private readonly ILogger<ServerCommand> _logger;
    private readonly IMarkdownConfigService _markdownConfigService;
    private readonly IMultiMcpServerService _multiMcpServerService;

    public ServerCommand(
        ILogger<ServerCommand> logger,
        IMarkdownConfigService markdownConfigService,
        IMultiMcpServerService multiMcpServerService)
    {
        _logger = logger;
        _markdownConfigService = markdownConfigService;
        _multiMcpServerService = multiMcpServerService;
    }

    public Command CreateCommand()
    {
        var serverCommand = new Command("server", "Manage MCP servers");

        // Add subcommands
        serverCommand.AddCommand(CreateListCommand());
        serverCommand.AddCommand(CreateEnableCommand());
        serverCommand.AddCommand(CreateDisableCommand());
        serverCommand.AddCommand(CreateStatusCommand());

        return serverCommand;
    }

    private Command CreateListCommand()
    {
        var listCommand = new Command("list", "List all configured servers");

        var configOption = new Option<string>(
            aliases: ["--config", "-c"],
            description: "Path to the markdown configuration file")
        {
            IsRequired = false
        };
        listCommand.AddOption(configOption);

        listCommand.SetHandler(async (string? configPath) =>
        {
            try
            {
                configPath ??= "configs/ai-releasenotes.md"; // Default config
                
                if (!File.Exists(configPath))
                {
                    Console.WriteLine($"❌ Configuration file not found: {configPath}");
                    return;
                }

                var config = await _markdownConfigService.ParseMarkdownConfigAsync(configPath);
                
                Console.WriteLine($"📋 **Server Configuration ({config.Servers.Count} servers)**\n");

                if (config.Servers.Count == 0)
                {
                    Console.WriteLine("No servers configured.");
                    return;
                }

                foreach (var server in config.Servers)
                {
                    var enabledIcon = server.Enabled ? "✅" : "❌";
                    var autoStartIcon = server.AutoStart ? "🚀" : "⏸️";
                    
                    Console.WriteLine($"{enabledIcon} **{server.Name}** ({server.Type})");
                    Console.WriteLine($"   📡 URL: {server.Url}");
                    Console.WriteLine($"   🔌 Port: {server.Port}");
                    Console.WriteLine($"   {autoStartIcon} Auto-start: {server.AutoStart}");
                    
                    if (!string.IsNullOrEmpty(server.Description))
                    {
                        Console.WriteLine($"   📝 Description: {server.Description}");
                    }
                    
                    if (server.Tags.Count > 0)
                    {
                        Console.WriteLine($"   🏷️  Tags: {string.Join(", ", server.Tags)}");
                    }
                    
                    if (server.ToolDefaults.Count > 0)
                    {
                        Console.WriteLine($"   🔧 Tool defaults: {server.ToolDefaults.Count} tools configured");
                    }
                    
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error listing servers");
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }, configOption);

        return listCommand;
    }

    private Command CreateEnableCommand()
    {
        var enableCommand = new Command("enable", "Enable a server");

        var serverNameArgument = new Argument<string>("server-name", "Name of the server to enable");
        enableCommand.AddArgument(serverNameArgument);

        var configOption = new Option<string>(
            aliases: ["--config", "-c"],
            description: "Path to the markdown configuration file")
        {
            IsRequired = false
        };
        enableCommand.AddOption(configOption);

        enableCommand.SetHandler(async (string serverName, string? configPath) =>
        {
            try
            {
                configPath ??= "configs/ai-releasenotes.md"; // Default config
                
                if (!File.Exists(configPath))
                {
                    Console.WriteLine($"❌ Configuration file not found: {configPath}");
                    return;
                }

                var config = await _markdownConfigService.ParseMarkdownConfigAsync(configPath);
                var updatedConfig = await _multiMcpServerService.EnableServerAsync(serverName, config);
                
                // Save the updated configuration
                await _markdownConfigService.SaveMarkdownConfigAsync(updatedConfig, configPath);
                
                Console.WriteLine($"✅ Server '{serverName}' has been enabled");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error enabling server {ServerName}", serverName);
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }, serverNameArgument, configOption);

        return enableCommand;
    }

    private Command CreateDisableCommand()
    {
        var disableCommand = new Command("disable", "Disable a server");

        var serverNameArgument = new Argument<string>("server-name", "Name of the server to disable");
        disableCommand.AddArgument(serverNameArgument);

        var configOption = new Option<string>(
            aliases: ["--config", "-c"],
            description: "Path to the markdown configuration file")
        {
            IsRequired = false
        };
        disableCommand.AddOption(configOption);

        disableCommand.SetHandler(async (string serverName, string? configPath) =>
        {
            try
            {
                configPath ??= "configs/ai-releasenotes.md"; // Default config
                
                if (!File.Exists(configPath))
                {
                    Console.WriteLine($"❌ Configuration file not found: {configPath}");
                    return;
                }

                var config = await _markdownConfigService.ParseMarkdownConfigAsync(configPath);
                var updatedConfig = await _multiMcpServerService.DisableServerAsync(serverName, config);
                
                // Save the updated configuration
                await _markdownConfigService.SaveMarkdownConfigAsync(updatedConfig, configPath);
                
                Console.WriteLine($"❌ Server '{serverName}' has been disabled");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error disabling server {ServerName}", serverName);
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }, serverNameArgument, configOption);

        return disableCommand;
    }

    private Command CreateStatusCommand()
    {
        var statusCommand = new Command("status", "Check the status of all servers");

        var configOption = new Option<string>(
            aliases: ["--config", "-c"],
            description: "Path to the markdown configuration file")
        {
            IsRequired = false
        };
        statusCommand.AddOption(configOption);

        statusCommand.SetHandler(async (string? configPath) =>
        {
            try
            {
                configPath ??= "configs/ai-releasenotes.md"; // Default config
                
                if (!File.Exists(configPath))
                {
                    Console.WriteLine($"❌ Configuration file not found: {configPath}");
                    return;
                }

                var config = await _markdownConfigService.ParseMarkdownConfigAsync(configPath);
                var statuses = await _multiMcpServerService.GetServerStatusAsync(config);
                
                Console.WriteLine($"🖥️  **Server Status Report ({statuses.Count} servers)**\n");

                if (statuses.Count == 0)
                {
                    Console.WriteLine("No servers configured.");
                    return;
                }

                foreach (var status in statuses)
                {
                    var enabledIcon = status.Enabled ? "✅" : "❌";
                    var runningIcon = status.IsRunning ? "🟢" : "🔴";
                    
                    Console.WriteLine($"{enabledIcon} **{status.Name}** ({status.Type})");
                    Console.WriteLine($"   📡 URL: {status.Url}");
                    Console.WriteLine($"   🔌 Port: {status.Port}");
                    Console.WriteLine($"   {runningIcon} Running: {status.IsRunning}");
                    Console.WriteLine($"   📊 Enabled: {status.Enabled}");
                    
                    if (!string.IsNullOrEmpty(status.Description))
                    {
                        Console.WriteLine($"   📝 Description: {status.Description}");
                    }
                    
                    if (status.Tags.Count > 0)
                    {
                        Console.WriteLine($"   🏷️  Tags: {string.Join(", ", status.Tags)}");
                    }
                    
                    if (status.LastStarted.HasValue)
                    {
                        Console.WriteLine($"   🕐 Last started: {status.LastStarted:yyyy-MM-dd HH:mm:ss}");
                    }
                    
                    if (!string.IsNullOrEmpty(status.Error))
                    {
                        Console.WriteLine($"   ⚠️  Error: {status.Error}");
                    }
                    
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking server status");
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }, configOption);

        return statusCommand;
    }
} 