using System.Text.Json.Serialization;

namespace McpCli.Models;

public class PlanStep
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    // Legacy tool-based execution
    public string ServerName { get; set; } = string.Empty;
    public string ToolName { get; set; } = string.Empty;
    
    // New prompt-based execution
    public string Prompt { get; set; } = string.Empty;
    public bool IsPromptBased => !string.IsNullOrEmpty(Prompt);
    
    public Dictionary<string, object> Inputs { get; set; } = new();
    public Dictionary<string, object> ExpectedOutputs { get; set; } = new();
    public Dictionary<string, object> ActualOutputs { get; set; } = new();
    public StepStatus Status { get; set; } = StepStatus.Pending;
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string? ErrorMessage { get; set; }
    public List<string> Dependencies { get; set; } = new();
    public int RetryCount { get; set; } = 0;
    public int MaxRetries { get; set; } = 3;
    public bool StopOnFailure { get; set; } = false;
    public TimeSpan? Duration => StartedAt.HasValue && CompletedAt.HasValue 
        ? CompletedAt.Value - StartedAt.Value 
        : null;
    public string? ContextFromPreviousSteps { get; set; }
    public string? Justification { get; set; }
}

public enum StepStatus
{
    Pending,
    InProgress,
    Completed,
    Failed,
    Skipped,
    Cancelled
} 