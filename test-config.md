---
name: "Test Configuration"
description: "Test configuration for tool selection fix"
preview_features: true
azure_ai:
  endpoint: "https://test-endpoint.openai.azure.com/"
  api_key: "test-api-key"
  deployment_name: "test-deployment"
  model_name: "gpt-4"
  use_managed_identity: false

# MCP Servers Configuration
servers:
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
---

# Test Configuration

This is a test configuration to verify that the AI planning feature correctly selects tools based on their descriptions.

## Expected Behavior

When given the prompt "initialize the client and tell me all the projects in the dnceng organization", the AI should:

1. Use `InitializeAzureDevOpsClient` to initialize the connection
2. Use `get_projects` to retrieve the list of projects
3. NOT use `get_pull_request_description` since that's not relevant to listing projects

## Test Prompt

```
initialize the client and tell me all the projects in the dnceng organization
``` 