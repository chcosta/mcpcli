---
name: "MCP Server with Managed Identity"
description: "Example configuration using DefaultAzureCredential for Azure DevOps"
azure_ai:
  endpoint: "https://your-resource.openai.azure.com/"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "gpt-4"
  model_name: "gpt-4"
  use_managed_identity: false
repository_url: "https://dev.azure.com/your-org/your-project/_git/filesystem-mcp-server"
mcp_server:
  port: 3000
  auto_start: true
  environment:
    NODE_ENV: "production"
    DEBUG: "mcp:*"
variables:
  base_path: "C:\\Users\\%USERNAME%\\Documents"
  max_file_size: "10MB"
---

# MCP Server with Managed Identity

This configuration demonstrates using DefaultAzureCredential for Azure DevOps authentication instead of Personal Access Tokens.

## Prerequisites

Before using this configuration, ensure you're authenticated with Azure using one of these methods:

### Option 1: Azure CLI
```cmd
az login
```

### Option 2: Visual Studio
Sign in to Visual Studio with your Azure account.

### Option 3: Environment Variables
Set these environment variables:
```cmd
set AZURE_CLIENT_ID=your-client-id
set AZURE_CLIENT_SECRET=your-client-secret
set AZURE_TENANT_ID=your-tenant-id
```

### Option 4: Managed Identity (when running in Azure)
No additional setup required when running on Azure VMs, App Service, etc.

## Configuration Setup

1. **Initialize configuration**:
   ```cmd
   mcpcli config init
   ```

2. **Set Azure DevOps to use managed identity**:
   ```cmd
   mcpcli config set --key "AzureDevOps.Organization" --value "your-org"
   mcpcli config set --key "AzureDevOps.UseManagedIdentity" --value "true"
   ```

3. **Set Azure AI credentials**:
   ```cmd
   mcpcli config set --key "AzureAi.Endpoint" --value "https://your-resource.openai.azure.com/"
   mcpcli config set --key "AzureAi.ApiKey" --value "your-api-key"
   mcpcli config set --key "AzureAi.DeploymentName" --value "gpt-4"
   ```

## Default Prompts

### System Status
```
Check the current system status and report any issues
```

### File Operations
```
List all files in the Documents folder and analyze their types
```

### Security Check
```
Verify that all security configurations are properly set
```

## Usage Examples

1. **Run with managed identity**:
   ```cmd
   mcpcli run --config example-managed-identity-config.md --prompt-index 0
   ```

2. **List available prompts**:
   ```cmd
   mcpcli run --config example-managed-identity-config.md --list-prompts
   ```

3. **Custom prompt**:
   ```cmd
   mcpcli run --config example-managed-identity-config.md --prompt "Analyze the project structure"
   ```

## Benefits of Managed Identity

- **No secrets to manage**: No need to store or rotate Personal Access Tokens
- **Enterprise security**: Leverages your organization's Azure AD authentication
- **Audit trail**: All access is logged through Azure AD
- **Seamless experience**: Works automatically in Azure environments
- **Multiple auth methods**: Supports CLI, Visual Studio, environment variables, and managed identity

## Troubleshooting

If you encounter authentication issues:

1. **Verify Azure authentication**:
   ```cmd
   az account show
   ```

2. **Check token acquisition**:
   ```cmd
   az account get-access-token --resource 499b84ac-1321-427f-aa17-267ca6975798
   ```

3. **Verify Azure DevOps access**:
   - Ensure your Azure AD account has access to the Azure DevOps organization
   - Check that you have at least "Basic" access level in Azure DevOps

4. **Enable detailed logging**:
   ```cmd
   set DOTNET_LOGGING__CONSOLE__LOGLEVEL__DEFAULT=Debug
   mcpcli run --config example-managed-identity-config.md --prompt "test"
   ``` 