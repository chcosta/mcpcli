using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace McpCli.Services;

public class SystemPromptService : ISystemPromptService
{
    private readonly ILogger<SystemPromptService> _logger;
    private readonly IMarkdownConfigService _markdownConfigService;
    private readonly IRepositoryRootService _repositoryRootService;

    public SystemPromptService(ILogger<SystemPromptService> logger, IMarkdownConfigService markdownConfigService, IRepositoryRootService repositoryRootService)
    {
        _logger = logger;
        _markdownConfigService = markdownConfigService;
        _repositoryRootService = repositoryRootService;
    }

    public async Task<string> LoadPromptAsync(string promptFilePath, Models.ExecutionSummary? executionSummary = null)
    {
        try
        {
            // Resolve relative paths relative to repository root
            var resolvedFilePath = _repositoryRootService.IsRelativePath(promptFilePath) 
                ? _repositoryRootService.ResolvePath(promptFilePath) 
                : promptFilePath;

            if (!File.Exists(resolvedFilePath))
            {
                throw new FileNotFoundException($"Prompt file not found: {resolvedFilePath}");
            }

            // Track file read in execution summary
            executionSummary?.AddSystemPromptFileRead(resolvedFilePath);

            var content = await File.ReadAllTextAsync(resolvedFilePath);
            
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

    public async Task<string> ProcessPromptAsync(string promptFilePath, Dictionary<string, string> variables, Models.ExecutionSummary? executionSummary = null)
    {
        try
        {
            var promptContent = await LoadPromptAsync(promptFilePath, executionSummary);
            
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

    public async Task<bool> ValidatePromptFileAsync(string promptFilePath, Models.ExecutionSummary? executionSummary = null)
    {
        try
        {
            // Resolve relative paths relative to repository root
            var resolvedFilePath = _repositoryRootService.IsRelativePath(promptFilePath) 
                ? _repositoryRootService.ResolvePath(promptFilePath) 
                : promptFilePath;

            if (!File.Exists(resolvedFilePath))
            {
                _logger.LogWarning("Prompt file not found: {PromptFilePath}", resolvedFilePath);
                return false;
            }

            // Track file read in execution summary
            executionSummary?.AddSystemPromptFileRead(resolvedFilePath);

            var content = await File.ReadAllTextAsync(resolvedFilePath);
            
            // Check if it has YAML frontmatter
            var frontmatterMatch = Regex.Match(content, @"^---\s*\n(.*?)\n---\s*\n", RegexOptions.Singleline);
            if (!frontmatterMatch.Success)
            {
                _logger.LogWarning("Prompt file missing YAML frontmatter: {PromptFilePath}", resolvedFilePath);
                return false;
            }

            // Check if it has content after frontmatter
            var promptContent = content.Substring(frontmatterMatch.Length).Trim();
            if (string.IsNullOrEmpty(promptContent))
            {
                _logger.LogWarning("Prompt file has no content after frontmatter: {PromptFilePath}", resolvedFilePath);
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