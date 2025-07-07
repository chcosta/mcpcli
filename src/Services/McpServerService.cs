using System.Diagnostics;
using System.Text.Json;
using CliWrap;
using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class McpServerService : IMcpServerService
{
    private readonly ILogger<McpServerService> _logger;
    private readonly HttpClient _httpClient;
    private readonly Dictionary<string, Process> _runningProcesses = new();

    public McpServerService(ILogger<McpServerService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task<McpServerInfo> StartServerAsync(string repositoryPath, int port = 3000, CancellationToken cancellationToken = default)
    {
        try
        {
            var serverInfo = await DiscoverServerConfigurationAsync(repositoryPath);
            serverInfo.Port = port;

            _logger.LogInformation("Starting MCP server at {RepositoryPath}", repositoryPath);

            // Build the command to start the server
            var workingDirectory = Path.GetFullPath(serverInfo.LocalPath);
            
            var startInfo = new ProcessStartInfo
            {
                FileName = serverInfo.StartCommand,
                Arguments = string.Join(" ", serverInfo.StartArguments),
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            // Add environment variables
            foreach (var env in serverInfo.Environment)
            {
                startInfo.EnvironmentVariables[env.Key] = env.Value;
            }

            var process = new Process { StartInfo = startInfo };
            process.Start();

            // Store the process for later communication
            var processKey = $"{serverInfo.LocalPath}:{port}";
            _runningProcesses[processKey] = process;

            serverInfo.IsRunning = true;
            serverInfo.ProcessId = process.Id;
            
            _logger.LogInformation("MCP server started successfully with PID {ProcessId}", process.Id);

            return serverInfo;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error starting MCP server at {RepositoryPath}", repositoryPath);
            throw;
        }
    }

    public async Task<bool> StopServerAsync(McpServerInfo serverInfo, CancellationToken cancellationToken = default)
    {
        try
        {
            if (!serverInfo.IsRunning)
            {
                return true;
            }

            _logger.LogInformation("Stopping MCP server with PID {ProcessId}", serverInfo.ProcessId);

            var processKey = $"{serverInfo.LocalPath}:{serverInfo.Port}";
            if (_runningProcesses.TryGetValue(processKey, out var process))
            {
                try
                {
                    if (!process.HasExited)
                    {
                        // Try graceful shutdown first
                        process.StandardInput.Close();
                        
                        // Wait a bit for graceful shutdown
                        if (!process.WaitForExit(5000))
                        {
                            _logger.LogWarning("Process did not exit gracefully, forcing termination");
                            process.Kill();
                            await process.WaitForExitAsync(cancellationToken);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogDebug(ex, "Error stopping process gracefully, forcing kill");
                    try
                    {
                        if (!process.HasExited)
                        {
                            process.Kill();
                            await process.WaitForExitAsync(cancellationToken);
                        }
                    }
                    catch (Exception killEx)
                    {
                        _logger.LogDebug(killEx, "Error killing process");
                    }
                }
                finally
                {
                    process.Dispose();
                    _runningProcesses.Remove(processKey);
                }
            }

            serverInfo.IsRunning = false;
            serverInfo.ProcessId = null;

            _logger.LogInformation("MCP server stopped");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error stopping MCP server");
            return false;
        }
    }

    public async Task<bool> IsServerRunningAsync(McpServerInfo serverInfo)
    {
        try
        {
            var processKey = $"{serverInfo.LocalPath}:{serverInfo.Port}";
            if (_runningProcesses.TryGetValue(processKey, out var process))
            {
                // Make this truly async by adding a small delay to allow for proper async behavior
                await Task.Delay(1);
                return !process.HasExited;
            }
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "Error checking if server is running");
            return false;
        }
    }

    public async Task<McpResponse> SendRequestAsync(McpServerInfo serverInfo, McpRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            if (!serverInfo.IsRunning)
            {
                throw new InvalidOperationException("MCP server is not running");
            }

            var processKey = $"{serverInfo.LocalPath}:{serverInfo.Port}";
            if (!_runningProcesses.TryGetValue(processKey, out var process) || process.HasExited)
            {
                throw new InvalidOperationException("MCP server process is not available");
            }

            var json = JsonSerializer.Serialize(request);
            _logger.LogDebug("Sending MCP request: {Method} - {Json}", request.Method, json);

            // Send the JSON-RPC request to the process stdin
            await process.StandardInput.WriteLineAsync(json);
            await process.StandardInput.FlushAsync();

            // Read the response from stdout
            var responseJson = await process.StandardOutput.ReadLineAsync();
            
            if (string.IsNullOrEmpty(responseJson))
            {
                return new McpResponse { Error = new McpError { Code = -1, Message = "No response from MCP server" } };
            }

            _logger.LogDebug("Received MCP response: {Response}", responseJson);

            var mcpResponse = JsonSerializer.Deserialize<McpResponse>(responseJson);
            return mcpResponse ?? new McpResponse { Error = new McpError { Code = -1, Message = "Invalid response format" } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending MCP request");
            return new McpResponse
            {
                Error = new McpError
                {
                    Code = -1,
                    Message = ex.Message
                }
            };
        }
    }

    public async Task<string> SendPromptAsync(McpServerInfo serverInfo, string prompt, CancellationToken cancellationToken = default)
    {
        try
        {
            // Get available tools - this will be used by the AI service to determine what to call
            var listToolsRequest = new McpRequest
            {
                Method = "tools/list",
                Params = null
            };

            var response = await SendRequestAsync(serverInfo, listToolsRequest, cancellationToken);
            
            if (response.Error != null)
            {
                return $"MCP server error: {response.Error.Message}";
            }

            // Format the tools response for AI processing
            if (response.Result != null)
            {
                var resultJson = JsonSerializer.Serialize(response.Result);
                _logger.LogDebug("Raw tools response: {Response}", resultJson);
                
                try
                {
                    // Parse and format the MCP tools response for better AI understanding
                    var toolsResponse = JsonSerializer.Deserialize<JsonElement>(resultJson);
                    
                    if (toolsResponse.TryGetProperty("tools", out var toolsArray) && toolsArray.ValueKind == JsonValueKind.Array)
                    {
                        var formattedTools = new List<string>();
                        
                        foreach (var tool in toolsArray.EnumerateArray())
                        {
                            if (tool.TryGetProperty("name", out var nameElement) && nameElement.ValueKind == JsonValueKind.String)
                            {
                                var toolName = nameElement.GetString();
                                var description = tool.TryGetProperty("description", out var descElement) ? descElement.GetString() : "No description";
                                
                                var toolInfo = $"Tool: {toolName}";
                                if (!string.IsNullOrEmpty(description))
                                {
                                    toolInfo += $" - {description}";
                                }
                                
                                // Add parameter schema info if available
                                if (tool.TryGetProperty("inputSchema", out var schemaElement))
                                {
                                    try
                                    {
                                        var schemaJson = JsonSerializer.Serialize(schemaElement);
                                        var schema = JsonSerializer.Deserialize<JsonElement>(schemaJson);
                                        
                                        if (schema.TryGetProperty("properties", out var properties))
                                        {
                                            var paramNames = new List<string>();
                                            foreach (var prop in properties.EnumerateObject())
                                            {
                                                paramNames.Add(prop.Name);
                                            }
                                            
                                            if (paramNames.Count > 0)
                                            {
                                                toolInfo += $" (Parameters: {string.Join(", ", paramNames)})";
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.LogDebug(ex, "Error parsing schema for tool {ToolName}", toolName);
                                    }
                                }
                                
                                formattedTools.Add(toolInfo);
                            }
                        }
                        
                        var result = $"Available tools:\n{string.Join("\n", formattedTools)}";
                        _logger.LogDebug("Formatted tools for AI: {FormattedTools}", result);
                        return result;
                    }
                    else
                    {
                        return "No tools available - response does not contain 'tools' array";
                    }
                }
                catch (JsonException ex)
                {
                    _logger.LogError(ex, "Error parsing tools response for AI processing");
                    // Fall back to raw response
                    return $"Available tools (raw): {resultJson}";
                }
            }

            return "No tools available";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending prompt to MCP server");
            return $"Error communicating with MCP server: {ex.Message}";
        }
    }

    public async Task<string> CallToolAsync(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
    {
        return await CallToolAsync(serverInfo, toolName, parameters, null, cancellationToken);
    }

    public async Task<string> CallToolAsync(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, Dictionary<string, Dictionary<string, object>>? toolDefaults, CancellationToken cancellationToken = default)
    {
        try
        {
            // Merge tool defaults with provided parameters
            var mergedParameters = MergeToolDefaults(toolName, parameters, toolDefaults);
            
            // Convert string parameters to appropriate types for known parameter names
            var convertedParameters = ConvertParameterTypes(mergedParameters);
            
            _logger.LogDebug("Calling tool {ToolName} with parameters: {Parameters}", toolName, JsonSerializer.Serialize(convertedParameters));

            
            var toolRequest = new McpRequest
            {
                Method = "tools/call",
                Params = new
                {
                    name = toolName,
                    arguments = convertedParameters
                }
            };

            var response = await SendRequestAsync(serverInfo, toolRequest, cancellationToken);
            
            if (response.Error != null)
            {
                _logger.LogError("Tool {ToolName} returned error: {ErrorCode} - {ErrorMessage}", toolName, response.Error.Code, response.Error.Message);
                return $"Tool error: {response.Error.Message}";
            }

            var result = response.Result?.ToString() ?? "No result returned";
            _logger.LogDebug("Tool {ToolName} returned result: {ResultLength} characters", toolName, result.Length);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling tool {ToolName} with parameters {Parameters}", toolName, JsonSerializer.Serialize(parameters));
            return $"Error calling tool {toolName}: {ex.Message}";
        }
    }

    private Dictionary<string, object> MergeToolDefaults(string toolName, Dictionary<string, object> parameters, Dictionary<string, Dictionary<string, object>>? toolDefaults)
    {
        if (toolDefaults == null || !toolDefaults.TryGetValue(toolName, out var defaults))
        {
            return parameters;
        }

        var mergedParameters = new Dictionary<string, object>();
        
        // First, add all defaults
        foreach (var kvp in defaults)
        {
            mergedParameters[kvp.Key] = kvp.Value;
        }
        
        // Then, add/override with explicit parameters
        foreach (var kvp in parameters)
        {
            mergedParameters[kvp.Key] = kvp.Value;
        }

        _logger.LogDebug("Merged tool defaults for {ToolName}: {DefaultsCount} defaults, {ParametersCount} explicit parameters", 
            toolName, defaults.Count, parameters.Count);


        return mergedParameters;
    }

    private Dictionary<string, object> ConvertParameterTypes(Dictionary<string, object> parameters)
    {
        var convertedParameters = new Dictionary<string, object>();
        
        // Common parameter names that should be integers
        var integerParameters = new[]
        {
            "pullRequestId", "id", "requestId", "number", "count", "maxCount", "skip", "top", "port", "timeout"
        };

        // Common parameter names that should be booleans
        var booleanParameters = new[]
        {
            "includeDeleted", "includeLinks", "includeWorkItems", "ascending", "descending", "enabled", "disabled"
        };

        foreach (var kvp in parameters)
        {
            var key = kvp.Key;
            var value = kvp.Value;

            // Skip null values entirely
            if (value == null)
            {
                continue;
            }

            // Try to convert to integer if parameter name suggests it should be an integer
            if (integerParameters.Contains(key, StringComparer.OrdinalIgnoreCase))
            {
                if (value is string stringValue && int.TryParse(stringValue, out int intValue))
                {
                    convertedParameters[key] = intValue;
                    _logger.LogDebug("Converted parameter {Key} from string '{StringValue}' to integer {IntValue}", key, stringValue, intValue);
                }
                else if (value is int)
                {
                    convertedParameters[key] = value; // Already an integer
                }
                else
                {
                    convertedParameters[key] = value; // Keep original value if conversion fails
                }
            }
            // Try to convert to boolean if parameter name suggests it should be a boolean
            else if (booleanParameters.Contains(key, StringComparer.OrdinalIgnoreCase))
            {
                if (value is string stringValue && bool.TryParse(stringValue, out bool boolValue))
                {
                    convertedParameters[key] = boolValue;
                    _logger.LogDebug("Converted parameter {Key} from string '{StringValue}' to boolean {BoolValue}", key, stringValue, boolValue);
                }
                else if (value is bool)
                {
                    convertedParameters[key] = value; // Already a boolean
                }
                else
                {
                    convertedParameters[key] = value; // Keep original value if conversion fails
                }
            }
            else
            {
                convertedParameters[key] = value; // Keep original value
            }
        }

        return convertedParameters;
    }

    public async Task<IEnumerable<string>> GetAvailableToolsAsync(McpServerInfo serverInfo, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = new McpRequest
            {
                Method = "tools/list",
                Params = null
            };

            var response = await SendRequestAsync(serverInfo, request, cancellationToken);
            
            if (response.Error != null)
            {
                _logger.LogWarning("Error getting tools: {Error}", response.Error.Message);
                return Array.Empty<string>();
            }

            if (response.Result != null)
            {
                // Parse the MCP tools response format
                var resultJson = JsonSerializer.Serialize(response.Result);
                _logger.LogDebug("Tools response: {Response}", resultJson);
                
                try
                {
                    // Parse the MCP tools/list response format
                    var toolsResponse = JsonSerializer.Deserialize<JsonElement>(resultJson);
                    
                    if (toolsResponse.TryGetProperty("tools", out var toolsArray) && toolsArray.ValueKind == JsonValueKind.Array)
                    {
                        var toolNames = new List<string>();
                        
                        foreach (var tool in toolsArray.EnumerateArray())
                        {
                            if (tool.TryGetProperty("name", out var nameElement) && nameElement.ValueKind == JsonValueKind.String)
                            {
                                var toolName = nameElement.GetString();
                                if (!string.IsNullOrEmpty(toolName))
                                {
                                    toolNames.Add(toolName);
                                    _logger.LogDebug("Found tool: {ToolName}", toolName);
                                }
                            }
                        }
                        
                        return toolNames;
                    }
                    else
                    {
                        _logger.LogWarning("Tools response does not contain expected 'tools' array");
                        return Array.Empty<string>();
                    }
                }
                catch (JsonException ex)
                {
                    _logger.LogError(ex, "Error parsing tools response JSON: {Response}", resultJson);
                    return Array.Empty<string>();
                }
            }

            return Array.Empty<string>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting available tools");
            return Array.Empty<string>();
        }
    }

    public async Task<McpServerInfo> DiscoverServerConfigurationAsync(string repositoryPath)
    {
        try
        {
            var serverInfo = new McpServerInfo
            {
                Name = Path.GetFileName(repositoryPath),
                LocalPath = repositoryPath,
                Port = 3000
            };

            // Look for common MCP server configuration files
            var configFiles = new[]
            {
                "package.json",
                "mcp.json",
                "server.json",
                "pyproject.toml",
                "requirements.txt"
            };

            foreach (var configFile in configFiles)
            {
                var configPath = Path.Combine(repositoryPath, configFile);
                if (File.Exists(configPath))
                {
                    await AnalyzeConfigurationFileAsync(serverInfo, configPath);
                    break;
                }
            }

            // If no configuration found, try to detect based on file structure
            if (string.IsNullOrEmpty(serverInfo.StartCommand))
            {
                await DetectServerTypeAsync(serverInfo);
            }

            return serverInfo;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error discovering MCP server configuration");
            throw;
        }
    }

    private async Task AnalyzeConfigurationFileAsync(McpServerInfo serverInfo, string configPath)
    {
        try
        {
            var fileName = Path.GetFileName(configPath);
            var content = await File.ReadAllTextAsync(configPath);

            switch (fileName.ToLower())
            {
                case "package.json":
                    var packageJson = JsonSerializer.Deserialize<JsonElement>(content);
                    if (packageJson.TryGetProperty("scripts", out var scripts))
                    {
                        if (scripts.TryGetProperty("start", out var startScript))
                        {
                            var startCommand = startScript.GetString();
                            if (!string.IsNullOrEmpty(startCommand))
                            {
                                var parts = startCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                serverInfo.StartCommand = parts[0];
                                serverInfo.StartArguments = parts.Skip(1).ToArray();
                            }
                        }
                    }
                    break;

                case "mcp.json":
                case "server.json":
                    var mcpConfig = JsonSerializer.Deserialize<JsonElement>(content);
                    if (mcpConfig.TryGetProperty("command", out var command))
                    {
                        serverInfo.StartCommand = command.GetString() ?? "";
                    }
                    if (mcpConfig.TryGetProperty("args", out var args) && args.ValueKind == JsonValueKind.Array)
                    {
                        serverInfo.StartArguments = args.EnumerateArray()
                            .Select(x => x.GetString() ?? "")
                            .ToArray();
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error analyzing configuration file {ConfigPath}", configPath);
        }
    }

    private async Task DetectServerTypeAsync(McpServerInfo serverInfo)
    {
        try
        {
            var repositoryPath = serverInfo.LocalPath;

            // Check for Python MCP server
            if (File.Exists(Path.Combine(repositoryPath, "main.py")) || 
                File.Exists(Path.Combine(repositoryPath, "server.py")))
            {
                serverInfo.StartCommand = "python";
                serverInfo.StartArguments = new[] { File.Exists(Path.Combine(repositoryPath, "main.py")) ? "main.py" : "server.py" };
            }
            // Check for Node.js MCP server
            else if (File.Exists(Path.Combine(repositoryPath, "index.js")) || 
                     File.Exists(Path.Combine(repositoryPath, "server.js")))
            {
                serverInfo.StartCommand = "node";
                serverInfo.StartArguments = new[] { File.Exists(Path.Combine(repositoryPath, "index.js")) ? "index.js" : "server.js" };
            }
            // Check for .NET MCP server
            else
            {
                var restorePath = FindDotNetProjectPath(repositoryPath);
                if (!string.IsNullOrEmpty(restorePath))
                {
                    _logger.LogInformation("Detected .NET project at {ProjectPath}, running dotnet restore...", restorePath);
                    await RunDotnetRestoreAsync(restorePath);
                    
                    // Find the actual project directory for running the server
                    var projectFiles = Directory.GetFiles(repositoryPath, "*.csproj", SearchOption.AllDirectories);
                    if (projectFiles.Length > 0)
                    {
                        var projectDir = Path.GetDirectoryName(projectFiles[0]);
                        serverInfo.StartCommand = "dotnet";
                        serverInfo.StartArguments = new[] { "run" };
                        serverInfo.LocalPath = projectDir ?? repositoryPath; // Use the actual project directory
                        _logger.LogInformation("Will run dotnet run from {ProjectDir}", projectDir ?? repositoryPath);
                    }
                    else
                    {
                        serverInfo.StartCommand = "dotnet";
                        serverInfo.StartArguments = new[] { "run" };
                        serverInfo.LocalPath = restorePath;
                    }
                }
                else
                {
                    _logger.LogWarning("Could not detect MCP server type for {RepositoryPath}", repositoryPath);
                    serverInfo.StartCommand = "echo";
                    serverInfo.StartArguments = new[] { "Unknown server type" };
                }
            }

            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error detecting server type");
        }
    }

    private bool IsPortAvailable(int port)
    {
        try
        {
            using var client = new System.Net.Sockets.TcpClient();
            var result = client.BeginConnect("localhost", port, null, null);
            var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
            
            if (success)
            {
                client.EndConnect(result);
                return false; // Port is in use
            }
            
            return true; // Port is available
        }
        catch
        {
            return true; // Port is available
        }
    }

    private async Task<bool> IsServerRespondingAsync(int port, CancellationToken cancellationToken = default)
    {
        try
        {
            var url = $"http://localhost:{port}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(TimeSpan.FromSeconds(5));
            
            var response = await _httpClient.SendAsync(request, cts.Token);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    private async Task KillProcessUsingPortAsync(int port)
    {
        try
        {
            // This is a simplified implementation
            // In a real implementation, you'd use netstat or similar to find the process
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "Error killing process using port {Port}", port);
        }
    }

    private string? FindDotNetProjectPath(string repositoryPath)
    {
        try
        {
            // First check for solution files at the root (preferred)
            var solutionFiles = Directory.GetFiles(repositoryPath, "*.sln");
            if (solutionFiles.Length > 0)
            {
                _logger.LogInformation("Found .NET solution file: {SolutionFile}", solutionFiles[0]);
                return repositoryPath; // Return root path for solution
            }

            // Check for project files in the root directory
            if (Directory.GetFiles(repositoryPath, "*.csproj").Any())
            {
                return repositoryPath;
            }

            // Recursively search for .csproj files
            var projectFiles = Directory.GetFiles(repositoryPath, "*.csproj", SearchOption.AllDirectories);
            if (projectFiles.Length > 0)
            {
                // Return the directory containing the first .csproj file found
                var projectFile = projectFiles[0];
                var projectDir = Path.GetDirectoryName(projectFile);
                _logger.LogInformation("Found .NET project file: {ProjectFile}", projectFile);
                return projectDir;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching for .NET project in {RepositoryPath}", repositoryPath);
            return null;
        }
    }

    private async Task RunDotnetRestoreAsync(string repositoryPath)
    {
        try
        {
            _logger.LogInformation("Running 'dotnet restore' in {RepositoryPath}", repositoryPath);
            
            var startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "restore",
                WorkingDirectory = repositoryPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = startInfo };
            process.Start();
            
            var output = await process.StandardOutput.ReadToEndAsync();
            var error = await process.StandardError.ReadToEndAsync();
            
            await process.WaitForExitAsync();
            
            if (process.ExitCode != 0)
            {
                _logger.LogError("dotnet restore failed with exit code {ExitCode}. Error: {Error}", process.ExitCode, error);
                throw new InvalidOperationException($"dotnet restore failed: {error}");
            }
            
            _logger.LogInformation("dotnet restore completed successfully. Output: {Output}", output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error running dotnet restore in {RepositoryPath}", repositoryPath);
            throw new InvalidOperationException($"Failed to restore .NET packages: {ex.Message}", ex);
        }
    }
} 