---
name: AI Release Notes
description: ".NET Engineering's Azure DevOps integration server"
preview_features: false
azure_ai:
  endpoint: "https://andya-ma8fyz00-eastus2.openai.azure.com/"
  api_key: "${azure_ai_api_key}"
  deployment_name: private-gpt-4o
  model_name: gpt-4o
  use_managed_identity: false

# MCP Servers Configuration
servers:
  - name: azure-devops-primary
    type: git
    url: "https://dev.azure.com/dnceng/internal/_git/dnceng-ai-experimental"
    description: ".NET Engineering's Azure DevOps integration server"
    enabled: true
    auto_start: true
    port: 3000
    tags: [azure-devops, primary, internal]
    use_managed_identity: true
    tool_defaults:
      initialize_azure_dev_ops_client:
        organizationUrl: "dnceng"

---

# AI Release Notes

.NET Engineering's Azure DevOps integration server

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
$env:AZURE_AI_ENDPOINT="https://andya-ma8fyz00-eastus2.openai.azure.com/"
$env:AZURE_AI_API_KEY="your-api-key-here"
$env:AZURE_AI_DEPLOYMENT_NAME="your-deployment-name"
$env:AZURE_AI_MODEL_NAME="gpt-4o"

# Unix/Linux/macOS
export AZURE_AI_ENDPOINT="https://andya-ma8fyz00-eastus2.openai.azure.com/"
export AZURE_AI_API_KEY="your-api-key-here"
export AZURE_AI_DEPLOYMENT_NAME="your-deployment-name"
export AZURE_AI_MODEL_NAME="gpt-4o"
```

### Azure DevOps Configuration
```bash
# Windows (Command Prompt)
set AZURE_DEVOPS_ORG=your-organization
set AZURE_DEVOPS_PROJECT=your-project

# Windows (PowerShell)
$env:AZURE_DEVOPS_ORG="your-organization"
$env:AZURE_DEVOPS_PROJECT="your-project"

# Unix/Linux/macOS
export AZURE_DEVOPS_ORG="your-organization"
export AZURE_DEVOPS_PROJECT="your-project"
```

## Tool Defaults

The `tool_defaults` section allows you to specify default parameter values for MCP tools. These defaults are automatically applied when tools are called without those parameters explicitly provided.

Example:
```yaml
tool_defaults:
  initialize_azure_dev_ops_client:
    organizationUrl: "dnceng"
  get_repositories:
    projectName: "internal"
```

With these defaults:
- When you run "initialize azure devops client", it will automatically use organizationUrl="dnceng"
- When you run "list repositories", it will automatically use projectName="internal"
- Explicit parameters always override defaults

## Security Benefits

Using environment variables instead of hardcoded secrets provides:
- **Security**: Secrets are not stored in configuration files
- **Flexibility**: Different environments can use different values
- **Version Control Safety**: Configuration files can be safely committed
- **Team Sharing**: Team members can use the same config with their own secrets

## Environment Variable Formats

This configuration supports multiple environment variable formats:
- `${VAR_NAME}` - Unix/Linux style with braces
- `${VAR_NAME:default}` - With default value
- `%VAR_NAME%` - Windows style
- `$VAR_NAME` - Simple Unix style

## Azure DevOps Authentication

Configure Azure DevOps authentication in your main configuration:
- **Personal Access Token**: mcpcli config set --key "AzureDevOps.PersonalAccessToken" --value "${AZURE_DEVOPS_PAT}"
- **Managed Identity**: mcpcli config set --key "AzureDevOps.UseManagedIdentity" --value "true"

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