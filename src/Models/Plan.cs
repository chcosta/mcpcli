using System.Text.Json.Serialization;

namespace McpCli.Models;

public class Plan
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Goal { get; set; } = string.Empty;
    public List<PlanStep> Steps { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public PlanStatus Status { get; set; } = PlanStatus.Created;
    public Dictionary<string, object> Variables { get; set; } = new();
    public Dictionary<string, object> ActualOutputs { get; set; } = new();
    public string? ErrorMessage { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public TimeSpan? Duration => StartedAt.HasValue && CompletedAt.HasValue 
        ? CompletedAt.Value - StartedAt.Value 
        : null;
}

public enum PlanStatus
{
    Created,
    InProgress,
    Completed,
    Failed,
    Cancelled
} 