# Multi-Server Release Analysis

This configuration demonstrates using multiple MCP servers for comprehensive release analysis.

## Configuration

```yaml
azure_ai:
  endpoint: "https://your-ai-endpoint.openai.azure.com/"
  api_key: "${AZURE_AI_API_KEY}"
  model_name: "gpt-4o"

# MCP Servers Configuration
servers:
  # Primary Azure DevOps server (Git-based)
  - name: "azure-devops"
    type: "git"
    url: "https://dev.azure.com/dnceng/internal/_git/dnceng-ai-experimental"
    description: "Azure DevOps integration for pull requests and work items"
    enabled: true
    auto_start: true
    port: 3000
    tags: ["devops", "primary"]
    tool_defaults:
      initialize_azure_dev_ops_client:
        organizationUrl: "dnceng"
      get_repositories:
        projectName: "internal"

  # External weather service (HTTP-based)
  - name: "weather-service"
    type: "http"
    url: "https://weather-mcp-api.example.com"
    description: "Weather information for deployment planning"
    enabled: true
    headers:
      "X-API-Version": "v1"
    auth_type: "bearer"
    auth_token: "${WEATHER_API_TOKEN}"
    tags: ["weather", "external"]

  # Local tools server (Git-based)
  - name: "local-tools"
    type: "git"
    url: "https://github.com/myorg/custom-mcp-tools"
    description: "Custom organizational tools"
    enabled: true
    auto_start: true
    port: 3001
    branch: "main"
    tags: ["custom", "internal"]
    environment:
      CUSTOM_API_KEY: "${CUSTOM_API_KEY}"
    tool_defaults:
      analyze_deployment:
        environment: "production"

  # Database analytics (HTTP-based) - temporarily disabled
  - name: "analytics-db"
    type: "http"
    url: "https://analytics.internal.com/mcp"
    description: "Database analytics and metrics"
    enabled: false
    headers:
      "Authorization": "Bearer ${DB_API_TOKEN}"
      "Content-Type": "application/json"
    tags: ["analytics", "database"]

  # Development server (Git-based) - only enabled for testing
  - name: "dev-server"
    type: "git"
    url: "https://github.com/myorg/dev-mcp-server"
    description: "Development and testing server"
    enabled: false
    auto_start: false
    port: 3002
    branch: "develop"
    tags: ["development", "testing"]

preview_features: true
```

## Default Prompts

```yaml
default_prompts:
  - "Get recent pull requests and check weather for deployment planning"
  - "Analyze deployment metrics using custom tools and database analytics"
  - "Comprehensive release report using all available servers"
```

## Usage Examples

### Example 1: Cross-Server Analysis
This prompt will use tools from multiple servers:
```
"Initialize Azure DevOps, get recent pull requests, check weather conditions for deployment, and run custom deployment analysis"
```

### Example 2: Server-Specific Tools
When AI planning is enabled, tools will be automatically routed to appropriate servers based on tool availability.

### Example 3: Fallback Behavior
If one server is unavailable, the system will continue with available servers and report which tools couldn't be executed. 