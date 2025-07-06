# External AI Planning Prompts

The MCP CLI supports external AI planning prompt files, allowing you to customize how the AI analyzes user requests and creates execution plans for MCP tool interactions.

## Overview

Instead of using hardcoded AI planning prompts, you can now:
- Define custom AI planning prompts in markdown files
- Use variable substitution for dynamic content
- Share prompt files across multiple configurations
- Version control your AI planning strategies
- Fallback to built-in prompts when external files are unavailable

## Configuration

Add the `ai_planning_prompt_file` field to your markdown configuration:

```yaml
---
name: "My Configuration"
description: "Configuration with custom AI planning prompt"
azure_ai:
  endpoint: "https://your-resource.openai.azure.com/"
  api_key: "your-api-key"
  deployment_name: "your-deployment"
  model_name: "gpt-4"
repository_url: "https://dev.azure.com/org/project/_git/repo"
ai_planning_prompt_file: "system-prompts/my-custom-prompt.md"
---
```

## Path Resolution

The `ai_planning_prompt_file` path can be:

- **Relative**: `system-prompts/ai-planning-prompt.md` (relative to project root)
- **Absolute**: `C:\path\to\custom-prompt.md`

If no file is specified, the system uses the default prompt at `system-prompts/ai-planning-prompt.md`.

## Prompt File Format

AI planning prompt files must be markdown files with YAML frontmatter:

```markdown
---
name: "My Custom AI Planning Prompt"
description: "Custom prompt for enhanced AI planning"
version: "1.0.0"
variables:
  user_prompt: "{{USER_PROMPT}}"
  available_tools: "{{AVAILABLE_TOOLS}}"
---

# My Custom AI Planning Prompt

You are an AI assistant that helps users interact with MCP servers.

User's request: {{USER_PROMPT}}

Available MCP tools: {{AVAILABLE_TOOLS}}

## Your custom instructions here...
```

## Variable Substitution

The following variables are automatically substituted:

- `{{USER_PROMPT}}`: The user's original request
- `{{AVAILABLE_TOOLS}}`: List of available MCP tools from the server

## Built-in Prompts

### Default System Prompt
Location: `system-prompts/ai-planning-prompt.md`

The default system prompt provides:
- Basic AI planning instructions
- Tool execution format requirements
- Date handling guidelines
- Azure DevOps workflow examples

### Custom Enhanced Prompt
Location: `system-prompts/custom-ai-planning-prompt.md`

The custom enhanced prompt includes:
- Enhanced request analysis
- Validation and error handling steps
- Debugging information
- Comprehensive dependency management

## Creating Custom Prompts

1. **Create the prompt file**:
   ```bash
   mkdir -p system-prompts
   touch system-prompts/my-prompt.md
   ```

2. **Add YAML frontmatter**:
   ```yaml
   ---
   name: "My Custom Prompt"
   description: "Description of what this prompt does"
   version: "1.0.0"
   variables:
     user_prompt: "{{USER_PROMPT}}"
     available_tools: "{{AVAILABLE_TOOLS}}"
   ---
   ```

3. **Write your prompt content**:
   - Use `{{USER_PROMPT}}` for the user's request
   - Use `{{AVAILABLE_TOOLS}}` for available tools
   - Include specific instructions for your use case
   - Define the expected output format

4. **Reference in configuration**:
   ```yaml
   ai_planning_prompt_file: "system-prompts/my-prompt.md"
   ```

## Best Practices

### Prompt Design
- Start with the default prompt as a template
- Include clear format requirements
- Specify exact tool name and parameter formats
- Handle edge cases and error scenarios

### File Organization
- Store prompts in a dedicated directory (`system-prompts/`)
- Use descriptive filenames
- Include version information in frontmatter
- Document prompt purpose and usage

### Testing
- Test prompts with various request types
- Validate tool execution formats
- Check variable substitution
- Ensure fallback behavior works

## Error Handling

The system provides robust error handling:

1. **File Not Found**: Falls back to built-in prompt
2. **Invalid Format**: Uses fallback prompt and logs warning
3. **Missing Variables**: Logs unresolved variables but continues
4. **Parsing Errors**: Falls back to built-in prompt

## Examples

### Basic Custom Prompt
```markdown
---
name: "Simple Custom Prompt"
description: "Basic customization example"
variables:
  user_prompt: "{{USER_PROMPT}}"
  available_tools: "{{AVAILABLE_TOOLS}}"
---

# Simple Custom Prompt

Analyze this request: {{USER_PROMPT}}

Available tools: {{AVAILABLE_TOOLS}}

Create a step-by-step plan using these exact formats:
- Tool name: [tool_name]
- Parameters: [key=value, key2=value2]
- Purpose: [explanation]
```

### Enhanced Debugging Prompt
```markdown
---
name: "Debug-Enhanced Prompt"
description: "Prompt with enhanced debugging and validation"
variables:
  user_prompt: "{{USER_PROMPT}}"
  available_tools: "{{AVAILABLE_TOOLS}}"
---

# Debug-Enhanced AI Planning

## Request Analysis
User wants: {{USER_PROMPT}}

## Available Tools
{{AVAILABLE_TOOLS}}

## Enhanced Instructions
1. Analyze the request thoroughly
2. Include validation steps
3. Add debugging information
4. Plan error handling
5. Provide detailed explanations

Create a comprehensive execution plan with validation and debugging steps.
```

## Integration with Templates

When using the template command, the generated configurations will include the AI planning prompt file field:

```bash
# Generate template with AI planning prompt reference
mcpcli template create "My Config" --description "Config with custom prompt"
```

This creates a configuration that references the default system prompt, which you can then customize as needed.

## Troubleshooting

### Common Issues

1. **Prompt file not found**
   - Check file path (relative to project root)
   - Verify file exists and is readable
   - Check for typos in configuration

2. **Variables not substituted**
   - Ensure variables use `{{VARIABLE_NAME}}` format
   - Check variable names match exactly
   - Verify frontmatter includes variable definitions

3. **AI planning not working**
   - Check prompt format and instructions
   - Verify tool name and parameter formats
   - Test with built-in prompt first

### Debugging Tips

- Enable verbose logging to see which prompt file is loaded
- Test with simple requests first
- Compare with built-in prompt behavior
- Check system logs for error messages

## Migration Guide

To migrate from hardcoded prompts to external files:

1. **Extract current prompt**: Copy the existing prompt logic
2. **Create prompt file**: Save as markdown with frontmatter
3. **Update configuration**: Add `ai_planning_prompt_file` field
4. **Test thoroughly**: Verify behavior matches expectations
5. **Customize gradually**: Make incremental improvements

This feature provides powerful customization capabilities while maintaining backward compatibility and robust error handling. 