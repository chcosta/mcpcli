namespace McpCli.Models;

public class MarkdownConfig
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public AzureAiConfig AzureAi { get; set; } = new();
    
    // Multiple servers support
    public List<MultiMcpServerConfig> Servers { get; set; } = new();
    
    public List<string> DefaultPrompts { get; set; } = new();
    public Dictionary<string, string> Variables { get; set; } = new();
    public string AiPlanningPromptFile { get; set; } = string.Empty;
    public bool PreviewFeatures { get; set; } = false;
    public Dictionary<string, Dictionary<string, object>> ToolDefaults { get; set; } = new();
}

 