---
name: "Test Custom AI Planning Prompt"
description: "Test configuration using custom AI planning prompt with enhanced debugging"
azure_ai:
  endpoint: "https://your-resource.openai.azure.com/"
  api_key: "your-api-key"
  deployment_name: "your-deployment"
  model_name: "gpt-4"
  use_managed_identity: false
repository_url: "https://dev.azure.com/dnceng/internal/_git/dnceng-ai-experimental"
mcp_server:
  port: 3000
  auto_start: true
  environment:
    NODE_ENV: "production"
ai_planning_prompt_file: "system-prompts/custom-ai-planning-prompt.md"
variables:
  debug_mode: "enabled"
  validation_level: "strict"
---

# Test Custom AI Planning Prompt

This configuration demonstrates using a custom AI planning prompt file with enhanced debugging and validation features.

## Custom Prompt Features

The custom AI planning prompt includes:

- **Enhanced Analysis**: More thorough request analysis
- **Validation Steps**: Built-in validation and error handling
- **Debugging Information**: Detailed purpose explanations
- **Dependency Management**: Better handling of step dependencies
- **Error Handling**: Comprehensive error scenarios

## Default Prompts

### Complex Workflow Test
```
Initialize Azure DevOps, get the latest 5 pull requests from the main branch, then get detailed descriptions for each one, and finally summarize the changes
```

### Date-Constrained Query
```
Get all pull requests closed in the last 30 days from the production branch and analyze their impact
``` 