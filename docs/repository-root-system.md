# Repository Root System

The MCP CLI now uses a `.reporoot` marker file system to standardize relative path resolution across the entire application.

## Overview

Instead of using relative paths based on the current working directory, all relative paths in the MCP CLI are now resolved relative to the repository root directory, which is identified by the presence of a `.reporoot` marker file.

## How It Works

### Repository Root Detection

The system automatically searches for a `.reporoot` file starting from the current directory and working upwards through the directory hierarchy. The first directory containing a `.reporoot` file is considered the repository root.

If no `.reporoot` file is found, the current directory is used as a fallback.

### Path Resolution

All relative paths in the system are resolved relative to the repository root:

- **Relative paths** (e.g., `./configs/`, `system-prompts/`, `../docs/`) are resolved relative to the repository root
- **Absolute paths** (e.g., `C:\path\to\file`, `/path/to/file`) are used as-is
- **Repository root** is returned when an empty or null path is provided

## Implementation

### Core Service

The `RepositoryRootService` provides the following functionality:

- `GetRepositoryRoot()`: Returns the absolute path to the repository root
- `ResolvePath(string relativePath)`: Resolves a relative path to an absolute path
- `IsRelativePath(string path)`: Checks if a path is relative
- `GetRelativePath(string absolutePath)`: Converts an absolute path to a relative path from repository root

### Integration Points

The repository root system is integrated into the following services:

1. **PlanPersistenceService**: Plans are stored in `.plans` directory relative to repository root
2. **AiPlanGenerator**: System prompts are loaded from `system-prompts/` relative to repository root
3. **MarkdownConfigService**: Configuration files are resolved relative to repository root
4. **SystemPromptService**: Prompt files are resolved relative to repository root
5. **PromptFileService**: Prompt files are resolved relative to repository root
6. **MultiMcpServerService**: Working directories for MCP servers are resolved relative to repository root
7. **ConnectCommand**: Working directories for repository cloning are resolved relative to repository root
8. **PlanCommand**: Working directories for plan execution are resolved relative to repository root

## Benefits

### Consistent Path Resolution

- **Predictable behavior**: Paths are always resolved relative to the same base directory
- **Portable configurations**: Configuration files work regardless of where the CLI is run from
- **Version control friendly**: All paths are relative to the repository, making them work across different environments

### Simplified Configuration

- **No absolute paths needed**: All paths in configuration files can be relative
- **Cross-platform compatibility**: Relative paths work the same on Windows, macOS, and Linux
- **Easier deployment**: No need to hardcode absolute paths for different environments

### Better Organization

- **Clear structure**: All project files are organized relative to the repository root
- **Logical grouping**: Related files (configs, prompts, plans) are grouped together
- **Easy navigation**: Developers can easily understand the project structure

## Usage Examples

### Configuration Files

```yaml
# configs/my-config.md
---
name: "My Configuration"
ai_planning_prompt_file: "system-prompts/custom-prompt.md"
---
```

### Command Line

```bash
# These all work from any directory within the repository
mcpcli run --config configs/my-config.md
mcpcli run --config ./configs/my-config.md
mcpcli run --working-dir ./mcp-servers
mcpcli run --working-dir mcp-servers
```

### File Structure

```
repository-root/
├── .reporoot                    # Marker file
├── configs/
│   ├── my-config.md
│   └── another-config.md
├── system-prompts/
│   ├── ai-planning-prompt.md
│   └── custom-prompt.md
├── .plans/                      # Generated plans
├── mcp-servers/                 # Working directory for servers
└── src/
    └── mcpcli.csproj
```

## Migration Guide

### For Existing Users

1. **Create `.reporoot` file**: Add a `.reporoot` file to your repository root
2. **Update paths**: Convert any absolute paths in configurations to relative paths
3. **Test configurations**: Verify that all relative paths work correctly

### For New Users

1. **Use relative paths**: Always use relative paths in configuration files
2. **Organize files**: Group related files in logical directories under the repository root
3. **Follow conventions**: Use consistent naming for directories (e.g., `configs/`, `system-prompts/`)

## Troubleshooting

### Common Issues

1. **Paths not resolving correctly**
   - Ensure `.reporoot` file exists in the repository root
   - Check that paths are relative (not absolute)
   - Verify the repository root is being detected correctly

2. **Configuration files not found**
   - Use relative paths from repository root
   - Check file permissions and existence
   - Verify the path resolution in logs

3. **Working directories not created**
   - Ensure the repository root is writable
   - Check that relative paths are valid
   - Verify directory creation permissions

### Debugging

Enable debug logging to see path resolution details:

```bash
# Set environment variable for debug logging
$env:Logging__LogLevel__Default="Debug"
mcpcli run --config configs/my-config.md
```

The logs will show:
- Repository root detection
- Path resolution steps
- Final resolved paths

## Best Practices

1. **Always use relative paths** in configuration files
2. **Organize files logically** under the repository root
3. **Use consistent naming** for directories
4. **Test configurations** from different directories
5. **Document path conventions** for your project
6. **Use version control** to track the `.reporoot` file

This system provides a robust, predictable, and portable way to handle file paths across the MCP CLI application. 