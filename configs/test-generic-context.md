---
name: "Test Generic Context Management"
description: "Test configuration demonstrating the new generic context management system"
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
  context_test: "enabled"
---

# Test Generic Context Management

This configuration demonstrates the new generic context management system that can work with any MCP server, not just Azure DevOps.

## New Context Features

The new system provides:

- **Generic Variable Resolution**: `FIELD_FROM_STEP_N` format works with any field name
- **Multiple Data Types**: Automatic extraction of IDs, dates, numbers, URLs, emails, JSON
- **Smart Field Matching**: Intelligent mapping of common field names
- **Backward Compatibility**: Legacy formats still work
- **Extensible Extractors**: Can register custom data extractors

## Variable Format Examples

### Generic Format (Recommended)
```
ID_FROM_STEP_2          # Gets any ID from step 2
DATE_FROM_STEP_1        # Gets any date from step 1
TITLE_FROM_STEP_3       # Gets title/name from step 3
STATUS_FROM_STEP_2      # Gets status/state from step 2
```

### Typed Format
```
ID_FROM_STEP_2_ID       # Specifically gets ID type data
DATE_FROM_STEP_1_DATE   # Specifically gets date type data
URL_FROM_STEP_3_URL     # Specifically gets URL type data
```

### Legacy Format (Still Supported)
```
RESULT_FROM_STEP_2_COMPLETION_DATE    # Old Azure DevOps format
PULL_REQUEST_ID_FROM_STEP_3_RESULT    # Old Azure DevOps format
```

## Default Prompts

### Generic Context Test
```
Initialize the system, get some data, then use that data in a follow-up query
```

### Multi-Step Workflow Test
```
Step 1: Get initial data, Step 2: Process that data, Step 3: Use processed results
``` 