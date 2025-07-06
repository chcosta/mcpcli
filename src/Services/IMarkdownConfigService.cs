using McpCli.Models;

namespace McpCli.Services;

public interface IMarkdownConfigService
{
    Task<MarkdownConfig> ParseMarkdownConfigAsync(string filePath);
    Task<MarkdownConfig> ParseMarkdownConfigFromContentAsync(string content);
    Task<bool> ValidateMarkdownConfigAsync(string filePath);
    Task<string> GenerateTemplateAsync(string name, string description = "");
    Task<string> GenerateTemplateFromConfigAsync(string name, string description, IConfigurationService configurationService);
    Task SaveMarkdownConfigAsync(MarkdownConfig config, string filePath);
} 