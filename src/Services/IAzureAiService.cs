using McpCli.Models;

namespace McpCli.Services;

public interface IAzureAiService
{
    Task<bool> TestConnectionAsync();
    Task<string> SendPromptAsync(string prompt, CancellationToken cancellationToken = default);
    Task<string> SendPromptWithToolsAsync(string prompt, IEnumerable<McpToolCall> tools, CancellationToken cancellationToken = default);
    void UpdateConfiguration(AzureAiConfig config);
} 