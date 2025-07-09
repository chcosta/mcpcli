using System.CommandLine;
using System.CommandLine.Invocation;
using Microsoft.Extensions.Logging;
using McpCli.Services;
using McpCli.Models;

namespace McpCli.Commands;

public class PlanCommand
{
    private readonly ILogger<PlanCommand> _logger;
    private readonly IPlanPersistenceService? _planPersistenceService;
    private readonly IMultiMcpServerService _multiMcpServerService;
    private readonly IPlanExecutor? _planExecutor;
    private readonly IRepositoryRootService _repositoryRootService;

    public PlanCommand(
        ILogger<PlanCommand> logger,
        IMultiMcpServerService multiMcpServerService,
        IRepositoryRootService repositoryRootService,
        IPlanPersistenceService? planPersistenceService = null,
        IPlanExecutor? planExecutor = null)
    {
        _logger = logger;
        _multiMcpServerService = multiMcpServerService;
        _repositoryRootService = repositoryRootService;
        _planPersistenceService = planPersistenceService;
        _planExecutor = planExecutor;
    }

    public Command CreateCommand()
    {
        var listCommand = new Command("list", "List all available plans");
        listCommand.SetHandler(async () => await ListPlansAsync());

        var viewCommand = new Command("view", "View details of a specific plan");
        var viewPlanIdArg = new Argument<string>("plan-id", "The ID of the plan to view");
        viewCommand.AddArgument(viewPlanIdArg);
        viewCommand.SetHandler(async (string planId) => await ViewPlanAsync(planId), viewPlanIdArg);

        var executeCommand = new Command("execute", "Execute a specific plan");
        var execPlanIdArg = new Argument<string>("plan-id", "The ID of the plan to execute");
        var execConfigOpt = new Option<string>("--config", "Path to the Markdown configuration file") { IsRequired = true };
        var execWorkingDirOpt = new Option<string>("--working-dir", () => "./mcp-servers", "Working directory for cloned repositories");
        executeCommand.AddArgument(execPlanIdArg);
        executeCommand.AddOption(execConfigOpt);
        executeCommand.AddOption(execWorkingDirOpt);
        executeCommand.SetHandler(async (string planId, string config, string workingDir) => await ExecutePlanAsync(planId, config, workingDir), execPlanIdArg, execConfigOpt, execWorkingDirOpt);

        var cleanupCommand = new Command("cleanup", "Clean up old plans");
        var daysOpt = new Option<int>("--days", () => 30, "Number of days to keep plans");
        cleanupCommand.AddOption(daysOpt);
        cleanupCommand.SetHandler(async (int days) => await CleanupPlansAsync(days), daysOpt);

        var deleteCommand = new Command("delete", "Delete a specific plan");
        var delPlanIdArg = new Argument<string>("plan-id", "The ID of the plan to delete");
        deleteCommand.AddArgument(delPlanIdArg);
        deleteCommand.SetHandler(async (string planId) => await DeletePlanAsync(planId), delPlanIdArg);

        var command = new Command("plan", "Manage AI-generated execution plans")
        {
            listCommand,
            viewCommand,
            executeCommand,
            cleanupCommand,
            deleteCommand
        };

        return command;
    }

    private async Task ListPlansAsync()
    {
        try
        {
            if (_planPersistenceService == null)
            {
                Console.WriteLine("❌ Plan persistence service not available");
                return;
            }

            Console.WriteLine("📋 Available Plans:");
            Console.WriteLine("==================");

            var plans = await _planPersistenceService.ListPlansAsync();
            if (plans.Count == 0)
            {
                Console.WriteLine("No plans found.");
                return;
            }

            foreach (var plan in plans.OrderByDescending(p => p.CreatedAt))
            {
                var status = plan.Status switch
                {
                    PlanStatus.Created => "📝 Created",
                    PlanStatus.InProgress => "🔄 In Progress",
                    PlanStatus.Completed => "✅ Completed",
                    PlanStatus.Failed => "❌ Failed",
                    _ => "❓ Unknown"
                };

                Console.WriteLine($"\n{status} | {plan.Name}");
                Console.WriteLine($"   ID: {plan.Id}");
                Console.WriteLine($"   Created: {plan.CreatedAt:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine($"   Steps: {plan.Steps.Count}");
                Console.WriteLine($"   Goal: {plan.Goal}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error listing plans");
            Console.WriteLine($"❌ Error listing plans: {ex.Message}");
        }
    }

    private async Task ViewPlanAsync(string planId)
    {
        try
        {
            if (_planPersistenceService == null)
            {
                Console.WriteLine("❌ Plan persistence service not available");
                return;
            }

            var plan = await _planPersistenceService.LoadPlanAsync(planId);
            if (plan == null)
            {
                Console.WriteLine($"❌ Plan not found: {planId}");
                return;
            }

            Console.WriteLine($"📋 Plan Details: {plan.Name}");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"ID: {plan.Id}");
            Console.WriteLine($"Status: {plan.Status}");
            Console.WriteLine($"Created: {plan.CreatedAt:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Goal: {plan.Goal}");
            Console.WriteLine($"Steps: {plan.Steps.Count}");

            if (plan.Variables?.Count > 0)
            {
                Console.WriteLine($"\n📊 Variables:");
                foreach (var variable in plan.Variables)
                {
                    Console.WriteLine($"   {variable.Key}: {variable.Value}");
                }
            }

            Console.WriteLine($"\n📝 Steps:");
            for (int i = 0; i < plan.Steps.Count; i++)
            {
                var step = plan.Steps[i];
                var status = step.Status switch
                {
                    StepStatus.Pending => "⏳ Pending",
                    StepStatus.InProgress => "🔄 In Progress",
                    StepStatus.Completed => "✅ Completed",
                    StepStatus.Failed => "❌ Failed",
                    StepStatus.Skipped => "⏭️ Skipped",
                    _ => "❓ Unknown"
                };

                Console.WriteLine($"\n{i + 1}. {status} | {step.Name}");
                Console.WriteLine($"   Description: {step.Description}");
                Console.WriteLine($"   Server: {step.ServerName}");
                Console.WriteLine($"   Tool: {step.ToolName}");

                if (step.Inputs?.Count > 0)
                {
                    Console.WriteLine($"   Inputs: {string.Join(", ", step.Inputs.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
                }

                if (step.ActualOutputs?.Count > 0)
                {
                    Console.WriteLine($"   Outputs: {string.Join(", ", step.ActualOutputs.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
                }

                if (!string.IsNullOrEmpty(step.ErrorMessage))
                {
                    Console.WriteLine($"   Error: {step.ErrorMessage}");
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error viewing plan");
            Console.WriteLine($"❌ Error viewing plan: {ex.Message}");
        }
    }

    private async Task ExecutePlanAsync(string planId, string configFile, string workingDir)
    {
        try
        {
            if (_planPersistenceService == null || _planExecutor == null)
            {
                Console.WriteLine("❌ Plan services not available");
                return;
            }

            var plan = await _planPersistenceService.LoadPlanAsync(planId);
            if (plan == null)
            {
                Console.WriteLine($"❌ Plan not found: {planId}");
                return;
            }

            Console.WriteLine($"📋 Executing plan: {planId}");
            
            // Resolve working directory relative to repository root
            var resolvedWorkingDir = _repositoryRootService.IsRelativePath(workingDir) 
                ? _repositoryRootService.ResolvePath(workingDir) 
                : workingDir;

            Console.WriteLine($"📁 Working directory: {resolvedWorkingDir}");

            // Load configuration
            // Note: This would need to be implemented based on your configuration loading logic
            Console.WriteLine("⚠️  Plan execution from dedicated command not yet implemented");
            Console.WriteLine("💡 Use 'mcpcli run --plan-id <plan-id>' instead");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing plan");
            Console.WriteLine($"❌ Error executing plan: {ex.Message}");
        }
    }

    private async Task CleanupPlansAsync(int days)
    {
        try
        {
            if (_planPersistenceService == null)
            {
                Console.WriteLine("❌ Plan persistence service not available");
                return;
            }

            Console.WriteLine($"🧹 Cleaning up plans older than {days} days...");
            
            var deletedCount = await _planPersistenceService.CleanupOldPlansAsync(days);
            Console.WriteLine($"✅ Cleaned up {deletedCount} old plans");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error cleaning up plans");
            Console.WriteLine($"❌ Error cleaning up plans: {ex.Message}");
        }
    }

    private async Task DeletePlanAsync(string planId)
    {
        try
        {
            if (_planPersistenceService == null)
            {
                Console.WriteLine("❌ Plan persistence service not available");
                return;
            }

            Console.WriteLine($"🗑️  Deleting plan: {planId}");
            
            await _planPersistenceService.DeletePlanAsync(planId);
            Console.WriteLine($"✅ Plan {planId} deleted successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting plan");
            Console.WriteLine($"❌ Error deleting plan: {ex.Message}");
        }
    }
} 