namespace McpCli.Services;

public interface ISystemPromptService
{
    Task<string> LoadPromptAsync(string promptFilePath, Models.ExecutionSummary? executionSummary = null);
    Task<string> ProcessPromptAsync(string promptFilePath, Dictionary<string, string> variables, Models.ExecutionSummary? executionSummary = null);
    Task<bool> ValidatePromptFileAsync(string promptFilePath, Models.ExecutionSummary? executionSummary = null);
} 