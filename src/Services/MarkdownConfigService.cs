using System.Text.RegularExpressions;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class MarkdownConfigService : IMarkdownConfigService
{
    private readonly ILogger<MarkdownConfigService> _logger;
    private readonly IEnvironmentVariableService _environmentVariableService;

    public MarkdownConfigService(ILogger<MarkdownConfigService> logger, IEnvironmentVariableService environmentVariableService)
    {
        _logger = logger;
        _environmentVariableService = environmentVariableService;
    }

    public async Task<MarkdownConfig> ParseMarkdownConfigAsync(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {filePath}");
            }

            var content = await File.ReadAllTextAsync(filePath);
            return await ParseMarkdownConfigFromContentAsync(content);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing markdown config from file {FilePath}", filePath);
            throw;
        }
    }

    public async Task<MarkdownConfig> ParseMarkdownConfigFromContentAsync(string content)
    {
        try
        {
            var config = new MarkdownConfig();
            
            // Parse YAML frontmatter if present
            var frontmatterMatch = Regex.Match(content, @"^---\s*\n(.*?)\n---\s*\n", RegexOptions.Singleline);
            if (frontmatterMatch.Success)
            {
                var yamlContent = frontmatterMatch.Groups[1].Value;
                ParseYamlFrontmatter(config, yamlContent);
                
                // Remove frontmatter from content
                content = content.Substring(frontmatterMatch.Length);
            }

            // Parse markdown sections
            await ParseMarkdownSectionsAsync(config, content);

            // Validate secret fields before resolving environment variables
            if (!_environmentVariableService.ValidateSecretFields(config, out var validationErrors))
            {
                var errorMessage = "Configuration validation failed:\n" + string.Join("\n", validationErrors);
                _logger.LogError("Secret field validation failed: {ErrorMessage}", errorMessage);
                throw new InvalidOperationException(errorMessage);
            }

            // Resolve environment variables in the configuration
            _environmentVariableService.ResolveEnvironmentVariablesInObject(config);

            return config;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing markdown config from content");
            throw;
        }
    }

    public async Task<bool> ValidateMarkdownConfigAsync(string filePath)
    {
        try
        {
            var config = await ParseMarkdownConfigAsync(filePath);
            
            // Validate required fields
            if (string.IsNullOrEmpty(config.AzureAi.Endpoint))
            {
                _logger.LogWarning("Azure AI endpoint is required");
                return false;
            }

            if (string.IsNullOrEmpty(config.AzureAi.ApiKey) && !config.AzureAi.UseManagedIdentity)
            {
                _logger.LogWarning("Azure AI API key or managed identity is required");
                return false;
            }

            if (string.IsNullOrEmpty(config.RepositoryUrl))
            {
                _logger.LogWarning("Repository URL is required");
                return false;
            }

            return true;
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("Configuration validation failed"))
        {
            _logger.LogError("Secret field validation failed: {ErrorMessage}", ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating markdown config");
            return false;
        }
    }

    public async Task<string> GenerateTemplateAsync(string name, string description = "")
    {
        var template = $@"---
name: {name}
description: {description}
preview_features: false
azure_ai:
  endpoint: ""${{AZURE_AI_ENDPOINT}}""
  api_key: ""${{AZURE_AI_API_KEY}}""
  deployment_name: ""${{AZURE_AI_DEPLOYMENT_NAME}}""
  model_name: ""${{AZURE_AI_MODEL_NAME:gpt-4}}""
  use_managed_identity: false
repository_url: ""https://dev.azure.com/${{AZURE_DEVOPS_ORG}}/${{AZURE_DEVOPS_PROJECT}}/_git/your-mcp-server""
mcp_server:
  port: 3000
  auto_start: true
  environment:
    NODE_ENV: ""production""
ai_planning_prompt_file: ""system-prompts/ai-planning-prompt.md""
variables:
  custom_var: ""${{CUSTOM_VARIABLE:default-value}}""
tool_defaults:
  initialize_azure_dev_ops_client:
    organizationUrl: ""dnceng""
  get_repositories:
    projectName: ""internal""
---

# {name}

{(string.IsNullOrEmpty(description) ? "MCP CLI Configuration" : description)}

## Environment Variables Required

Before using this configuration, set the following environment variables:

### Azure AI Configuration
```bash
# Windows (Command Prompt)
set AZURE_AI_ENDPOINT=https://your-resource.openai.azure.com/
set AZURE_AI_API_KEY=your-api-key-here
set AZURE_AI_DEPLOYMENT_NAME=your-deployment-name
set AZURE_AI_MODEL_NAME=gpt-4

# Windows (PowerShell)
$env:AZURE_AI_ENDPOINT=""https://your-resource.openai.azure.com/""
$env:AZURE_AI_API_KEY=""your-api-key-here""
$env:AZURE_AI_DEPLOYMENT_NAME=""your-deployment-name""
$env:AZURE_AI_MODEL_NAME=""gpt-4""

# Unix/Linux/macOS
export AZURE_AI_ENDPOINT=""https://your-resource.openai.azure.com/""
export AZURE_AI_API_KEY=""your-api-key-here""
export AZURE_AI_DEPLOYMENT_NAME=""your-deployment-name""
export AZURE_AI_MODEL_NAME=""gpt-4""
```

### Azure DevOps Configuration
```bash
# Windows (Command Prompt)
set AZURE_DEVOPS_ORG=your-organization
set AZURE_DEVOPS_PROJECT=your-project

# Windows (PowerShell)
$env:AZURE_DEVOPS_ORG=""your-organization""
$env:AZURE_DEVOPS_PROJECT=""your-project""

# Unix/Linux/macOS
export AZURE_DEVOPS_ORG=""your-organization""
export AZURE_DEVOPS_PROJECT=""your-project""
```

## Tool Defaults

The `tool_defaults` section allows you to specify default parameter values for MCP tools. These defaults are automatically applied when tools are called without those parameters explicitly provided.

Example:
```yaml
tool_defaults:
  initialize_azure_dev_ops_client:
    organizationUrl: ""dnceng""
  get_repositories:
    projectName: ""internal""
```

With these defaults:
- When you run ""initialize azure devops client"", it will automatically use organizationUrl=""dnceng""
- When you run ""list repositories"", it will automatically use projectName=""internal""
- Explicit parameters always override defaults

## Security Benefits

Using environment variables instead of hardcoded secrets provides:
- **Security**: Secrets are not stored in configuration files
- **Flexibility**: Different environments can use different values
- **Version Control Safety**: Configuration files can be safely committed
- **Team Sharing**: Team members can use the same config with their own secrets

## Environment Variable Formats

This configuration supports multiple environment variable formats:
- `${{VAR_NAME}}` - Unix/Linux style with braces
- `${{VAR_NAME:default}}` - With default value
- `%VAR_NAME%` - Windows style
- `$VAR_NAME` - Simple Unix style

## Azure DevOps Authentication

Configure Azure DevOps authentication in your main configuration:
- **Personal Access Token**: mcpcli config set --key ""AzureDevOps.PersonalAccessToken"" --value ""${{AZURE_DEVOPS_PAT}}""
- **Managed Identity**: mcpcli config set --key ""AzureDevOps.UseManagedIdentity"" --value ""true""

## Default Prompts

You can add default prompts below that will be available for quick execution:

### Example Prompt 1
```
What is the current status of the system?
```

### Example Prompt 2
```
Generate a summary of recent activities
```

## Variables

Use the variables section to define reusable values that can be referenced in prompts or configuration.
Environment variables can also be used in the variables section.
";

        return await Task.FromResult(template);
    }

    public async Task<string> GenerateTemplateFromConfigAsync(string name, string description, IConfigurationService configurationService)
    {
        try
        {
            var config = await configurationService.LoadConfigurationAsync();
            
            // Create safe values for secrets (replace with environment variable references)
            var safeApiKey = "${AZURE_AI_API_KEY}";
            var safeOrg = string.IsNullOrEmpty(config.AzureDevOps.Organization) ? "${AZURE_DEVOPS_ORG}" : config.AzureDevOps.Organization;
            var safeProject = string.IsNullOrEmpty(config.AzureDevOps.DefaultProject) ? "${AZURE_DEVOPS_PROJECT}" : config.AzureDevOps.DefaultProject;
            var safeEndpoint = string.IsNullOrEmpty(config.AzureAi.Endpoint) ? "${AZURE_AI_ENDPOINT}" : config.AzureAi.Endpoint;
            var safeDeployment = string.IsNullOrEmpty(config.AzureAi.DeploymentName) ? "${AZURE_AI_DEPLOYMENT_NAME}" : config.AzureAi.DeploymentName;
            var safeModel = string.IsNullOrEmpty(config.AzureAi.ModelName) ? "${AZURE_AI_MODEL_NAME:gpt-4}" : config.AzureAi.ModelName;

            var template = $@"---
name: {name}
description: {description}
azure_ai:
  endpoint: ""{safeEndpoint}""
  api_key: ""{safeApiKey}""
  deployment_name: ""{safeDeployment}""
  model_name: ""{safeModel}""
  use_managed_identity: {config.AzureAi.UseManagedIdentity.ToString().ToLower()}
repository_url: ""https://dev.azure.com/{safeOrg}/{safeProject}/_git/your-mcp-server""
mcp_server:
  port: {config.Mcp.DefaultPort}
  auto_start: true
  environment:
    NODE_ENV: ""production""
ai_planning_prompt_file: ""system-prompts/ai-planning-prompt.md""
variables:
  working_directory: ""{config.Mcp.WorkingDirectory}""
  timeout_seconds: {config.Mcp.TimeoutSeconds}
  azure_devops_org: ""{safeOrg}""
  azure_devops_project: ""{safeProject}""
  use_managed_identity: {config.AzureDevOps.UseManagedIdentity.ToString().ToLower()}
---

# {name}

{(string.IsNullOrEmpty(description) ? "MCP CLI Configuration" : description)}

## Environment Variables Required

Before using this configuration, set the following environment variables:

### Azure AI Configuration
```bash
# Windows (Command Prompt)
set AZURE_AI_ENDPOINT={safeEndpoint}
set AZURE_AI_API_KEY=your-api-key-here
set AZURE_AI_DEPLOYMENT_NAME={safeDeployment}
set AZURE_AI_MODEL_NAME={safeModel}

# Windows (PowerShell)
$env:AZURE_AI_ENDPOINT=""{safeEndpoint}""
$env:AZURE_AI_API_KEY=""your-api-key-here""
$env:AZURE_AI_DEPLOYMENT_NAME=""{safeDeployment}""
$env:AZURE_AI_MODEL_NAME=""{safeModel}""

# Unix/Linux/macOS
export AZURE_AI_ENDPOINT=""{safeEndpoint}""
export AZURE_AI_API_KEY=""your-api-key-here""
export AZURE_AI_DEPLOYMENT_NAME=""{safeDeployment}""
export AZURE_AI_MODEL_NAME=""{safeModel}""
```

### Azure DevOps Configuration
```bash
# Windows (Command Prompt)
set AZURE_DEVOPS_ORG={safeOrg}
set AZURE_DEVOPS_PROJECT={safeProject}

# Windows (PowerShell)
$env:AZURE_DEVOPS_ORG=""{safeOrg}""
$env:AZURE_DEVOPS_PROJECT=""{safeProject}""

# Unix/Linux/macOS
export AZURE_DEVOPS_ORG=""{safeOrg}""
export AZURE_DEVOPS_PROJECT=""{safeProject}""
```

## Security Benefits

Using environment variables instead of hardcoded secrets provides:
- **Security**: Secrets are not stored in configuration files
- **Flexibility**: Different environments can use different values
- **Version Control Safety**: Configuration files can be safely committed
- **Team Sharing**: Team members can use the same config with their own secrets

## Current Configuration

**Azure AI Configuration**:
- **Endpoint**: {safeEndpoint}
- **Authentication**: {(config.AzureAi.UseManagedIdentity ? "Using managed identity" : "API key from environment variable")}
- **Deployment**: {safeDeployment}
- **Model**: {safeModel}
- **Use Managed Identity**: {config.AzureAi.UseManagedIdentity}

**Azure DevOps Configuration**:
- **Organization**: {safeOrg}
- **Default Project**: {safeProject}
- **Authentication Method**: {(config.AzureDevOps.UseManagedIdentity ? "Managed Identity" : "Personal Access Token from environment variable")}

## Azure DevOps Authentication

Configure Azure DevOps authentication in your main configuration:
- **Personal Access Token**: mcpcli config set --key ""AzureDevOps.PersonalAccessToken"" --value ""${{AZURE_DEVOPS_PAT}}""
- **Managed Identity**: mcpcli config set --key ""AzureDevOps.UseManagedIdentity"" --value ""true""

## MCP Server Configuration

- **Port**: {config.Mcp.DefaultPort}
- **Working Directory**: {config.Mcp.WorkingDirectory}
- **Timeout**: {config.Mcp.TimeoutSeconds} seconds
- **Auto Cleanup**: {config.Mcp.AutoCleanup}

## Default Prompts

You can add default prompts below that will be available for quick execution:

### Example Prompt 1
```
What is the current status of the system?
```

### Example Prompt 2
```
Generate a summary of recent activities
```

## Variables

Use the variables section to define reusable values that can be referenced in prompts or configuration.
Current configuration values are included as variables for reference.
";

            return await Task.FromResult(template);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating template from current configuration");
            // Fall back to default template
            return await GenerateTemplateAsync(name, description);
        }
    }

    public async Task SaveMarkdownConfigAsync(MarkdownConfig config, string filePath)
    {
        try
        {
            var template = await GenerateTemplateAsync(config.Name, config.Description);
            
            // Replace template values with actual config values
            template = template.Replace("\"https://your-resource.openai.azure.com/\"", $"\"{config.AzureAi.Endpoint}\"");
            template = template.Replace("\"your-api-key\"", $"\"{config.AzureAi.ApiKey}\"");
            template = template.Replace("\"your-deployment\"", $"\"{config.AzureAi.DeploymentName}\"");
            template = template.Replace("\"gpt-4\"", $"\"{config.AzureAi.ModelName}\"");
            template = template.Replace("false", config.AzureAi.UseManagedIdentity.ToString().ToLower());
            template = template.Replace("\"https://dev.azure.com/your-org/your-project/_git/your-mcp-server\"", $"\"{config.RepositoryUrl}\"");
            template = template.Replace("3000", config.McpServer.Port.ToString());
            template = template.Replace("true", config.McpServer.AutoStart.ToString().ToLower());

            await File.WriteAllTextAsync(filePath, template);
            _logger.LogInformation("Markdown configuration saved to {FilePath}", filePath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving markdown config to {FilePath}", filePath);
            throw;
        }
    }

    private void ParseYamlFrontmatter(MarkdownConfig config, string yamlContent)
    {
        try
        {
            // Simple YAML parsing - handles nested structure
            var lines = yamlContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            string currentSection = "";
            string currentToolName = "";
            
            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith('#'))
                    continue;

                var colonIndex = trimmed.IndexOf(':');
                if (colonIndex == -1) continue;

                var key = trimmed.Substring(0, colonIndex).Trim();
                var value = trimmed.Substring(colonIndex + 1).Trim().Trim('"');

                // Check if this is a section header (no value after colon, or empty value)
                if (string.IsNullOrEmpty(value))
                {
                    if (currentSection == "tool_defaults")
                    {
                        // Within tool_defaults, this is a tool name
                        currentToolName = key;
                        if (!config.ToolDefaults.ContainsKey(currentToolName))
                        {
                            config.ToolDefaults[currentToolName] = new Dictionary<string, object>();
                        }
                        continue;
                    }
                    else
                    {
                        // This is a top-level section header
                        currentSection = key.ToLower();
                        currentToolName = ""; // Reset tool name when entering new section
                        continue;
                    }
                }

                // Handle top-level keys
                switch (key.ToLower())
                {
                    case "name":
                        config.Name = value;
                        break;
                    case "description":
                        config.Description = value;
                        break;
                    case "repository_url":
                        config.RepositoryUrl = value;
                        break;
                    case "ai_planning_prompt_file":
                        config.AiPlanningPromptFile = value;
                        break;
                    case "preview_features":
                        config.PreviewFeatures = bool.Parse(value);
                        break;
                }

                // Handle nested sections based on current section
                if (currentSection == "azure_ai")
                {
                    switch (key.ToLower())
                    {
                        case "endpoint":
                            config.AzureAi.Endpoint = value;
                            break;
                        case "api_key":
                            config.AzureAi.ApiKey = value;
                            break;
                        case "deployment_name":
                            config.AzureAi.DeploymentName = value;
                            break;
                        case "model_name":
                            config.AzureAi.ModelName = value;
                            break;
                        case "use_managed_identity":
                            config.AzureAi.UseManagedIdentity = bool.Parse(value);
                            break;
                    }
                }
                else if (currentSection == "mcp_server")
                {
                    switch (key.ToLower())
                    {
                        case "port":
                            config.McpServer.Port = int.Parse(value);
                            break;
                        case "auto_start":
                            config.McpServer.AutoStart = bool.Parse(value);
                            break;
                        case "start_command":
                            config.McpServer.StartCommand = value;
                            break;
                        case "working_directory":
                            config.McpServer.WorkingDirectory = value;
                            break;
                    }
                }
                else if (currentSection == "variables")
                {
                    config.Variables[key] = value;
                }
                else if (currentSection == "tool_defaults")
                {
                    // Handle tool_defaults section - parameters for the current tool
                    if (!string.IsNullOrEmpty(currentToolName))
                    {
                        config.ToolDefaults[currentToolName][key] = value;
                    }
                }

                // Also handle dot notation for backward compatibility
                if (key.StartsWith("azure_ai."))
                {
                    var aiKey = key.Substring("azure_ai.".Length);
                    switch (aiKey.ToLower())
                    {
                        case "endpoint":
                            config.AzureAi.Endpoint = value;
                            break;
                        case "api_key":
                            config.AzureAi.ApiKey = value;
                            break;
                        case "deployment_name":
                            config.AzureAi.DeploymentName = value;
                            break;
                        case "model_name":
                            config.AzureAi.ModelName = value;
                            break;
                        case "use_managed_identity":
                            config.AzureAi.UseManagedIdentity = bool.Parse(value);
                            break;
                    }
                }

                if (key.StartsWith("mcp_server."))
                {
                    var mcpKey = key.Substring("mcp_server.".Length);
                    switch (mcpKey.ToLower())
                    {
                        case "port":
                            config.McpServer.Port = int.Parse(value);
                            break;
                        case "auto_start":
                            config.McpServer.AutoStart = bool.Parse(value);
                            break;
                        case "start_command":
                            config.McpServer.StartCommand = value;
                            break;
                        case "working_directory":
                            config.McpServer.WorkingDirectory = value;
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error parsing YAML frontmatter, using defaults");
        }
    }

    private async Task ParseMarkdownSectionsAsync(MarkdownConfig config, string content)
    {
        try
        {
            // Extract code blocks that might contain prompts
            var codeBlockRegex = new Regex(@"```[^`]*```", RegexOptions.Singleline);
            var codeBlocks = codeBlockRegex.Matches(content);

            foreach (Match match in codeBlocks)
            {
                var codeBlock = match.Value;
                // Remove the ``` markers
                var prompt = codeBlock.Substring(3, codeBlock.Length - 6).Trim();
                
                // Skip if it looks like a language specifier
                var lines = prompt.Split('\n');
                if (lines.Length > 1 && lines[0].All(c => char.IsLetter(c) || c == '-' || c == '_'))
                {
                    prompt = string.Join('\n', lines.Skip(1)).Trim();
                }

                if (!string.IsNullOrEmpty(prompt) && prompt.Length > 10)
                {
                    config.DefaultPrompts.Add(prompt);
                }
            }

            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error parsing markdown sections");
        }
    }
} 