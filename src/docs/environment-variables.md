# Environment Variables for Secure Configuration

This document explains how to use environment variables for secure configuration management in MCP CLI.

## Overview

Instead of storing sensitive information like API keys and personal access tokens directly in configuration files, MCP CLI supports environment variable references. This approach provides better security and flexibility.

## Benefits

### Security
- **No secrets in files**: Sensitive information is not stored in configuration files
- **Version control safe**: Configuration files can be safely committed to version control
- **Team sharing**: Team members can use the same configuration with their own secrets
- **Environment isolation**: Different environments can use different values

### Flexibility
- **Dynamic values**: Values can be changed without modifying configuration files
- **Default values**: Support for fallback values when environment variables are not set
- **Multiple formats**: Support for various environment variable formats

## Supported Formats

MCP CLI supports multiple environment variable formats:

### Unix/Linux Style with Braces
```yaml
api_key: "${AZURE_AI_API_KEY}"
endpoint: "${AZURE_AI_ENDPOINT}"
```

### Unix/Linux Style with Default Values
```yaml
model_name: "${AZURE_AI_MODEL_NAME:gpt-4}"
port: "${MCP_SERVER_PORT:3000}"
```

### Windows Style
```yaml
api_key: "%AZURE_AI_API_KEY%"
endpoint: "%AZURE_AI_ENDPOINT%"
```

### Simple Unix Style
```yaml
api_key: "$AZURE_AI_API_KEY"
endpoint: "$AZURE_AI_ENDPOINT"
```

## Required Environment Variables

### Azure AI Configuration

| Variable | Description | Example |
|----------|-------------|---------|
| `AZURE_AI_ENDPOINT` | Azure OpenAI endpoint URL | `https://your-resource.openai.azure.com/` |
| `AZURE_AI_API_KEY` | Azure OpenAI API key | `abc123...` |
| `AZURE_AI_DEPLOYMENT_NAME` | Model deployment name | `gpt-4-deployment` |
| `AZURE_AI_MODEL_NAME` | Model name (optional) | `gpt-4` |

### Azure DevOps Configuration

| Variable | Description | Example |
|----------|-------------|---------|
| `AZURE_DEVOPS_ORG` | Azure DevOps organization | `myorganization` |
| `AZURE_DEVOPS_PROJECT` | Default project name | `myproject` |
| `AZURE_DEVOPS_PAT` | Personal Access Token | `pat_token_here` |

### Optional Configuration

| Variable | Description | Default |
|----------|-------------|---------|
| `MCP_SERVER_PORT` | Default MCP server port | `3000` |
| `MCP_WORKING_DIR` | Working directory for servers | `./mcp-servers` |
| `MCP_TIMEOUT_SECONDS` | Server timeout in seconds | `30` |

## Setting Environment Variables

### Windows Command Prompt
```cmd
set AZURE_AI_ENDPOINT=https://your-resource.openai.azure.com/
set AZURE_AI_API_KEY=your-api-key-here
set AZURE_AI_DEPLOYMENT_NAME=your-deployment-name
set AZURE_AI_MODEL_NAME=gpt-4
set AZURE_DEVOPS_ORG=your-organization
set AZURE_DEVOPS_PROJECT=your-project
set AZURE_DEVOPS_PAT=your-pat-token
```

### Windows PowerShell
```powershell
$env:AZURE_AI_ENDPOINT="https://your-resource.openai.azure.com/"
$env:AZURE_AI_API_KEY="your-api-key-here"
$env:AZURE_AI_DEPLOYMENT_NAME="your-deployment-name"
$env:AZURE_AI_MODEL_NAME="gpt-4"
$env:AZURE_DEVOPS_ORG="your-organization"
$env:AZURE_DEVOPS_PROJECT="your-project"
$env:AZURE_DEVOPS_PAT="your-pat-token"
```

### Unix/Linux/macOS
```bash
export AZURE_AI_ENDPOINT="https://your-resource.openai.azure.com/"
export AZURE_AI_API_KEY="your-api-key-here"
export AZURE_AI_DEPLOYMENT_NAME="your-deployment-name"
export AZURE_AI_MODEL_NAME="gpt-4"
export AZURE_DEVOPS_ORG="your-organization"
export AZURE_DEVOPS_PROJECT="your-project"
export AZURE_DEVOPS_PAT="your-pat-token"
```

## Persistent Environment Variables

### Windows - System Environment Variables
1. Open **System Properties** → **Advanced** → **Environment Variables**
2. Add variables to **User variables** or **System variables**
3. Restart your terminal/application

### Windows - PowerShell Profile
Add to your PowerShell profile (`$PROFILE`):
```powershell
$env:AZURE_AI_ENDPOINT="https://your-resource.openai.azure.com/"
$env:AZURE_AI_API_KEY="your-api-key-here"
# ... other variables
```

### Unix/Linux/macOS - Shell Profile
Add to your shell profile (`~/.bashrc`, `~/.zshrc`, etc.):
```bash
export AZURE_AI_ENDPOINT="https://your-resource.openai.azure.com/"
export AZURE_AI_API_KEY="your-api-key-here"
# ... other variables
```

## Configuration File Examples

### Basic Configuration with Environment Variables
```yaml
---
name: "My MCP Configuration"
description: "Secure configuration using environment variables"
azure_ai:
  endpoint: "${AZURE_AI_ENDPOINT}"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "${AZURE_AI_DEPLOYMENT_NAME}"
  model_name: "${AZURE_AI_MODEL_NAME:gpt-4}"
  use_managed_identity: false
repository_url: "https://dev.azure.com/${AZURE_DEVOPS_ORG}/${AZURE_DEVOPS_PROJECT}/_git/my-mcp-server"
mcp_server:
  port: "${MCP_SERVER_PORT:3000}"
  auto_start: true
  environment:
    NODE_ENV: "production"
    CUSTOM_VAR: "${CUSTOM_VARIABLE:default-value}"
---
```

### Mixed Configuration (Some Environment Variables, Some Direct Values)
```yaml
---
name: "Mixed Configuration"
azure_ai:
  endpoint: "${AZURE_AI_ENDPOINT}"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "gpt-4-deployment"  # Direct value
  model_name: "gpt-4"                  # Direct value
  use_managed_identity: false
repository_url: "https://dev.azure.com/myorg/myproject/_git/my-server"
mcp_server:
  port: "${MCP_SERVER_PORT:3000}"
  auto_start: true
---
```

## Validation and Troubleshooting

### Checking Environment Variables
```bash
# Windows Command Prompt
echo %AZURE_AI_ENDPOINT%

# Windows PowerShell
echo $env:AZURE_AI_ENDPOINT

# Unix/Linux/macOS
echo $AZURE_AI_ENDPOINT
```

### Common Issues

1. **Variable not found**: Check spelling and ensure the variable is set
2. **Empty values**: Ensure variables have non-empty values
3. **Quotes in values**: Be careful with quotes in environment variable values
4. **Case sensitivity**: Environment variable names are case-sensitive on Unix/Linux

### Testing Configuration
Use the MCP CLI to test your configuration:
```bash
mcpcli config show
```

This will show your resolved configuration values (with environment variables resolved).

## Best Practices

1. **Use descriptive names**: Choose clear, descriptive environment variable names
2. **Group related variables**: Use prefixes like `AZURE_AI_` for related settings
3. **Document variables**: Document required environment variables for your team
4. **Use defaults**: Provide sensible defaults for non-sensitive configuration
5. **Validate on startup**: Check that required environment variables are set
6. **Keep secrets secure**: Never log or display secret values
7. **Use different values per environment**: Development, staging, production should use different values

## Security Enforcement

MCP CLI automatically enforces security best practices:

### Secret Field Validation
The following fields are **required** to use environment variables and **cannot** contain hardcoded values:
- `ApiKey` - API keys for services
- `PersonalAccessToken` - Personal access tokens
- `Password` - Passwords
- `Secret` - Secret values
- `Token` - Authentication tokens
- `Key` - Cryptographic keys

### Validation Examples

**❌ Invalid (hardcoded secrets):**
```yaml
azure_ai:
  api_key: "sk-abc123..."  # ERROR: Will be rejected
```

**✅ Valid (environment variables):**
```yaml
azure_ai:
  api_key: "${AZURE_AI_API_KEY}"  # OK: Uses environment variable
```

### Error Messages
If you try to use hardcoded secrets, you'll see errors like:
```
Secret field 'ApiKey' must use environment variables only. 
Use formats like '${VAR_NAME}' or '%VAR_NAME%' instead of hardcoded values.
```

## Security Considerations

1. **Automatic enforcement**: Secret fields are automatically validated
2. **Never commit secrets**: Don't commit files containing actual secret values
3. **Use managed identities**: Prefer managed identities over API keys when possible
4. **Rotate secrets regularly**: Change API keys and tokens regularly
5. **Limit permissions**: Use tokens with minimal required permissions
6. **Monitor usage**: Monitor API key usage for unusual activity
7. **Use secure storage**: Consider using secure credential stores for production

## Integration with CI/CD

### GitHub Actions
```yaml
env:
  AZURE_AI_ENDPOINT: ${{ secrets.AZURE_AI_ENDPOINT }}
  AZURE_AI_API_KEY: ${{ secrets.AZURE_AI_API_KEY }}
  AZURE_DEVOPS_ORG: ${{ secrets.AZURE_DEVOPS_ORG }}
```

### Azure DevOps Pipelines
```yaml
variables:
  AZURE_AI_ENDPOINT: $(AZURE_AI_ENDPOINT)
  AZURE_AI_API_KEY: $(AZURE_AI_API_KEY)
  AZURE_DEVOPS_ORG: $(AZURE_DEVOPS_ORG)
```

## Migration from Direct Configuration

If you have existing configuration files with hardcoded values:

1. **Identify secrets**: Find all sensitive values in your configuration
2. **Create environment variables**: Set up environment variables for these values
3. **Update configuration**: Replace hardcoded values with environment variable references
4. **Test thoroughly**: Ensure all functionality works with the new configuration
5. **Clean up**: Remove old configuration files with hardcoded secrets

Example migration:
```yaml
# Before (insecure)
azure_ai:
  api_key: "sk-abc123..."

# After (secure)
azure_ai:
  api_key: "${AZURE_AI_API_KEY}"
```

## Support

For issues with environment variable configuration:
1. Check the logs for environment variable resolution messages
2. Verify environment variables are set correctly
3. Test with simple values first
4. Check the documentation for your specific use case 