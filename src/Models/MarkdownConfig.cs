namespace McpCli.Models;

public class MarkdownConfig
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public AzureAiConfig AzureAi { get; set; } = new();
    public string RepositoryUrl { get; set; } = string.Empty;
    public McpServerConfig McpServer { get; set; } = new();
    public List<string> DefaultPrompts { get; set; } = new();
    public Dictionary<string, string> Variables { get; set; } = new();
    public string AiPlanningPromptFile { get; set; } = string.Empty;
    public bool PreviewFeatures { get; set; } = false;
    public Dictionary<string, Dictionary<string, object>> ToolDefaults { get; set; } = new();
}

public class McpServerConfig
{
    public string StartCommand { get; set; } = string.Empty;
    public string[] StartArguments { get; set; } = Array.Empty<string>();
    public int Port { get; set; } = 3000;
    public Dictionary<string, string> Environment { get; set; } = new();
    public string WorkingDirectory { get; set; } = string.Empty;
    public bool AutoStart { get; set; } = true;
} 