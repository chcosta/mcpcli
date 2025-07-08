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

Markdown configuration files use YAML frontmatter for structured configuration and Markdown content for documentation and default prompts. The configuration supports **multiple MCP servers** for enhanced functionality.

### Configuration Examples

The MCP CLI supports a unified multi-server configuration format that works for both single and multiple server setups:

#### Single Server Configuration

```markdown
---
name: "Azure DevOps Integration"
description: "Azure DevOps MCP server for project management"
preview_features: false
azure_ai:
  endpoint: "https://your-resource.openai.azure.com/"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "gpt-4o"
  model_name: "gpt-4o"
  use_managed_identity: false

# MCP Servers Configuration
servers:
  - name: "azure-devops-primary"
    type: "git"
    url: "https://dev.azure.com/dnceng/internal/_git/dnceng-ai-experimental"
    description: "Azure DevOps integration server"
    enabled: true
    auto_start: true
    port: 3000
    tags: [azure-devops, primary]
    use_managed_identity: true
    tool_defaults:
      initialize_azure_dev_ops_client:
        organizationUrl: "dnceng"
      get_repositories:
        projectName: "internal"
---

# Azure DevOps Integration

This server provides Azure DevOps operations including project management, pull request tracking, and repository analysis.
```

#### Multiple Servers Configuration

```markdown
---
name: "Multi-Server Setup"
description: "Combined Azure DevOps and file system operations"
preview_features: false
azure_ai:
  endpoint: "https://your-resource.openai.azure.com/"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "gpt-4o"
  model_name: "gpt-4o"
  use_managed_identity: false

# MCP Servers Configuration
servers:
  - name: "azure-devops-primary"
    type: "git"
    url: "https://dev.azure.com/dnceng/internal/_git/dnceng-ai-experimental"
    description: "Azure DevOps integration server"
    enabled: true
    auto_start: true
    port: 3000
    tags: [azure-devops, primary]
    use_managed_identity: true
    tool_defaults:
      initialize_azure_dev_ops_client:
        organizationUrl: "dnceng"
        
  - name: "filesystem-server"
    type: "git"
    url: "https://github.com/org/filesystem-mcp.git"
    description: "File system operations server"
    enabled: true
    auto_start: true
    port: 3001
    tags: [filesystem, utility]
    environment:
      BASE_PATH: "${BASE_PATH:C:\\Data}"
      NODE_ENV: "production"
    tool_defaults:
      read_file:
        encoding: "utf-8"
      list_directory:
        include_hidden: false
        
  - name: "database-tools"
    type: "http"
    url: "https://api.example.com/mcp"
    description: "Database operations via HTTP"
    enabled: false
    tags: [database, http]
    headers:
      Authorization: "Bearer ${DB_API_TOKEN}"
      Content-Type: "application/json"
---

# Multi-Server MCP Setup

This configuration provides access to multiple MCP servers:
- **Azure DevOps**: Project management and repository operations
- **File System**: Local file operations and analysis
- **Database Tools**: Remote database operations (disabled by default)
```

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
- `preview_features`: Enable preview features (default: false)
- `azure_ai`: Azure AI Foundry settings
  - `endpoint`: Azure OpenAI endpoint URL
  - `api_key`: API key (or use managed identity)
  - `deployment_name`: Model deployment name
  - `model_name`: Model name (e.g., gpt-4o)
  - `use_managed_identity`: Use managed identity instead of API key
- `servers`: Array of MCP server configurations
  - `name`: Unique server name
  - `type`: Server type (`git` or `http`)
  - `url`: Repository URL (git) or API endpoint (http)
  - `description`: Server description (optional)
  - `enabled`: Enable/disable server (default: true)
  - `auto_start`: Auto-start server (default: true, git only)
  - `port`: Server port (git servers only, default: 3000)
  - `tags`: Array of tags for organization (optional)
  - `use_managed_identity`: Use Azure managed identity (optional)
  - `environment`: Environment variables for git servers (optional)
  - `headers`: HTTP headers for http servers (optional)
  - `tool_defaults`: Default parameters for tools (optional)
    - `tool_name`: Tool name
      - `parameter_name`: Default parameter value
- `variables`: Custom variables for reuse (optional)

**Markdown Content:**
- Code blocks (```) are parsed as default prompts
- Documentation and usage examples

## Environment Variables (Recommended)

For security, use environment variables instead of hardcoding secrets in configuration files:

### Secure Configuration Example

```markdown
---
name: "Secure Multi-Server Setup"
description: "Configuration using environment variables for security"
preview_features: false
azure_ai:
  endpoint: "${AZURE_AI_ENDPOINT}"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "${AZURE_AI_DEPLOYMENT_NAME}"
  model_name: "${AZURE_AI_MODEL_NAME:gpt-4o}"
  use_managed_identity: false

servers:
  - name: "azure-devops"
    type: "git"
    url: "https://dev.azure.com/${AZURE_DEVOPS_ORG}/${AZURE_DEVOPS_PROJECT}/_git/my-mcp-server"
    description: "Azure DevOps integration"
    enabled: true
    auto_start: true
    port: "${MCP_SERVER_PORT:3000}"
    use_managed_identity: true
    tool_defaults:
      initialize_azure_dev_ops_client:
        organizationUrl: "${AZURE_DEVOPS_ORG}"
        
  - name: "custom-server"
    type: "git"
    url: "https://github.com/${GITHUB_ORG}/custom-mcp.git"
    description: "Custom operations server"
    enabled: "${ENABLE_CUSTOM_SERVER:true}"
    auto_start: true
    port: 3001
    environment:
      NODE_ENV: "production"
      CUSTOM_VAR: "${CUSTOM_VARIABLE:default-value}"
      API_ENDPOINT: "${EXTERNAL_API_ENDPOINT}"
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

## Key Features

### Multi-Server Support

Configure and manage multiple MCP servers simultaneously:
- **Git Servers**: Clone from Azure DevOps or GitHub repositories
- **HTTP Servers**: Connect to remote MCP APIs  
- **Enable/Disable**: Control which servers are active
- **Tool Routing**: Automatically route tool calls to appropriate servers
- **Parallel Execution**: Execute tools across multiple servers

### Tool Defaults

Define default parameters for MCP tools to simplify usage:

```yaml
tool_defaults:
  initialize_azure_dev_ops_client:
    organizationUrl: "dnceng"
  get_repositories:
    projectName: "internal"
  read_file:
    encoding: "utf-8"
```

With tool defaults configured:
- **Before**: `mcpcli run -p "initialize azure devops client with organization dnceng"`
- **After**: `mcpcli run -p "initialize azure devops client"` (organization auto-filled)

### Server Management

Control individual servers without changing configuration:

```cmd
# List all configured servers and their status
mcpcli server list

# Enable a specific server
mcpcli server enable azure-devops-primary

# Disable a server temporarily  
mcpcli server disable database-tools

# Check server health and performance
mcpcli server status
```

### Preview Features

Enable experimental features like AI planning mode:

```yaml
preview_features: true  # Enable in configuration
```

Or use command line flag:
```cmd
mcpcli run --config config.md --preview-features --prompt "complex task"
```

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

**Method 1: DefaultAzureCredential (Recommended)**
Set `use_managed_identity: true` in your server configuration:

```yaml
servers:
  - name: "azure-devops"
    type: "git"
    url: "https://dev.azure.com/org/project/_git/repo"
    use_managed_identity: true
    tool_defaults:
      initialize_azure_dev_ops_client:
        organizationUrl: "your-org"
```

DefaultAzureCredential supports multiple authentication methods (tried in order):
- **Managed Identity**: Azure VMs, App Service, Container Instances, etc.
- **Azure CLI**: `az login` (works on developer machines)
- **Visual Studio**: Visual Studio IDE authentication
- **Environment Variables**: `AZURE_CLIENT_ID`, `AZURE_CLIENT_SECRET`, `AZURE_TENANT_ID`
- **Interactive Browser**: Fallback browser-based authentication

**Method 2: Personal Access Token (PAT)**
Set the `AZURE_DEVOPS_PAT` environment variable:

```cmd
# Windows PowerShell
$env:AZURE_DEVOPS_PAT="your-pat-token-here"

# Windows Command Prompt
set AZURE_DEVOPS_PAT=your-pat-token-here
```

The PAT requires these scopes:
- **Code (read)**: Access repositories
- **Project and team (read)**: List projects
- **Pull Request (read)**: Access pull requests

## Configuration Files

- **Main Config**: `%USERPROFILE%\.mcpcli\config.json` - Persistent application settings
- **Markdown Config**: Custom `.md` files - Project-specific configurations

## Examples

### File System MCP Server

```markdown
---
name: "File Operations"
description: "Local file system operations"
azure_ai:
  endpoint: "${AZURE_AI_ENDPOINT}"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "gpt-4o"
  model_name: "gpt-4o"

servers:
  - name: "filesystem-server"
    type: "git"
    url: "https://dev.azure.com/org/project/_git/filesystem-mcp"
    description: "File system operations server"
    enabled: true
    auto_start: true
    port: 3000
    environment:
      BASE_PATH: "C:\\Data"
    tool_defaults:
      read_file:
        encoding: "utf-8"
      list_directory:
        show_hidden: false
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
description: "Database operations and analysis"
azure_ai:
  endpoint: "${AZURE_AI_ENDPOINT}"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "gpt-4o"
  model_name: "gpt-4o"

servers:
  - name: "database-server"
    type: "git"
    url: "https://dev.azure.com/org/project/_git/database-mcp"
    description: "Database operations server"
    enabled: true
    auto_start: true
    port: 3001
    environment:
      DB_CONNECTION: "Server=localhost;Database=mydb"
    tool_defaults:
      execute_query:
        timeout: 30
        format: "table"
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