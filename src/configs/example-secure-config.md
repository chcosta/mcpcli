---
name: "Secure MCP Configuration Example"
description: "Example configuration using environment variables for security"
azure_ai:
  endpoint: "${AZURE_AI_ENDPOINT}"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "${AZURE_AI_DEPLOYMENT_NAME}"
  model_name: "${AZURE_AI_MODEL_NAME:gpt-4}"
  use_managed_identity: false
repository_url: "https://dev.azure.com/${AZURE_DEVOPS_ORG}/${AZURE_DEVOPS_PROJECT}/_git/filesystem-mcp"
mcp_server:
  port: "${MCP_SERVER_PORT:3000}"
  auto_start: true
  environment:
    NODE_ENV: "production"
    BASE_PATH: "${BASE_PATH:C:\\Data}"
    LOG_LEVEL: "${LOG_LEVEL:info}"
ai_planning_prompt_file: "system-prompts/ai-planning-prompt.md"
variables:
  working_directory: "${MCP_WORKING_DIR:./mcp-servers}"
  timeout_seconds: "${MCP_TIMEOUT_SECONDS:30}"
  custom_setting: "${CUSTOM_SETTING:default-value}"
---

# Secure MCP Configuration Example

This configuration demonstrates how to use environment variables for secure configuration management.

## Environment Variables Required

Before using this configuration, set the following environment variables:

### Windows Command Prompt
```cmd
set AZURE_AI_ENDPOINT=https://your-resource.openai.azure.com/
set AZURE_AI_API_KEY=your-api-key-here
set AZURE_AI_DEPLOYMENT_NAME=your-deployment-name
set AZURE_AI_MODEL_NAME=gpt-4
set AZURE_DEVOPS_ORG=your-organization
set AZURE_DEVOPS_PROJECT=your-project
set MCP_SERVER_PORT=3000
set BASE_PATH=C:\Data
set LOG_LEVEL=info
set MCP_WORKING_DIR=./mcp-servers
set MCP_TIMEOUT_SECONDS=30
set CUSTOM_SETTING=my-custom-value
```

### Windows PowerShell
```powershell
$env:AZURE_AI_ENDPOINT="https://your-resource.openai.azure.com/"
$env:AZURE_AI_API_KEY="your-api-key-here"
$env:AZURE_AI_DEPLOYMENT_NAME="your-deployment-name"
$env:AZURE_AI_MODEL_NAME="gpt-4"
$env:AZURE_DEVOPS_ORG="your-organization"
$env:AZURE_DEVOPS_PROJECT="your-project"
$env:MCP_SERVER_PORT="3000"
$env:BASE_PATH="C:\Data"
$env:LOG_LEVEL="info"
$env:MCP_WORKING_DIR="./mcp-servers"
$env:MCP_TIMEOUT_SECONDS="30"
$env:CUSTOM_SETTING="my-custom-value"
```

### Unix/Linux/macOS
```bash
export AZURE_AI_ENDPOINT="https://your-resource.openai.azure.com/"
export AZURE_AI_API_KEY="your-api-key-here"
export AZURE_AI_DEPLOYMENT_NAME="your-deployment-name"
export AZURE_AI_MODEL_NAME="gpt-4"
export AZURE_DEVOPS_ORG="your-organization"
export AZURE_DEVOPS_PROJECT="your-project"
export MCP_SERVER_PORT="3000"
export BASE_PATH="C:\Data"
export LOG_LEVEL="info"
export MCP_WORKING_DIR="./mcp-servers"
export MCP_TIMEOUT_SECONDS="30"
export CUSTOM_SETTING="my-custom-value"
```

## Security Benefits

Using environment variables provides:
- **No secrets in files**: API keys and tokens are not stored in configuration files
- **Version control safe**: This file can be safely committed to version control
- **Team sharing**: Team members can use the same config with their own secrets
- **Environment flexibility**: Different environments (dev, staging, prod) can use different values

## Default Prompts

The following prompts are available for quick execution:

### File System Analysis
```
Analyze the file system structure in the base directory and provide a summary of the main folders and file types
```

### Directory Listing
```
List all files and directories in the current working directory with their sizes and modification dates
```

### Search Files
```
Search for files containing "configuration" or "config" in their names and summarize their purposes
```

### System Information
```
Provide information about the current system, including available disk space and directory permissions
```

## Usage Examples

```bash
# List available prompts
mcpcli run --config configs/example-secure-config.md --list-prompts

# Run with the first default prompt
mcpcli run --config configs/example-secure-config.md --prompt-index 0

# Run with a custom prompt
mcpcli run --config configs/example-secure-config.md --prompt "Create a backup of important files"
```

## Environment Variable Formats

This configuration demonstrates multiple environment variable formats:

- `${VAR_NAME}` - Standard format, variable is required
- `${VAR_NAME:default}` - With default value if variable is not set
- Variables can be used in any string field including URLs, paths, and custom settings

## Troubleshooting

If you encounter issues:

1. **Check environment variables are set**:
   ```cmd
   # Windows
   echo %AZURE_AI_ENDPOINT%
   
   # PowerShell
   echo $env:AZURE_AI_ENDPOINT
   
   # Unix/Linux/macOS
   echo $AZURE_AI_ENDPOINT
   ```

2. **Verify configuration resolution**:
   ```cmd
   mcpcli config show
   ```

3. **Test with minimal configuration**:
   Start with just the required variables and add optional ones incrementally.

## Advanced Usage

### Mixed Configuration
You can mix environment variables with direct values:
```yaml
azure_ai:
  endpoint: "${AZURE_AI_ENDPOINT}"           # From environment
  api_key: "${AZURE_AI_API_KEY}"             # From environment
  deployment_name: "gpt-4-deployment"        # Direct value
  model_name: "gpt-4"                        # Direct value
```

### Conditional Configuration
Use different values based on environment:
```yaml
mcp_server:
  port: "${MCP_SERVER_PORT:3000}"            # Default to 3000
  environment:
    NODE_ENV: "${NODE_ENV:development}"      # Default to development
    LOG_LEVEL: "${LOG_LEVEL:info}"           # Default to info
```

This approach allows for flexible configuration management across different environments while maintaining security best practices. 