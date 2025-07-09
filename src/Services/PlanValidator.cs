using McpCli.Models;
using Microsoft.Extensions.Logging;

namespace McpCli.Services;

public class PlanValidator
{
    private readonly ILogger<PlanValidator> _logger;

    public PlanValidator(ILogger<PlanValidator> logger)
    {
        _logger = logger;
    }

    public ValidationResult ValidatePlan(Plan plan, List<RunningServerInfo> servers, ServerToolMapping toolMapping)
    {
        var result = new ValidationResult { IsValid = true };
        var errors = new List<string>();
        var warnings = new List<string>();

        _logger.LogDebug("Validating plan {PlanId} with {StepCount} steps", plan.Id, plan.Steps.Count);

        // Validate plan structure
        if (string.IsNullOrEmpty(plan.Id))
        {
            errors.Add("Plan ID is required");
        }

        if (string.IsNullOrEmpty(plan.Name))
        {
            errors.Add("Plan name is required");
        }

        if (string.IsNullOrEmpty(plan.Goal))
        {
            errors.Add("Plan goal is required");
        }

        // Validate steps
        if (plan.Steps.Count == 0)
        {
            errors.Add("Plan must contain at least one step");
        }

        var stepIds = new HashSet<string>();
        var stepNumbers = new HashSet<int>();

        for (int i = 0; i < plan.Steps.Count; i++)
        {
            var step = plan.Steps[i];
            var stepValidation = ValidateStep(step, i + 1, servers, toolMapping);
            
            errors.AddRange(stepValidation.Errors);
            warnings.AddRange(stepValidation.Warnings);

            // Check for duplicate step IDs
            if (!string.IsNullOrEmpty(step.Id))
            {
                if (stepIds.Contains(step.Id))
                {
                    errors.Add($"Duplicate step ID: {step.Id}");
                }
                else
                {
                    stepIds.Add(step.Id);
                }
            }

            // Check for duplicate step numbers
            if (int.TryParse(step.Id, out var stepNumber))
            {
                if (stepNumbers.Contains(stepNumber))
                {
                    errors.Add($"Duplicate step number: {stepNumber}");
                }
                else
                {
                    stepNumbers.Add(stepNumber);
                }
            }
        }

        // Validate dependencies
        var dependencyValidation = ValidateDependencies(plan.Steps);
        errors.AddRange(dependencyValidation.Errors);
        warnings.AddRange(dependencyValidation.Warnings);

        // Validate server availability
        var serverValidation = ValidateServerAvailability(plan.Steps, servers);
        errors.AddRange(serverValidation.Errors);
        warnings.AddRange(serverValidation.Warnings);

        // Validate tool availability
        var toolValidation = ValidateToolAvailability(plan.Steps, toolMapping);
        errors.AddRange(toolValidation.Errors);
        warnings.AddRange(toolValidation.Warnings);

        result.IsValid = errors.Count == 0;
        result.Errors = errors;
        result.Warnings = warnings;

        if (result.IsValid)
        {
            _logger.LogInformation("Plan {PlanId} validation passed with {WarningCount} warnings", plan.Id, warnings.Count);
        }
        else
        {
            _logger.LogWarning("Plan {PlanId} validation failed with {ErrorCount} errors and {WarningCount} warnings", 
                plan.Id, errors.Count, warnings.Count);
        }

        return result;
    }

    private ValidationResult ValidateStep(PlanStep step, int expectedStepNumber, List<RunningServerInfo> servers, ServerToolMapping toolMapping)
    {
        var result = new ValidationResult { IsValid = true };
        var errors = new List<string>();
        var warnings = new List<string>();

        // Validate step ID
        if (string.IsNullOrEmpty(step.Id))
        {
            errors.Add($"Step {expectedStepNumber}: Step ID is required");
        }
        else if (!int.TryParse(step.Id, out var stepNumber) || stepNumber != expectedStepNumber)
        {
            warnings.Add($"Step {expectedStepNumber}: Step ID '{step.Id}' doesn't match expected number {expectedStepNumber}");
        }

        // Validate step name
        if (string.IsNullOrEmpty(step.Name))
        {
            errors.Add($"Step {expectedStepNumber}: Step name is required");
        }

        // Validate step description
        if (string.IsNullOrEmpty(step.Description))
        {
            warnings.Add($"Step {expectedStepNumber}: Step description is missing");
        }

        // Check if this is a prompt-based step or tool-based step
        if (step.IsPromptBased)
        {
            // For prompt-based steps, validate the prompt
            if (string.IsNullOrEmpty(step.Prompt))
            {
                errors.Add($"Step {expectedStepNumber}: Prompt is required for prompt-based steps");
            }
            // Prompt-based steps must NOT have tool/server/toolName
            if (!string.IsNullOrEmpty(step.ServerName) || !string.IsNullOrEmpty(step.ToolName))
            {
                warnings.Add($"Step {expectedStepNumber}: Prompt-based step should not have server/tool/toolName fields");
            }
        }
        else
        {
            // For tool-based steps, validate server and tool
            if (string.IsNullOrEmpty(step.ServerName))
            {
                errors.Add($"Step {expectedStepNumber}: Server name is required for tool-based steps");
            }
            else if (!servers.Any(s => s.Name == step.ServerName))
            {
                errors.Add($"Step {expectedStepNumber}: Server '{step.ServerName}' is not available");
            }

            if (string.IsNullOrEmpty(step.ToolName))
            {
                errors.Add($"Step {expectedStepNumber}: Tool name is required for tool-based steps");
            }
            else if (!toolMapping.ServerToTools.ContainsKey(step.ServerName) || 
                     !toolMapping.ServerToTools[step.ServerName].Contains(step.ToolName))
            {
                errors.Add($"Step {expectedStepNumber}: Tool '{step.ToolName}' is not available on server '{step.ServerName}'");
            }
        }

        // Validate inputs (basic structure validation)
        if (step.Inputs == null)
        {
            errors.Add($"Step {expectedStepNumber}: Inputs cannot be null");
        }

        // Validate expected outputs (basic structure validation)
        if (step.ExpectedOutputs == null)
        {
            warnings.Add($"Step {expectedStepNumber}: Expected outputs are missing");
        }

        result.IsValid = errors.Count == 0;
        result.Errors = errors;
        result.Warnings = warnings;

        return result;
    }

    private ValidationResult ValidateDependencies(List<PlanStep> steps)
    {
        var result = new ValidationResult { IsValid = true };
        var errors = new List<string>();
        var warnings = new List<string>();

        var stepIds = steps.Select(s => s.Id).ToHashSet();

        foreach (var step in steps)
        {
            foreach (var dependency in step.Dependencies)
            {
                if (!stepIds.Contains(dependency))
                {
                    errors.Add($"Step {step.Id}: Dependency '{dependency}' references non-existent step");
                }
            }
        }

        // Check for circular dependencies (basic check)
        var visited = new HashSet<string>();
        var recursionStack = new HashSet<string>();

        foreach (var step in steps)
        {
            if (!visited.Contains(step.Id))
            {
                if (HasCircularDependency(step, steps, visited, recursionStack))
                {
                    errors.Add($"Step {step.Id}: Circular dependency detected");
                }
            }
        }

        result.IsValid = errors.Count == 0;
        result.Errors = errors;
        result.Warnings = warnings;

        return result;
    }

    private bool HasCircularDependency(PlanStep step, List<PlanStep> allSteps, HashSet<string> visited, HashSet<string> recursionStack)
    {
        visited.Add(step.Id);
        recursionStack.Add(step.Id);

        foreach (var dependencyId in step.Dependencies)
        {
            var dependency = allSteps.FirstOrDefault(s => s.Id == dependencyId);
            if (dependency == null) continue;

            if (!visited.Contains(dependency.Id))
            {
                if (HasCircularDependency(dependency, allSteps, visited, recursionStack))
                {
                    return true;
                }
            }
            else if (recursionStack.Contains(dependency.Id))
            {
                return true;
            }
        }

        recursionStack.Remove(step.Id);
        return false;
    }

    private ValidationResult ValidateServerAvailability(List<PlanStep> steps, List<RunningServerInfo> servers)
    {
        var result = new ValidationResult { IsValid = true };
        var errors = new List<string>();
        var warnings = new List<string>();

        var availableServers = servers.Select(s => s.Name).ToHashSet();
        // Only consider tool-based steps for server validation
        var usedServers = steps.Where(s => !s.IsPromptBased).Select(s => s.ServerName).ToHashSet();

        foreach (var serverName in usedServers)
        {
            if (!availableServers.Contains(serverName))
            {
                errors.Add($"Server '{serverName}' is not available");
            }
        }

        // Check if any servers are not being used (only for tool-based steps)
        var unusedServers = availableServers.Except(usedServers).ToList();
        if (unusedServers.Any())
        {
            warnings.Add($"Unused servers: {string.Join(", ", unusedServers)}");
        }

        result.IsValid = errors.Count == 0;
        result.Errors = errors;
        result.Warnings = warnings;

        return result;
    }

    private ValidationResult ValidateToolAvailability(List<PlanStep> steps, ServerToolMapping toolMapping)
    {
        var result = new ValidationResult { IsValid = true };
        var errors = new List<string>();
        var warnings = new List<string>();

        // Only validate tool availability for tool-based steps
        foreach (var step in steps.Where(s => !s.IsPromptBased))
        {
            if (toolMapping.ServerToTools.ContainsKey(step.ServerName))
            {
                var availableTools = toolMapping.ServerToTools[step.ServerName];
                if (!availableTools.Contains(step.ToolName))
                {
                    errors.Add($"Step {step.Id}: Tool '{step.ToolName}' is not available on server '{step.ServerName}'");
                }
            }
            else
            {
                errors.Add($"Step {step.Id}: No tools available on server '{step.ServerName}'");
            }
        }

        result.IsValid = errors.Count == 0;
        result.Errors = errors;
        result.Warnings = warnings;

        return result;
    }
}

public class ValidationResult
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; } = new();
    public List<string> Warnings { get; set; } = new();
} 