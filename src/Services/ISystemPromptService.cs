namespace McpCli.Services;

public interface ISystemPromptService
{
    Task<string> LoadPromptAsync(string promptFilePath);
    Task<string> ProcessPromptAsync(string promptFilePath, Dictionary<string, string> variables);
    Task<bool> ValidatePromptFileAsync(string promptFilePath);
} 