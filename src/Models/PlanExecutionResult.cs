namespace McpCli.Models;

public class PlanExecutionResult
{
    public string PlanId { get; set; } = string.Empty;
    public PlanStatus FinalStatus { get; set; }
    public int TotalSteps { get; set; }
    public int CompletedSteps { get; set; }
    public int FailedSteps { get; set; }
    public int SkippedSteps { get; set; }
    public TimeSpan TotalDuration { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime CompletedAt { get; set; }
    public string? ErrorMessage { get; set; }
    public List<PlanStep> StepResults { get; set; } = new();
    public Dictionary<string, object> FinalOutputs { get; set; } = new();
    
    public double SuccessRate => TotalSteps > 0 ? (double)CompletedSteps / TotalSteps * 100 : 0;
    public bool IsSuccessful => FinalStatus == PlanStatus.Completed && FailedSteps == 0;
} 