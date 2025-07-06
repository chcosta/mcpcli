---
name: AI Release Notes
description: .NET Engineering's Release Notes MCP server
azure_ai:
  endpoint: "https://andya-ma8fyz00-eastus2.openai.azure.com/"
  api_key: "${azure_ai_api_key}"
  deployment_name: "private-gpt-4o"
  model_name: "gpt-4o"
  use_managed_identity: false
repository_url: "https://dev.azure.com/dnceng/internal/_git/dnceng-ai-experimental"
mcp_server:
  port: 3000
  auto_start: true
  environment:
    NODE_ENV: "production"
variables:
  working_directory: ".\\mcp-servers"
  timeout_seconds: 30
  azure_devops_org: "dnceng"
  azure_devops_project: "internal"
  use_managed_identity: true
---

# AI Release Notes

.NET Engineering's Release Notes MCP server

## Azure AI Configuration

This configuration connects to Azure AI Foundry with the following settings:
- **Endpoint**: https://andya-ma8fyz00-eastus2.openai.azure.com/
- **API Key**: API key required
- **Deployment**: private-gpt-4o
- **Model**: gpt-4o
- **Use Managed Identity**: False

## Repository Configuration

The MCP server will be cloned from the specified Azure DevOps repository.

**Current Azure DevOps Configuration**:
- **Organization**: dnceng
- **Default Project**: internal
- **Authentication Method**: Managed Identity

**Authentication**: Configure Azure DevOps authentication in your main configuration:
- **Personal Access Token**: mcpcli config set --key "AzureDevOps.PersonalAccessToken" --value "your-pat"
- **Managed Identity**: mcpcli config set --key "AzureDevOps.UseManagedIdentity" --value "true"

## MCP Server Configuration

- **Port**: 3000
- **Working Directory**: ./mcp-servers
- **Timeout**: 30 seconds
- **Auto Cleanup**: True

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
