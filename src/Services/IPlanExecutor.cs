using McpCli.Models;

namespace McpCli.Services;

public interface IPlanExecutor
{
    Task<PlanExecutionResult> ExecutePlanAsync(Plan plan, List<RunningServerInfo> servers, ServerToolMapping toolMapping);
} 