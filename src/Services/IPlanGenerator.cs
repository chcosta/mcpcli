using McpCli.Models;

namespace McpCli.Services;
 
public interface IPlanGenerator
{
    Task<Plan> GeneratePlanAsync(string prompt, List<RunningServerInfo> servers, ServerToolMapping toolMapping, Models.ExecutionSummary? executionSummary = null);
} 