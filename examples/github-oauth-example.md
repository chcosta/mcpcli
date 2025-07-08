---
name: GitHub OAuth MCP Server Example
description: "Example configuration using GitHub OAuth authentication for HTTP MCP servers"
preview_features: false
azure_ai:
  endpoint: "https://your-resource.openai.azure.com/"
  api_key: "${AZURE_AI_API_KEY}"
  deployment_name: "gpt-4o"
  model_name: "gpt-4o"
  use_managed_identity: false

# MCP Servers Configuration with GitHub Authentication
servers:
  # Method 1: Device Flow (Recommended - interactive browser authentication)
  - name: "github-api-device"
    type: "http"
    url: "https://api.github.com/mcp/"
    description: "GitHub API using device flow (interactive browser)"
    enabled: true
    use_github_auth: true
    github_auth_method: "device"  # Interactive browser authentication
    github_scopes: ["user", "repo", "gist"]
    
  # Method 2: GitHub CLI (requires CLI setup)
  - name: "github-api-cli"
    type: "http"
    url: "https://api.github.com/mcp/"
    description: "GitHub API using CLI authentication"
    enabled: false
    use_github_auth: true
    github_auth_method: "cli"  # Uses 'gh auth token'
    github_scopes: ["user", "repo", "gist"]
    
  # Method 3: Personal Access Token
  - name: "github-api-token"
    type: "http"
    url: "https://api.github.com/mcp/"
    description: "GitHub API using personal access token"
    enabled: false
    use_github_auth: true
    github_auth_method: "token"
    github_token: "${GITHUB_TOKEN}"  # Your personal access token
    github_scopes: ["user", "repo", "gist"]
    
  # Method 4: OAuth App (Advanced - requires app setup)
  - name: "github-api-oauth"
    type: "http"
    url: "https://api.github.com/mcp/"
    description: "GitHub API using OAuth app"
    enabled: false  # Disabled by default
    use_github_auth: true
    github_auth_method: "oauth"
    github_client_id: "${GITHUB_CLIENT_ID}"
    github_client_secret: "${GITHUB_CLIENT_SECRET}"
    allow_github_interactive_auth: true
    github_scopes: ["user", "repo", "gist"]

---

# GitHub Authentication for MCP Servers

This example demonstrates how to configure HTTP MCP servers with GitHub authentication. You can choose from three authentication methods, with GitHub CLI being the easiest option.

## 🚀 **Quick Start (Recommended)**

### Method 1: Device Flow Authentication
The easiest way to authenticate as the current user with **zero setup**:

1. **Use in configuration**:
   ```yaml
   servers:
     - name: "github-api"
       type: "http"
       url: "https://api.github.com/mcp/"
       use_github_auth: true
       github_auth_method: "device"  # That's it!
   ```

2. **First run will prompt you**:
   ```
   === GitHub Authentication Required ===
   
   Please visit: https://github.com/login/device
   And enter code: ABCD-1234
   
   Opening browser automatically...
   Waiting for authorization...
   ```

3. **Authorize in browser** and you're done!

**Benefits of Device Flow**:
- ✅ **Zero setup required** - no CLI installation needed
- ✅ **Interactive browser** - familiar GitHub login experience
- ✅ **Authenticates as you** - uses your GitHub account
- ✅ **Works with 2FA** - handles all authentication complexity
- ✅ **Works with SSO** - supports organization single sign-on
- ✅ **No app registration** - uses GitHub's public device flow
- ✅ **Secure** - no secrets in configuration files

### 🌐 **GitHub Scopes**
Different GitHub APIs require different scopes:
- **`user`**: Read user profile information
- **`repo`**: Full access to repositories (read and write)
- **`public_repo`**: Access to public repositories only
- **`gist`**: Create, read, update gists
- **`copilot`**: Access GitHub Copilot features (if available)
- **`read:org`**: Read organization membership
- **`workflow`**: Access GitHub Actions workflows

## 🔧 **Authentication Methods**

### Method 1: Device Flow (Recommended)
```yaml
use_github_auth: true
github_auth_method: "device"              # Interactive browser authentication
github_scopes: ["user", "repo"]           # Optional: specify required scopes
```

### Method 2: GitHub CLI
```yaml
use_github_auth: true
github_auth_method: "cli"                 # Uses current user's GitHub CLI token
github_scopes: ["user", "repo"]           # Optional: specify required scopes
```

### Method 3: Personal Access Token  
```yaml
use_github_auth: true
github_auth_method: "token"               # Uses personal access token
github_token: "${GITHUB_TOKEN}"           # Your GitHub personal access token
github_scopes: ["user", "repo"]           # Optional: specify scopes (for documentation)
```

### Method 4: OAuth App (Advanced)
```yaml
use_github_auth: true
github_auth_method: "oauth"               # Uses OAuth app flow
github_client_id: "${GITHUB_CLIENT_ID}"   # OAuth app client ID
github_client_secret: "${GITHUB_CLIENT_SECRET}" # OAuth app secret
allow_github_interactive_auth: true       # Allow browser authentication
github_scopes: ["user", "repo"]           # Required scopes
```

## 🛠️ **Setup Instructions**

### Method 1: Device Flow Setup (Zero Setup Required!)
```bash
# No setup required! Just run your configuration and follow the prompts.
# The app will automatically open your browser for GitHub authentication.
```

### Method 2: GitHub CLI Setup
```bash
# Install GitHub CLI (if not already installed)
gh --version  # Check if installed

# Login to GitHub (one time setup)
gh auth login

# That's it! Your configuration will automatically use your GitHub authentication
```

### Method 3: Personal Access Token Setup
1. **Create Personal Access Token**:
   - Go to GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)
   - Click "Generate new token (classic)"
   - Select scopes: `user`, `repo`, etc.
   - Copy the generated token

2. **Set Environment Variable**:
   ```bash
   # Windows (PowerShell)
   $env:GITHUB_TOKEN="your-personal-access-token-here"
   
   # Unix/Linux/macOS
   export GITHUB_TOKEN="your-personal-access-token-here"
   ```

### Method 3: OAuth App Setup (Advanced)
1. **Create GitHub OAuth App**:
   - Go to GitHub Settings → Developer settings → OAuth Apps
   - Click "New OAuth App"
   - Fill in application details:
     - **Application name**: "MCP CLI Tool"
     - **Homepage URL**: "https://github.com/your-username/mcpcli"
     - **Authorization callback URL**: `http://localhost:8080/callback`
   - Click "Register application"
   - Note the **Client ID** and generate a **Client Secret**

2. **Set Environment Variables**:
   ```bash
   # Windows (PowerShell)
   $env:GITHUB_CLIENT_ID="your-client-id-here"
   $env:GITHUB_CLIENT_SECRET="your-client-secret-here"
   
   # Unix/Linux/macOS
   export GITHUB_CLIENT_ID="your-client-id-here"
   export GITHUB_CLIENT_SECRET="your-client-secret-here"
   ```

## Authentication Flow

### 1. **First Run (Interactive)**
When you first run the configuration:
1. Application starts local HTTP server on port 8080
2. Opens browser to GitHub OAuth authorization page
3. User logs into GitHub and authorizes the application
4. GitHub redirects back to local server with authorization code
5. Application exchanges code for access token
6. Access token is used for API requests

### 2. **Token Usage**
- Access token is automatically added to Authorization header
- Token is valid for the duration of the session
- No token caching implemented (tokens obtained per session)

### 3. **Security Features**
- **State Parameter**: Prevents CSRF attacks
- **Local Callback**: Secure localhost callback handling
- **HTTPS Communication**: All GitHub API calls use HTTPS
- **No Token Storage**: Tokens are not persisted to disk

## Benefits

### 🔒 **Security**
- **No hardcoded tokens** in configuration files
- **Dynamic token acquisition** with proper OAuth flow
- **User-controlled permissions** through GitHub's OAuth consent
- **Secure callback handling** with state validation

### 🚀 **User Experience**
- **Familiar GitHub login** process
- **Clear permission requests** during OAuth consent
- **No manual token management** required
- **Works with 2FA** enabled GitHub accounts

### 🛠️ **Operational**
- **No token expiration issues** (new token per session)
- **Works with organization SSO** if configured
- **Audit trails** through GitHub's OAuth logs
- **Granular scope control**

## Common Scopes

| Scope | Access Level | Use Case |
|-------|-------------|----------|
| `user` | Public profile info | Basic user identification |
| `user:email` | Email addresses | Contact information |
| `repo` | Full repository access | Code management, issues, PRs |
| `public_repo` | Public repositories only | Open source projects |
| `gist` | Gist management | Code snippets |
| `read:org` | Organization membership | Team/org information |
| `workflow` | GitHub Actions | CI/CD management |
| `copilot` | GitHub Copilot | AI-powered coding assistance |

## Troubleshooting

### OAuth App Issues
```bash
# Verify your OAuth app settings
# Callback URL must be: http://localhost:8080/callback
# Make sure the app is not suspended or restricted
```

### Common Error Solutions
- **"Application not authorized"**: Check OAuth app approval in GitHub
- **"Invalid client"**: Verify CLIENT_ID and CLIENT_SECRET
- **"Redirect URI mismatch"**: Ensure callback URL is `http://localhost:8080/callback`
- **"Port already in use"**: Close other applications using port 8080
- **"Access denied"**: User cancelled OAuth flow or insufficient permissions

### Firewall/Network Issues
- Ensure port 8080 is not blocked by firewall
- Corporate networks may block localhost callbacks
- Consider using GitHub Personal Access Tokens as fallback

## 🎯 **Example Usage**

### Using Device Flow (Recommended)
```bash
# Just run it - interactive browser authentication will start automatically
mcpcli run --config examples/github-oauth-example.md --prompt "list my repositories"

# Each run: Opens browser for GitHub authorization (secure, no token storage)
# Quick and easy - just click authorize in the browser that opens
```

### Using GitHub CLI
```bash
# Just run it - uses your current GitHub authentication
mcpcli run --config examples/github-oauth-example.md --prompt "list my repositories"

# No browser popups, no token management needed!
```

### Using Personal Access Token
```bash
# Set your token and run
export GITHUB_TOKEN="ghp_your_token_here"
mcpcli run --config examples/github-oauth-example.md --prompt "list my repositories"
```

### Using OAuth App
```bash
# Set OAuth credentials and run
export GITHUB_CLIENT_ID="your_client_id"
export GITHUB_CLIENT_SECRET="your_client_secret"
mcpcli run --config examples/github-oauth-example.md --prompt "list my repositories"

# First run will open browser for GitHub OAuth
# Subsequent runs in the same session will reuse the token
```

## Security Best Practices

### OAuth App Configuration
- Use specific callback URLs (not wildcards)
- Regularly rotate client secrets
- Monitor OAuth app usage in GitHub settings
- Use minimal required scopes

### Environment Variables
- Never commit CLIENT_SECRET to version control
- Use different OAuth apps for dev/staging/prod
- Consider using secret management systems
- Rotate secrets regularly

### Network Security
- OAuth flow uses HTTPS for all GitHub communication
- Local callback server runs only during authentication
- No sensitive data is logged or persisted

This configuration provides secure, user-friendly GitHub authentication while maintaining compatibility with traditional token-based authentication methods. 