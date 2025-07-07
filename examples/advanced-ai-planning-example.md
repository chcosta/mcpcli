# Advanced AI Planning Example

This example demonstrates how the new advanced AI planning approach handles complex scenarios without requiring custom server-specific code.

## Scenario: Analyzing Multiple Repositories

**User Request:** "Get pull request descriptions for all recent changes across all repositories in the dnceng/internal project"

## Traditional Approach (Old)

Previously, this would require:
1. Creating a custom strategy class for Azure DevOps
2. Hardcoding the logic for multiple repositories
3. Writing server-specific code for batch processing

## New AI Planning Approach

The AI now generates a sophisticated plan that handles this complexity:

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
   - Parameters: organizationName=dnceng, projectName=internal, repositoryName={REPO_FROM_LIST}, status=completed, maxCount=5, _LIST_REPO=ALL_REPOS_FROM_STEP_2
   - Purpose: Get recent changes across all repositories

4. Get descriptions for all pull requests found
   - Tool name: get_pull_request_description
   - Parameters: organizationName=dnceng, projectName=internal, _MULTIPLE_PR_IDS=ALL_PR_IDS_FROM_STEP_3
   - Purpose: Retrieve detailed descriptions for batch processing
```

## How the System Executes This Plan

### Step 1: Normal Execution
- Calls `InitializeAzureDevOpsClient` with the provided parameters
- Establishes connection to Azure DevOps

### Step 2: Normal Execution
- Calls `get_repositories` to get list of repositories
- Result: `["repo1", "repo2", "repo3", "repo4"]`

### Step 3: List Iteration Pattern
- Detects `{REPO_FROM_LIST}` pattern and `_LIST_REPO` parameter
- Extracts repository list from Step 2
- Executes `get_pull_requests` 4 times:
  1. `repositoryName=repo1`
  2. `repositoryName=repo2`
  3. `repositoryName=repo3`
  4. `repositoryName=repo4`
- Combines results: `["PR123", "PR124", "PR125", "PR126", "PR127"]`

### Step 4: Batch Processing Pattern
- Detects `_MULTIPLE_PR_IDS` parameter
- Extracts PR IDs from Step 3
- Executes `get_pull_request_description` 5 times:
  1. `pullRequestId=123`
  2. `pullRequestId=124`
  3. `pullRequestId=125`
  4. `pullRequestId=126`
  5. `pullRequestId=127`
- Combines all descriptions into final result

## Benefits Demonstrated

1. **No Custom Code**: No need to write Azure DevOps-specific strategy classes
2. **AI Intelligence**: The AI figured out the complex multi-step process
3. **Pattern Recognition**: System automatically handles list iteration and batch processing
4. **Scalability**: Works with any number of repositories and pull requests
5. **Flexibility**: Can easily adapt to different scenarios

## Console Output Example

```
Executing get_pull_requests for 4 items
  Processing item: repo1
  Successfully processed item: repo1
  Processing item: repo2
  Successfully processed item: repo2
  Processing item: repo3
  Successfully processed item: repo3
  Processing item: repo4
  Successfully processed item: repo4

Executing get_pull_request_description for 5 items
  Processing item: 123
  Successfully processed item: 123
  Processing item: 124
  Successfully processed item: 124
  Processing item: 125
  Successfully processed item: 125
  Processing item: 126
  Successfully processed item: 126
  Processing item: 127
  Successfully processed item: 127
```

## Adding Conditional Logic

The AI can even add conditional logic to handle edge cases:

```
3. Check if any repositories were found
   - Tool name: validate_repositories
   - Parameters: repositoryList=ALL_REPOS_FROM_STEP_2, _IF_NOT_EMPTY=ALL_REPOS_FROM_STEP_2
   - Purpose: Only proceed if repositories exist

4. For each repository, get recent pull requests (only if repositories exist)
   - Tool name: get_pull_requests
   - Parameters: organizationName=dnceng, projectName=internal, repositoryName={REPO_FROM_LIST}, status=completed, maxCount=5, _LIST_REPO=ALL_REPOS_FROM_STEP_2, _IF_NOT_EMPTY=ALL_REPOS_FROM_STEP_2
   - Purpose: Get recent changes across all repositories if any exist
```

## Conclusion

This approach demonstrates how advanced AI planning can handle complex scenarios that previously required custom server-specific code. The system is now more flexible, maintainable, and can adapt to new requirements without code changes. 