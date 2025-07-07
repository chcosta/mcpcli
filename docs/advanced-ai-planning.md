# Advanced AI Planning for MCP CLI

## Overview

The MCP CLI now uses an advanced AI planning approach that enables sophisticated execution patterns without requiring custom server-specific code. Instead of creating strategy classes for each MCP server, the AI generates detailed execution plans that handle complex scenarios through special parameter patterns.

## Key Benefits

1. **No Custom Code Required**: Handle complex scenarios without writing server-specific strategy classes
2. **AI-Driven Intelligence**: The AI planning system is sophisticated enough to handle batch processing, iterations, and conditional execution
3. **Extensible Patterns**: New patterns can be added to support additional complexity
4. **Backward Compatible**: Existing simple tool calls continue to work as before

## Advanced Patterns

### 1. Batch Processing (Multiple IDs)

When you need to process multiple items in a single operation:

```
- Tool name: get_pull_request_description
- Parameters: organizationName=dnceng, projectName=internal, _MULTIPLE_PR_IDS=ALL_IDS_FROM_STEP_2
- Purpose: Get descriptions for all pull requests found in step 2
```

**Special Parameters:**
- `_MULTIPLE_PR_IDS`: Batch process multiple pull request IDs
- `_MULTIPLE_IDS`: Batch process multiple generic IDs

**How it works:**
- The system automatically detects the batch parameter
- Extracts the list of IDs from the referenced step
- Executes the tool once for each ID
- Combines all results into a single response

### 2. List Iteration

When you need to iterate over a list of items:

```
- Tool name: get_pull_requests
- Parameters: organizationName=dnceng, projectName=internal, repositoryName={REPO_FROM_LIST}, _LIST_REPO=ALL_REPOS_FROM_STEP_1
- Purpose: Get pull requests for each repository found in step 1
```

**Special Parameters:**
- `{FIELD_FROM_LIST}`: Placeholder for iteration value
- `_LIST_FIELD`: The actual list to iterate over

**How it works:**
- The system detects the iteration pattern `{FIELD_FROM_LIST}`
- Finds the corresponding list in `_LIST_FIELD`
- Executes the tool once for each item in the list
- Replaces the placeholder with the actual value for each iteration

### 3. Conditional Execution

When execution depends on conditions:

```
- Tool name: get_work_items
- Parameters: organizationName=dnceng, projectName=internal, _IF_NOT_EMPTY=RESULT_FROM_STEP_1
- Purpose: Get work items only if previous step returned results
```

**Special Parameters:**
- `_IF_NOT_EMPTY`: Execute only if the referenced value is not empty
- `_IF_EXISTS`: Execute only if the referenced value exists and is not null

**How it works:**
- The system checks the condition before executing
- If the condition fails, returns a "skipped" message
- If the condition passes, executes normally with the special parameter removed

### 4. Sub-Plan Generation

When you need more information to complete a task:

```
EXECUTION PLAN:
1. Investigate available repositories
   - Tool name: get_repositories
   - Parameters: organizationName=dnceng, projectName=internal
   - Purpose: Determine which repositories exist before proceeding

2. FOR EACH repository found in step 1, get pull requests
   - Tool name: get_pull_requests
   - Parameters: organizationName=dnceng, projectName=internal, repositoryName={REPO_FROM_LIST}, _LIST_REPO=ALL_REPOS_FROM_STEP_1
   - Purpose: Get pull requests for each repository
```

**Benefits:**
- AI can explore the environment before making assumptions
- Dynamic planning based on discovered information
- No need to hardcode server-specific logic

### 5. Iterative Refinement

When the initial plan might not be complete:

```
5. Analyze results from previous steps and determine if more data is needed
   - Tool name: analyze_completeness
   - Parameters: currentResults=COMBINED_RESULTS_FROM_STEPS_1_TO_4
   - Purpose: Check if we have sufficient information or need additional queries

6. IF additional data needed, execute follow-up queries
   - Tool name: [determined dynamically based on step 5]
   - Parameters: [determined dynamically based on step 5]
   - Purpose: Fill any gaps identified in step 5
```

**Benefits:**
- Self-correcting execution plans
- Can adapt to incomplete or unexpected results
- Ensures comprehensive coverage

## Example: Complex Azure DevOps Analysis

Here's how the AI would plan a complex Azure DevOps analysis:

```
EXECUTION PLAN:
1. Initialize Azure DevOps connection
   - Tool name: InitializeAzureDevOpsClient
   - Parameters: organizationUrl=https://dev.azure.com/dnceng
   - Purpose: Enable access to Azure DevOps APIs

2. Get all repositories in the project
   - Tool name: get_repositories
   - Parameters: organizationName=dnceng, projectName=internal
   - Purpose: Identify all repositories to analyze

3. For each repository, get recent pull requests
   - Tool name: get_pull_requests
   - Parameters: organizationName=dnceng, projectName=internal, repositoryName={REPO_FROM_LIST}, status=completed, maxCount=10, _LIST_REPO=ALL_REPOS_FROM_STEP_2
   - Purpose: Get recent changes across all repositories

4. Get descriptions for all pull requests found
   - Tool name: get_pull_request_description
   - Parameters: organizationName=dnceng, projectName=internal, _MULTIPLE_PR_IDS=ALL_PR_IDS_FROM_STEP_3
   - Purpose: Retrieve detailed descriptions for batch processing

5. Analyze if any repositories were missed or need deeper investigation
   - Tool name: validate_completeness
   - Parameters: repositoryCount=COUNT_FROM_STEP_2, pullRequestCount=COUNT_FROM_STEP_3
   - Purpose: Ensure comprehensive coverage
```

## Implementation Details

### Pattern Recognition

The system uses pattern recognition to detect special parameters:

```csharp
// Pattern 1: Multiple IDs for batch processing
if (parameters.ContainsKey("_MULTIPLE_IDS"))
{
    return await HandleBatchExecution(serverInfo, toolName, parameters, "_MULTIPLE_IDS", "id");
}

// Pattern 2: List iteration
if (parameters.Values.Any(v => v.ToString()?.Contains("{") == true && v.ToString()?.Contains("_FROM_LIST}") == true))
{
    return await HandleListIteration(serverInfo, toolName, parameters);
}

// Pattern 3: Conditional execution
if (parameters.ContainsKey("_IF_NOT_EMPTY") || parameters.ContainsKey("_IF_EXISTS"))
{
    return await HandleConditionalExecution(serverInfo, toolName, parameters);
}
```

### Adding New Patterns

To add a new pattern:

1. Add detection logic to `ExecuteToolWithPatternRecognition`
2. Implement the handler method
3. Update the AI planning prompt with examples
4. Document the pattern in this file

### Example: Adding a retry pattern

```csharp
// Pattern 4: Retry on failure
if (parameters.ContainsKey("_RETRY_COUNT"))
{
    return await HandleRetryExecution(serverInfo, toolName, parameters);
}
```

## Best Practices

1. **Start Simple**: Begin with basic patterns and add complexity as needed
2. **Use Descriptive Names**: Make special parameters self-documenting
3. **Test Thoroughly**: Verify patterns work with different data types
4. **Document Examples**: Provide clear examples in the AI planning prompt
5. **Maintain Backward Compatibility**: Ensure existing functionality continues to work

## Migration from Strategy Pattern

If you previously used the strategy pattern:

1. Remove custom strategy classes
2. Update AI planning prompts to use new patterns
3. Test existing workflows to ensure they still work
4. Gradually adopt new patterns for enhanced functionality

## Conclusion

This advanced AI planning approach provides a flexible, scalable way to handle complex MCP server interactions without requiring custom code for each server. The AI is intelligent enough to generate sophisticated execution plans that can handle batch processing, iterations, conditional logic, and adaptive planning. 