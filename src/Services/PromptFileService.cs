using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class PromptFileService : IPromptFileService
{
    private readonly ILogger<PromptFileService> _logger;
    private readonly IRepositoryRootService _repositoryRootService;

    public PromptFileService(ILogger<PromptFileService> logger, IRepositoryRootService repositoryRootService)
    {
        _logger = logger;
        _repositoryRootService = repositoryRootService;
    }

    public async Task<PromptFile> ParsePromptFileAsync(string filePath)
    {
        try
        {
            // Resolve relative paths relative to repository root
            var resolvedFilePath = _repositoryRootService.IsRelativePath(filePath) 
                ? _repositoryRootService.ResolvePath(filePath) 
                : filePath;

            var content = await File.ReadAllTextAsync(resolvedFilePath);
            var promptFile = new PromptFile();

            // Parse YAML frontmatter
            var frontmatterMatch = Regex.Match(content, @"^---\s*\n(.*?)\n---\s*\n", RegexOptions.Singleline);
            if (frontmatterMatch.Success)
            {
                var yamlContent = frontmatterMatch.Groups[1].Value;
                ParseYamlFrontmatter(promptFile, yamlContent);
                content = content.Substring(frontmatterMatch.Length);
            }

            // Parse markdown content
            ParseMarkdownContent(promptFile, content);

            _logger.LogInformation("Parsed prompt file: {Title}", promptFile.Title);
            return promptFile;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing prompt file {FilePath}", filePath);
            throw;
        }
    }

    public async Task<bool> ValidatePromptFileAsync(string filePath)
    {
        try
        {
            var promptFile = await ParsePromptFileAsync(filePath);
            
            // Basic validation
            if (string.IsNullOrEmpty(promptFile.Title))
            {
                _logger.LogWarning("Prompt file missing title: {FilePath}", filePath);
                return false;
            }

            if (promptFile.Steps.Count == 0 && string.IsNullOrEmpty(promptFile.Context))
            {
                _logger.LogWarning("Prompt file has no steps or context: {FilePath}", filePath);
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating prompt file {FilePath}", filePath);
            return false;
        }
    }

    public async Task<string> ProcessPromptFileAsync(PromptFile promptFile, Dictionary<string, string>? variableOverrides = null)
    {
        try
        {
            var variables = new Dictionary<string, string>(promptFile.Variables);
            
            // Apply variable overrides
            if (variableOverrides != null)
            {
                foreach (var kvp in variableOverrides)
                {
                    variables[kvp.Key] = kvp.Value;
                }
            }

            var processedContent = promptFile.Context;

            // Replace variables in context
            foreach (var variable in variables)
            {
                processedContent = processedContent.Replace($"{{{variable.Key}}}", variable.Value);
            }

            // If there are steps, format them into a comprehensive prompt
            if (promptFile.Steps.Count > 0)
            {
                var stepsContent = "\n\n## Sequential Steps:\n\n";
                for (int i = 0; i < promptFile.Steps.Count; i++)
                {
                    var step = promptFile.Steps[i];
                    stepsContent += $"### Step {i + 1}: {step.Name}\n";
                    
                    if (!string.IsNullOrEmpty(step.Description))
                    {
                        stepsContent += $"**Description**: {step.Description}\n\n";
                    }
                    
                    stepsContent += $"**Instruction**: {step.Instruction}\n\n";
                    
                    if (step.RequiredTools.Count > 0)
                    {
                        stepsContent += $"**Required Tools**: {string.Join(", ", step.RequiredTools)}\n\n";
                    }
                    
                    if (step.Parameters.Count > 0)
                    {
                        stepsContent += $"**Parameters**: {JsonSerializer.Serialize(step.Parameters, new JsonSerializerOptions { WriteIndented = true })}\n\n";
                    }
                    
                    if (!string.IsNullOrEmpty(step.ExpectedResult))
                    {
                        stepsContent += $"**Expected Result**: {step.ExpectedResult}\n\n";
                    }
                    
                    stepsContent += "---\n\n";
                }
                
                processedContent += stepsContent;
            }

            // Replace variables in the final content
            foreach (var variable in variables)
            {
                processedContent = processedContent.Replace($"{{{variable.Key}}}", variable.Value);
            }

            // Add a small async operation to make this truly async
            await Task.Yield();
            return processedContent;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing prompt file");
            throw;
        }
    }

    public async Task<List<string>> GetAvailablePromptFilesAsync(string directory)
    {
        try
        {
            // Resolve relative paths relative to repository root
            var resolvedDirectory = _repositoryRootService.IsRelativePath(directory) 
                ? _repositoryRootService.ResolvePath(directory) 
                : directory;

            if (!Directory.Exists(resolvedDirectory))
            {
                return new List<string>();
            }

            // Make this truly async by using Task.Run for the file system operations
            var files = await Task.Run(() => 
                Directory.GetFiles(resolvedDirectory, "*.md", SearchOption.AllDirectories)
                    .Where(f => Path.GetFileName(f).StartsWith("prompt-") || 
                               Path.GetFileName(f).Contains("prompt"))
                    .ToList());

            _logger.LogInformation("Found {Count} prompt files in {Directory}", files.Count, resolvedDirectory);
            return files;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting prompt files from {Directory}", directory);
            return new List<string>();
        }
    }

    private void ParseYamlFrontmatter(PromptFile promptFile, string yamlContent)
    {
        var lines = yamlContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var currentStep = new PromptStep();
        var inSteps = false;

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#"))
                continue;

            if (trimmedLine.StartsWith("steps:"))
            {
                inSteps = true;
                continue;
            }

            if (inSteps)
            {
                if (trimmedLine.StartsWith("- name:") || trimmedLine.StartsWith("  - name:"))
                {
                    // Save previous step if exists
                    if (!string.IsNullOrEmpty(currentStep.Name))
                    {
                        promptFile.Steps.Add(currentStep);
                    }
                    currentStep = new PromptStep();
                    currentStep.Name = ExtractValue(trimmedLine);
                }
                else if (trimmedLine.StartsWith("  description:") || trimmedLine.StartsWith("    description:"))
                {
                    currentStep.Description = ExtractValue(trimmedLine);
                }
                else if (trimmedLine.StartsWith("  instruction:") || trimmedLine.StartsWith("    instruction:"))
                {
                    currentStep.Instruction = ExtractValue(trimmedLine);
                }
                else if (trimmedLine.StartsWith("  required_tools:") || trimmedLine.StartsWith("    required_tools:"))
                {
                    // Handle array values
                    var toolsValue = ExtractValue(trimmedLine);
                    if (!string.IsNullOrEmpty(toolsValue))
                    {
                        currentStep.RequiredTools = toolsValue.Split(',').Select(t => t.Trim()).ToList();
                    }
                }
                continue;
            }

            var colonIndex = trimmedLine.IndexOf(':');
            if (colonIndex > 0)
            {
                var key = trimmedLine.Substring(0, colonIndex).Trim();
                var value = trimmedLine.Substring(colonIndex + 1).Trim();

                switch (key.ToLower())
                {
                    case "title":
                        promptFile.Title = value;
                        break;
                    case "description":
                        promptFile.Description = value;
                        break;
                    case "version":
                        promptFile.Version = value;
                        break;
                    case "tags":
                        promptFile.Tags = value.Split(',').Select(t => t.Trim()).ToList();
                        break;
                    case "expected_output":
                        promptFile.ExpectedOutput = value;
                        break;
                    default:
                        // Treat as variable
                        promptFile.Variables[key] = value;
                        break;
                }
            }
        }

        // Add the last step if exists
        if (inSteps && !string.IsNullOrEmpty(currentStep.Name))
        {
            promptFile.Steps.Add(currentStep);
        }
    }

    private void ParseMarkdownContent(PromptFile promptFile, string content)
    {
        // Extract context from the main markdown content
        var lines = content.Split('\n');
        var contextLines = new List<string>();
        bool inCodeBlock = false;

        foreach (var line in lines)
        {
            if (line.Trim().StartsWith("```"))
            {
                inCodeBlock = !inCodeBlock;
                continue;
            }

            if (!inCodeBlock)
            {
                contextLines.Add(line);
            }
        }

        promptFile.Context = string.Join('\n', contextLines).Trim();
    }

    private string ExtractValue(string line)
    {
        var colonIndex = line.IndexOf(':');
        if (colonIndex > 0 && colonIndex < line.Length - 1)
        {
            return line.Substring(colonIndex + 1).Trim().Trim('"');
        }
        return string.Empty;
    }
} 