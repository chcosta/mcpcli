---
name: "Test External AI Planning Prompt"
description: "Test configuration using external AI planning prompt file"
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
ai_planning_prompt_file: "system-prompts/ai-planning-prompt.md"
variables:
  custom_var: "value"
---

# Test External AI Planning Prompt

This configuration demonstrates using an external AI planning prompt file instead of the hardcoded prompt.

## AI Planning Prompt Configuration

The `ai_planning_prompt_file` field specifies the path to a markdown file containing the AI planning prompt. This allows for:

- **Customization**: Modify the AI planning behavior without changing code
- **Reusability**: Share prompt files across multiple configurations
- **Version Control**: Track changes to prompts separately from code
- **Fallback**: If the file is not found, the system uses a hardcoded fallback

## Path Resolution

The path can be:
- **Relative**: `system-prompts/ai-planning-prompt.md` (relative to project root)
- **Absolute**: `C:\path\to\custom-prompt.md`

## Default Prompts

### Test Prompt 1
```
What is the current status of the system?
```

### Test Prompt 2
```
Generate a summary of recent activities
``` 