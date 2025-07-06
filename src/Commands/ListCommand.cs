using System.CommandLine;
using Microsoft.Extensions.Logging;
using McpCli.Services;

namespace McpCli.Commands;

public class ListCommand
{
    private readonly ILogger<ListCommand> _logger;
    private readonly IMcpServerService _mcpServerService;

    public ListCommand(
        ILogger<ListCommand> logger,
        IMcpServerService mcpServerService)
    {
        _logger = logger;
        _mcpServerService = mcpServerService;
    }

    public Command CreateCommand()
    {
        var command = new Command("list", "List running MCP servers");

        command.SetHandler(async () =>
        {
            await ExecuteAsync();
        });

        return command;
    }

    private async Task ExecuteAsync()
    {
        try
        {
            Console.WriteLine("Listing MCP servers...");
            Console.WriteLine("Note: This is a placeholder - full implementation requires server tracking.");
            
            // TODO: Implement server tracking and listing
            // This would require maintaining a registry of running servers
            // For now, we'll show a placeholder message
            
            Console.WriteLine("No running servers found.");
            Console.WriteLine("Use 'mcpcli connect' to start a new MCP server session.");
            
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error listing MCP servers");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
} 