namespace McpCli.Models;

public class McpCliConfig
{
    public AzureAiConfig AzureAi { get; set; } = new();
    public AzureDevOpsConfig AzureDevOps { get; set; } = new();
    public McpConfig Mcp { get; set; } = new();
}

public class AzureAiConfig
{
    public string Endpoint { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string DeploymentName { get; set; } = string.Empty;
    public string ModelName { get; set; } = "gpt-4";
    public bool UseManagedIdentity { get; set; } = false;
}

public class AzureDevOpsConfig
{
    public string Organization { get; set; } = string.Empty;
    public string PersonalAccessToken { get; set; } = string.Empty;
    public string DefaultProject { get; set; } = string.Empty;
    public bool UseManagedIdentity { get; set; } = false;
}

public class McpConfig
{
    public string WorkingDirectory { get; set; } = "./mcp-servers";
    public int DefaultPort { get; set; } = 3000;
    public int TimeoutSeconds { get; set; } = 30;
    public bool AutoCleanup { get; set; } = true;
} 