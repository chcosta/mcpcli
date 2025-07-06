---
name: "My MCP Server Setup"
description: "Example configuration for a file system MCP server"
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

# My MCP Server Setup

This configuration sets up a file system MCP server that provides file operations capabilities to Azure AI Foundry models.

## Azure AI Configuration

This configuration connects to Azure AI Foundry with the following settings:
- **Endpoint**: Your Azure OpenAI endpoint URL
- **API Key**: Your Azure OpenAI API key
- **Deployment**: The model deployment name (e.g., gpt-4)
- **Model**: The model to use (gpt-4, gpt-3.5-turbo, etc.)

## Repository Configuration

The MCP server will be cloned from the specified Azure DevOps repository. This should contain a Node.js, Python, or .NET MCP server implementation.

## MCP Server Configuration

- **Port**: The server runs on port 3000
- **Auto Start**: Automatically starts the server when running
- **Environment**: Sets NODE_ENV and DEBUG variables for the server

## Default Prompts

The following prompts are available for quick execution:

### List Files
```
List all files in the current directory and show their sizes
```

### File Analysis
```
Analyze the structure of the project and identify the main components
```

### Search Files
```
Search for files containing the word "configuration" and summarize their contents
```

### System Status
```
Check the system status and report any issues or warnings
```

## Usage Examples

1. **Generate this template**:
   ```cmd
   mcpcli template --name "My MCP Server Setup" --description "Example configuration for a file system MCP server"
   ```

2. **List available prompts**:
   ```cmd
   mcpcli run --config example-config.md --list-prompts
   ```

3. **Run with a specific prompt**:
   ```cmd
   mcpcli run --config example-config.md --prompt "List all files in the current directory"
   ```

4. **Run with a default prompt by index**:
   ```cmd
   mcpcli run --config example-config.md --prompt-index 0
   ```

## Variables

- `base_path`: Base directory for file operations (Windows path format)
- `max_file_size`: Maximum file size for processing

These variables can be referenced in prompts or server configuration as needed. 