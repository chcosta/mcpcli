using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace McpCli.Services;

public class SystemPromptService : ISystemPromptService
{
    private readonly ILogger<SystemPromptService> _logger;
    private readonly IMarkdownConfigService _markdownConfigService;

    public SystemPromptService(ILogger<SystemPromptService> logger, IMarkdownConfigService markdownConfigService)
    {
        _logger = logger;
        _markdownConfigService = markdownConfigService;
    }

    public async Task<string> LoadPromptAsync(string promptFilePath)
    {
        try
        {
            if (!File.Exists(promptFilePath))
            {
                throw new FileNotFoundException($"Prompt file not found: {promptFilePath}");
            }

            var content = await File.ReadAllTextAsync(promptFilePath);
            
            // Extract the prompt content (everything after YAML frontmatter)
            var frontmatterMatch = Regex.Match(content, @"^---\s*\n(.*?)\n---\s*\n", RegexOptions.Singleline);
            if (frontmatterMatch.Success)
            {
                content = content.Substring(frontmatterMatch.Length);
            }

            // Remove markdown headers and return clean content
            content = Regex.Replace(content, @"^#+\s*.*$", "", RegexOptions.Multiline);
            content = content.Trim();

            return content;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading prompt from {PromptFilePath}", promptFilePath);
            throw;
        }
    }

    public async Task<string> ProcessPromptAsync(string promptFilePath, Dictionary<string, string> variables)
    {
        try
        {
            var promptContent = await LoadPromptAsync(promptFilePath);
            
            // Replace variables in the format {{VARIABLE_NAME}}
            foreach (var variable in variables)
            {
                var placeholder = $"{{{{{variable.Key}}}}}";
                promptContent = promptContent.Replace(placeholder, variable.Value);
            }

            // Log any remaining unresolved variables
            var unresolvedVariables = Regex.Matches(promptContent, @"\{\{([^}]+)\}\}");
            if (unresolvedVariables.Count > 0)
            {
                var unresolvedList = unresolvedVariables.Cast<Match>().Select(m => m.Groups[1].Value).Distinct();
                _logger.LogWarning("Unresolved variables in prompt: {Variables}", string.Join(", ", unresolvedList));
            }

            return promptContent;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing prompt from {PromptFilePath}", promptFilePath);
            throw;
        }
    }

    public async Task<bool> ValidatePromptFileAsync(string promptFilePath)
    {
        try
        {
            if (!File.Exists(promptFilePath))
            {
                _logger.LogWarning("Prompt file not found: {PromptFilePath}", promptFilePath);
                return false;
            }

            var content = await File.ReadAllTextAsync(promptFilePath);
            
            // Check if it has YAML frontmatter
            var frontmatterMatch = Regex.Match(content, @"^---\s*\n(.*?)\n---\s*\n", RegexOptions.Singleline);
            if (!frontmatterMatch.Success)
            {
                _logger.LogWarning("Prompt file missing YAML frontmatter: {PromptFilePath}", promptFilePath);
                return false;
            }

            // Check if it has content after frontmatter
            var promptContent = content.Substring(frontmatterMatch.Length).Trim();
            if (string.IsNullOrEmpty(promptContent))
            {
                _logger.LogWarning("Prompt file has no content after frontmatter: {PromptFilePath}", promptFilePath);
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating prompt file {PromptFilePath}", promptFilePath);
            return false;
        }
    }
} 