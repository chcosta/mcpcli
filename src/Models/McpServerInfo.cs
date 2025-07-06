namespace McpCli.Models;

public class McpServerInfo
{
    public string Name { get; set; } = string.Empty;
    public string RepositoryUrl { get; set; } = string.Empty;
    public string LocalPath { get; set; } = string.Empty;
    public string StartCommand { get; set; } = string.Empty;
    public string[] StartArguments { get; set; } = Array.Empty<string>();
    public int Port { get; set; } = 3000;
    public bool IsRunning { get; set; } = false;
    public int? ProcessId { get; set; }
    public Dictionary<string, string> Environment { get; set; } = new();
} 