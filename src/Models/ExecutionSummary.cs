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
    public List<string> ToolsExecuted { get; set; } = new();
    public bool PreviewFeaturesEnabled { get; set; }
    public string? ExecutionMode { get; set; }

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

    public void AddToolExecuted(string toolName)
    {
        if (!string.IsNullOrEmpty(toolName) && !ToolsExecuted.Contains(toolName))
        {
            ToolsExecuted.Add(toolName);
        }
    }
} 