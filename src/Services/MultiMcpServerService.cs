using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using McpCli.Models;
using Azure.Identity;
using Azure.Core;

namespace McpCli.Services;

public class MultiMcpServerService : IMultiMcpServerService
{
    private readonly ILogger<MultiMcpServerService> _logger;
    private readonly HttpClient _httpClient;
    private readonly IGitService _gitService;
    private readonly IMcpServerService _mcpServerService;
    private readonly IEnvironmentVariableService _environmentVariableService;
    private readonly IRepositoryRootService _repositoryRootService;
    private readonly Dictionary<string, Process> _runningProcesses = new();
    private readonly Dictionary<string, HttpClient> _httpClients = new();
    private readonly Dictionary<string, DateTime> _lastHealthCheck = new();

    public MultiMcpServerService(
        ILogger<MultiMcpServerService> logger,
        HttpClient httpClient,
        IGitService gitService,
        IMcpServerService mcpServerService,
        IEnvironmentVariableService environmentVariableService,
        IRepositoryRootService repositoryRootService)
    {
        _logger = logger;
        _httpClient = httpClient;
        _gitService = gitService;
        _mcpServerService = mcpServerService;
        _environmentVariableService = environmentVariableService;
        _repositoryRootService = repositoryRootService;
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
        var toolMapping = new ServerToolMapping();
        var tasks = new List<Task<(string serverName, IEnumerable<string> tools)>>();

        foreach (var serverInfo in runningServers.Where(s => s.IsRunning))
        {
            tasks.Add(GetToolsForServerAsync(serverInfo));
        }

        var results = await Task.WhenAll(tasks);

        foreach (var (serverName, tools) in results)
        {
            toolMapping.ServerToTools[serverName] = tools.ToList();
            
            foreach (var tool in tools)
            {
                if (toolMapping.ToolToServer.ContainsKey(tool))
                {
                    // Tool exists on multiple servers - mark as conflicting
                    if (!toolMapping.ConflictingTools.ContainsKey(tool))
                    {
                        toolMapping.ConflictingTools[tool] = new List<string> { toolMapping.ToolToServer[tool] };
                    }
                    toolMapping.ConflictingTools[tool].Add(serverName);
                }
                else
                {
                    toolMapping.ToolToServer[tool] = serverName;
                    toolMapping.AllTools.Add(tool);
                }
            }
        }

        return toolMapping;
    }

    public async Task<Dictionary<string, object>> GetToolSchemasAsync(RunningServerInfo serverInfo)
    {
        try
        {
            var mcpServerInfo = new McpServerInfo
            {
                Name = serverInfo.Name,
                Port = serverInfo.Port,
                LocalPath = serverInfo.LocalPath,
                IsRunning = serverInfo.IsRunning
            };

            return await _mcpServerService.GetToolSchemasAsync(mcpServerInfo);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting tool schemas for server {ServerName}", serverInfo.Name);
            return new Dictionary<string, object>();
        }
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
                        if (_httpClients.TryGetValue(server.Name, out var httpClient))
                        {
                            status.IsRunning = await IsHttpServerRespondingAsync(httpClient, server.Url);
                        }
                        else
                        {
                            status.IsRunning = false;
                        }
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
        // Resolve working directory relative to repository root
        var resolvedWorkingDir = _repositoryRootService.IsRelativePath(workingDir) 
            ? _repositoryRootService.ResolvePath(workingDir) 
            : workingDir;

        // Ensure working directory exists
        if (!Directory.Exists(resolvedWorkingDir))
        {
            Directory.CreateDirectory(resolvedWorkingDir);
            _logger.LogInformation("Created working directory: {WorkingDir}", resolvedWorkingDir);
        }

        // Get available port
        var port = await portManager.GetAvailablePortAsync(serverConfig.Port);
        runningServer.Port = port;

        // Determine local path for the repository
        var repoName = _gitService.GetRepositoryNameFromUrl(serverConfig.Url);
        var localPath = Path.Combine(resolvedWorkingDir, "servers", repoName);
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
        
        // IMPORTANT: Update the LocalPath to match what the McpServerService is using
        // This ensures process lookup keys match between services
        runningServer.LocalPath = startedServer.LocalPath;

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
        // Create HTTP client with authentication and timeout
        var httpClient = new HttpClient();
        httpClient.Timeout = TimeSpan.FromSeconds(30); // Set 30-second timeout
        
        // Configure Azure Identity authentication if enabled
        if (serverConfig.UseAzureIdentity)
        {
            await ConfigureAzureIdentityAuthAsync(httpClient, serverConfig);
        }
        // Configure GitHub authentication if enabled
        else if (serverConfig.UseGitHubAuth)
        {
            await ConfigureGitHubAuthAsync(httpClient, serverConfig);
        }
        // Configure traditional authentication
        else if (!string.IsNullOrEmpty(serverConfig.AuthToken))
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

        // Add custom headers - resolve environment variables first
        foreach (var header in serverConfig.Headers)
        {
            var resolvedValue = _environmentVariableService.ResolveEnvironmentVariables(header.Value);
            _logger.LogDebug("Adding header {HeaderName} for server {ServerName}", header.Key, serverConfig.Name);
            
            // Content-Type is a content header and will be set per request, skip it here
            if (header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogDebug("Skipping Content-Type header - will be set per request");
                continue;
            }
            
            try
            {
                httpClient.DefaultRequestHeaders.Add(header.Key, resolvedValue);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to add header {HeaderName}: {HeaderValue}", header.Key, resolvedValue);
            }
        }

        // Store the HTTP client
        _httpClients[serverConfig.Name] = httpClient;
        runningServer.Headers = serverConfig.Headers;
        runningServer.AuthToken = serverConfig.AuthToken;

        // Test connection using the configured client with headers
        _logger.LogInformation("Testing connection to HTTP server: {ServerUrl}", serverConfig.Url);
        var isResponding = await IsHttpServerRespondingAsync(httpClient, serverConfig.Url);
        if (!isResponding)
        {
            _logger.LogWarning("Connection test failed for {ServerUrl}, but proceeding anyway (some MCP servers may not respond to initialization requests)", serverConfig.Url);
        }

        _logger.LogInformation("HTTP server connection established: {ServerUrl}", serverConfig.Url);
    }

    private async Task ConfigureAzureIdentityAuthAsync(HttpClient httpClient, MultiMcpServerConfig serverConfig)
    {
        try
        {
            _logger.LogInformation("Configuring Azure Identity authentication for server {ServerName}", serverConfig.Name);

            // Create credential options
            var options = new DefaultAzureCredentialOptions();
            
            // Configure tenant ID if specified
            if (!string.IsNullOrEmpty(serverConfig.AzureTenantId))
            {
                options.TenantId = serverConfig.AzureTenantId;
                _logger.LogDebug("Using Azure tenant ID: {TenantId}", serverConfig.AzureTenantId);
            }

            // Configure interactive authentication
            options.ExcludeInteractiveBrowserCredential = !serverConfig.AllowInteractiveAuth;
            if (serverConfig.AllowInteractiveAuth)
            {
                _logger.LogDebug("Interactive browser authentication enabled for server {ServerName}", serverConfig.Name);
            }

            // Create the credential
            var credential = new DefaultAzureCredential(options);

            // Prepare scopes - use default if none specified
            var scopes = serverConfig.AzureScopes?.Count > 0 
                ? serverConfig.AzureScopes.ToArray()
                : new[] { "https://management.azure.com/.default" }; // Default Azure management scope

            _logger.LogDebug("Requesting Azure token for scopes: {Scopes}", string.Join(", ", scopes));

            // Get the access token
            var tokenRequestContext = new TokenRequestContext(scopes);
            var tokenResult = await credential.GetTokenAsync(tokenRequestContext);

            // Set the authorization header
            httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResult.Token);

            _logger.LogInformation("Azure Identity authentication configured successfully for server {ServerName}", serverConfig.Name);
            _logger.LogDebug("Token expires at: {ExpiresOn}", tokenResult.ExpiresOn);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to configure Azure Identity authentication for server {ServerName}: {Error}", 
                serverConfig.Name, ex.Message);
            throw new InvalidOperationException($"Azure Identity authentication failed for server {serverConfig.Name}: {ex.Message}", ex);
        }
    }

    private async Task ConfigureGitHubAuthAsync(HttpClient httpClient, MultiMcpServerConfig serverConfig)
    {
        try
        {
            var authMethod = serverConfig.GitHubAuthMethod?.ToLower() ?? "cli";
            _logger.LogInformation("Configuring GitHub authentication for server {ServerName} using method: {AuthMethod}", 
                serverConfig.Name, authMethod);

            string accessToken;

            switch (authMethod)
            {
                case "device":
                    // Prepare scopes - use default if none specified
                    var deviceScopes = serverConfig.GitHubScopes?.Count > 0 
                        ? serverConfig.GitHubScopes
                        : new List<string> { "user", "repo" }; // Default GitHub scopes
                    accessToken = await GetGitHubDeviceFlowTokenAsync(deviceScopes);
                    break;
                    
                case "cli":
                    accessToken = await GetGitHubCliTokenAsync();
                    break;
                    
                case "token":
                    accessToken = GetGitHubPersonalTokenAsync(serverConfig);
                    break;
                    
                case "oauth":
                    // Prepare scopes - use default if none specified
                    var scopes = serverConfig.GitHubScopes?.Count > 0 
                        ? serverConfig.GitHubScopes
                        : new List<string> { "user", "repo" }; // Default GitHub scopes
                    accessToken = await GetGitHubOAuthTokenAsync(serverConfig, scopes);
                    break;
                    
                default:
                    throw new InvalidOperationException($"Unknown GitHub authentication method: {authMethod}");
            }

            // Set the authorization header
            httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            _logger.LogInformation("GitHub authentication configured successfully for server {ServerName}", serverConfig.Name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to configure GitHub authentication for server {ServerName}: {Error}", 
                serverConfig.Name, ex.Message);
            throw new InvalidOperationException($"GitHub authentication failed for server {serverConfig.Name}: {ex.Message}", ex);
        }
    }

    private async Task<string> GetGitHubDeviceFlowTokenAsync(List<string> scopes)
    {
        try
        {
            _logger.LogInformation("Starting GitHub device flow authentication");

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "mcpcli-github-auth");

            // Step 1: Request device and user codes
            var scopeString = string.Join(" ", scopes);
            var deviceRequest = new
            {
                client_id = "Iv1.b507a08c87ecfe98", // GitHub CLI's public client ID
                scope = scopeString
            };

            var deviceJson = JsonSerializer.Serialize(deviceRequest);
            var deviceContent = new StringContent(deviceJson, System.Text.Encoding.UTF8, "application/json");

            _logger.LogDebug("Requesting device code for scopes: {Scopes}", scopeString);
            var deviceResponse = await httpClient.PostAsync("https://github.com/login/device/code", deviceContent);
            deviceResponse.EnsureSuccessStatusCode();

            var deviceResponseJson = await deviceResponse.Content.ReadAsStringAsync();
            var deviceData = JsonSerializer.Deserialize<JsonElement>(deviceResponseJson);

            var deviceCode = deviceData.GetProperty("device_code").GetString();
            var userCode = deviceData.GetProperty("user_code").GetString();
            var verificationUri = deviceData.GetProperty("verification_uri").GetString();
            var interval = deviceData.GetProperty("interval").GetInt32();

            // Step 2: Display instructions to user
            Console.WriteLine();
            Console.WriteLine("=== GitHub Authentication Required ===");
            Console.WriteLine();
            Console.WriteLine($"Please visit: {verificationUri}");
            Console.WriteLine($"And enter code: {userCode}");
            Console.WriteLine();
            Console.WriteLine("Opening browser automatically...");
            Console.WriteLine();

            // Open browser automatically
            try
            {
                var processStartInfo = new ProcessStartInfo(verificationUri)
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to open browser automatically");
                Console.WriteLine("(Failed to open browser automatically - please visit the URL manually)");
            }

            // Step 3: Poll for access token
            Console.WriteLine("Waiting for authorization...");
            var pollingInterval = TimeSpan.FromSeconds(interval);
            var timeout = TimeSpan.FromMinutes(10); // 10 minute timeout
            var startTime = DateTime.UtcNow;

            while (DateTime.UtcNow - startTime < timeout)
            {
                await Task.Delay(pollingInterval);

                var tokenRequest = new
                {
                    client_id = "Iv1.b507a08c87ecfe98", // GitHub CLI's public client ID
                    device_code = deviceCode,
                    grant_type = "urn:ietf:params:oauth:grant-type:device_code"
                };

                var tokenJson = JsonSerializer.Serialize(tokenRequest);
                var tokenContent = new StringContent(tokenJson, System.Text.Encoding.UTF8, "application/json");

                var tokenResponse = await httpClient.PostAsync("https://github.com/login/oauth/access_token", tokenContent);
                var tokenResponseJson = await tokenResponse.Content.ReadAsStringAsync();
                var tokenData = JsonSerializer.Deserialize<JsonElement>(tokenResponseJson);

                if (tokenData.TryGetProperty("access_token", out var accessTokenElement))
                {
                    var accessToken = accessTokenElement.GetString();
                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        Console.WriteLine("✅ Successfully authenticated with GitHub!");
                        Console.WriteLine();
                        _logger.LogInformation("GitHub device flow authentication completed successfully");
                        return accessToken;
                    }
                }

                if (tokenData.TryGetProperty("error", out var errorElement))
                {
                    var error = errorElement.GetString();
                    if (error == "authorization_pending")
                    {
                        // Still waiting for user authorization
                        Console.Write(".");
                        continue;
                    }
                    if (error == "slow_down")
                    {
                        // GitHub wants us to slow down polling
                        pollingInterval = pollingInterval.Add(TimeSpan.FromSeconds(5));
                        continue;
                    }
                    if (error == "expired_token")
                    {
                        throw new InvalidOperationException("Device code expired. Please try again.");
                    }
                    if (error == "access_denied")
                    {
                        throw new InvalidOperationException("User cancelled the authorization.");
                    }

                    throw new InvalidOperationException($"GitHub authentication error: {error}");
                }
            }

            throw new InvalidOperationException("GitHub authentication timed out. Please try again.");
        }
        catch (Exception ex) when (ex is not InvalidOperationException)
        {
            _logger.LogError(ex, "Failed to complete GitHub device flow authentication");
            throw new InvalidOperationException($"GitHub device flow authentication failed: {ex.Message}", ex);
        }
    }

    private async Task<string> GetGitHubCliTokenAsync()
    {
        try
        {
            _logger.LogInformation("Attempting to get GitHub token from GitHub CLI");

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "gh",
                Arguments = "auth token",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(processStartInfo);
            if (process == null)
            {
                throw new InvalidOperationException("Failed to start GitHub CLI process");
            }

            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
            {
                var error = await process.StandardError.ReadToEndAsync();
                throw new InvalidOperationException($"GitHub CLI authentication failed: {error}. Please run 'gh auth login' first.");
            }

            var token = (await process.StandardOutput.ReadToEndAsync()).Trim();
            if (string.IsNullOrEmpty(token))
            {
                throw new InvalidOperationException("GitHub CLI returned empty token. Please run 'gh auth login' first.");
            }

            _logger.LogInformation("Successfully obtained GitHub token from CLI");
            return token;
        }
        catch (Exception ex) when (ex is not InvalidOperationException)
        {
            _logger.LogError(ex, "Failed to get GitHub token from CLI");
            throw new InvalidOperationException($"GitHub CLI authentication failed: {ex.Message}. Make sure GitHub CLI is installed and authenticated.", ex);
        }
    }

    private string GetGitHubPersonalTokenAsync(MultiMcpServerConfig serverConfig)
    {
        if (string.IsNullOrEmpty(serverConfig.GitHubToken))
        {
            throw new InvalidOperationException("GitHub personal access token is required when using 'token' authentication method");
        }

        _logger.LogInformation("Using configured GitHub personal access token");
        return serverConfig.GitHubToken;
    }

    private async Task<string> GetGitHubOAuthTokenAsync(MultiMcpServerConfig serverConfig, List<string> scopes)
    {
        // Check for required OAuth parameters
        if (string.IsNullOrEmpty(serverConfig.GitHubClientId))
        {
            throw new InvalidOperationException("GitHub Client ID is required for OAuth authentication");
        }

        if (string.IsNullOrEmpty(serverConfig.GitHubClientSecret))
        {
            throw new InvalidOperationException("GitHub Client Secret is required for OAuth authentication");
        }

        if (!serverConfig.AllowGitHubInteractiveAuth)
        {
            throw new InvalidOperationException("Interactive authentication is disabled, but no cached token is available");
        }

        _logger.LogDebug("Requesting GitHub OAuth token for scopes: {Scopes}", string.Join(", ", scopes));

        _logger.LogInformation("Starting GitHub OAuth interactive flow");
        
        // Start local HTTP listener for OAuth callback
        var listener = new HttpListener();
        var redirectUri = "http://localhost:8080/callback";
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();

        try
        {
            // Create authorization URL
            var state = Guid.NewGuid().ToString();
            var scopeString = string.Join(",", scopes);
            var authUrl = $"https://github.com/login/oauth/authorize?" +
                         $"client_id={serverConfig.GitHubClientId}&" +
                         $"redirect_uri={Uri.EscapeDataString(redirectUri)}&" +
                         $"scope={Uri.EscapeDataString(scopeString)}&" +
                         $"state={state}";

            _logger.LogInformation("Opening browser for GitHub OAuth authorization");
            _logger.LogDebug("Authorization URL: {AuthUrl}", authUrl);

            // Open browser
            var processStartInfo = new ProcessStartInfo(authUrl)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(processStartInfo);

            // Wait for callback
            _logger.LogInformation("Waiting for OAuth callback...");
            var context = await listener.GetContextAsync();
            var request = context.Request;
            var response = context.Response;

            // Extract authorization code
            var query = request.Url?.Query;
            if (string.IsNullOrEmpty(query))
            {
                throw new InvalidOperationException("No query parameters received in OAuth callback");
            }

            var queryParams = System.Web.HttpUtility.ParseQueryString(query);
            var code = queryParams["code"];
            var returnedState = queryParams["state"];
            var error = queryParams["error"];

            if (!string.IsNullOrEmpty(error))
            {
                throw new InvalidOperationException($"OAuth authorization failed: {error}");
            }

            if (returnedState != state)
            {
                throw new InvalidOperationException("OAuth state mismatch - possible CSRF attack");
            }

            if (string.IsNullOrEmpty(code))
            {
                throw new InvalidOperationException("No authorization code received");
            }

            // Send success response to browser
            var responseString = "<html><body><h1>Authorization Successful!</h1><p>You can close this window and return to the application.</p></body></html>";
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentType = "text/html";
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.OutputStream.Close();

            _logger.LogInformation("Authorization code received, exchanging for access token");

            // Exchange code for access token
            var tokenRequest = new
            {
                client_id = serverConfig.GitHubClientId,
                client_secret = serverConfig.GitHubClientSecret,
                code = code,
                redirect_uri = redirectUri
            };

            var tokenJson = JsonSerializer.Serialize(tokenRequest);
            var tokenContent = new StringContent(tokenJson, System.Text.Encoding.UTF8, "application/json");

            using var tokenHttpClient = new HttpClient();
            tokenHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            tokenHttpClient.DefaultRequestHeaders.Add("User-Agent", "mcpcli-oauth");

            var tokenResponse = await tokenHttpClient.PostAsync("https://github.com/login/oauth/access_token", tokenContent);
            tokenResponse.EnsureSuccessStatusCode();

            var tokenResponseJson = await tokenResponse.Content.ReadAsStringAsync();
            var tokenData = JsonSerializer.Deserialize<JsonElement>(tokenResponseJson);

            if (!tokenData.TryGetProperty("access_token", out var accessTokenElement))
            {
                var errorDescription = tokenData.TryGetProperty("error_description", out var desc) 
                    ? desc.GetString() 
                    : "Unknown error";
                throw new InvalidOperationException($"Failed to obtain access token: {errorDescription}");
            }

            var accessToken = accessTokenElement.GetString();
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new InvalidOperationException("Received empty access token");
            }

            _logger.LogInformation("GitHub OAuth access token obtained successfully");
            return accessToken;
        }
        finally
        {
            listener.Stop();
        }
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

    private async Task<(string serverName, IEnumerable<string> tools)> GetToolsForServerAsync(RunningServerInfo server)
    {
        try
        {
            if (server.Type == "git")
            {
                return (server.Name, await GetGitServerToolsAsync(server));
            }
            else if (server.Type == "http")
            {
                return (server.Name, await GetHttpServerToolsAsync(server));
            }
            else
            {
                _logger.LogWarning("Unknown server type for tools discovery: {ServerType}", server.Type);
                return (server.Name, new List<string>());
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting tools from server {ServerName}", server.Name);
            return (server.Name, new List<string>());
        }
    }

    private async Task<Dictionary<string, string>> GetServerToolDescriptionsAsync(RunningServerInfo server, List<string> tools)
    {
        var descriptions = new Dictionary<string, string>();
        
        try
        {
            if (server.Type == "git")
            {
                return await GetGitServerToolDescriptionsAsync(server, tools);
            }
            else if (server.Type == "http")
            {
                return await GetHttpServerToolDescriptionsAsync(server, tools);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error getting tool descriptions from server {ServerName}, using basic descriptions", server.Name);
        }
        
        // Fallback: provide basic descriptions
        foreach (var tool in tools)
        {
            descriptions[tool] = GetBasicToolDescription(tool);
        }
        
        return descriptions;
    }

    private async Task<Dictionary<string, string>> GetGitServerToolDescriptionsAsync(RunningServerInfo server, List<string> tools)
    {
        var descriptions = new Dictionary<string, string>();
        
        try
        {
            // Try to get tool descriptions from the MCP server
            var processKey = $"{server.Name}:{server.Port}";
            if (_runningProcesses.TryGetValue(processKey, out var process))
            {
                // For now, we'll use basic descriptions since MCP tool descriptions require more complex parsing
                // In the future, this could query the MCP server for tool metadata
                foreach (var tool in tools)
                {
                    descriptions[tool] = GetBasicToolDescription(tool);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error getting tool descriptions from git server {ServerName}", server.Name);
        }
        
        return descriptions;
    }

    private Task<Dictionary<string, string>> GetHttpServerToolDescriptionsAsync(RunningServerInfo server, List<string> tools)
    {
        var descriptions = new Dictionary<string, string>();
        
        try
        {
            // For HTTP servers, we could potentially query the server for tool metadata
            // For now, use basic descriptions
            foreach (var tool in tools)
            {
                descriptions[tool] = GetBasicToolDescription(tool);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error getting tool descriptions from HTTP server {ServerName}", server.Name);
        }
        
        return Task.FromResult(descriptions);
    }

    private string GetBasicToolDescription(string toolName)
    {
        var lowerName = toolName.ToLower();
        
        // Provide intelligent descriptions based on common tool name patterns
        return lowerName switch
        {
            // Initialization and setup tools
            var name when name.Contains("initialize") && name.Contains("azure") && name.Contains("devops") => 
                "Initialize Azure DevOps client connection and authenticate with the organization",
            var name when name.Contains("initialize") => 
                "Initialize and configure the client connection for the service",
            
            // Project and repository management
            var name when name.Contains("get_projects") => 
                "Retrieve a comprehensive list of all projects in the organization with metadata",
            var name when name.Contains("get_repositories") => 
                "Get all repositories for a specific project with branch and commit information",
            var name when name.Contains("get_repos") => 
                "Retrieve repository information including details and statistics",
            
            // Pull request operations
            var name when name.Contains("get_pull_requests") && name.Contains("creation_date") => 
                "Get pull requests filtered by their creation date range with detailed metadata",
            var name when name.Contains("get_pull_requests") && name.Contains("closed_date") => 
                "Get pull requests filtered by their closed/completed date range with status information",
            var name when name.Contains("get_pull_request_description") => 
                "Get detailed description, comments, and metadata for specific pull requests",
            var name when name.Contains("get_pull_requests") => 
                "Retrieve pull requests with various filters (status, branch, author, etc.)",
            
            // Commit and branch operations
            var name when name.Contains("get_commits") => 
                "Retrieve commit information including messages, authors, and timestamps",
            var name when name.Contains("get_branches") => 
                "Get branch information including protection rules and latest commits",
            
            // Work item operations
            var name when name.Contains("get_work_items") => 
                "Retrieve work items (bugs, tasks, user stories) with detailed field information",
            var name when name.Contains("work_items") => 
                "Query and retrieve work items using WIQL (Work Item Query Language)",
            
            // Data analysis and processing
            var name when name.Contains("analyze") => 
                "Analyze data or content to extract insights and patterns",
            var name when name.Contains("search") => 
                "Search for specific items or content across the system",
            var name when name.Contains("filter") => 
                "Filter data based on specified criteria and conditions",
            var name when name.Contains("sort") => 
                "Sort data by specified fields and criteria",
            
            // CRUD operations
            var name when name.Contains("create") => 
                "Create new resources, items, or entities in the system",
            var name when name.Contains("update") => 
                "Update existing resources, items, or entities with new information",
            var name when name.Contains("delete") => 
                "Delete resources, items, or entities from the system",
            
            // Data import/export
            var name when name.Contains("export") => 
                "Export data or reports in various formats (JSON, CSV, etc.)",
            var name when name.Contains("import") => 
                "Import data or content from external sources",
            
            // Validation and testing
            var name when name.Contains("validate") => 
                "Validate data, configurations, or system state",
            var name when name.Contains("test") => 
                "Run tests, validations, or health checks",
            
            // Reporting and formatting
            var name when name.Contains("report") => 
                "Generate formatted reports or summaries of data",
            var name when name.Contains("format") => 
                "Format data or content for display or export",
            var name when name.Contains("summarize") => 
                "Create summaries or overviews of data or results",
            
            // Default case with more context
            _ => $"Execute the {toolName} operation - analyze the tool name to understand its purpose"
        };
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

        _logger.LogDebug("Sending tools/list request to {ServerName}: {RequestJson}", server.Name, json);

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        var response = await httpClient.PostAsync(server.Url, content, cts.Token);
        
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _logger.LogError("Tools discovery failed for {ServerName}. Status: {StatusCode}, Response: {Response}", 
                server.Name, response.StatusCode, errorContent);
        }
        
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

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        var response = await httpClient.PostAsync(server.Url, content, cts.Token);
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
                if (_httpClients.TryGetValue(server.Name, out var httpClient))
                {
                    health.IsHealthy = await IsHttpServerRespondingAsync(httpClient, server.Url);
                    health.Status = health.IsHealthy ? "Responding" : "Not Responding";
                }
                else
                {
                    health.IsHealthy = false;
                    health.Status = "No HttpClient";
                }
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

    private async Task<bool> IsHttpServerRespondingAsync(HttpClient httpClient, string url)
    {
        try
        {
            _logger.LogDebug("Testing connection to {Url}", url);
            
            // For MCP servers, test with a simple initialization request
            var initRequest = new
            {
                jsonrpc = "2.0",
                id = 1,
                method = "initialize",
                @params = new
                {
                    protocolVersion = "2024-11-05",
                    capabilities = new { },
                    clientInfo = new
                    {
                        name = "mcpcli",
                        version = "1.0.0"
                    }
                }
            };

            var json = JsonSerializer.Serialize(initRequest);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            
            // Use a shorter timeout for the connection test
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
            var response = await httpClient.PostAsync(url, content, cts.Token);
            
            _logger.LogDebug("Received response from {Url}: {StatusCode}", url, response.StatusCode);
            return response.IsSuccessStatusCode;
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("Connection test to {Url} timed out after 15 seconds", url);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "Connection test to {Url} failed: {Message}", url, ex.Message);
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