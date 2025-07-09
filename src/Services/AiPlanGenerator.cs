using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class AiPlanGenerator : IPlanGenerator
{
    private readonly ILogger<AiPlanGenerator> _logger;
    private readonly IAzureAiService _azureAiService;
    private readonly PlanValidator _planValidator;
    private readonly ISystemPromptService _systemPromptService;
    private readonly IRepositoryRootService _repositoryRootService;
    private readonly IMultiMcpServerService _multiMcpServerService;

    public AiPlanGenerator(
        ILogger<AiPlanGenerator> logger,
        IAzureAiService azureAiService,
        PlanValidator planValidator,
        ISystemPromptService systemPromptService,
        IRepositoryRootService repositoryRootService,
        IMultiMcpServerService multiMcpServerService)
    {
        _logger = logger;
        _azureAiService = azureAiService;
        _planValidator = planValidator;
        _systemPromptService = systemPromptService;
        _repositoryRootService = repositoryRootService;
        _multiMcpServerService = multiMcpServerService;
    }

    public async Task<Plan> GeneratePlanAsync(string prompt, List<RunningServerInfo> servers, ServerToolMapping toolMapping, Models.ExecutionSummary? executionSummary = null)
    {
        try
        {
            _logger.LogInformation("Generating AI-powered plan for prompt: {Prompt}", prompt);

            // Step 1: Analyze the prompt and available tools
            var analysisPrompt = await BuildAnalysisPrompt(prompt, servers, toolMapping, executionSummary);
            var analysisResponse = await _azureAiService.SendPromptAsync(analysisPrompt);

            // Step 2: Parse the AI response to extract plan structure
            var planStructure = ParsePlanStructure(analysisResponse, prompt);

            // Step 3: Generate detailed steps with tool mappings
            var steps = GenerateDetailedStepsAsync(planStructure, servers, toolMapping);

            // After parsing steps, auto-populate missing Id and Name for prompt-based steps
            if (steps != null && steps.Count > 0)
            {
                // Auto-populate plan name if missing
                if (string.IsNullOrWhiteSpace(planStructure.Name))
                {
                    planStructure.Name = $"Plan for: {prompt.Substring(0, Math.Min(50, prompt.Length))}...";
                }
                
                for (int i = 0; i < steps.Count; i++)
                {
                    var step = steps[i];
                    // Auto-populate Id
                    if (string.IsNullOrWhiteSpace(step.Id))
                    {
                        step.Id = (i + 1).ToString();
                    }
                    // Auto-populate Name
                    if (string.IsNullOrWhiteSpace(step.Name))
                    {
                        if (!string.IsNullOrWhiteSpace(step.Prompt))
                        {
                            var words = step.Prompt.Split(' ');
                            step.Name = string.Join(" ", words.Take(6)) + (words.Length > 6 ? "..." : "");
                        }
                        else
                        {
                            step.Name = $"Step {step.Id}";
                        }
                    }
                }
            }

            // Step 4: Create the plan
            var plan = new Plan
            {
                Id = GeneratePlanId(),
                Name = planStructure.Name,
                Goal = prompt,
                Steps = steps ?? new List<PlanStep>(),
                CreatedAt = DateTime.UtcNow,
                Status = PlanStatus.Created
            };

            // Step 5: Validate the generated plan
            var validationResult = _planValidator.ValidatePlan(plan, servers, toolMapping);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Generated plan has validation issues: {Errors}", string.Join(", ", validationResult.Errors));
                
                // Try to fix common issues
                plan = FixPlanIssuesAsync(plan, validationResult, servers, toolMapping);
            }

            _logger.LogInformation("Generated plan {PlanId} with {StepCount} steps", plan.Id, plan.Steps.Count);
            return plan;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating AI-powered plan");
            
            // Fallback to basic plan generation
            return GenerateFallbackPlanAsync(prompt, servers, toolMapping);
        }
    }

    private async Task<string> BuildAnalysisPrompt(string prompt, List<RunningServerInfo> servers, ServerToolMapping toolMapping, Models.ExecutionSummary? executionSummary = null)
    {
        var toolsInfo = await BuildToolsInfoAsync(servers, toolMapping);
        
        _logger.LogInformation("AI Planning Prompt - Available Tools Info:");
        _logger.LogInformation(toolsInfo);
        
        try
        {
            // Try to load the external AI planning prompt file
            var promptFilePath = _repositoryRootService.ResolvePath("system-prompts/ai-planning-prompt.md");
            if (await _systemPromptService.ValidatePromptFileAsync(promptFilePath, executionSummary))
            {
                _logger.LogInformation("Using external AI planning prompt file: {PromptFilePath}", promptFilePath);
                var variables = new Dictionary<string, string>
                {
                    ["USER_PROMPT"] = prompt,
                    ["AVAILABLE_TOOLS"] = toolsInfo
                };
                return await _systemPromptService.ProcessPromptAsync(promptFilePath, variables, executionSummary);
            }
            else
            {
                _logger.LogWarning("External AI planning prompt file not found or invalid, using fallback prompt");
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error loading external AI planning prompt file, using fallback prompt");
        }
        
        // Fallback to hardcoded prompt
        return $@"
You are an AI planning expert. Analyze the user's request and create a structured execution plan using natural language prompts.

**User Request**: {prompt}

**Available Tools by Server** (for reference only - you will create prompts, not direct tool calls):
{toolsInfo}

**CRITICAL RULES**:
1. **DO NOT specify explicit tools or servers** - create natural language prompts instead
2. **Focus on the logical flow and goals** - let the execution system determine which tools to use
3. **Create clear, actionable prompts** that describe what needs to be accomplished
4. **Consider dependencies and sequencing** between steps
5. **Make prompts specific enough to be actionable** but general enough to be flexible

**Your Task**:
1. Analyze the user's request to understand what they want to accomplish
2. Break down the request into logical, sequential steps
3. Create natural language prompts for each step that describe the goal
4. Identify any dependencies between steps
5. Consider conditional logic if needed

**Prompt Creation Guidelines**:
- **For initialization tasks**: Create prompts like ""Initialize the Azure DevOps client for the dnceng organization""
- **For data retrieval**: Create prompts like ""Get all projects in the dnceng organization"" or ""Retrieve recent pull requests""
- **For analysis tasks**: Create prompts like ""Analyze the pull request data and identify trends""
- **For reporting**: Create prompts like ""Generate a summary report of the findings""
- **Make prompts specific and actionable** - they should clearly describe what needs to be done
- **Consider context flow** - later steps can reference results from earlier steps

**Response Format**:
Respond with a JSON structure like this:
{{
  ""name"": ""Plan Name"",
  ""description"": ""Brief description of what this plan accomplishes"",
  ""steps"": [
    {{
      ""id"": ""1"",
      ""name"": ""Step Name"",
      ""description"": ""What this step does"",
      ""prompt"": ""Natural language prompt describing what needs to be accomplished"",
      ""expectedOutputs"": {{}},
      ""dependencies"": [],
      ""condition"": null,
      ""justification"": ""Why this step is needed and what it accomplishes.""
    }}
  ]
}}

**Important Rules**:
1. For each step, provide a clear justification for why this step is needed
2. **DO NOT specify server names or tool names** - create natural language prompts instead
3. **Focus on the goal and outcome** of each step
4. **Make steps logical and sequential**
5. **Include meaningful descriptions for each step**
6. **If a step depends on previous steps, list them in dependencies**
7. **Create prompts that are specific enough to be actionable**

**Example**:
If the user wants to analyze pull requests, you might create steps like:
1. ""Initialize the Azure DevOps client and authenticate""
2. ""Get all repositories in the dnceng organization""
3. ""Retrieve recent pull requests from all repositories""
4. ""Analyze pull request data and identify patterns""
5. ""Generate a comprehensive report of the findings""

**REMEMBER**: Create natural language prompts that describe goals, not explicit tool calls.

Provide your response as valid JSON only.
";
    }

    private async Task<string> BuildToolsInfoAsync(List<RunningServerInfo> servers, ServerToolMapping toolMapping)
    {
        var toolsInfo = new List<string>();
        
        _logger.LogInformation("Building tools info for {ServerCount} enabled and running servers", servers.Count);
        
        // Add a comprehensive overview
        toolsInfo.Add("# Available MCP Tools Analysis");
        toolsInfo.Add("");
        toolsInfo.Add($"Total tools available: {toolMapping.AllTools.Count}");
        toolsInfo.Add($"Servers with tools: {servers.Count}");
        toolsInfo.Add("");
        
        // Categorize tools by capability
        var toolCategories = CategorizeTools(toolMapping);
        
        // Add category overview
        toolsInfo.Add("## Tool Categories");
        foreach (var category in toolCategories)
        {
            toolsInfo.Add($"- **{category.Key}**: {category.Value.Count} tools");
        }
        toolsInfo.Add("");
        
        // Add detailed server information with parameter schemas
        toolsInfo.Add("## Detailed Tool Information by Server");
        toolsInfo.Add("");
        
        foreach (var server in servers)
        {
            if (toolMapping.ServerToTools.ContainsKey(server.Name))
            {
                var tools = toolMapping.ServerToTools[server.Name];
                toolsInfo.Add($"### {server.Name} ({server.Type} server)");
                _logger.LogInformation("Server {ServerName} ({ServerType}) has {ToolCount} tools", 
                    server.Name, server.Type, tools.Count);
                
                // Get tool schemas for this server
                Dictionary<string, object> toolSchemas = new();
                try
                {
                    toolSchemas = await _multiMcpServerService.GetToolSchemasAsync(server);
                    _logger.LogInformation("Retrieved {SchemaCount} tool schemas for server {ServerName}", toolSchemas.Count, server.Name);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Error getting tool schemas for server {ServerName}", server.Name);
                }
                
                // Group tools by category for this server
                var serverToolCategories = GroupToolsByCategory(tools, toolMapping);
                
                foreach (var category in serverToolCategories)
                {
                    toolsInfo.Add($"#### {category.Key}");
                    foreach (var tool in category.Value)
                    {
                        var description = toolMapping.ToolDescriptions.GetValueOrDefault(tool, "No description available");
                        var parameterInfo = "";
                        
                        // Get parameter information from schema
                        if (toolSchemas.TryGetValue(tool, out var schema) && schema is Dictionary<string, object> schemaDict)
                        {
                            _logger.LogInformation("Found schema for tool {ToolName} in AiPlanGenerator: {Schema}", tool, System.Text.Json.JsonSerializer.Serialize(schemaDict));
                            
                            if (schemaDict.TryGetValue("description", out var schemaDescription))
                            {
                                description = schemaDescription.ToString() ?? description;
                            }
                            
                            // Extract parameter information from input schema
                            if (schemaDict.TryGetValue("inputSchema", out var inputSchemaObj) && inputSchemaObj is Dictionary<string, object> inputSchema)
                            {
                                _logger.LogInformation("Found input schema for tool {ToolName} in AiPlanGenerator: {InputSchema}", tool, System.Text.Json.JsonSerializer.Serialize(inputSchema));
                                
                                if (inputSchema.TryGetValue("properties", out var propertiesObj) && propertiesObj is Dictionary<string, object> properties)
                                {
                                    _logger.LogInformation("Found properties for tool {ToolName} in AiPlanGenerator: {Properties}", tool, System.Text.Json.JsonSerializer.Serialize(properties));
                                    
                                    var paramDetails = new List<string>();
                                    foreach (var paramName in properties.Keys)
                                    {
                                        if (properties.TryGetValue(paramName, out var paramSchemaObj) && paramSchemaObj is Dictionary<string, object> paramSchema)
                                        {
                                            var paramType = paramSchema.GetValueOrDefault("type", "string").ToString();
                                            var isRequired = inputSchema.TryGetValue("required", out var requiredObj) && 
                                                           requiredObj is System.Text.Json.JsonElement requiredElement && 
                                                           requiredElement.ValueKind == System.Text.Json.JsonValueKind.Array &&
                                                           requiredElement.EnumerateArray().Any(e => e.GetString() == paramName);
                                            
                                            paramDetails.Add($"{paramName}({paramType}){(isRequired ? " [REQUIRED]" : "")}");
                                        }
                                        else
                                        {
                                            paramDetails.Add($"{paramName}(string)");
                                        }
                                    }
                                    
                                    if (paramDetails.Any())
                                    {
                                        parameterInfo = $"\n    Parameters: {string.Join(", ", paramDetails)}";
                                        _logger.LogInformation("Generated parameter info for tool {ToolName} in AiPlanGenerator: {ParameterInfo}", tool, parameterInfo);
                                    }
                                }
                                else
                                {
                                    _logger.LogInformation("No properties found for tool {ToolName} in AiPlanGenerator", tool);
                                }
                            }
                            else
                            {
                                _logger.LogInformation("No input schema found for tool {ToolName} in AiPlanGenerator", tool);
                            }
                        }
                        else
                        {
                            _logger.LogInformation("No schema found for tool {ToolName} in AiPlanGenerator", tool);
                        }
                        
                        toolsInfo.Add($"- **{tool}**: {description}{parameterInfo}");
                        _logger.LogInformation("Tool: {ToolName} -> Description: {Description}", tool, description);
                    }
                    toolsInfo.Add("");
                }
            }
            else
            {
                _logger.LogWarning("Server {ServerName} is enabled and running but has no tools available", server.Name);
            }
        }
        
        // Add tool conflict information
        if (toolMapping.ConflictingTools.Count > 0)
        {
            toolsInfo.Add("## Tool Conflicts (Available on Multiple Servers)");
            foreach (var conflict in toolMapping.ConflictingTools)
            {
                var serverNames = string.Join(", ", conflict.Value);
                toolsInfo.Add($"- **{conflict.Key}**: Available on {serverNames}");
            }
            toolsInfo.Add("");
        }
        
        // Add planning guidance
        toolsInfo.Add("## Planning Guidance");
        toolsInfo.Add("");
        toolsInfo.Add("When creating execution plans, consider:");
        toolsInfo.Add("1. **Initialization**: Start with setup/authentication tools if available");
        toolsInfo.Add("2. **Data Retrieval**: Use tools that fetch projects, repositories, pull requests, etc.");
        toolsInfo.Add("3. **Data Processing**: Leverage tools that analyze, filter, or transform data");
        toolsInfo.Add("4. **Reporting**: Use tools that generate summaries or formatted output");
        toolsInfo.Add("");
        toolsInfo.Add("Create specific, actionable prompts that reference the capabilities shown above.");
        
        var result = string.Join("\n", toolsInfo);
        _logger.LogInformation("Built comprehensive tools info with {ToolCount} total tools across {ServerCount} servers", 
            toolMapping.AllTools.Count, servers.Count);
        
        return result;
    }
    
    private Dictionary<string, List<string>> CategorizeTools(ServerToolMapping toolMapping)
    {
        var categories = new Dictionary<string, List<string>>
        {
            ["Initialization"] = new List<string>(),
            ["Data Retrieval"] = new List<string>(),
            ["Data Analysis"] = new List<string>(),
            ["Data Processing"] = new List<string>(),
            ["Reporting"] = new List<string>(),
            ["Management"] = new List<string>(),
            ["Other"] = new List<string>()
        };
        
        foreach (var tool in toolMapping.AllTools)
        {
            var lowerName = tool.ToLower();
            
            if (lowerName.Contains("initialize") || lowerName.Contains("setup") || lowerName.Contains("auth"))
            {
                categories["Initialization"].Add(tool);
            }
            else if (lowerName.Contains("get_") || lowerName.Contains("retrieve") || lowerName.Contains("fetch"))
            {
                categories["Data Retrieval"].Add(tool);
            }
            else if (lowerName.Contains("analyze") || lowerName.Contains("search") || lowerName.Contains("query"))
            {
                categories["Data Analysis"].Add(tool);
            }
            else if (lowerName.Contains("filter") || lowerName.Contains("sort") || lowerName.Contains("process"))
            {
                categories["Data Processing"].Add(tool);
            }
            else if (lowerName.Contains("report") || lowerName.Contains("format") || lowerName.Contains("summarize"))
            {
                categories["Reporting"].Add(tool);
            }
            else if (lowerName.Contains("create") || lowerName.Contains("update") || lowerName.Contains("delete"))
            {
                categories["Management"].Add(tool);
            }
            else
            {
                categories["Other"].Add(tool);
            }
        }
        
        // Remove empty categories
        return categories.Where(kvp => kvp.Value.Count > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
    
    private Dictionary<string, List<string>> GroupToolsByCategory(List<string> tools, ServerToolMapping toolMapping)
    {
        var categories = new Dictionary<string, List<string>>
        {
            ["Initialization"] = new List<string>(),
            ["Data Retrieval"] = new List<string>(),
            ["Data Analysis"] = new List<string>(),
            ["Data Processing"] = new List<string>(),
            ["Reporting"] = new List<string>(),
            ["Management"] = new List<string>(),
            ["Other"] = new List<string>()
        };
        
        foreach (var tool in tools)
        {
            var lowerName = tool.ToLower();
            
            if (lowerName.Contains("initialize") || lowerName.Contains("setup") || lowerName.Contains("auth"))
            {
                categories["Initialization"].Add(tool);
            }
            else if (lowerName.Contains("get_") || lowerName.Contains("retrieve") || lowerName.Contains("fetch"))
            {
                categories["Data Retrieval"].Add(tool);
            }
            else if (lowerName.Contains("analyze") || lowerName.Contains("search") || lowerName.Contains("query"))
            {
                categories["Data Analysis"].Add(tool);
            }
            else if (lowerName.Contains("filter") || lowerName.Contains("sort") || lowerName.Contains("process"))
            {
                categories["Data Processing"].Add(tool);
            }
            else if (lowerName.Contains("report") || lowerName.Contains("format") || lowerName.Contains("summarize"))
            {
                categories["Reporting"].Add(tool);
            }
            else if (lowerName.Contains("create") || lowerName.Contains("update") || lowerName.Contains("delete"))
            {
                categories["Management"].Add(tool);
            }
            else
            {
                categories["Other"].Add(tool);
            }
        }
        
        // Remove empty categories and sort tools within each category
        return categories
            .Where(kvp => kvp.Value.Count > 0)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.OrderBy(t => t).ToList());
    }

    private PlanStructure ParsePlanStructure(string aiResponse, string originalPrompt)
    {
        try
        {
            _logger.LogInformation("Parsing AI response: {ResponseLength} characters", aiResponse.Length);
            _logger.LogInformation("=== RAW AI RESPONSE START ===");
            _logger.LogInformation(aiResponse);
            _logger.LogInformation("=== RAW AI RESPONSE END ===");

            // Try to extract JSON from the response - look for the first valid JSON object
            var jsonStart = aiResponse.IndexOf('{');
            var jsonEnd = -1;
            
            if (jsonStart >= 0)
            {
                // Find the matching closing brace
                var braceCount = 0;
                for (int i = jsonStart; i < aiResponse.Length; i++)
                {
                    if (aiResponse[i] == '{')
                        braceCount++;
                    else if (aiResponse[i] == '}')
                    {
                        braceCount--;
                        if (braceCount == 0)
                        {
                            jsonEnd = i;
                            break;
                        }
                    }
                }
            }

            if (jsonStart >= 0 && jsonEnd > jsonStart)
            {
                var jsonContent = aiResponse.Substring(jsonStart, jsonEnd - jsonStart + 1);
                
                _logger.LogInformation("=== EXTRACTED JSON START ===");
                _logger.LogInformation(jsonContent);
                _logger.LogInformation("=== EXTRACTED JSON END ===");

                try
                {
                    // Use JsonSerializerOptions to handle comments and extra whitespace
                    var options = new System.Text.Json.JsonSerializerOptions
                    {
                        ReadCommentHandling = System.Text.Json.JsonCommentHandling.Skip,
                        AllowTrailingCommas = true,
                        PropertyNameCaseInsensitive = true
                    };
                    
                    var planStructure = System.Text.Json.JsonSerializer.Deserialize<PlanStructure>(jsonContent, options);
                    if (planStructure != null && planStructure.Steps != null && planStructure.Steps.Count > 0)
                    {
                        // Validate that all steps have required fields
                        var validSteps = new List<PlanStepStructure>();
                        foreach (var step in planStructure.Steps)
                        {
                            if (!string.IsNullOrWhiteSpace(step.Prompt))
                            {
                                // Auto-populate missing required fields
                                if (string.IsNullOrWhiteSpace(step.Id))
                                    step.Id = (validSteps.Count + 1).ToString();
                                if (string.IsNullOrWhiteSpace(step.Name))
                                    step.Name = $"Step {step.Id}";
                                if (string.IsNullOrWhiteSpace(step.Description))
                                    step.Description = step.Prompt;
                                
                                validSteps.Add(step);
                            }
                        }
                        
                        planStructure.Steps = validSteps;
                        
                        // Auto-populate plan name if missing
                        if (string.IsNullOrWhiteSpace(planStructure.Name))
                        {
                            planStructure.Name = $"Plan for: {originalPrompt.Substring(0, Math.Min(50, originalPrompt.Length))}...";
                        }
                        
                        _logger.LogInformation("Successfully parsed plan with {StepCount} valid steps", validSteps.Count);
                        return planStructure;
                    }
                }
                catch (System.Text.Json.JsonException ex)
                {
                    _logger.LogWarning(ex, "Failed to parse extracted JSON content");
                }
            }
            
            _logger.LogWarning("Could not extract valid JSON from AI response");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error parsing AI response");
        }
        
        // Fallback: return empty plan structure
        return new PlanStructure { Steps = new List<PlanStepStructure>() };
    }

    private List<PlanStep> GenerateDetailedStepsAsync(PlanStructure planStructure, List<RunningServerInfo> servers, ServerToolMapping toolMapping)
    {
        var steps = new List<PlanStep>();
        var invalidSteps = new List<string>();
        
        _logger.LogInformation("Processing {StepCount} steps from AI-generated plan", planStructure.Steps.Count);
        
        foreach (var stepStructure in planStructure.Steps)
        {
            // Only accept prompt-based steps
            if (!string.IsNullOrEmpty(stepStructure.Prompt))
            {
                var step = new PlanStep
                {
                    Id = stepStructure.Id,
                    Name = stepStructure.Name,
                    Description = stepStructure.Description,
                    Prompt = stepStructure.Prompt,
                    ExpectedOutputs = stepStructure.ExpectedOutputs ?? new Dictionary<string, object>(),
                    Dependencies = stepStructure.Dependencies ?? new List<string>(),
                    Status = StepStatus.Pending
                };
                steps.Add(step);
                _logger.LogInformation("Prompt-based step added: {StepName} - {Prompt}", stepStructure.Name, stepStructure.Prompt);
            }
            else if (!string.IsNullOrEmpty(stepStructure.ServerName) || !string.IsNullOrEmpty(stepStructure.ToolName))
            {
                // Filter out tool/server/toolName-based steps
                _logger.LogWarning("Filtered out tool/server/toolName-based step: {StepName}", stepStructure.Name);
                continue;
            }
            else
            {
                // Invalid step - neither prompt nor tool specified
                var invalidStep = $"Step '{stepStructure.Name}' has neither a prompt nor valid tool specification";
                _logger.LogWarning("Invalid step: {Step} - {Reason}", stepStructure.Name, invalidStep);
                continue;
            }
        }
        
        if (invalidSteps.Count > 0)
        {
            _logger.LogWarning("Filtered out {InvalidCount} invalid steps from AI-generated plan. Invalid steps: {InvalidSteps}", 
                invalidSteps.Count, string.Join("; ", invalidSteps));
        }
        
        _logger.LogInformation("Plan processing complete: {ValidSteps} valid steps, {InvalidSteps} invalid steps filtered out", 
            steps.Count, invalidSteps.Count);

        // If no valid steps were created, create a basic prompt-based step
        if (steps.Count == 0)
        {
            steps.Add(new PlanStep
            {
                Id = "1",
                Name = "Execute Request",
                Description = "Execute the user's request using available tools",
                Prompt = "Execute the requested analysis and provide results",
                ExpectedOutputs = new Dictionary<string, object>
                {
                    ["result"] = "Analysis results"
                },
                Status = StepStatus.Pending
            });
            
            _logger.LogInformation("Created fallback prompt-based step");
        }

        return steps;
    }

    private Plan FixPlanIssuesAsync(Plan plan, ValidationResult validationResult, List<RunningServerInfo> servers, ServerToolMapping toolMapping)
    {
        _logger.LogInformation("Attempting to fix plan validation issues");

        // Remove invalid steps
        var validSteps = new List<PlanStep>();
        foreach (var step in plan.Steps)
        {
            if (toolMapping.ServerToTools.ContainsKey(step.ServerName) &&
                toolMapping.ServerToTools[step.ServerName].Contains(step.ToolName))
            {
                validSteps.Add(step);
            }
            else
            {
                _logger.LogWarning("Removing invalid step: {Server}.{Tool}", step.ServerName, step.ToolName);
            }
        }

        plan.Steps = validSteps;

        // If no valid steps remain, create a fallback plan
        if (plan.Steps.Count == 0)
        {
            return GenerateFallbackPlanAsync(plan.Goal, servers, toolMapping);
        }

        return plan;
    }

    private Plan GenerateFallbackPlanAsync(string prompt, List<RunningServerInfo> servers, ServerToolMapping toolMapping)
    {
        _logger.LogInformation("Generating fallback plan with prompt-based steps");

        var steps = new List<PlanStep>();
        var stepNumber = 1;

        // Create prompt-based steps based on the user's request
        // Analyze the prompt to create meaningful steps
        if (prompt.ToLowerInvariant().Contains("initialize") && prompt.ToLowerInvariant().Contains("client"))
        {
            steps.Add(new PlanStep
            {
                Id = stepNumber.ToString(),
                Name = "Initialize Azure DevOps Client",
                Description = "Initialize the Azure DevOps client for the dnceng organization",
                Prompt = "Initialize the Azure DevOps client and authenticate with the dnceng organization",
                ExpectedOutputs = new Dictionary<string, object>
                {
                    ["result"] = "Client initialization status"
                },
                Status = StepStatus.Pending
            });
            stepNumber++;
        }

        if (prompt.ToLowerInvariant().Contains("project"))
        {
            steps.Add(new PlanStep
            {
                Id = stepNumber.ToString(),
                Name = "Get Projects",
                Description = "Retrieve all projects from the dnceng organization",
                Prompt = "Get all projects in the dnceng organization and list them",
                ExpectedOutputs = new Dictionary<string, object>
                {
                    ["result"] = "List of projects"
                },
                Status = StepStatus.Pending
            });
            stepNumber++;
        }

        // If no specific steps were created, create a generic one
        if (steps.Count == 0)
        {
            steps.Add(new PlanStep
            {
                Id = "1",
                Name = "Execute Request",
                Description = "Execute the user's request using available tools",
                Prompt = prompt,
                ExpectedOutputs = new Dictionary<string, object>
                {
                    ["result"] = "Request execution results"
                },
                Status = StepStatus.Pending
            });
        }

        _logger.LogInformation("Generated fallback plan with {StepCount} prompt-based steps", steps.Count);

        return new Plan
        {
            Id = GeneratePlanId(),
            Name = $"Fallback Plan: {prompt.Substring(0, Math.Min(50, prompt.Length))}...",
            Goal = prompt,
            Steps = steps,
            CreatedAt = DateTime.UtcNow,
            Status = PlanStatus.Created
        };
    }

    private string GeneratePlanId()
    {
        return $"{DateTime.UtcNow:yyyyMMdd-HHmmss}-{Guid.NewGuid().ToString("N").Substring(0, 8)}";
    }

    // Helper classes for parsing AI response
    private class PlanStructure
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<PlanStepStructure> Steps { get; set; } = new();
    }

    private class PlanStepStructure
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        // Legacy tool-based execution
        public string ServerName { get; set; } = string.Empty;
        public string ToolName { get; set; } = string.Empty;
        
        // New prompt-based execution
        public string Prompt { get; set; } = string.Empty;
        
        public Dictionary<string, object>? Inputs { get; set; }
        public Dictionary<string, object>? ExpectedOutputs { get; set; }
        public List<string>? Dependencies { get; set; }
        public string? Condition { get; set; }
        public string? Justification { get; set; }
    }
} 