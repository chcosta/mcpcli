namespace McpCli.Models;

public class MultiMcpServerConfig
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "git" or "http"
    public string Url { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public bool AutoStart { get; set; } = true;
    public int Port { get; set; } = 3000;
    public string? StartCommand { get; set; }
    public string? StartArguments { get; set; }
    public Dictionary<string, string> Environment { get; set; } = new();
    public Dictionary<string, Dictionary<string, object>> ToolDefaults { get; set; } = new();
    public string? Description { get; set; }
    public List<string> Tags { get; set; } = new();
    
    // HTTP-specific properties
    public Dictionary<string, string> Headers { get; set; } = new();
    public string? AuthType { get; set; } // "bearer", "basic", "apikey", etc.
    public string? AuthToken { get; set; }
    
    // Git-specific properties  
    public string? Branch { get; set; }
    public string? LocalPath { get; set; }
} 