# MCP CLI

A command-line interface for connecting Azure AI Foundry models to MCP (Model Context Protocol) servers hosted in Azure DevOps repositories.

## Features

- **Azure AI Foundry Integration**: Connect to Azure OpenAI models with API key or managed identity authentication
- **Azure DevOps Git Integration**: Clone and manage MCP servers from Azure DevOps repositories
- **MCP Server Management**: Automatically discover, start, and manage MCP servers
- **Markdown Configuration**: Define your environment setup in readable Markdown files
- **Prompt Management**: Store and execute default prompts for quick operations
- **Configuration Management**: Persistent configuration with secure credential storage

## Installation

1. Clone this repository
2. Build the project:
   ```cmd
   dotnet build
   ```
3. Run the CLI:
   ```cmd
   dotnet run -- --help
   ```

## Quick Start

### 1. Initialize Configuration

```cmd
# Initialize default configuration
mcpcli config init

# Set your Azure AI Foundry credentials
mcpcli config set --key "AzureAi.Endpoint" --value "https://your-resource.openai.azure.com/"
mcpcli config set --key "AzureAi.ApiKey" --value "your-api-key"
mcpcli config set --key "AzureAi.DeploymentName" --value "gpt-4"

# Set your Azure DevOps credentials (choose one method)

# Method 1: Personal Access Token
mcpcli config set --key "AzureDevOps.Organization" --value "your-org"
mcpcli config set --key "AzureDevOps.PersonalAccessToken" --value "your-pat"

# Method 2: Managed Identity / DefaultAzureCredential
mcpcli config set --key "AzureDevOps.Organization" --value "your-org"
mcpcli config set --key "AzureDevOps.UseManagedIdentity" --value "true"
```

### 2. Generate a Markdown Configuration Template

```cmd
# Generate template with default placeholder values
mcpcli template --name "My Project" --description "File system MCP server setup"

# Generate template using current configuration values (secrets replaced with placeholders)
mcpcli template --name "My Project" --description "File system MCP server setup" --use-current-config
```

This creates a `my-project.md` file with a template you can customize. The `--use-current-config` option uses your current configuration values as defaults, making it easier to create new configurations.

### 3. Run with Markdown Configuration

```cmd
# List available prompts in the configuration
mcpcli run --config my-project.md --list-prompts

# Run with a specific prompt
mcpcli run --config my-project.md --prompt "List all files in the current directory"

# Run with a default prompt by index
mcpcli run --config my-project.md --prompt-index 0
```

### 4. Manual Connection (Alternative)

```cmd
mcpcli connect --repository "https://dev.azure.com/your-org/your-project/_git/your-mcp-server" --prompt "What is the current status?"
```

## Commands

### `mcpcli run`

Run MCP CLI using a Markdown configuration file (recommended approach).

**Options:**
- `--config, -c`: Path to Markdown configuration file (required)
- `--prompt, -p`: Prompt to send (optional, uses default prompts if not provided)
- `--list-prompts`: List available default prompts
- `--prompt-index`: Index of default prompt to use (0-based)
- `--working-dir`: Working directory for repositories (default: ./mcp-servers)

**Examples:**
```cmd
# List prompts
mcpcli run -c config.md --list-prompts

# Run with custom prompt
mcpcli run -c config.md -p "Analyze the project structure"

# Run with default prompt
mcpcli run -c config.md --prompt-index 0
```

### `mcpcli template`

Generate Markdown configuration templates.

**Options:**
- `--name, -n`: Template name (required)
- `--description, -d`: Template description (optional)
- `--output, -o`: Output file path (default: <name>.md)
- `--use-current-config, -c`: Use current configuration values as defaults (secrets replaced with placeholders)

**Examples:**
```cmd
# Generate template with default placeholders
mcpcli template -n "File Server" -d "File operations MCP server"

# Generate template using current configuration
mcpcli template -n "Database Tools" -o db-config.md --use-current-config

# Generate template with custom output path
mcpcli template -n "Custom Server" -o custom-path.md
```

### `mcpcli connect`

Direct connection to MCP server (manual approach).

**Options:**
- `--repository, -r`: Repository URL (required)
- `--prompt, -p`: Prompt to send (required)
- `--port`: MCP server port (default: 3000)
- `--working-dir`: Working directory (default: ./mcp-servers)
- `--force-clone`: Force re-clone repository

**Examples:**
```cmd
mcpcli connect -r "https://dev.azure.com/org/project/_git/mcp-server" -p "Hello world"
mcpcli connect -r "https://github.com/user/mcp-server.git" -p "Status check" --port 3001
```

### `mcpcli config`

Manage application configuration.

**Subcommands:**
- `init`: Initialize default configuration
- `show`: Show current configuration
- `set`: Set configuration value
- `get`: Get configuration value

**Examples:**
```cmd
mcpcli config init
mcpcli config show
mcpcli config set --key "AzureAi.Endpoint" --value "https://your-resource.openai.azure.com/"
mcpcli config get --key "AzureAi.ModelName"
```

### `mcpcli list`

List running MCP servers (placeholder for future implementation).

### `mcpcli stop`

Stop running MCP servers (placeholder for future implementation).

## Markdown Configuration Format

Markdown configuration files use YAML frontmatter for structured configuration and Markdown content for documentation and default prompts.

### Example Configuration

```markdown
---
name: "My MCP Server"
description: "File system operations server"
azure_ai:
  endpoint: "https://your-resource.openai.azure.com/"
  api_key: "your-api-key"
  deployment_name: "gpt-4"
  model_name: "gpt-4"
  use_managed_identity: false
repository_url: "https://dev.azure.com/org/project/_git/mcp-server"
mcp_server:
  port: 3000
  auto_start: true
  environment:
    NODE_ENV: "production"
variables:
  base_path: "C:\\Data"
---

# My MCP Server

This server provides file system operations.

## Default Prompts

### List Files
```
List all files in the current directory
```

### File Analysis
```
Analyze the project structure and identify main components
```
```

### Configuration Schema

**YAML Frontmatter:**
- `name`: Configuration name
- `description`: Configuration description
- `azure_ai`: Azure AI Foundry settings
  - `endpoint`: Azure OpenAI endpoint URL
  - `api_key`: API key (or use managed identity)
  - `deployment_name`: Model deployment name
  - `model_name`: Model name (e.g., gpt-4)
  - `use_managed_identity`: Use managed identity instead of API key
- `repository_url`: Azure DevOps Git repository URL
- `mcp_server`: MCP server configuration
  - `port`: Server port (default: 3000)
  - `auto_start`: Auto-start server (default: true)
  - `environment`: Environment variables
- `variables`: Custom variables for reuse

**Markdown Content:**
- Code blocks (```) are parsed as default prompts
- Documentation and usage examples

## Environment Variables (Recommended)

For security, use environment variables instead of hardcoding secrets in configuration files:

### Secure Configuration Example

```markdown
---
name: "Secure MCP Server"
description: "Configuration using environment variables"
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

### Setting Environment Variables

**Windows Command Prompt:**
```cmd
set AZURE_AI_ENDPOINT=https://your-resource.openai.azure.com/
set AZURE_AI_API_KEY=your-api-key-here
set AZURE_AI_DEPLOYMENT_NAME=your-deployment-name
set AZURE_DEVOPS_ORG=your-organization
set AZURE_DEVOPS_PROJECT=your-project
```

**Windows PowerShell:**
```powershell
$env:AZURE_AI_ENDPOINT="https://your-resource.openai.azure.com/"
$env:AZURE_AI_API_KEY="your-api-key-here"
$env:AZURE_AI_DEPLOYMENT_NAME="your-deployment-name"
$env:AZURE_DEVOPS_ORG="your-organization"
$env:AZURE_DEVOPS_PROJECT="your-project"
```

### Supported Formats

- `${VAR_NAME}` - Unix/Linux style with braces
- `${VAR_NAME:default}` - With default value
- `%VAR_NAME%` - Windows style
- `$VAR_NAME` - Simple Unix style

### Benefits

- **Security**: Secrets are not stored in configuration files
- **Automatic Enforcement**: Secret fields (API keys, tokens, passwords) are automatically validated
- **Flexibility**: Different environments can use different values
- **Version Control Safe**: Configuration files can be safely committed
- **Team Sharing**: Team members can use the same config with their own secrets

📖 **Full Documentation**: See [docs/environment-variables.md](docs/environment-variables.md) for complete details.

## Supported MCP Server Types

The CLI automatically detects and supports:

- **Node.js**: Looks for `package.json`, `index.js`, `server.js`
- **Python**: Looks for `main.py`, `server.py`, `requirements.txt`
- **.NET**: Looks for `*.csproj` files
- **Custom**: Define `start_command` and `start_arguments` in configuration

## Authentication

### Azure AI Foundry

Choose one of:
1. **API Key**: Set `azure_ai.api_key` in configuration
2. **Managed Identity**: Set `azure_ai.use_managed_identity: true`

### Azure DevOps

Choose one of the following authentication methods:

**Method 1: Personal Access Token (PAT)**
```cmd
mcpcli config set --key "AzureDevOps.Organization" --value "your-org"
mcpcli config set --key "AzureDevOps.PersonalAccessToken" --value "your-pat"
```

**Method 2: DefaultAzureCredential (Recommended for Enterprise)**
```cmd
mcpcli config set --key "AzureDevOps.Organization" --value "your-org"
mcpcli config set --key "AzureDevOps.UseManagedIdentity" --value "true"
```

DefaultAzureCredential supports:
- Managed Identity (Azure VMs, App Service, etc.)
- Azure CLI authentication (`az login`)
- Visual Studio authentication
- Environment variables (AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, AZURE_TENANT_ID)

## Configuration Files

- **Main Config**: `%USERPROFILE%\.mcpcli\config.json` - Persistent application settings
- **Markdown Config**: Custom `.md` files - Project-specific configurations

## Examples

### File System MCP Server

```markdown
---
name: "File Operations"
repository_url: "https://dev.azure.com/org/project/_git/filesystem-mcp"
mcp_server:
  port: 3000
  environment:
    BASE_PATH: "C:\\Data"
---

# File Operations MCP Server

### List Directory
```
List all files and folders in the current directory with their sizes
```

### Search Files
```
Search for files containing "configuration" and summarize their contents
```
```

### Database MCP Server

```markdown
---
name: "Database Tools"
repository_url: "https://dev.azure.com/org/project/_git/database-mcp"
mcp_server:
  port: 3001
  environment:
    DB_CONNECTION: "Server=localhost;Database=mydb"
---

# Database Tools MCP Server

### Schema Analysis
```
Analyze the database schema and identify all tables and relationships
```

### Query Builder
```
Help me build a SQL query to find all users created in the last 30 days
```
```

## Troubleshooting

### Common Issues

1. **Authentication Errors**
   - Verify Azure AI Foundry credentials: `mcpcli config show`
   - For Azure DevOps PAT: Check token permissions and expiration
   - For Azure DevOps Managed Identity: Ensure you're authenticated (`az login` or running in Azure)

2. **Repository Clone Failures**
   - Ensure PAT has repository read permissions
   - For managed identity: Verify the identity has Azure DevOps access
   - Check repository URL format

3. **MCP Server Start Failures**
   - Verify server dependencies are installed
   - Check port availability
   - Review server logs

### Debug Mode

Enable verbose logging:
```cmd
# Set log level to debug
set DOTNET_LOGGING__CONSOLE__LOGLEVEL__DEFAULT=Debug
mcpcli run -c config.md -p "test"
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is licensed under the MIT License. 