using System.Text.RegularExpressions;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using McpCli.Models;
using System.Text;

namespace McpCli.Services;

public class MarkdownConfigService : IMarkdownConfigService
{
    private readonly ILogger<MarkdownConfigService> _logger;
    private readonly IEnvironmentVariableService _environmentVariableService;
    private readonly IRepositoryRootService _repositoryRootService;

    public MarkdownConfigService(ILogger<MarkdownConfigService> logger, IEnvironmentVariableService environmentVariableService, IRepositoryRootService repositoryRootService)
    {
        _logger = logger;
        _environmentVariableService = environmentVariableService;
        _repositoryRootService = repositoryRootService;
    }

    public async Task<MarkdownConfig> ParseMarkdownConfigAsync(string filePath)
    {
        try
        {
            // Resolve relative paths relative to repository root
            var resolvedFilePath = _repositoryRootService.IsRelativePath(filePath) 
                ? _repositoryRootService.ResolvePath(filePath) 
                : filePath;

            if (!File.Exists(resolvedFilePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {resolvedFilePath}");
            }

            var content = await File.ReadAllTextAsync(resolvedFilePath);
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

            // Validate server configuration
            if (config.Servers.Count == 0)
            {
                _logger.LogWarning("At least one server must be configured");
                return false;
            }

            foreach (var server in config.Servers)
            {
                if (string.IsNullOrEmpty(server.Name))
                {
                    _logger.LogWarning("Server name is required");
                    return false;
                }

                if (string.IsNullOrEmpty(server.Type))
                {
                    _logger.LogWarning($"Server type is required for server '{server.Name}'");
                    return false;
                }

                if (server.Type != "git" && server.Type != "http")
                {
                    _logger.LogWarning($"Server type must be 'git' or 'http' for server '{server.Name}'");
                    return false;
                }

                if (string.IsNullOrEmpty(server.Url))
                {
                    _logger.LogWarning($"Server URL is required for server '{server.Name}'");
                    return false;
                }
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

# MCP Servers Configuration
servers:
  - name: ""primary-server""
    type: ""git""
    url: ""https://dev.azure.com/${{AZURE_DEVOPS_ORG}}/${{AZURE_DEVOPS_PROJECT}}/_git/your-mcp-server""
    description: ""Primary MCP server""
    enabled: true
    auto_start: true
    port: 3000
    tags: [""primary""]
    tool_defaults:
      initialize_azure_dev_ops_client:
        organizationUrl: ""dnceng""
      get_repositories:
        projectName: ""internal""
  - name: ""external-api""
    type: ""http""
    url: ""https://api.example.com/mcp""
    description: ""External API server""
    enabled: true
    headers:
      Authorization: ""Bearer ${{EXTERNAL_API_TOKEN}}""
    tags: [""external""]
  - name: ""disabled-server""
    type: ""git""
    url: ""https://github.com/example/disabled-server""
    description: ""Disabled server for testing""
    enabled: false
    auto_start: false
    port: 3001
    tags: [""testing"", ""disabled""]

ai_planning_prompt_file: ""system-prompts/ai-planning-prompt.md""
variables:
  custom_var: ""${{CUSTOM_VARIABLE:default-value}}""

# Global tool defaults (applies to all servers)
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
            var yamlContent = SerializeToYaml(config);
            var markdownContent = ExtractMarkdownContent(filePath);
            
            var fullContent = $"---\n{yamlContent}\n---\n\n{markdownContent}";
            await File.WriteAllTextAsync(filePath, fullContent);
            
            _logger.LogInformation("Markdown configuration saved to {FilePath}", filePath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving markdown config to {FilePath}", filePath);
            throw;
        }
    }

    private string SerializeToYaml(MarkdownConfig config)
    {
        var yaml = new StringBuilder();
        
        // Basic properties
        yaml.AppendLine($"name: {EscapeYamlValue(config.Name)}");
        yaml.AppendLine($"description: {EscapeYamlValue(config.Description)}");
        yaml.AppendLine($"preview_features: {config.PreviewFeatures.ToString().ToLower()}");
        
        // Azure AI configuration
        yaml.AppendLine("azure_ai:");
        yaml.AppendLine($"  endpoint: {EscapeYamlValue(config.AzureAi.Endpoint)}");
        yaml.AppendLine($"  api_key: {PreserveEnvironmentVariableFormat("api_key", config.AzureAi.ApiKey)}");
        yaml.AppendLine($"  deployment_name: {EscapeYamlValue(config.AzureAi.DeploymentName)}");
        yaml.AppendLine($"  model_name: {EscapeYamlValue(config.AzureAi.ModelName)}");
        yaml.AppendLine($"  use_managed_identity: {config.AzureAi.UseManagedIdentity.ToString().ToLower()}");
        
        // Servers configuration
        if (config.Servers.Count > 0)
        {
            yaml.AppendLine();
            yaml.AppendLine("# MCP Servers Configuration");
            yaml.AppendLine("servers:");
            
            foreach (var server in config.Servers)
            {
                yaml.AppendLine($"  - name: {EscapeYamlValue(server.Name)}");
                yaml.AppendLine($"    type: {EscapeYamlValue(server.Type)}");
                yaml.AppendLine($"    url: {EscapeYamlValue(server.Url)}");
                yaml.AppendLine($"    description: {EscapeYamlValue(server.Description)}");
                yaml.AppendLine($"    enabled: {server.Enabled.ToString().ToLower()}");
                yaml.AppendLine($"    auto_start: {server.AutoStart.ToString().ToLower()}");
                yaml.AppendLine($"    port: {server.Port}");
                
                if (server.Tags.Count > 0)
                {
                    yaml.AppendLine($"    tags: [{string.Join(", ", server.Tags.Select(EscapeYamlValue))}]");
                }
                
                if (server.Environment.Count > 0)
                {
                    yaml.AppendLine("    environment:");
                    foreach (var env in server.Environment)
                    {
                        yaml.AppendLine($"      {env.Key}: {EscapeYamlValue(env.Value)}");
                    }
                }
                
                if (server.Headers.Count > 0)
                {
                    yaml.AppendLine("    headers:");
                    foreach (var header in server.Headers)
                    {
                        yaml.AppendLine($"      {header.Key}: {EscapeYamlValue(header.Value)}");
                    }
                }
                
                if (!string.IsNullOrEmpty(server.StartCommand))
                {
                    yaml.AppendLine($"    start_command: {EscapeYamlValue(server.StartCommand)}");
                }
                
                if (!string.IsNullOrEmpty(server.StartArguments))
                {
                    yaml.AppendLine($"    start_arguments: {EscapeYamlValue(server.StartArguments)}");
                }
                
                if (!string.IsNullOrEmpty(server.AuthToken))
                {
                    yaml.AppendLine($"    auth_token: {PreserveEnvironmentVariableFormat("auth_token", server.AuthToken)}");
                }
                
                if (!string.IsNullOrEmpty(server.AuthType))
                {
                    yaml.AppendLine($"    auth_type: {EscapeYamlValue(server.AuthType)}");
                }
                
                // Azure Identity configuration
                if (server.UseAzureIdentity)
                {
                    yaml.AppendLine($"    use_azure_identity: {server.UseAzureIdentity.ToString().ToLower()}");
                    
                    if (!string.IsNullOrEmpty(server.AzureTenantId))
                    {
                        yaml.AppendLine($"    azure_tenant_id: {EscapeYamlValue(server.AzureTenantId)}");
                    }
                    
                    yaml.AppendLine($"    allow_interactive_auth: {server.AllowInteractiveAuth.ToString().ToLower()}");
                    
                    if (server.AzureScopes.Count > 0)
                    {
                        yaml.AppendLine($"    azure_scopes: [{string.Join(", ", server.AzureScopes.Select(EscapeYamlValue))}]");
                    }
                }
                
                // GitHub authentication configuration
                if (server.UseGitHubAuth)
                {
                    yaml.AppendLine($"    use_github_auth: {server.UseGitHubAuth.ToString().ToLower()}");
                    
                    if (!string.IsNullOrEmpty(server.GitHubAuthMethod))
                    {
                        yaml.AppendLine($"    github_auth_method: {EscapeYamlValue(server.GitHubAuthMethod)}");
                    }
                    
                    // Token method configuration
                    if (server.GitHubAuthMethod == "token" && !string.IsNullOrEmpty(server.GitHubToken))
                    {
                        yaml.AppendLine($"    github_token: {PreserveEnvironmentVariableFormat("github_token", server.GitHubToken)}");
                    }
                    
                    // OAuth method configuration
                    if (server.GitHubAuthMethod == "oauth")
                    {
                        if (!string.IsNullOrEmpty(server.GitHubClientId))
                        {
                            yaml.AppendLine($"    github_client_id: {PreserveEnvironmentVariableFormat("github_client_id", server.GitHubClientId)}");
                        }
                        
                        if (!string.IsNullOrEmpty(server.GitHubClientSecret))
                        {
                            yaml.AppendLine($"    github_client_secret: {PreserveEnvironmentVariableFormat("github_client_secret", server.GitHubClientSecret)}");
                        }
                        
                        yaml.AppendLine($"    allow_github_interactive_auth: {server.AllowGitHubInteractiveAuth.ToString().ToLower()}");
                    }
                    
                    if (server.GitHubScopes.Count > 0)
                    {
                        yaml.AppendLine($"    github_scopes: [{string.Join(", ", server.GitHubScopes.Select(EscapeYamlValue))}]");
                    }
                }
                
                if (server.ToolDefaults.Count > 0)
                {
                    yaml.AppendLine("    tool_defaults:");
                    foreach (var toolDefault in server.ToolDefaults)
                    {
                        yaml.AppendLine($"      {toolDefault.Key}:");
                        foreach (var param in toolDefault.Value)
                        {
                            yaml.AppendLine($"        {param.Key}: {EscapeYamlValue(param.Value.ToString())}");
                        }
                    }
                }
            }
        }
        
        // AI planning prompt file
        if (!string.IsNullOrEmpty(config.AiPlanningPromptFile))
        {
            yaml.AppendLine($"ai_planning_prompt_file: {EscapeYamlValue(config.AiPlanningPromptFile)}");
        }
        
        // Variables
        if (config.Variables.Count > 0)
        {
            yaml.AppendLine("variables:");
            foreach (var variable in config.Variables)
            {
                yaml.AppendLine($"  {variable.Key}: {EscapeYamlValue(variable.Value)}");
            }
        }
        
        // Global tool defaults
        if (config.ToolDefaults.Count > 0)
        {
            yaml.AppendLine();
            yaml.AppendLine("# Global tool defaults (applies to all servers)");
            yaml.AppendLine("tool_defaults:");
            foreach (var toolDefault in config.ToolDefaults)
            {
                yaml.AppendLine($"  {toolDefault.Key}:");
                foreach (var param in toolDefault.Value)
                {
                    yaml.AppendLine($"    {param.Key}: {EscapeYamlValue(param.Value.ToString())}");
                }
            }
        }
        
        return yaml.ToString();
    }

    private string StripYamlComment(string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        // Find comment character '#' that's not inside quotes
        bool insideQuotes = false;
        char quoteChar = '\0';
        
        for (int i = 0; i < value.Length; i++)
        {
            var ch = value[i];
            
            if (!insideQuotes && (ch == '"' || ch == '\''))
            {
                insideQuotes = true;
                quoteChar = ch;
            }
            else if (insideQuotes && ch == quoteChar)
            {
                insideQuotes = false;
                quoteChar = '\0';
            }
            else if (!insideQuotes && ch == '#')
            {
                // Found a comment, return everything before it
                return value.Substring(0, i).Trim();
            }
        }
        
        return value;
    }

    private string EscapeYamlValue(string value)
    {
        if (string.IsNullOrEmpty(value))
            return "\"\"";
            
        // If value contains special characters, quote it
        if (value.Contains(":") || value.Contains("'") || value.Contains("\"") || 
            value.Contains("\n") || value.Contains("\r") || value.Contains("\t") ||
            value.StartsWith("$") || value.StartsWith("%") || value.Contains("${"))
        {
            return $"\"{value.Replace("\"", "\\\"")}\"";
        }
        
        return value;
    }

    private string PreserveEnvironmentVariableFormat(string key, string value)
    {
        // For sensitive fields, try to preserve environment variable format
        if (IsSensitiveField(key))
        {
            // If the value looks like it might be an actual resolved value (long, no spaces, base64-like)
            // and we're dealing with a sensitive field, use a placeholder format
            if (value.Length > 30 && !value.Contains(" ") && !value.Contains("${") && !value.Contains("%"))
            {
                // Convert to environment variable format based on field name
                var envVarName = ConvertToEnvironmentVariableName(key);
                return $"\"${{{envVarName}}}\"";
            }
        }
        
        return EscapeYamlValue(value);
    }

    private bool IsSensitiveField(string key)
    {
        var sensitiveFields = new[] { "api_key", "apikey", "token", "password", "secret", "auth_token" };
        return sensitiveFields.Any(field => key.ToLower().Contains(field));
    }

    private string ConvertToEnvironmentVariableName(string key)
    {
        // Convert field names to environment variable names
        return key.ToLower() switch
        {
            "api_key" => "azure_ai_api_key",
            "auth_token" => "auth_token",
            "password" => "password",
            _ => key.ToLower().Replace(".", "_")
        };
    }

    private string ExtractMarkdownContent(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                return "";
                
            var content = File.ReadAllText(filePath);
            var markdownStart = content.IndexOf("---", 3); // Find second ---
            
            if (markdownStart >= 0)
            {
                var markdownContent = content.Substring(markdownStart + 3).Trim();
                return markdownContent;
            }
            
            return "";
        }
        catch
        {
            return "";
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
            MultiMcpServerConfig? currentServer = null;
            
            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith('#'))
                    continue;

                var colonIndex = trimmed.IndexOf(':');
                if (colonIndex == -1) continue;

                var key = trimmed.Substring(0, colonIndex).Trim();
                var valueWithComment = trimmed.Substring(colonIndex + 1).Trim();
                
                // Strip comments (anything after #, but not inside quotes)
                var value = StripYamlComment(valueWithComment).Trim('"');

                // Handle array indicators for servers
                if (trimmed.StartsWith("- "))
                {
                    if (currentSection == "servers" || currentSection == "server_tool_defaults" || currentSection == "server_headers")
                    {
                        // Start of a new server entry
                        currentServer = new MultiMcpServerConfig();
                        config.Servers.Add(currentServer);
                        currentToolName = ""; // Reset tool name for new server
                        currentSection = "servers"; // Reset to servers section
                        
                        // Parse the first property if it's on the same line
                        var serverLine = trimmed.Substring(2).Trim(); // Remove "- "
                        var serverColonIndex = serverLine.IndexOf(':');
                        if (serverColonIndex > 0)
                        {
                            var serverKey = serverLine.Substring(0, serverColonIndex).Trim();
                            var serverValueWithComment = serverLine.Substring(serverColonIndex + 1).Trim();
                            var serverValue = StripYamlComment(serverValueWithComment).Trim('"');
                            SetServerProperty(currentServer, serverKey, serverValue);
                        }
                        continue;
                    }
                    // Handle other array sections if needed
                    continue;
                }

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
                    else if (currentSection == "servers" && currentServer != null)
                    {
                        // Within a server definition, this might be a nested section like tool_defaults or headers
                        if (key.ToLower() == "tool_defaults")
                        {
                            currentToolName = ""; // Reset for server-specific tool defaults
                            // Set a special flag to indicate we're in server tool_defaults section
                            currentSection = "server_tool_defaults";
                        }
                        else if (key.ToLower() == "headers")
                        {
                            // Set a special flag to indicate we're in server headers section
                            currentSection = "server_headers";
                        }
                        continue;
                    }
                    else if (currentSection == "server_tool_defaults")
                    {
                        // Within server's tool_defaults, this is a tool name
                        currentToolName = key;
                        if (currentServer != null && !currentServer.ToolDefaults.ContainsKey(currentToolName))
                        {
                            currentServer.ToolDefaults[currentToolName] = new Dictionary<string, object>();
                        }
                        continue;
                    }
                    else
                    {
                        // This is a top-level section header
                        currentSection = key.ToLower();
                        currentToolName = ""; // Reset tool name when entering new section
                        currentServer = null; // Reset server when entering new section
                        
                        // Special handling for servers section
                        if (currentSection == "servers")
                        {
                            currentToolName = ""; // Ensure tool name is clear for servers
                        }
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
                else if (currentSection == "server_tool_defaults" && currentServer != null)
                {
                    // Handle parameters for the current tool within server's tool_defaults
                    if (!string.IsNullOrEmpty(currentToolName))
                    {
                        currentServer.ToolDefaults[currentToolName][key] = value;
                    }
                }
                else if (currentSection == "server_headers" && currentServer != null)
                {
                    // Handle header key-value pairs
                    currentServer.Headers[key] = value;
                }
                else if (currentSection == "servers" && currentServer != null)
                {
                    // Handle direct server properties
                    SetServerProperty(currentServer, key, value);
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

    private static void SetServerProperty(MultiMcpServerConfig server, string key, string value)
    {
        switch (key.ToLower())
        {
            case "name":
                server.Name = value;
                break;
            case "type":
                server.Type = value;
                break;
            case "url":
                server.Url = value;
                break;
            case "description":
                server.Description = value;
                break;
            case "enabled":
                server.Enabled = bool.Parse(value);
                break;
            case "auto_start":
                server.AutoStart = bool.Parse(value);
                break;
            case "port":
                server.Port = int.Parse(value);
                break;
            case "start_command":
                server.StartCommand = value;
                break;
            case "start_arguments":
                server.StartArguments = value;
                break;
            case "branch":
                server.Branch = value;
                break;
            case "local_path":
                server.LocalPath = value;
                break;
            case "auth_type":
                server.AuthType = value;
                break;
            case "auth_token":
                server.AuthToken = value;
                break;
            case "use_azure_identity":
                server.UseAzureIdentity = bool.Parse(value);
                break;
            case "azure_tenant_id":
                server.AzureTenantId = value;
                break;
            case "allow_interactive_auth":
                server.AllowInteractiveAuth = bool.Parse(value);
                break;
            case "use_github_auth":
                server.UseGitHubAuth = bool.Parse(value);
                break;
            case "github_auth_method":
                server.GitHubAuthMethod = value;
                break;
            case "github_token":
                server.GitHubToken = value;
                break;
            case "github_client_id":
                server.GitHubClientId = value;
                break;
            case "github_client_secret":
                server.GitHubClientSecret = value;
                break;
            case "allow_github_interactive_auth":
                server.AllowGitHubInteractiveAuth = bool.Parse(value);
                break;
            // Handle array properties like tags and azure_scopes
            case "tags":
                if (value.StartsWith("[") && value.EndsWith("]"))
                {
                    // Simple array parsing - remove brackets and split by comma
                    var arrayValue = value.Substring(1, value.Length - 2);
                    server.Tags = arrayValue.Split(',').Select(t => t.Trim().Trim('"')).ToList();
                }
                else
                {
                    server.Tags.Add(value);
                }
                break;
            case "azure_scopes":
                if (value.StartsWith("[") && value.EndsWith("]"))
                {
                    // Simple array parsing - remove brackets and split by comma
                    var arrayValue = value.Substring(1, value.Length - 2);
                    server.AzureScopes = arrayValue.Split(',').Select(s => s.Trim().Trim('"')).ToList();
                }
                else
                {
                    server.AzureScopes.Add(value);
                }
                break;
            case "github_scopes":
                if (value.StartsWith("[") && value.EndsWith("]"))
                {
                    // Simple array parsing - remove brackets and split by comma
                    var arrayValue = value.Substring(1, value.Length - 2);
                    server.GitHubScopes = arrayValue.Split(',').Select(s => s.Trim().Trim('"')).ToList();
                }
                else
                {
                    server.GitHubScopes.Add(value);
                }
                break;
        }
    }
} 