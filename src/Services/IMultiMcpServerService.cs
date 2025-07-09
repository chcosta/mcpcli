using McpCli.Models;

namespace McpCli.Services;

public interface IMultiMcpServerService
{
    /// <summary>
    /// Starts all configured servers based on the markdown configuration
    /// </summary>
    /// <param name="config">Configuration containing server definitions</param>
    /// <param name="workingDir">Working directory for git-based servers</param>
    /// <param name="executionSummary">Execution summary for performance tracking</param>
    /// <returns>List of running server information</returns>
    Task<List<RunningServerInfo>> StartServersAsync(MarkdownConfig config, string workingDir, ExecutionSummary? executionSummary = null);

    /// <summary>
    /// Stops all running servers
    /// </summary>
    /// <param name="runningServers">List of servers to stop</param>
    Task StopServersAsync(List<RunningServerInfo> runningServers);

    /// <summary>
    /// Gets available tools from all running servers
    /// </summary>
    /// <param name="runningServers">List of running servers</param>
    /// <returns>Consolidated list of available tools with server mapping</returns>
    Task<ServerToolMapping> GetAvailableToolsAsync(List<RunningServerInfo> runningServers);
    Task<Dictionary<string, object>> GetToolSchemasAsync(RunningServerInfo serverInfo);
    /// <summary>
    /// Calls a tool on the appropriate server
    /// </summary>
    /// <param name="toolName">Name of the tool to call</param>
    /// <param name="parameters">Tool parameters</param>
    /// <param name="runningServers">List of running servers</param>
    /// <param name="toolMapping">Mapping of tools to servers</param>
    /// <param name="executionSummary">Execution summary for performance tracking</param>
    /// <returns>Tool execution result</returns>
    Task<string> CallToolAsync(string toolName, Dictionary<string, object> parameters, 
        List<RunningServerInfo> runningServers, ServerToolMapping toolMapping, ExecutionSummary? executionSummary = null);

    /// <summary>
    /// Gets the health status of all servers
    /// </summary>
    /// <param name="runningServers">List of running servers</param>
    /// <param name="executionSummary">Execution summary for performance tracking</param>
    /// <returns>Health status for each server</returns>
    Task<Dictionary<string, ServerHealth>> GetServerHealthAsync(List<RunningServerInfo> runningServers, ExecutionSummary? executionSummary = null);

    /// <summary>
    /// Gets consolidated prompt response from all servers
    /// </summary>
    /// <param name="prompt">The prompt to send</param>
    /// <param name="runningServers">List of running servers</param>
    /// <returns>Consolidated prompt response</returns>
    Task<string> SendPromptAsync(string prompt, List<RunningServerInfo> runningServers);

    /// <summary>
    /// Enables a server by name
    /// </summary>
    /// <param name="serverName">Name of the server to enable</param>
    /// <param name="config">Current configuration</param>
    /// <returns>Updated configuration</returns>
    Task<MarkdownConfig> EnableServerAsync(string serverName, MarkdownConfig config);

    /// <summary>
    /// Disables a server by name
    /// </summary>
    /// <param name="serverName">Name of the server to disable</param>
    /// <param name="config">Current configuration</param>
    /// <returns>Updated configuration</returns>
    Task<MarkdownConfig> DisableServerAsync(string serverName, MarkdownConfig config);

    /// <summary>
    /// Gets a list of all servers with their enabled/disabled status
    /// </summary>
    /// <param name="config">Current configuration</param>
    /// <returns>List of servers with status information</returns>
    Task<List<ServerStatus>> GetServerStatusAsync(MarkdownConfig config);
}

public class RunningServerInfo
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "git" or "http"
    public string Url { get; set; } = string.Empty;
    public int Port { get; set; }
    public bool IsRunning { get; set; }
    public int? ProcessId { get; set; } // For git-based servers
    public string? LocalPath { get; set; } // For git-based servers
    public Dictionary<string, string> Headers { get; set; } = new(); // For HTTP servers
    public string? AuthToken { get; set; } // For HTTP servers
    public DateTime StartTime { get; set; }
    public string? Error { get; set; }
    public List<string> Tags { get; set; } = new();
    public Dictionary<string, Dictionary<string, object>> ToolDefaults { get; set; } = new();
}

public class ServerToolMapping
{
    public Dictionary<string, string> ToolToServer { get; set; } = new(); // tool name -> server name
    public Dictionary<string, List<string>> ServerToTools { get; set; } = new(); // server name -> tool names
    public List<string> AllTools { get; set; } = new();
    public Dictionary<string, string> ToolDescriptions { get; set; } = new(); // tool name -> description
    public Dictionary<string, List<string>> ConflictingTools { get; set; } = new(); // tool name -> server names
}

public class ServerHealth
{
    public string ServerName { get; set; } = string.Empty;
    public bool IsHealthy { get; set; }
    public string Status { get; set; } = string.Empty;
    public TimeSpan ResponseTime { get; set; }
    public string? Error { get; set; }
    public DateTime LastChecked { get; set; }
    public Dictionary<string, object> Metadata { get; set; } = new();
}

public class ServerStatus
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public bool Enabled { get; set; }
    public bool IsRunning { get; set; }
    public string? Description { get; set; }
    public List<string> Tags { get; set; } = new();
    public int Port { get; set; }
    public DateTime? LastStarted { get; set; }
    public string? Error { get; set; }
} 