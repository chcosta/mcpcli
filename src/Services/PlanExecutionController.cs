using Microsoft.Extensions.Logging;
using McpCli.Models;
using System.Threading;

namespace McpCli.Services;

public class PlanExecutionController
{
    private readonly ILogger<PlanExecutionController> _logger;
    private readonly PlanExecutionMonitor _executionMonitor;
    private readonly Dictionary<string, CancellationTokenSource> _activeCancellationTokens = new();
    private readonly Dictionary<string, DateTime> _executionStartTimes = new();
    private readonly object _lockObject = new();

    // Default timeouts
    private readonly TimeSpan _defaultPlanTimeout = TimeSpan.FromHours(2);
    private readonly TimeSpan _defaultStepTimeout = TimeSpan.FromMinutes(10);

    public PlanExecutionController(
        ILogger<PlanExecutionController> logger,
        PlanExecutionMonitor executionMonitor)
    {
        _logger = logger;
        _executionMonitor = executionMonitor;
    }

    /// <summary>
    /// Starts a new plan execution with timeout and cancellation support
    /// </summary>
    public ExecutionControl StartExecution(string planId, int totalSteps, TimeSpan? planTimeout = null)
    {
        lock (_lockObject)
        {
            // Create cancellation token source
            var cts = new CancellationTokenSource();
            
            // Set plan timeout
            var timeout = planTimeout ?? _defaultPlanTimeout;
            cts.CancelAfter(timeout);
            
            // Store execution info
            _activeCancellationTokens[planId] = cts;
            _executionStartTimes[planId] = DateTime.UtcNow;
            
            // Start monitoring
            _executionMonitor.StartMonitoring(planId, totalSteps);
            
            _logger.LogInformation("Started execution control for plan {PlanId} with timeout {Timeout}", planId, timeout);
            
            return new ExecutionControl
            {
                PlanId = planId,
                CancellationToken = cts.Token,
                StartTime = _executionStartTimes[planId],
                Timeout = timeout
            };
        }
    }

    /// <summary>
    /// Cancels a plan execution
    /// </summary>
    public bool CancelExecution(string planId)
    {
        lock (_lockObject)
        {
            if (_activeCancellationTokens.TryGetValue(planId, out var cts))
            {
                cts.Cancel();
                _logger.LogInformation("Cancelled execution for plan {PlanId}", planId);
                return true;
            }
            
            _logger.LogWarning("Attempted to cancel non-existent execution for plan {PlanId}", planId);
            return false;
        }
    }

    /// <summary>
    /// Completes a plan execution and cleans up resources
    /// </summary>
    public void CompleteExecution(string planId, PlanStatus finalStatus)
    {
        lock (_lockObject)
        {
            // Complete monitoring
            _executionMonitor.CompleteMonitoring(planId, finalStatus);
            
            // Clean up resources
            if (_activeCancellationTokens.TryGetValue(planId, out var cts))
            {
                cts.Dispose();
                _activeCancellationTokens.Remove(planId);
            }
            
            _executionStartTimes.Remove(planId);
            
            _logger.LogInformation("Completed execution control for plan {PlanId} with status {Status}", planId, finalStatus);
        }
    }

    /// <summary>
    /// Gets the current status of a plan execution
    /// </summary>
    public ExecutionStatus? GetExecutionStatus(string planId)
    {
        lock (_lockObject)
        {
            if (!_executionStartTimes.TryGetValue(planId, out var startTime))
            {
                return null;
            }

            var progress = _executionMonitor.GetCurrentProgress(planId);
            var isCancelled = _activeCancellationTokens.TryGetValue(planId, out var cts) && cts.Token.IsCancellationRequested;
            var elapsed = DateTime.UtcNow - startTime;
            var timeout = _activeCancellationTokens.TryGetValue(planId, out var tokenSource) ? 
                         TimeSpan.FromMilliseconds(tokenSource.Token.WaitHandle.WaitOne(0) ? 0 : 1) : 
                         _defaultPlanTimeout;

            return new ExecutionStatus
            {
                PlanId = planId,
                IsActive = progress != null,
                IsCancelled = isCancelled,
                ElapsedTime = elapsed,
                RemainingTime = timeout - elapsed,
                Progress = progress,
                StartTime = startTime
            };
        }
    }

    /// <summary>
    /// Gets all active executions
    /// </summary>
    public List<ExecutionStatus> GetActiveExecutions()
    {
        lock (_lockObject)
        {
            var activeExecutions = new List<ExecutionStatus>();
            
            foreach (var planId in _activeCancellationTokens.Keys)
            {
                var status = GetExecutionStatus(planId);
                if (status != null)
                {
                    activeExecutions.Add(status);
                }
            }
            
            return activeExecutions;
        }
    }

    /// <summary>
    /// Extends the timeout for a plan execution
    /// </summary>
    public bool ExtendTimeout(string planId, TimeSpan additionalTime)
    {
        lock (_lockObject)
        {
            if (_activeCancellationTokens.TryGetValue(planId, out var cts))
            {
                // Cancel the current timeout and create a new one
                cts.CancelAfter(additionalTime);
                _logger.LogInformation("Extended timeout for plan {PlanId} by {AdditionalTime}", planId, additionalTime);
                return true;
            }
            
            _logger.LogWarning("Attempted to extend timeout for non-existent execution {PlanId}", planId);
            return false;
        }
    }

    /// <summary>
    /// Gets execution statistics
    /// </summary>
    public ExecutionControllerStatistics GetStatistics()
    {
        lock (_lockObject)
        {
            var monitorStats = _executionMonitor.GetStatistics();
            
            return new ExecutionControllerStatistics
            {
                ActiveExecutions = _activeCancellationTokens.Count,
                TotalExecutions = monitorStats.TotalPlans,
                CompletedExecutions = monitorStats.CompletedPlans,
                FailedExecutions = monitorStats.FailedPlans,
                CancelledExecutions = monitorStats.CancelledPlans,
                SuccessRate = monitorStats.SuccessRate,
                AverageExecutionTime = CalculateAverageExecutionTime()
            };
        }
    }

    /// <summary>
    /// Cleans up expired executions
    /// </summary>
    public void CleanupExpiredExecutions(TimeSpan maxExecutionTime)
    {
        lock (_lockObject)
        {
            var expiredPlans = new List<string>();
            
            foreach (var kvp in _executionStartTimes)
            {
                var elapsed = DateTime.UtcNow - kvp.Value;
                if (elapsed > maxExecutionTime)
                {
                    expiredPlans.Add(kvp.Key);
                }
            }
            
            foreach (var planId in expiredPlans)
            {
                _logger.LogWarning("Cleaning up expired execution for plan {PlanId}", planId);
                CompleteExecution(planId, PlanStatus.Failed);
            }
        }
    }

    private TimeSpan CalculateAverageExecutionTime()
    {
        var history = _executionMonitor.GetActiveExecutions();
        if (!history.Any())
        {
            return TimeSpan.Zero;
        }

        var totalTime = TimeSpan.Zero;
        var count = 0;
        
        foreach (var progress in history)
        {
            var status = GetExecutionStatus(progress.PlanId);
            if (status != null)
            {
                totalTime += status.ElapsedTime;
                count++;
            }
        }
        
        return count > 0 ? TimeSpan.FromTicks(totalTime.Ticks / count) : TimeSpan.Zero;
    }

    /// <summary>
    /// Disposes all active executions
    /// </summary>
    public void Dispose()
    {
        lock (_lockObject)
        {
            foreach (var cts in _activeCancellationTokens.Values)
            {
                cts.Dispose();
            }
            
            _activeCancellationTokens.Clear();
            _executionStartTimes.Clear();
        }
    }
}

public class ExecutionControl
{
    public string PlanId { get; set; } = string.Empty;
    public CancellationToken CancellationToken { get; set; }
    public DateTime StartTime { get; set; }
    public TimeSpan Timeout { get; set; }
}

public class ExecutionStatus
{
    public string PlanId { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsCancelled { get; set; }
    public TimeSpan ElapsedTime { get; set; }
    public TimeSpan RemainingTime { get; set; }
    public ExecutionProgress? Progress { get; set; }
    public DateTime StartTime { get; set; }
}

public class ExecutionControllerStatistics
{
    public int ActiveExecutions { get; set; }
    public int TotalExecutions { get; set; }
    public int CompletedExecutions { get; set; }
    public int FailedExecutions { get; set; }
    public int CancelledExecutions { get; set; }
    public double SuccessRate { get; set; }
    public TimeSpan AverageExecutionTime { get; set; }
} 