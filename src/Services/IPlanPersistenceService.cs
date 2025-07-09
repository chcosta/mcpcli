using McpCli.Models;

namespace McpCli.Services;

public interface IPlanPersistenceService
{
    Task<Plan> SavePlanAsync(Plan plan);
    Task<Plan?> LoadPlanAsync(string planId, Models.ExecutionSummary? executionSummary = null);
    Task<PlanStep> SaveStepResultAsync(string planId, PlanStep step);
    Task<List<PlanStep>> LoadStepResultsAsync(string planId, Models.ExecutionSummary? executionSummary = null);
    Task<string> GetPlanDirectoryAsync(string planId);
    Task<List<string>> ListPlanIdsAsync();
    Task DeletePlanAsync(string planId);
    Task<bool> PlanExistsAsync(string planId);
    Task<List<Plan>> ListPlansAsync();
    Task<int> CleanupOldPlansAsync(int daysToKeep = 30);
} 