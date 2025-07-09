using McpCli.Models;
using Microsoft.Extensions.Logging;

namespace McpCli.Services;

public class BasicPlanGenerator : IPlanGenerator
{
    private readonly ILogger<BasicPlanGenerator> _logger;

    public BasicPlanGenerator(ILogger<BasicPlanGenerator> logger)
    {
        _logger = logger;
    }

    public async Task<Plan> GeneratePlanAsync(string prompt, List<RunningServerInfo> servers, ServerToolMapping toolMapping, Models.ExecutionSummary? executionSummary = null)
    {
        _logger.LogInformation("Generating plan for prompt: {Prompt}", prompt);
        
        // Generate a unique plan ID
        var planId = GeneratePlanId(prompt);
        
        // Create a basic plan structure
        var plan = new Plan
        {
            Id = planId,
            Name = ExtractPlanName(prompt),
            Goal = prompt,
            CreatedAt = DateTime.UtcNow,
            Status = PlanStatus.Created
        };

        // Analyze the prompt and available tools to determine steps
        var steps = await AnalyzePromptAndGenerateStepsAsync(prompt, servers, toolMapping);
        plan.Steps = steps;

        _logger.LogInformation("Generated plan {PlanId} with {StepCount} steps", plan.Id, plan.Steps.Count);
        
        return plan;
    }

    private string GeneratePlanId(string prompt)
    {
        // Create a timestamp-based ID with a hash of the prompt
        var timestamp = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
        var promptHash = Math.Abs(prompt.GetHashCode()).ToString("x8");
        return $"{timestamp}-{promptHash}";
    }

    private string ExtractPlanName(string prompt)
    {
        // Extract a simple name from the prompt
        var words = prompt.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length <= 5)
        {
            return string.Join(" ", words);
        }
        
        return string.Join(" ", words.Take(5)) + "...";
    }

    private async Task<List<PlanStep>> AnalyzePromptAndGenerateStepsAsync(string prompt, List<RunningServerInfo> servers, ServerToolMapping toolMapping)
    {
        var steps = new List<PlanStep>();
        var stepNumber = 1;

        // Generic analysis - create steps based on available tools and servers
        // The specific tool selection and configuration should be handled by AI in Phase 2
        
        // For now, create a simple generic plan structure
        foreach (var server in servers)
        {
            if (toolMapping.ServerToTools.ContainsKey(server.Name))
            {
                var tools = toolMapping.ServerToTools[server.Name];
                
                // Create a step for each available tool (this is a placeholder - Phase 2 will be smarter)
                foreach (var tool in tools.Take(3)) // Limit to first 3 tools for now
                {
                    steps.Add(new PlanStep
                    {
                        Id = stepNumber.ToString(),
                        Name = $"Execute {tool}",
                        Description = $"Execute the {tool} tool on {server.Name} server",
                        ServerName = server.Name,
                        ToolName = tool,
                        Inputs = new Dictionary<string, object>(),
                        ExpectedOutputs = new Dictionary<string, object>
                        {
                            ["result"] = $"Output from {tool}"
                        },
                        Status = StepStatus.Pending
                    });
                    stepNumber++;
                }
            }
        }

        // If no steps were created, create a generic step
        if (steps.Count == 0)
        {
            var firstServer = servers.FirstOrDefault();
            if (firstServer != null && toolMapping.ServerToTools.ContainsKey(firstServer.Name))
            {
                var firstTool = toolMapping.ServerToTools[firstServer.Name].FirstOrDefault();
                if (!string.IsNullOrEmpty(firstTool))
                {
                    steps.Add(new PlanStep
                    {
                        Id = stepNumber.ToString(),
                        Name = "Execute Analysis",
                        Description = "Execute the requested analysis using available tools",
                        ServerName = firstServer.Name,
                        ToolName = firstTool,
                        Inputs = new Dictionary<string, object>(),
                        ExpectedOutputs = new Dictionary<string, object>
                        {
                            ["result"] = "Analysis results"
                        },
                        Status = StepStatus.Pending
                    });
                }
            }
        }

        _logger.LogDebug("Generated {StepCount} generic steps for prompt analysis", steps.Count);
        return steps;
    }
} 