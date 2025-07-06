using System.CommandLine;
using Microsoft.Extensions.Logging;
using McpCli.Services;

namespace McpCli.Commands;

public class StopCommand
{
    private readonly ILogger<StopCommand> _logger;
    private readonly IMcpServerService _mcpServerService;

    public StopCommand(
        ILogger<StopCommand> logger,
        IMcpServerService mcpServerService)
    {
        _logger = logger;
        _mcpServerService = mcpServerService;
    }

    public Command CreateCommand()
    {
        var serverIdOption = new Option<string>(
            name: "--server-id",
            description: "ID of the MCP server to stop");

        var allOption = new Option<bool>(
            name: "--all",
            description: "Stop all running MCP servers",
            getDefaultValue: () => false);

        var command = new Command("stop", "Stop running MCP servers")
        {
            serverIdOption,
            allOption
        };

        command.SetHandler(async (serverId, all) =>
        {
            await ExecuteAsync(serverId, all);
        }, serverIdOption, allOption);

        return command;
    }

    private async Task ExecuteAsync(string? serverId, bool all)
    {
        try
        {
            if (all)
            {
                Console.WriteLine("Stopping all MCP servers...");
                Console.WriteLine("Note: This is a placeholder - full implementation requires server tracking.");
                Console.WriteLine("All servers would be stopped here.");
            }
            else if (!string.IsNullOrEmpty(serverId))
            {
                Console.WriteLine($"Stopping MCP server: {serverId}");
                Console.WriteLine("Note: This is a placeholder - full implementation requires server tracking.");
                Console.WriteLine($"Server {serverId} would be stopped here.");
            }
            else
            {
                Console.WriteLine("Please specify --server-id or --all option.");
                Console.WriteLine("Use 'mcpcli list' to see running servers.");
            }
            
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error stopping MCP servers");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
} 