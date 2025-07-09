using System.Text;
using McpCli.Models;
using Microsoft.Extensions.Logging;

namespace McpCli.Services;

public class PlanPersistenceService : IPlanPersistenceService
{
    private readonly ILogger<PlanPersistenceService> _logger;
    private readonly IRepositoryRootService _repositoryRootService;
    private readonly string _plansDirectory;

    public PlanPersistenceService(ILogger<PlanPersistenceService> logger, IRepositoryRootService repositoryRootService)
    {
        _logger = logger;
        _repositoryRootService = repositoryRootService;
        _plansDirectory = _repositoryRootService.ResolvePath(".plans");
        
        // Ensure plans directory exists
        if (!Directory.Exists(_plansDirectory))
        {
            Directory.CreateDirectory(_plansDirectory);
            _logger.LogInformation("Created plans directory: {PlansDirectory}", _plansDirectory);
        }
    }

    public async Task<Plan> SavePlanAsync(Plan plan)
    {
        var planDirectory = await GetPlanDirectoryAsync(plan.Id);
        
        if (!Directory.Exists(planDirectory))
        {
            Directory.CreateDirectory(planDirectory);
        }

        var planFilePath = Path.Combine(planDirectory, "plan.md");
        var planContent = GeneratePlanMarkdown(plan);
        await File.WriteAllTextAsync(planFilePath, planContent, Encoding.UTF8);
        
        _logger.LogDebug("Saved plan {PlanId} to {PlanFilePath}", plan.Id, planFilePath);
        return plan;
    }

    public async Task<Plan?> LoadPlanAsync(string planId, Models.ExecutionSummary? executionSummary = null)
    {
        var planDirectory = await GetPlanDirectoryAsync(planId);
        var planFilePath = Path.Combine(planDirectory, "plan.md");
        
        if (!File.Exists(planFilePath))
        {
            _logger.LogWarning("Plan file not found: {PlanFilePath}", planFilePath);
            return null;
        }

        try
        {
            // Track file read in execution summary
            executionSummary?.AddPlanFileRead(planFilePath);

            var planContent = await File.ReadAllTextAsync(planFilePath, Encoding.UTF8);
            var plan = ParsePlanMarkdown(planContent, planId);
            _logger.LogDebug("Loaded plan {PlanId} from {PlanFilePath}", planId, planFilePath);
            return plan;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load plan {PlanId} from {PlanFilePath}", planId, planFilePath);
            return null;
        }
    }

    public async Task<PlanStep> SaveStepResultAsync(string planId, PlanStep step)
    {
        var planDirectory = await GetPlanDirectoryAsync(planId);
        var stepFileName = $"step-{step.Id:D3}-{SanitizeFileName(step.Name)}.md";
        var stepFilePath = Path.Combine(planDirectory, stepFileName);
        
        var stepContent = GenerateStepMarkdown(step, planId);
        await File.WriteAllTextAsync(stepFilePath, stepContent, Encoding.UTF8);
        
        _logger.LogDebug("Saved step {StepId} for plan {PlanId} to {StepFilePath}", step.Id, planId, stepFilePath);
        
        return step;
    }

    public async Task<List<PlanStep>> LoadStepResultsAsync(string planId, Models.ExecutionSummary? executionSummary = null)
    {
        var planDirectory = await GetPlanDirectoryAsync(planId);
        var steps = new List<PlanStep>();
        
        if (!Directory.Exists(planDirectory))
        {
            return steps;
        }

        var stepFiles = Directory.GetFiles(planDirectory, "step-*.md")
            .OrderBy(f => f)
            .ToList();

        foreach (var stepFile in stepFiles)
        {
            try
            {
                // Track file read in execution summary
                executionSummary?.AddStepResultFileRead(stepFile);

                var stepContent = await File.ReadAllTextAsync(stepFile, Encoding.UTF8);
                var step = ParseStepMarkdown(stepContent, planId);
                if (step != null)
                {
                    steps.Add(step);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load step from {StepFile}", stepFile);
            }
        }

        _logger.LogDebug("Loaded {StepCount} steps for plan {PlanId}", steps.Count, planId);
        return steps;
    }

    public Task<string> GetPlanDirectoryAsync(string planId)
    {
        return Task.FromResult(Path.Combine(_plansDirectory, planId));
    }

    public Task<List<string>> ListPlanIdsAsync()
    {
        if (!Directory.Exists(_plansDirectory))
        {
            return Task.FromResult(new List<string>());
        }

        var planIds = Directory.GetDirectories(_plansDirectory)
            .Select(Path.GetFileName)
            .Where(id => !string.IsNullOrEmpty(id))
            .Select(id => id!)
            .ToList();

        _logger.LogDebug("Found {PlanCount} plans in {PlansDirectory}", planIds.Count, _plansDirectory);
        return Task.FromResult(planIds);
    }

    public Task DeletePlanAsync(string planId)
    {
        var planDirectory = Path.Combine(_plansDirectory, planId);
        
        if (Directory.Exists(planDirectory))
        {
            Directory.Delete(planDirectory, true);
            _logger.LogInformation("Deleted plan {PlanId} directory: {PlanDirectory}", planId, planDirectory);
        }
        
        return Task.CompletedTask;
    }

    public Task<bool> PlanExistsAsync(string planId)
    {
        var planDirectory = Path.Combine(_plansDirectory, planId);
        return Task.FromResult(Directory.Exists(planDirectory));
    }

    public async Task<List<Plan>> ListPlansAsync()
    {
        var planIds = await ListPlanIdsAsync();
        var plans = new List<Plan>();
        
        foreach (var planId in planIds)
        {
            var plan = await LoadPlanAsync(planId);
            if (plan != null)
            {
                plans.Add(plan);
            }
        }
        
        _logger.LogDebug("Loaded {PlanCount} plans", plans.Count);
        return plans;
    }

    public async Task<int> CleanupOldPlansAsync(int daysToKeep = 30)
    {
        var cutoffDate = DateTime.UtcNow.AddDays(-daysToKeep);
        var planIds = await ListPlanIdsAsync();
        var deletedCount = 0;
        
        foreach (var planId in planIds)
        {
            var plan = await LoadPlanAsync(planId);
            if (plan != null && plan.CreatedAt < cutoffDate)
            {
                await DeletePlanAsync(planId);
                deletedCount++;
                _logger.LogInformation("Cleaned up old plan {PlanId} (created {CreatedAt})", planId, plan.CreatedAt);
            }
        }
        
        _logger.LogInformation("Cleaned up {DeletedCount} old plans (older than {DaysToKeep} days)", deletedCount, daysToKeep);
        return deletedCount;
    }

    private string GeneratePlanMarkdown(Plan plan)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine($"# Plan: {plan.Name}");
        sb.AppendLine();
        sb.AppendLine($"**Goal**: {plan.Goal}");
        sb.AppendLine();
        sb.AppendLine($"**Created**: {plan.CreatedAt:yyyy-MM-ddTHH:mm:ssZ}");
        sb.AppendLine($"**Status**: {plan.Status}");
        
        if (plan.StartedAt.HasValue)
        {
            sb.AppendLine($"**Started**: {plan.StartedAt.Value:yyyy-MM-ddTHH:mm:ssZ}");
        }
        
        if (plan.CompletedAt.HasValue)
        {
            sb.AppendLine($"**Completed**: {plan.CompletedAt.Value:yyyy-MM-ddTHH:mm:ssZ}");
        }
        
        if (plan.Duration.HasValue)
        {
            sb.AppendLine($"**Duration**: {plan.Duration.Value.TotalSeconds:F2} seconds");
        }
        
        if (!string.IsNullOrEmpty(plan.ErrorMessage))
        {
            sb.AppendLine($"**Error**: {plan.ErrorMessage}");
        }
        
        sb.AppendLine();
        sb.AppendLine("## Steps");
        sb.AppendLine();
        
        foreach (var step in plan.Steps)
        {
            // Only output prompt-based steps
            if (step.IsPromptBased)
            {
                sb.AppendLine($"- Step {step.Id}: {step.Prompt}");
            }
        }
        
        return sb.ToString();
    }

    private string GenerateStepMarkdown(PlanStep step, string planId)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine($"# Step {step.Id}: {step.Name}");
        sb.AppendLine();
        sb.AppendLine($"**Plan**: {planId}");
        sb.AppendLine($"**Status**: {step.Status}");
        
        if (step.StartedAt.HasValue)
        {
            sb.AppendLine($"**Started**: {step.StartedAt.Value:yyyy-MM-ddTHH:mm:ssZ}");
        }
        
        if (step.CompletedAt.HasValue)
        {
            sb.AppendLine($"**Completed**: {step.CompletedAt.Value:yyyy-MM-ddTHH:mm:ssZ}");
        }
        
        if (step.Duration.HasValue)
        {
            sb.AppendLine($"**Duration**: {step.Duration.Value.TotalSeconds:F2} seconds");
        }
        
        if (step.RetryCount > 0)
        {
            sb.AppendLine($"**Retries**: {step.RetryCount}/{step.MaxRetries}");
        }
        
        sb.AppendLine();
        sb.AppendLine("## Goal");
        sb.AppendLine(step.Description);
        sb.AppendLine();
        
        // Prompt gets its own section (for prompt-based steps)
        if (step.IsPromptBased && !string.IsNullOrEmpty(step.Prompt))
        {
            sb.AppendLine("## Prompt");
            sb.AppendLine(step.Prompt);
            sb.AppendLine();
        }
        
        sb.AppendLine("## Execution Details");
        
        if (step.Inputs.Any())
        {
            sb.AppendLine("- **Inputs**:");
            sb.AppendLine("```json");
            sb.AppendLine(System.Text.Json.JsonSerializer.Serialize(step.Inputs, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
            sb.AppendLine("```");
        }
        
        if (!string.IsNullOrEmpty(step.ContextFromPreviousSteps))
        {
            sb.AppendLine();
            sb.AppendLine("## Context from Previous Steps");
            sb.AppendLine(step.ContextFromPreviousSteps);
        }
        
        // Response section includes Server, Tools, and Results (only when step is completed)
        if (step.Status == StepStatus.Completed)
        {
            sb.AppendLine();
            sb.AppendLine("## Response");
            sb.AppendLine($"- **Server**: {step.ServerName}");
            sb.AppendLine($"- **Tool**: {step.ToolName}");
            
            if (step.ActualOutputs.Any())
            {
                // Pretty-printed Results section
                sb.AppendLine("- **Results**:");
                var prettyResults = FormatPrettyResults(step.ActualOutputs);
                sb.AppendLine(prettyResults);
                sb.AppendLine();
                
                // Raw Results section
                sb.AppendLine("- **Raw Results**:");
                sb.AppendLine("```json");
                sb.AppendLine(System.Text.Json.JsonSerializer.Serialize(step.ActualOutputs, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
                sb.AppendLine("```");
            }
        }
        
        if (!string.IsNullOrEmpty(step.ErrorMessage))
        {
            sb.AppendLine();
            sb.AppendLine("## Error");
            sb.AppendLine(step.ErrorMessage);
        }
        
        return sb.ToString();
    }

    private Plan ParsePlanMarkdown(string content, string planId)
    {
        // Basic parsing - in a real implementation, you'd want a more robust markdown parser
        var lines = content.Split('\n');
        var plan = new Plan { Id = planId };
        
        foreach (var line in lines)
        {
            if (line.StartsWith("# Plan: "))
            {
                plan.Name = line.Substring("# Plan: ".Length).Trim();
            }
            else if (line.StartsWith("**Goal**: "))
            {
                plan.Goal = line.Substring("**Goal**: ".Length).Trim();
            }
            else if (line.StartsWith("**Created**: "))
            {
                var dateStr = line.Substring("**Created**: ".Length).Trim();
                if (DateTime.TryParse(dateStr, out var date))
                {
                    plan.CreatedAt = date;
                }
            }
            else if (line.StartsWith("**Status**: "))
            {
                var statusStr = line.Substring("**Status**: ".Length).Trim();
                if (Enum.TryParse<PlanStatus>(statusStr, out var status))
                {
                    plan.Status = status;
                }
            }
        }
        
        return plan;
    }

    private PlanStep? ParseStepMarkdown(string content, string planId)
    {
        // Basic parsing - in a real implementation, you'd want a more robust markdown parser
        var lines = content.Split('\n');
        var step = new PlanStep();
        
        foreach (var line in lines)
        {
            if (line.StartsWith("# Step "))
            {
                var parts = line.Split(':');
                if (parts.Length >= 2)
                {
                    var stepPart = parts[0].Substring("# Step ".Length).Trim();
                    if (int.TryParse(stepPart, out var stepNumber))
                    {
                        step.Id = stepNumber.ToString();
                    }
                    step.Name = parts[1].Trim();
                }
            }
            else if (line.StartsWith("**Status**: "))
            {
                var statusStr = line.Substring("**Status**: ".Length).Trim();
                if (Enum.TryParse<StepStatus>(statusStr, out var status))
                {
                    step.Status = status;
                }
            }
            // Handle both old format (in Execution Details) and new format (in Response section)
            else if (line.StartsWith("- **Server**: "))
            {
                step.ServerName = line.Substring("- **Server**: ".Length).Trim();
            }
            else if (line.StartsWith("- **Tool**: "))
            {
                step.ToolName = line.Substring("- **Tool**: ".Length).Trim();
            }
        }
        
        return step;
    }

    private string SanitizeFileName(string fileName)
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        var sanitized = fileName;
        
        foreach (var invalidChar in invalidChars)
        {
            sanitized = sanitized.Replace(invalidChar, '_');
        }
        
        // Replace spaces with hyphens and convert to lowercase
        sanitized = sanitized.Replace(' ', '-').ToLowerInvariant();
        
        // Limit length
        if (sanitized.Length > 50)
        {
            sanitized = sanitized.Substring(0, 50);
        }
        
        return sanitized;
    }

    private string FormatPrettyResults(Dictionary<string, object> actualOutputs)
    {
        var sb = new StringBuilder();
        
        // Try to extract the main result content
        if (actualOutputs.TryGetValue("raw_result", out var rawResult))
        {
            var cleanResult = ExtractCleanResult(rawResult?.ToString());
            if (!string.IsNullOrEmpty(cleanResult))
            {
                sb.AppendLine("```");
                sb.AppendLine(cleanResult);
                sb.AppendLine("```");
                return sb.ToString();
            }
        }
        
        // Try to extract from parsed_results
        if (actualOutputs.TryGetValue("parsed_results", out var parsedResults))
        {
            var cleanResult = ExtractCleanResult(parsedResults?.ToString());
            if (!string.IsNullOrEmpty(cleanResult))
            {
                sb.AppendLine("```");
                sb.AppendLine(cleanResult);
                sb.AppendLine("```");
                return sb.ToString();
            }
        }
        
        // Fallback: just show the first meaningful value
        foreach (var kvp in actualOutputs)
        {
            if (kvp.Key != "ai_tool_selection_response" && kvp.Value != null)
            {
                var cleanResult = ExtractCleanResult(kvp.Value.ToString());
                if (!string.IsNullOrEmpty(cleanResult))
                {
                    sb.AppendLine("```");
                    sb.AppendLine(cleanResult);
                    sb.AppendLine("```");
                    return sb.ToString();
                }
            }
        }
        
        return "```\n[No readable results available]\n```";
    }

    private string ExtractCleanResult(string? input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        
        try
        {
            // Try to parse as JSON and extract meaningful content
            var jsonDoc = System.Text.Json.JsonDocument.Parse(input);
            
            // Look for common patterns in MCP responses
            if (jsonDoc.RootElement.TryGetProperty("content", out var content))
            {
                if (content.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    var items = content.EnumerateArray().ToList();
                    if (items.Count > 0 && items[0].TryGetProperty("text", out var textElement))
                    {
                        var text = textElement.GetString();
                        if (!string.IsNullOrEmpty(text))
                        {
                            // Try to parse the text as JSON for further prettification
                            try
                            {
                                var innerJson = System.Text.Json.JsonDocument.Parse(text);
                                return System.Text.Json.JsonSerializer.Serialize(innerJson, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                            }
                            catch
                            {
                                // If it's not JSON, return as-is
                                return text;
                            }
                        }
                    }
                }
            }
            
            // If no content property, just pretty-print the whole thing
            return System.Text.Json.JsonSerializer.Serialize(jsonDoc, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        }
        catch
        {
            // If it's not JSON, return as-is
            return input;
        }
    }
} 