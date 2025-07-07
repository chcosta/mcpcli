using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class MultiMcpServerService : IMultiMcpServerService
{
    private readonly ILogger<MultiMcpServerService> _logger;
    private readonly HttpClient _httpClient;
    private readonly IGitService _gitService;
    private readonly IMcpServerService _mcpServerService;
    private readonly Dictionary<string, Process> _runningProcesses = new();
    private readonly Dictionary<string, HttpClient> _httpClients = new();
    private readonly Dictionary<string, DateTime> _lastHealthCheck = new();

    public MultiMcpServerService(
        ILogger<MultiMcpServerService> logger,
        HttpClient httpClient,
        IGitService gitService,
        IMcpServerService mcpServerService)
    {
        _logger = logger;
        _httpClient = httpClient;
        _gitService = gitService;
        _mcpServerService = mcpServerService;
    }

    public async Task<List<RunningServerInfo>> StartServersAsync(MarkdownConfig config, string workingDir, ExecutionSummary? executionSummary = null)
    {
        var runningServers = new List<RunningServerInfo>();
        var portManager = new PortManager(_logger);

        _logger.LogInformation("Starting {ServerCount} configured servers", config.Servers.Count);

        foreach (var serverConfig in config.Servers)
        {
            if (!serverConfig.Enabled)
            {
                _logger.LogInformation("Skipping disabled server: {ServerName}", serverConfig.Name);
                continue;
            }

            var startTime = DateTime.UtcNow;
            var runningServer = await StartIndividualServerAsync(serverConfig, workingDir, portManager);
            var startupTime = DateTime.UtcNow - startTime;
            
            // Track server startup performance
            executionSummary?.TrackServerStartup(serverConfig.Name, startupTime, runningServer.IsRunning);
            
            runningServers.Add(runningServer);
        }

        _logger.LogInformation("Started {RunningCount} out of {ConfiguredCount} servers", 
            runningServers.Count(s => s.IsRunning), config.Servers.Count);

        return runningServers;
    }

    public async Task StopServersAsync(List<RunningServerInfo> runningServers)
    {
        _logger.LogInformation("Stopping {ServerCount} servers", runningServers.Count);

        var stopTasks = runningServers.Select(async server =>
        {
            try
            {
                await StopIndividualServerAsync(server);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error stopping server {ServerName}", server.Name);
            }
        });

        await Task.WhenAll(stopTasks);

        // Clean up HTTP clients
        foreach (var client in _httpClients.Values)
        {
            client.Dispose();
        }
        _httpClients.Clear();

        _logger.LogInformation("All servers stopped");
    }

    public async Task<ServerToolMapping> GetAvailableToolsAsync(List<RunningServerInfo> runningServers)
    {
        var mapping = new ServerToolMapping();
        
        var toolDiscoveryTasks = runningServers
            .Where(s => s.IsRunning)
            .Select(async server =>
            {
                try
                {
                    var tools = await GetServerToolsAsync(server);
                    return new { Server = server, Tools = tools };
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error getting tools from server {ServerName}", server.Name);
                    return new { Server = server, Tools = new List<string>() };
                }
            });

        var results = await Task.WhenAll(toolDiscoveryTasks);

        foreach (var result in results)
        {
            mapping.ServerToTools[result.Server.Name] = result.Tools.ToList();
            
            foreach (var tool in result.Tools)
            {
                mapping.AllTools.Add(tool);
                
                // Handle tool conflicts
                if (mapping.ToolToServer.ContainsKey(tool))
                {
                    // Tool exists on multiple servers - track conflict
                    if (!mapping.ConflictingTools.ContainsKey(tool))
                    {
                        mapping.ConflictingTools[tool] = new List<string> { mapping.ToolToServer[tool] };
                    }
                    mapping.ConflictingTools[tool].Add(result.Server.Name);
                    
                    _logger.LogWarning("Tool conflict detected: {ToolName} exists on servers {Servers}", 
                        tool, string.Join(", ", mapping.ConflictingTools[tool]));
                }
                else
                {
                    mapping.ToolToServer[tool] = result.Server.Name;
                }
            }
        }

        _logger.LogInformation("Discovered {ToolCount} tools across {ServerCount} servers", 
            mapping.AllTools.Count, runningServers.Count);

        return mapping;
    }

    public async Task<string> CallToolAsync(string toolName, Dictionary<string, object> parameters, 
        List<RunningServerInfo> runningServers, ServerToolMapping toolMapping, ExecutionSummary? executionSummary = null)
    {
        if (!toolMapping.ToolToServer.TryGetValue(toolName, out var serverName))
        {
            throw new InvalidOperationException($"Tool '{toolName}' not found on any server");
        }

        var server = runningServers.FirstOrDefault(s => s.Name == serverName);
        if (server == null)
        {
            throw new InvalidOperationException($"Server '{serverName}' not found");
        }

        if (!server.IsRunning)
        {
            throw new InvalidOperationException($"Server '{serverName}' is not running");
        }

        // Merge server-specific tool defaults
        var mergedParameters = MergeToolDefaults(toolName, parameters, server.ToolDefaults);

        _logger.LogInformation("Calling tool {ToolName} on server {ServerName}", toolName, serverName);

        var executionStart = DateTime.UtcNow;
        bool successful = false;
        string? error = null;
        
        try
        {
            var result = await CallToolOnServerAsync(server, toolName, mergedParameters);
            successful = true;
            return result;
        }
        catch (Exception ex)
        {
            successful = false;
            error = ex.Message;
            _logger.LogError(ex, "Error calling tool {ToolName} on server {ServerName}", toolName, serverName);
            throw;
        }
        finally
        {
            var executionTime = DateTime.UtcNow - executionStart;
            // Track tool execution performance
            executionSummary?.TrackToolExecution(toolName, serverName, executionTime, successful, error);
        }
    }

    public async Task<Dictionary<string, ServerHealth>> GetServerHealthAsync(List<RunningServerInfo> runningServers, ExecutionSummary? executionSummary = null)
    {
        var healthResults = new Dictionary<string, ServerHealth>();
        
        var healthTasks = runningServers.Select(async server =>
        {
            var health = await CheckServerHealthAsync(server);
            
            // Track server health performance
            executionSummary?.TrackServerHealth(server.Name, health.IsHealthy, health.ResponseTime);
            
            return new { Server = server, Health = health };
        });

        var results = await Task.WhenAll(healthTasks);

        foreach (var result in results)
        {
            healthResults[result.Server.Name] = result.Health;
        }

        return healthResults;
    }

    public async Task<string> SendPromptAsync(string prompt, List<RunningServerInfo> runningServers)
    {
        var responses = new List<string>();
        
        var promptTasks = runningServers
            .Where(s => s.IsRunning)
            .Select(async server =>
            {
                try
                {
                    var response = await SendPromptToServerAsync(server, prompt);
                    return new { Server = server, Response = response };
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending prompt to server {ServerName}", server.Name);
                    return new { Server = server, Response = $"Error: {ex.Message}" };
                }
            });

        var results = await Task.WhenAll(promptTasks);

        foreach (var result in results)
        {
            responses.Add($"[{result.Server.Name}] {result.Response}");
        }

        return string.Join("\n\n", responses);
    }

    public async Task<MarkdownConfig> EnableServerAsync(string serverName, MarkdownConfig config)
    {
        var server = config.Servers.FirstOrDefault(s => s.Name == serverName);
        if (server == null)
        {
            throw new ArgumentException($"Server '{serverName}' not found in configuration");
        }

        server.Enabled = true;
        _logger.LogInformation("Enabled server: {ServerName}", serverName);

        return await Task.FromResult(config);
    }

    public async Task<MarkdownConfig> DisableServerAsync(string serverName, MarkdownConfig config)
    {
        var server = config.Servers.FirstOrDefault(s => s.Name == serverName);
        if (server == null)
        {
            throw new ArgumentException($"Server '{serverName}' not found in configuration");
        }

        server.Enabled = false;
        _logger.LogInformation("Disabled server: {ServerName}", serverName);

        return await Task.FromResult(config);
    }

    public async Task<List<ServerStatus>> GetServerStatusAsync(MarkdownConfig config)
    {
        var statuses = new List<ServerStatus>();

        foreach (var server in config.Servers)
        {
            var status = new ServerStatus
            {
                Name = server.Name,
                Type = server.Type,
                Url = server.Url,
                Enabled = server.Enabled,
                IsRunning = false,
                Description = server.Description,
                Tags = server.Tags,
                Port = server.Port
            };

            // Check if server is actually running
            if (server.Enabled)
            {
                try
                {
                    if (server.Type == "git")
                    {
                        var processKey = $"{server.Name}:{server.Port}";
                        if (_runningProcesses.TryGetValue(processKey, out var process))
                        {
                            status.IsRunning = !process.HasExited;
                        }
                    }
                    else if (server.Type == "http")
                    {
                        status.IsRunning = await IsHttpServerRespondingAsync(server.Url);
                    }
                }
                catch (Exception ex)
                {
                    status.Error = ex.Message;
                }
            }

            statuses.Add(status);
        }

        return statuses;
    }

    private async Task<RunningServerInfo> StartIndividualServerAsync(MultiMcpServerConfig serverConfig, 
        string workingDir, PortManager portManager)
    {
        var runningServer = new RunningServerInfo
        {
            Name = serverConfig.Name,
            Type = serverConfig.Type,
            Url = serverConfig.Url,
            Port = serverConfig.Port,
            Tags = serverConfig.Tags,
            ToolDefaults = serverConfig.ToolDefaults,
            StartTime = DateTime.UtcNow
        };

        try
        {
            _logger.LogInformation("Starting server {ServerName} of type {ServerType}", 
                serverConfig.Name, serverConfig.Type);

            if (serverConfig.Type == "git")
            {
                await StartGitServerAsync(serverConfig, workingDir, portManager, runningServer);
            }
            else if (serverConfig.Type == "http")
            {
                await StartHttpServerAsync(serverConfig, runningServer);
            }
            else
            {
                throw new InvalidOperationException($"Unknown server type: {serverConfig.Type}");
            }

            runningServer.IsRunning = true;
            _logger.LogInformation("Successfully started server {ServerName}", serverConfig.Name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to start server {ServerName}", serverConfig.Name);
            runningServer.IsRunning = false;
            runningServer.Error = ex.Message;
        }

        return runningServer;
    }

    private async Task StartGitServerAsync(MultiMcpServerConfig serverConfig, string workingDir, 
        PortManager portManager, RunningServerInfo runningServer)
    {
        // Assign port if not specified or if port is taken
        var port = await portManager.GetAvailablePortAsync(serverConfig.Port);
        runningServer.Port = port;

        // Determine local path for the repository
        var repoName = _gitService.GetRepositoryNameFromUrl(serverConfig.Url);
        var localPath = Path.Combine(workingDir, "servers", repoName);
        runningServer.LocalPath = localPath;

        // Clone or update repository
        if (await _gitService.IsRepositoryClonedAsync(localPath))
        {
            _logger.LogInformation("Repository already exists, updating: {LocalPath}", localPath);
            await _gitService.UpdateRepositoryAsync(localPath);
        }
        else
        {
            _logger.LogInformation("Cloning repository: {RepositoryUrl}", serverConfig.Url);
            await _gitService.CloneRepositoryAsync(serverConfig.Url, localPath);
        }

        // Start the MCP server process
        var serverInfo = await _mcpServerService.DiscoverServerConfigurationAsync(localPath);
        serverInfo.Port = port;
        serverInfo.Environment = serverConfig.Environment;

        // Override start command and arguments if specified
        if (!string.IsNullOrEmpty(serverConfig.StartCommand))
        {
            serverInfo.StartCommand = serverConfig.StartCommand;
        }
        if (!string.IsNullOrEmpty(serverConfig.StartArguments))
        {
            serverInfo.StartArguments = serverConfig.StartArguments.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        var startedServer = await _mcpServerService.StartServerAsync(localPath, port);
        runningServer.ProcessId = startedServer.ProcessId;

        // Store the process for management
        var processKey = $"{serverConfig.Name}:{port}";
        if (startedServer.ProcessId.HasValue)
        {
            var process = Process.GetProcessById(startedServer.ProcessId.Value);
            _runningProcesses[processKey] = process;
        }
    }

    private async Task StartHttpServerAsync(MultiMcpServerConfig serverConfig, RunningServerInfo runningServer)
    {
        // Create HTTP client with authentication
        var httpClient = new HttpClient();
        
        // Configure authentication
        if (!string.IsNullOrEmpty(serverConfig.AuthToken))
        {
            switch (serverConfig.AuthType?.ToLower())
            {
                case "bearer":
                    httpClient.DefaultRequestHeaders.Authorization = 
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", serverConfig.AuthToken);
                    break;
                case "basic":
                    var basicAuth = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(serverConfig.AuthToken));
                    httpClient.DefaultRequestHeaders.Authorization = 
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", basicAuth);
                    break;
                case "apikey":
                    httpClient.DefaultRequestHeaders.Add("X-API-Key", serverConfig.AuthToken);
                    break;
            }
        }

        // Add custom headers
        foreach (var header in serverConfig.Headers)
        {
            httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        // Store the HTTP client
        _httpClients[serverConfig.Name] = httpClient;
        runningServer.Headers = serverConfig.Headers;
        runningServer.AuthToken = serverConfig.AuthToken;

        // Test connection
        var isResponding = await IsHttpServerRespondingAsync(serverConfig.Url);
        if (!isResponding)
        {
            throw new InvalidOperationException($"HTTP server at {serverConfig.Url} is not responding");
        }

        _logger.LogInformation("HTTP server connection established: {ServerUrl}", serverConfig.Url);
    }

    private async Task StopIndividualServerAsync(RunningServerInfo server)
    {
        _logger.LogInformation("Stopping server {ServerName}", server.Name);

        if (server.Type == "git" && server.ProcessId.HasValue)
        {
            var processKey = $"{server.Name}:{server.Port}";
            if (_runningProcesses.TryGetValue(processKey, out var process))
            {
                try
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                        await process.WaitForExitAsync();
                    }
                    process.Dispose();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error stopping process for server {ServerName}", server.Name);
                }
                finally
                {
                    _runningProcesses.Remove(processKey);
                }
            }
        }
        else if (server.Type == "http")
        {
            if (_httpClients.TryGetValue(server.Name, out var httpClient))
            {
                httpClient.Dispose();
                _httpClients.Remove(server.Name);
            }
        }

        server.IsRunning = false;
        _logger.LogInformation("Stopped server {ServerName}", server.Name);
    }

    private async Task<List<string>> GetServerToolsAsync(RunningServerInfo server)
    {
        try
        {
            if (server.Type == "git")
            {
                return await GetGitServerToolsAsync(server);
            }
            else if (server.Type == "http")
            {
                return await GetHttpServerToolsAsync(server);
            }
            else
            {
                _logger.LogWarning("Unknown server type for tools discovery: {ServerType}", server.Type);
                return new List<string>();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting tools from server {ServerName}", server.Name);
            return new List<string>();
        }
    }

    private async Task<List<string>> GetGitServerToolsAsync(RunningServerInfo server)
    {
        // Use the existing McpServerService to get tools
        var serverInfo = new McpServerInfo
        {
            Name = server.Name,
            LocalPath = server.LocalPath ?? "",
            Port = server.Port,
            IsRunning = server.IsRunning,
            ProcessId = server.ProcessId
        };

        var tools = await _mcpServerService.GetAvailableToolsAsync(serverInfo);
        return tools.ToList();
    }

    private async Task<List<string>> GetHttpServerToolsAsync(RunningServerInfo server)
    {
        if (!_httpClients.TryGetValue(server.Name, out var httpClient))
        {
            throw new InvalidOperationException($"HTTP client not found for server {server.Name}");
        }

        // Send MCP tools/list request
        var request = new McpRequest
        {
            JsonRpc = "2.0",
            Id = Guid.NewGuid().ToString(),
            Method = "tools/list",
            Params = new Dictionary<string, object>()
        };

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(server.Url, content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var mcpResponse = JsonSerializer.Deserialize<McpResponse>(responseJson);

        var tools = new List<string>();
        if (mcpResponse?.Result != null)
        {
            var toolsArray = JsonSerializer.Deserialize<JsonElement>(mcpResponse.Result.ToString() ?? "{}");
            if (toolsArray.TryGetProperty("tools", out var toolsProperty) && toolsProperty.ValueKind == JsonValueKind.Array)
            {
                foreach (var tool in toolsProperty.EnumerateArray())
                {
                    if (tool.TryGetProperty("name", out var nameProperty))
                    {
                        var toolName = nameProperty.GetString();
                        if (!string.IsNullOrEmpty(toolName))
                        {
                            tools.Add(toolName);
                        }
                    }
                }
            }
        }

        return tools;
    }

    private async Task<string> CallToolOnServerAsync(RunningServerInfo server, string toolName, 
        Dictionary<string, object> parameters)
    {
        if (server.Type == "git")
        {
            return await CallGitServerToolAsync(server, toolName, parameters);
        }
        else if (server.Type == "http")
        {
            return await CallHttpServerToolAsync(server, toolName, parameters);
        }
        else
        {
            throw new InvalidOperationException($"Unknown server type: {server.Type}");
        }
    }

    private async Task<string> CallGitServerToolAsync(RunningServerInfo server, string toolName, 
        Dictionary<string, object> parameters)
    {
        var serverInfo = new McpServerInfo
        {
            Name = server.Name,
            LocalPath = server.LocalPath ?? "",
            Port = server.Port,
            IsRunning = server.IsRunning,
            ProcessId = server.ProcessId
        };

        return await _mcpServerService.CallToolAsync(serverInfo, toolName, parameters);
    }

    private async Task<string> CallHttpServerToolAsync(RunningServerInfo server, string toolName, 
        Dictionary<string, object> parameters)
    {
        if (!_httpClients.TryGetValue(server.Name, out var httpClient))
        {
            throw new InvalidOperationException($"HTTP client not found for server {server.Name}");
        }

        var request = new McpRequest
        {
            JsonRpc = "2.0",
            Id = Guid.NewGuid().ToString(),
            Method = "tools/call",
            Params = new Dictionary<string, object>
            {
                ["name"] = toolName,
                ["arguments"] = parameters
            }
        };

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(server.Url, content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var mcpResponse = JsonSerializer.Deserialize<McpResponse>(responseJson);

        if (mcpResponse?.Error != null)
        {
            throw new InvalidOperationException($"Tool call failed: {mcpResponse.Error.Message}");
        }

        return mcpResponse?.Result?.ToString() ?? "";
    }

    private async Task<ServerHealth> CheckServerHealthAsync(RunningServerInfo server)
    {
        var health = new ServerHealth
        {
            ServerName = server.Name,
            LastChecked = DateTime.UtcNow
        };

        var startTime = DateTime.UtcNow;

        try
        {
            if (server.Type == "git")
            {
                // Check if process is still running
                if (server.ProcessId.HasValue)
                {
                    var process = Process.GetProcessById(server.ProcessId.Value);
                    health.IsHealthy = !process.HasExited;
                    health.Status = health.IsHealthy ? "Running" : "Stopped";
                }
                else
                {
                    health.IsHealthy = false;
                    health.Status = "No Process ID";
                }
            }
            else if (server.Type == "http")
            {
                // Check if HTTP server is responding
                health.IsHealthy = await IsHttpServerRespondingAsync(server.Url);
                health.Status = health.IsHealthy ? "Responding" : "Not Responding";
            }
        }
        catch (Exception ex)
        {
            health.IsHealthy = false;
            health.Status = "Error";
            health.Error = ex.Message;
        }

        health.ResponseTime = DateTime.UtcNow - startTime;
        _lastHealthCheck[server.Name] = health.LastChecked;

        return health;
    }

    private async Task<string> SendPromptToServerAsync(RunningServerInfo server, string prompt)
    {
        if (server.Type == "git")
        {
            var serverInfo = new McpServerInfo
            {
                Name = server.Name,
                LocalPath = server.LocalPath ?? "",
                Port = server.Port,
                IsRunning = server.IsRunning,
                ProcessId = server.ProcessId
            };

            return await _mcpServerService.SendPromptAsync(serverInfo, prompt);
        }
        else if (server.Type == "http")
        {
            // For HTTP servers, we might need to implement a specific prompt endpoint
            // For now, return a placeholder
            return $"HTTP server {server.Name} received prompt: {prompt}";
        }
        else
        {
            throw new InvalidOperationException($"Unknown server type: {server.Type}");
        }
    }

    private async Task<bool> IsHttpServerRespondingAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    private Dictionary<string, object> MergeToolDefaults(string toolName, Dictionary<string, object> parameters, 
        Dictionary<string, Dictionary<string, object>> toolDefaults)
    {
        var mergedParameters = new Dictionary<string, object>(parameters);

        if (toolDefaults.TryGetValue(toolName, out var defaults))
        {
            foreach (var defaultParam in defaults)
            {
                if (!mergedParameters.ContainsKey(defaultParam.Key))
                {
                    mergedParameters[defaultParam.Key] = defaultParam.Value;
                }
            }
        }

        return mergedParameters;
    }
}

public class PortManager
{
    private readonly ILogger _logger;
    private readonly HashSet<int> _assignedPorts = new();

    public PortManager(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<int> GetAvailablePortAsync(int preferredPort = 3000)
    {
        // Try the preferred port first
        if (await IsPortAvailableAsync(preferredPort) && !_assignedPorts.Contains(preferredPort))
        {
            _assignedPorts.Add(preferredPort);
            return preferredPort;
        }

        // Find an available port starting from the preferred port
        for (int port = preferredPort; port < preferredPort + 100; port++)
        {
            if (await IsPortAvailableAsync(port) && !_assignedPorts.Contains(port))
            {
                _assignedPorts.Add(port);
                _logger.LogInformation("Assigned port {Port} (preferred was {PreferredPort})", port, preferredPort);
                return port;
            }
        }

        throw new InvalidOperationException($"No available ports found near {preferredPort}");
    }

    private async Task<bool> IsPortAvailableAsync(int port)
    {
        try
        {
            var listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            listener.Stop();
            await Task.CompletedTask; // Make this actually async
            return true;
        }
        catch
        {
            await Task.CompletedTask; // Make this actually async
            return false;
        }
    }
} 