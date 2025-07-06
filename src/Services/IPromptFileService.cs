using McpCli.Models;

namespace McpCli.Services;

public interface IPromptFileService
{
    Task<PromptFile> ParsePromptFileAsync(string filePath);
    Task<bool> ValidatePromptFileAsync(string filePath);
    Task<string> ProcessPromptFileAsync(PromptFile promptFile, Dictionary<string, string>? variableOverrides = null);
    Task<List<string>> GetAvailablePromptFilesAsync(string directory);
} 