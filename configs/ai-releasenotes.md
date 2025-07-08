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
  - name: "github-mcp"
    type: "http"
    url: "https://api.githubcopilot.com/mcp/"
    description: "GitHub's official remote MCP server for GitHub API access"
    enabled: true
    headers:
      # PAT scopes: repo, read:user, copilot
      Authorization: "Bearer ${github_copilot_pat}"
      Content-Type: "application/json"
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

## Quick Setup Guide

1. **Create GitHub Personal Access Token** (see detailed instructions below)
   - Go to https://github.com/settings/tokens
   - Generate classic token with `repo` scope
   - Set `GITHUB_COPILOT_PAT` environment variable

2. **Set Required Environment Variables** (see sections below)
   - `AZURE_AI_API_KEY` for Azure OpenAI access
   - `GITHUB_COPILOT_PAT` for GitHub MCP server (remote HTTP server)
   - Azure DevOps variables (if using that server)

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

### GitHub MCP Server Configuration

This configuration uses GitHub's **remote MCP server** (`https://api.githubcopilot.com/mcp/`) which is hosted by GitHub and provides the easiest setup method. 

**Alternative approaches:**
- **Local Docker:** GitHub also provides a Docker image (`ghcr.io/github/github-mcp-server`) for local hosting
- **Git Repository:** The source code is available at `https://github.com/github/github-mcp-server.git`, but it's a Go project that requires compilation and isn't directly executable like Node.js or .NET projects

**Why we use the remote server:**
- ✅ No local setup required
- ✅ Always up-to-date with latest features
- ✅ Managed and maintained by GitHub
- ✅ Same functionality as local installation

#### Creating a Personal Access Token for GitHub MCP Server

1. **Navigate to GitHub Settings**
   - Go to https://github.com/settings/tokens
   - Or: GitHub profile → Settings → Developer settings → Personal access tokens → Tokens (classic)
   - **Important**: Use "Tokens (classic)" for compatibility

2. **Generate New Token**
   - Click "Generate new token" → "Generate new token (classic)"
   - Give it a descriptive name like "GitHub MCP Server"

3. **Set Expiration**
   - Choose an appropriate expiration (30 days, 90 days, or custom)
   - Consider security vs. convenience for your use case

4. **Required Scopes**
   Select the following scopes for GitHub MCP server functionality:
   - ✅ **`repo`** - Full control of private repositories (required for GitHub API access)
   - ✅ **`read:user`** - Read access to user profile data
   - ✅ **`user:email`** - Access to user email addresses
   - ✅ **`read:org`** - Read organization information (if working with organizations)

   **Note**: These scopes provide access to GitHub's API through the official GitHub MCP server.

5. **Generate and Copy Token**
   - Click "Generate token"
   - **Important**: Copy the token immediately - you won't be able to see it again
   - Store it securely (password manager recommended)

6. **Set Environment Variable**
   ```bash
   # Windows (Command Prompt)
   set GITHUB_COPILOT_PAT=ghp_your_actual_token_here

   # Windows (PowerShell)
   $env:GITHUB_COPILOT_PAT="ghp_your_actual_token_here"

   # Unix/Linux/macOS
   export GITHUB_COPILOT_PAT="ghp_your_actual_token_here"
   ```

   **Note**: We keep the variable name `GITHUB_COPILOT_PAT` for consistency with existing configuration.

#### Token Security Best Practices

- **Never commit tokens to version control**
- **Use environment variables or secure secret management**
- **Rotate tokens regularly** (every 30-90 days)
- **Use minimum required scopes** for your use case
- **Monitor token usage** in GitHub Settings → Developer settings → Personal access tokens

#### Troubleshooting

If you encounter authentication issues:

1. **Check Token Scopes**
   - Verify the token has the required `repo`, `read:user`, and `read:org` scopes
   - Regenerate with correct scopes if needed

2. **Test Token Manually**
   ```bash
   # Test general GitHub API access
   curl -H "Authorization: Bearer $GITHUB_COPILOT_PAT" https://api.github.com/user
   
   # Test repository access (should show repositories you have access to)
   curl -H "Authorization: Bearer $GITHUB_COPILOT_PAT" https://api.github.com/user/repos
   ```

3. **Verify Repository Access**
   - Ensure the token can access the repositories you want to work with
   - Check that the GitHub MCP server repository is cloned successfully

4. **Enterprise Users**
   - Contact your GitHub admin if PAT creation is restricted
   - May need organization approval for certain scopes

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