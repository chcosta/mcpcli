# Generic Context Management System

The MCP CLI features a powerful generic context management system that automatically extracts and stores data from step results, making it easy to pass information between sequential tool executions regardless of the MCP server type.

## Overview

The new context management system replaces the previous hardcoded Azure DevOps-specific approach with a flexible, extensible framework that:

- **Works with any MCP server**: Not limited to Azure DevOps
- **Automatically extracts common data types**: IDs, dates, numbers, URLs, emails, JSON
- **Provides intelligent field matching**: Handles variations in field names
- **Maintains backward compatibility**: Legacy formats still work
- **Supports custom extractors**: Extensible for new data types

## How It Works

### 1. Step Execution and Data Storage

When each step executes:
1. The tool result is stored in a `StepContext` object
2. Multiple extractors analyze the result text
3. Common data patterns are automatically identified and extracted
4. Structured data (JSON) is parsed and flattened
5. All extracted data is indexed for easy retrieval

### 2. Variable Resolution

When the next step references previous data:
1. The system parses the variable name (e.g., `ID_FROM_STEP_2`)
2. It looks up the specified step in the context library
3. Multiple resolution strategies are tried in order of preference
4. The best match is returned for use in the current step

## Variable Formats

### Generic Format (Recommended)

Use descriptive field names that work across different MCP servers:

```
FIELD_NAME_FROM_STEP_N
```

**Examples:**
- `ID_FROM_STEP_2` - Gets any ID from step 2
- `DATE_FROM_STEP_1` - Gets any date from step 1
- `TITLE_FROM_STEP_3` - Gets title/name from step 3
- `STATUS_FROM_STEP_2` - Gets status/state from step 2
- `AUTHOR_FROM_STEP_1` - Gets author/creator from step 1
- `BRANCH_FROM_STEP_4` - Gets branch name from step 4

### Typed Format

Specify the exact data type to extract:

```
FIELD_NAME_FROM_STEP_N_TYPE
```

**Available Types:**
- `id` - Numeric IDs, UUIDs
- `date` - ISO dates, timestamps
- `number` - Numeric values
- `json` - JSON objects/arrays
- `url` - HTTP/HTTPS URLs
- `email` - Email addresses

**Examples:**
- `ID_FROM_STEP_2_ID` - Specifically gets ID-type data
- `DATE_FROM_STEP_1_DATE` - Specifically gets date-type data
- `URL_FROM_STEP_3_URL` - Specifically gets URL-type data

### Legacy Format (Backward Compatibility)

The old Azure DevOps-specific formats are still supported:

```
RESULT_FROM_STEP_N_FIELD_NAME
PULL_REQUEST_ID_FROM_STEP_N_RESULT
```

## Data Extraction

### Automatic Extractors

The system includes built-in extractors for common data types:

#### ID Extractor
- **Patterns**: 4+ digit numbers, UUIDs, JSON ID fields
- **Examples**: `12345`, `550e8400-e29b-41d4-a716-446655440000`
- **JSON Fields**: `id`, `pullRequestId`, `requestId`

#### Date Extractor
- **Patterns**: ISO dates, timestamps, JSON date fields
- **Examples**: `2025-01-15`, `2025-01-15T10:30:00Z`
- **JSON Fields**: `date`, `closedDate`, `createdDate`, `completedDate`

#### Number Extractor
- **Patterns**: Integer and decimal numbers
- **Examples**: `42`, `3.14`, `1000`

#### JSON Extractor
- **Patterns**: Valid JSON objects and arrays
- **Examples**: `{"id": 123}`, `[1, 2, 3]`

#### URL Extractor
- **Patterns**: HTTP and HTTPS URLs
- **Examples**: `https://example.com`, `http://api.example.com/data`

#### Email Extractor
- **Patterns**: Valid email addresses
- **Examples**: `user@example.com`, `admin@company.org`

### Custom Extractors

You can register custom extractors for specialized data types:

```csharp
contextLibrary.RegisterExtractor("custom", new MyCustomExtractor());
```

## Resolution Strategies

The system tries multiple strategies to resolve variables, in order of preference:

### 1. Direct Field Lookup
Exact match in parsed structured data:
```
step.ParsedData["fieldname"] → value
```

### 2. Case-Insensitive Field Lookup
Case-insensitive match in parsed data:
```
step.ParsedData["FieldName"] → value (matches "fieldname")
```

### 3. Typed Extractor Lookup
Using the specified extractor type:
```
ID_FROM_STEP_2_ID → step.ExtractedValues["id"][0]
```

### 4. Smart Field Matching
Intelligent mapping using common field name variations:

```csharp
// Field mappings
"id" → ["id", "pullrequestid", "requestid", "number"]
"date" → ["date", "closeddate", "createddate", "completedate"]
"title" → ["title", "name", "subject"]
"description" → ["description", "desc", "body"]
"status" → ["status", "state"]
"author" → ["author", "creator", "createdby"]
"branch" → ["branch", "sourcebranch", "targetbranch"]
```

## Practical Examples

### Example 1: Azure DevOps Workflow

```yaml
# Step 1: Get latest deployment
- Tool name: get_pull_requests_by_closed_date
- Parameters: projectName=internal, targetBranch=production, maxCount=1
- Purpose: Get the latest production deployment

# Step 2: Get changes after deployment
- Tool name: get_pull_requests_by_closed_date  
- Parameters: projectName=internal, targetBranch=main, afterClosedDate=DATE_FROM_STEP_1
- Purpose: Get changes merged after the deployment date

# Step 3: Get detailed descriptions
- Tool name: get_pull_request_description
- Parameters: pullRequestId=ID_FROM_STEP_2
- Purpose: Get detailed description of the changes
```

### Example 2: Generic API Workflow

```yaml
# Step 1: Get user data
- Tool name: get_user_info
- Parameters: userId=12345
- Purpose: Retrieve user information

# Step 2: Get user's projects
- Tool name: get_user_projects
- Parameters: authorEmail=EMAIL_FROM_STEP_1
- Purpose: Get projects created by this user

# Step 3: Get project details
- Tool name: get_project_details
- Parameters: projectId=ID_FROM_STEP_2, projectUrl=URL_FROM_STEP_2
- Purpose: Get detailed information about the projects
```

### Example 3: Multi-Source Data

```yaml
# Step 1: Get database records
- Tool name: query_database
- Parameters: table=users, limit=10
- Purpose: Get user records from database

# Step 2: Enrich with API data
- Tool name: get_api_data
- Parameters: userIds=ID_FROM_STEP_1_ID, lastUpdate=DATE_FROM_STEP_1_DATE
- Purpose: Enrich database data with API information

# Step 3: Generate report
- Tool name: create_report
- Parameters: dataSource=JSON_FROM_STEP_2, reportTitle=TITLE_FROM_STEP_1
- Purpose: Create a comprehensive report
```

## Error Handling

The context management system provides robust error handling:

### Missing Steps
If a referenced step doesn't exist:
```
ID_FROM_STEP_99 → null (step 99 not found)
```

### Missing Fields
If a field isn't found in the step result:
```
NONEXISTENT_FROM_STEP_2 → null (field not found)
```

### Type Mismatches
If the requested type isn't available:
```
ID_FROM_STEP_2_URL → null (no URLs found in step 2)
```

### Fallback Behavior
- Unresolved variables remain as-is in parameters
- Warning messages are logged for debugging
- Execution continues with available data

## Debugging

### Logging
The system provides detailed logging for troubleshooting:

```
Processing dynamic value: ID_FROM_STEP_2
Resolved 'ID_FROM_STEP_2' to: 12345
Stored result for step 2: {"id": 12345, "title": "Fix bug"}...
```

### Context Inspection
You can inspect the context library state:

```csharp
var allSteps = contextLibrary.GetAllSteps();
var specificStep = contextLibrary.GetStep(2);
```

## Migration Guide

### From Hardcoded Azure DevOps

**Old:**
```
RESULT_FROM_STEP_2_COMPLETION_DATE
PULL_REQUEST_ID_FROM_STEP_3_RESULT
```

**New:**
```
DATE_FROM_STEP_2
ID_FROM_STEP_3
```

### Benefits of Migration

1. **Simpler syntax**: More intuitive variable names
2. **Better compatibility**: Works with any MCP server
3. **Automatic extraction**: No need to specify exact field names
4. **Error resilience**: Multiple fallback strategies

## Best Practices

### Variable Naming
- Use descriptive field names: `ID_FROM_STEP_2` not `VAL_FROM_STEP_2`
- Be specific when needed: `AUTHOR_EMAIL_FROM_STEP_1` vs `EMAIL_FROM_STEP_1`
- Use typed format for disambiguation: `ID_FROM_STEP_2_ID` vs `ID_FROM_STEP_2_NUMBER`

### Step Organization
- Keep related operations in sequential steps
- Use meaningful step purposes for debugging
- Minimize dependencies between distant steps

### Error Handling
- Test variable resolution with sample data
- Provide fallback values when possible
- Use logging to debug resolution issues

## Advanced Features

### Custom Field Mappings
Extend the smart field matching with custom mappings:

```csharp
// In a custom extractor
var customMappings = new Dictionary<string, string[]>
{
    ["ticket"] = ["ticket", "ticketid", "issue", "issueid"],
    ["priority"] = ["priority", "pri", "importance", "urgency"]
};
```

### Multi-Value Handling
When multiple values are found:
- First value is used by default
- All values stored for advanced processing
- Special handling for multiple IDs (e.g., `_MULTIPLE_PR_IDS`)

### Performance Optimization
- Results are cached within the context library
- Extractors run only once per step
- Lazy evaluation for expensive operations

This generic context management system provides a powerful foundation for building complex, multi-step workflows that can adapt to any MCP server while maintaining simplicity and reliability. 