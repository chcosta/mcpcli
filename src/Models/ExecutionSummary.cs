namespace McpCli.Models;

public class ExecutionSummary
{
    public string? AzureAiEndpoint { get; set; }
    public string? AzureAiModel { get; set; }
    public List<string> RepositoriesCloned { get; set; } = new();
    public List<string> McpServersUsed { get; set; } = new();
    public List<string> ConfigurationFilesRead { get; set; } = new();
    public List<string> PromptFilesRead { get; set; } = new();
    public List<string> OtherMarkdownFilesRead { get; set; } = new();
    public List<string> SystemPromptFilesRead { get; set; } = new();
    public List<string> PlanFilesRead { get; set; } = new();
    public List<string> StepResultFilesRead { get; set; } = new();
    public List<string> ToolsExecuted { get; set; } = new();
    public bool PreviewFeaturesEnabled { get; set; }
    public string? ExecutionMode { get; set; }

    // Performance tracking for multi-server operations
    public Dictionary<string, ServerPerformanceInfo> ServerPerformance { get; set; } = new();
    public List<ToolExecutionInfo> ToolExecutions { get; set; } = new();
    public DateTime ExecutionStartTime { get; set; } = DateTime.UtcNow;
    public DateTime? ExecutionEndTime { get; set; }
    public TimeSpan TotalExecutionTime => (ExecutionEndTime ?? DateTime.UtcNow) - ExecutionStartTime;

    public void AddRepositoryCloned(string repositoryUrl)
    {
        if (!string.IsNullOrEmpty(repositoryUrl) && !RepositoriesCloned.Contains(repositoryUrl))
        {
            RepositoriesCloned.Add(repositoryUrl);
        }
    }

    public void AddMcpServerUsed(string serverName)
    {
        if (!string.IsNullOrEmpty(serverName) && !McpServersUsed.Contains(serverName))
        {
            McpServersUsed.Add(serverName);
        }
    }

    public void AddConfigurationFileRead(string filePath)
    {
        if (!string.IsNullOrEmpty(filePath) && !ConfigurationFilesRead.Contains(filePath))
        {
            ConfigurationFilesRead.Add(filePath);
        }
    }

    public void AddPromptFileRead(string filePath)
    {
        if (!string.IsNullOrEmpty(filePath) && !PromptFilesRead.Contains(filePath))
        {
            PromptFilesRead.Add(filePath);
        }
    }

    public void AddOtherMarkdownFileRead(string filePath)
    {
        if (!string.IsNullOrEmpty(filePath) && !OtherMarkdownFilesRead.Contains(filePath))
        {
            OtherMarkdownFilesRead.Add(filePath);
        }
    }

    public void AddSystemPromptFileRead(string filePath)
    {
        if (!string.IsNullOrEmpty(filePath) && !SystemPromptFilesRead.Contains(filePath))
        {
            SystemPromptFilesRead.Add(filePath);
        }
    }

    public void AddPlanFileRead(string filePath)
    {
        if (!string.IsNullOrEmpty(filePath) && !PlanFilesRead.Contains(filePath))
        {
            PlanFilesRead.Add(filePath);
        }
    }

    public void AddStepResultFileRead(string filePath)
    {
        if (!string.IsNullOrEmpty(filePath) && !StepResultFilesRead.Contains(filePath))
        {
            StepResultFilesRead.Add(filePath);
        }
    }

    public void AddToolExecuted(string toolName)
    {
        if (!string.IsNullOrEmpty(toolName) && !ToolsExecuted.Contains(toolName))
        {
            ToolsExecuted.Add(toolName);
        }
    }

    // Enhanced performance tracking methods
    public void TrackServerStartup(string serverName, TimeSpan startupTime, bool successful)
    {
        if (!ServerPerformance.ContainsKey(serverName))
        {
            ServerPerformance[serverName] = new ServerPerformanceInfo
            {
                ServerName = serverName,
                StartupTime = startupTime,
                StartupSuccessful = successful,
                StartTime = DateTime.UtcNow
            };
        }
        else
        {
            ServerPerformance[serverName].StartupTime = startupTime;
            ServerPerformance[serverName].StartupSuccessful = successful;
        }
    }

    public void TrackToolExecution(string toolName, string serverName, TimeSpan executionTime, bool successful, string? error = null)
    {
        var toolExecution = new ToolExecutionInfo
        {
            ToolName = toolName,
            ServerName = serverName,
            ExecutionTime = executionTime,
            Successful = successful,
            Error = error,
            Timestamp = DateTime.UtcNow
        };

        ToolExecutions.Add(toolExecution);

        // Update server performance stats
        if (!ServerPerformance.ContainsKey(serverName))
        {
            ServerPerformance[serverName] = new ServerPerformanceInfo
            {
                ServerName = serverName,
                StartTime = DateTime.UtcNow
            };
        }

        var serverPerf = ServerPerformance[serverName];
        serverPerf.ToolsExecuted++;
        serverPerf.TotalToolExecutionTime += executionTime;
        
        if (successful)
        {
            serverPerf.SuccessfulToolExecutions++;
        }
        else
        {
            serverPerf.FailedToolExecutions++;
        }

        if (executionTime > serverPerf.SlowestToolExecutionTime)
        {
            serverPerf.SlowestToolExecutionTime = executionTime;
            serverPerf.SlowestTool = toolName;
        }

        if (serverPerf.FastestToolExecutionTime == TimeSpan.Zero || executionTime < serverPerf.FastestToolExecutionTime)
        {
            serverPerf.FastestToolExecutionTime = executionTime;
            serverPerf.FastestTool = toolName;
        }
    }

    public void TrackServerHealth(string serverName, bool isHealthy, TimeSpan responseTime)
    {
        if (!ServerPerformance.ContainsKey(serverName))
        {
            ServerPerformance[serverName] = new ServerPerformanceInfo
            {
                ServerName = serverName,
                StartTime = DateTime.UtcNow
            };
        }

        var serverPerf = ServerPerformance[serverName];
        serverPerf.IsHealthy = isHealthy;
        serverPerf.LastHealthCheckTime = DateTime.UtcNow;
        serverPerf.LastResponseTime = responseTime;
        serverPerf.HealthChecks++;

        if (isHealthy)
        {
            serverPerf.HealthyChecks++;
        }
    }

    public void CompleteExecution()
    {
        ExecutionEndTime = DateTime.UtcNow;
    }
}

public class ServerPerformanceInfo
{
    public string ServerName { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public TimeSpan StartupTime { get; set; }
    public bool StartupSuccessful { get; set; }
    public bool IsHealthy { get; set; } = true;
    public DateTime? LastHealthCheckTime { get; set; }
    public TimeSpan LastResponseTime { get; set; }
    public int HealthChecks { get; set; }
    public int HealthyChecks { get; set; }
    
    // Tool execution statistics
    public int ToolsExecuted { get; set; }
    public int SuccessfulToolExecutions { get; set; }
    public int FailedToolExecutions { get; set; }
    public TimeSpan TotalToolExecutionTime { get; set; }
    public TimeSpan FastestToolExecutionTime { get; set; }
    public TimeSpan SlowestToolExecutionTime { get; set; }
    public string? FastestTool { get; set; }
    public string? SlowestTool { get; set; }
    
    public double SuccessRate => ToolsExecuted > 0 ? (double)SuccessfulToolExecutions / ToolsExecuted * 100 : 0;
    public double HealthRate => HealthChecks > 0 ? (double)HealthyChecks / HealthChecks * 100 : 0;
    public TimeSpan AverageToolExecutionTime => ToolsExecuted > 0 ? 
        TimeSpan.FromMilliseconds(TotalToolExecutionTime.TotalMilliseconds / ToolsExecuted) : TimeSpan.Zero;
}

public class ToolExecutionInfo
{
    public string ToolName { get; set; } = string.Empty;
    public string ServerName { get; set; } = string.Empty;
    public TimeSpan ExecutionTime { get; set; }
    public bool Successful { get; set; }
    public string? Error { get; set; }
    public DateTime Timestamp { get; set; }
} 