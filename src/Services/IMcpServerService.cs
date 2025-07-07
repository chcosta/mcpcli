using McpCli.Models;

namespace McpCli.Services;

public interface IMcpServerService
{
    Task<McpServerInfo> StartServerAsync(string repositoryPath, int port = 3000, CancellationToken cancellationToken = default);
    Task<bool> StopServerAsync(McpServerInfo serverInfo, CancellationToken cancellationToken = default);
    Task<bool> IsServerRunningAsync(McpServerInfo serverInfo);
    Task<McpResponse> SendRequestAsync(McpServerInfo serverInfo, McpRequest request, CancellationToken cancellationToken = default);
    Task<string> SendPromptAsync(McpServerInfo serverInfo, string prompt, CancellationToken cancellationToken = default);
    Task<string> CallToolAsync(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, CancellationToken cancellationToken = default);
    Task<string> CallToolAsync(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, Dictionary<string, Dictionary<string, object>>? toolDefaults, CancellationToken cancellationToken = default);
    Task<IEnumerable<string>> GetAvailableToolsAsync(McpServerInfo serverInfo, CancellationToken cancellationToken = default);
    Task<McpServerInfo> DiscoverServerConfigurationAsync(string repositoryPath);
} 