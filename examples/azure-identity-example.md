---
name: Azure Identity MCP Server Example
description: "Example configuration using Azure Identity authentication for HTTP MCP servers"
preview_features: false
azure_ai:
  endpoint: "https://your-resource.openai.azure.com/"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "gpt-4o"
  model_name: "gpt-4o"
  use_managed_identity: false

# MCP Servers Configuration with Azure Identity
servers:
  - name: "azure-resource-manager"
    type: "http"
    url: "https://management.azure.com/mcp/"
    description: "Azure Resource Manager MCP server using Azure Identity"
    enabled: true
    use_azure_identity: true
    azure_tenant_id: "${AZURE_TENANT_ID}"  # Optional: specify tenant
    allow_interactive_auth: true
    azure_scopes: ["https://management.azure.com/.default"]
    
  - name: "azure-graph-api"
    type: "http"
    url: "https://graph.microsoft.com/mcp/"
    description: "Microsoft Graph API MCP server"
    enabled: true
    use_azure_identity: true
    allow_interactive_auth: true
    azure_scopes: ["https://graph.microsoft.com/.default"]
    
  - name: "azure-devops-boards"
    type: "http"
    url: "https://dev.azure.com/your-org/_apis/mcp/"
    description: "Azure DevOps Boards API with Azure Identity"
    enabled: true
    use_azure_identity: true
    azure_tenant_id: "${AZURE_TENANT_ID}"
    allow_interactive_auth: true
    azure_scopes: ["499b84ac-1321-427f-aa17-267ca6975798/.default"]  # Azure DevOps scope
    
  - name: "traditional-auth-server"
    type: "http"
    url: "https://api.example.com/mcp/"
    description: "Traditional token-based authentication server"
    enabled: true
    use_azure_identity: false
    auth_type: "bearer"
    auth_token: "${API_TOKEN}"
    headers:
      X-Custom-Header: "value"

---

# Azure Identity MCP Server Configuration

This example demonstrates how to configure HTTP MCP servers with Azure Identity authentication, providing a secure and seamless authentication experience.

## Azure Identity Features

### 🔐 **Authentication Methods Supported**
- **Managed Identity**: Automatic when running in Azure
- **Azure CLI**: Uses your local Azure CLI authentication  
- **Visual Studio**: Uses Visual Studio authentication
- **Interactive Browser**: Opens browser for authentication when needed
- **Service Principal**: Environment variables or certificate-based

### 🌐 **Scopes Configuration**
Different Azure services require different scopes:
- **Azure Resource Manager**: `https://management.azure.com/.default`
- **Microsoft Graph**: `https://graph.microsoft.com/.default`
- **Azure DevOps**: `499b84ac-1321-427f-aa17-267ca6975798/.default`
- **Custom API**: Your application's scope

### ⚙️ **Configuration Options**

```yaml
servers:
  - name: "my-azure-server"
    type: "http"
    url: "https://api.example.com/mcp/"
    use_azure_identity: true                    # Enable Azure Identity
    azure_tenant_id: "${AZURE_TENANT_ID}"      # Optional: specify tenant
    allow_interactive_auth: true                # Allow browser authentication
    azure_scopes: ["scope1", "scope2"]         # Required scopes
```

## Environment Variables

Set these environment variables for your configuration:

### Windows (PowerShell)
```powershell
$env:AZURE_TENANT_ID="your-tenant-id"
$env:AZURE_AI_API_KEY="your-azure-ai-key"
$env:API_TOKEN="fallback-token-for-traditional-auth"
```

### Unix/Linux/macOS
```bash
export AZURE_TENANT_ID="your-tenant-id"
export AZURE_AI_API_KEY="your-azure-ai-key"
export API_TOKEN="fallback-token-for-traditional-auth"
```

## Authentication Flow

### 1. **First Run (Interactive)**
When you first run the configuration:
1. Azure Identity checks for existing credentials
2. If none found and `allow_interactive_auth: true`, opens browser
3. You authenticate once in the browser
4. Credentials are cached for future use

### 2. **Subsequent Runs (Automatic)**
- Uses cached credentials automatically
- Refreshes tokens as needed
- No user interaction required

### 3. **Production (Managed Identity)**
- When running in Azure (VM, App Service, etc.)
- Uses Managed Identity automatically
- No credentials needed in configuration

## Benefits

### 🔒 **Security**
- No long-lived secrets in configuration files
- Automatic token refresh
- Uses Azure's secure token handling
- Supports conditional access policies

### 🚀 **Developer Experience**
- Works with your existing Azure CLI login
- Seamless Visual Studio integration
- Interactive browser fallback when needed
- Same configuration works locally and in Azure

### 🛠️ **Operational**
- No token management required
- Works with Azure RBAC
- Audit trails through Azure AD
- Centralized access control

## Common Scopes

| Service | Scope | Description |
|---------|--------|-------------|
| Azure Resource Manager | `https://management.azure.com/.default` | Manage Azure resources |
| Microsoft Graph | `https://graph.microsoft.com/.default` | Access Microsoft 365 data |
| Azure DevOps | `499b84ac-1321-427f-aa17-267ca6975798/.default` | Azure DevOps APIs |
| Key Vault | `https://vault.azure.net/.default` | Access Azure Key Vault |
| Storage | `https://storage.azure.com/.default` | Access Azure Storage |

## Troubleshooting

### Authentication Issues
```bash
# Check your Azure CLI authentication
az account show

# Login if needed
az login

# Check token for specific scope
az account get-access-token --scope https://management.azure.com/.default
```

### Common Error Solutions
- **"No credentials available"**: Run `az login` or enable interactive auth
- **"Access denied"**: Check RBAC permissions in Azure portal
- **"Invalid scope"**: Verify the scope URL for your target service
- **"Tenant not found"**: Check `azure_tenant_id` value

## Example Usage

```bash
# Run with Azure Identity authentication
mcpcli run --config examples/azure-identity-example.md --prompt "list azure resources"

# Interactive authentication will occur on first run
# Subsequent runs will use cached credentials automatically
```

This configuration provides enterprise-grade security while maintaining ease of use for developers. 