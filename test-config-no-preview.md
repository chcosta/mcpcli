---
name: "Test Configuration - No Preview"
description: "Test configuration with preview features disabled"
preview_features: false
azure_ai:
  endpoint: "https://andya-ma8fyz00-eastus2.openai.azure.com/"
  api_key: "${azure_ai_api_key}"
  deployment_name: private-gpt-4o
  model_name: gpt-4o
  use_managed_identity: false

# MCP Servers Configuration
servers:
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

# Test Configuration - No Preview Features

This configuration has preview_features disabled to test the non-AI planning mode. 