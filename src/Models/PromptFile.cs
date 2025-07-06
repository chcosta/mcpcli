namespace McpCli.Models;

public class PromptFile
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Version { get; set; } = "1.0";
    public List<string> Tags { get; set; } = new();
    public Dictionary<string, string> Variables { get; set; } = new();
    public List<PromptStep> Steps { get; set; } = new();
    public string Context { get; set; } = string.Empty;
    public string ExpectedOutput { get; set; } = string.Empty;
}

public class PromptStep
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Instruction { get; set; } = string.Empty;
    public List<string> RequiredTools { get; set; } = new();
    public Dictionary<string, object> Parameters { get; set; } = new();
    public bool WaitForConfirmation { get; set; } = false;
    public string ExpectedResult { get; set; } = string.Empty;
} 