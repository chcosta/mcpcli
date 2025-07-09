using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class PlanExecutionMonitor
{
    private readonly ILogger<PlanExecutionMonitor> _logger;
    private readonly Dictionary<string, ExecutionProgress> _activeExecutions = new();
    private readonly Dictionary<string, List<ExecutionProgress>> _executionHistory = new();
    private readonly object _lockObject = new();

    public PlanExecutionMonitor(ILogger<PlanExecutionMonitor> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Starts monitoring a plan execution
    /// </summary>
    public void StartMonitoring(string planId, int totalSteps)
    {
        lock (_lockObject)
        {
            var progress = new ExecutionProgress
            {
                PlanId = planId,
                TotalSteps = totalSteps,
                CompletedSteps = 0,
                FailedSteps = 0,
                SkippedSteps = 0,
                Status = "Started"
            };

            _activeExecutions[planId] = progress;
            
            if (!_executionHistory.ContainsKey(planId))
            {
                _executionHistory[planId] = new List<ExecutionProgress>();
            }
            
            _executionHistory[planId].Add(progress);
            
            _logger.LogInformation("Started monitoring plan {PlanId} with {TotalSteps} steps", planId, totalSteps);
        }
    }

    /// <summary>
    /// Updates the progress of a plan execution
    /// </summary>
    public void UpdateProgress(ExecutionProgress progress)
    {
        lock (_lockObject)
        {
            if (_activeExecutions.ContainsKey(progress.PlanId))
            {
                _activeExecutions[progress.PlanId] = progress;
                _executionHistory[progress.PlanId].Add(progress);
                
                _logger.LogDebug("Updated progress for plan {PlanId}: {Completed}/{Total} completed, {Failed} failed, {Skipped} skipped", 
                    progress.PlanId, progress.CompletedSteps, progress.TotalSteps, progress.FailedSteps, progress.SkippedSteps);
            }
        }
    }

    /// <summary>
    /// Completes monitoring for a plan execution
    /// </summary>
    public void CompleteMonitoring(string planId, PlanStatus finalStatus)
    {
        lock (_lockObject)
        {
            if (_activeExecutions.ContainsKey(planId))
            {
                var finalProgress = _activeExecutions[planId];
                finalProgress.Status = finalStatus.ToString();
                _executionHistory[planId].Add(finalProgress);
                
                _activeExecutions.Remove(planId);
                
                _logger.LogInformation("Completed monitoring for plan {PlanId} with final status {Status}", planId, finalStatus);
            }
        }
    }

    /// <summary>
    /// Gets the current progress of an active plan execution
    /// </summary>
    public ExecutionProgress? GetCurrentProgress(string planId)
    {
        lock (_lockObject)
        {
            return _activeExecutions.TryGetValue(planId, out var progress) ? progress : null;
        }
    }

    /// <summary>
    /// Gets the execution history for a plan
    /// </summary>
    public List<ExecutionProgress> GetExecutionHistory(string planId)
    {
        lock (_lockObject)
        {
            return _executionHistory.TryGetValue(planId, out var history) ? history : new List<ExecutionProgress>();
        }
    }

    /// <summary>
    /// Gets all currently active plan executions
    /// </summary>
    public List<ExecutionProgress> GetActiveExecutions()
    {
        lock (_lockObject)
        {
            return _activeExecutions.Values.ToList();
        }
    }

    /// <summary>
    /// Gets execution statistics
    /// </summary>
    public ExecutionStatistics GetStatistics()
    {
        lock (_lockObject)
        {
            var activeCount = _activeExecutions.Count;
            var totalPlans = _executionHistory.Count;
            var completedPlans = _executionHistory.Values.Count(h => h.Any(p => p.Status == "Completed"));
            var failedPlans = _executionHistory.Values.Count(h => h.Any(p => p.Status == "Failed"));
            var cancelledPlans = _executionHistory.Values.Count(h => h.Any(p => p.Status == "Cancelled"));

            return new ExecutionStatistics
            {
                ActiveExecutions = activeCount,
                TotalPlans = totalPlans,
                CompletedPlans = completedPlans,
                FailedPlans = failedPlans,
                CancelledPlans = cancelledPlans,
                SuccessRate = totalPlans > 0 ? (double)completedPlans / totalPlans : 0
            };
        }
    }

    /// <summary>
    /// Cleans up old execution history
    /// </summary>
    public void CleanupHistory(int maxHistoryPerPlan = 100)
    {
        lock (_lockObject)
        {
            foreach (var planId in _executionHistory.Keys.ToList())
            {
                if (_executionHistory[planId].Count > maxHistoryPerPlan)
                {
                    var history = _executionHistory[planId];
                    var toRemove = history.Count - maxHistoryPerPlan;
                    _executionHistory[planId] = history.Skip(toRemove).ToList();
                    
                    _logger.LogDebug("Cleaned up {RemovedCount} old progress entries for plan {PlanId}", toRemove, planId);
                }
            }
        }
    }

    /// <summary>
    /// Subscribes to progress updates for a specific plan
    /// </summary>
    public IDisposable SubscribeToProgress(string planId, Action<ExecutionProgress> callback)
    {
        return new ProgressSubscription(this, planId, callback);
    }

    private class ProgressSubscription : IDisposable
    {
        private readonly PlanExecutionMonitor _monitor;
        private readonly string _planId;
        private readonly Action<ExecutionProgress> _callback;
        private bool _disposed = false;

        public ProgressSubscription(PlanExecutionMonitor monitor, string planId, Action<ExecutionProgress> callback)
        {
            _monitor = monitor;
            _planId = planId;
            _callback = callback;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                // Could implement unsubscribe logic here if needed
            }
        }
    }
}

public class ExecutionStatistics
{
    public int ActiveExecutions { get; set; }
    public int TotalPlans { get; set; }
    public int CompletedPlans { get; set; }
    public int FailedPlans { get; set; }
    public int CancelledPlans { get; set; }
    public double SuccessRate { get; set; }
} 