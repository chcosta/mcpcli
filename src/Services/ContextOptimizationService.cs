using Microsoft.Extensions.Logging;
using McpCli.Models;
using System.Text.Json;

namespace McpCli.Services;

public class ContextOptimizationService
{
    private readonly ILogger<ContextOptimizationService> _logger;
    private readonly IPlanPersistenceService _planPersistenceService;
    private readonly Dictionary<string, OptimizedContext> _optimizedContexts = new();
    private readonly Dictionary<string, ContextAccessPattern> _accessPatterns = new();
    private readonly object _optimizationLock = new();

    // Optimization configuration
    private readonly int _maxOptimizedContexts = 500;
    private readonly TimeSpan _optimizationExpiration = TimeSpan.FromHours(2);

    public ContextOptimizationService(
        ILogger<ContextOptimizationService> logger,
        IPlanPersistenceService planPersistenceService)
    {
        _logger = logger;
        _planPersistenceService = planPersistenceService;
    }

    /// <summary>
    /// Optimizes context for a specific set of steps
    /// </summary>
    public async Task<OptimizedContext> OptimizeContextAsync(
        string planId, 
        List<string> stepIds, 
        Dictionary<string, object> context,
        Models.ExecutionSummary? executionSummary = null)
    {
        try
        {
            var optimizationKey = $"{planId}_{string.Join("_", stepIds.OrderBy(s => s))}";
            
            // Check if we already have an optimized version
            lock (_optimizationLock)
            {
                if (_optimizedContexts.TryGetValue(optimizationKey, out var existing))
                {
                    if (existing.ExpiresAt > DateTime.UtcNow)
                    {
                        existing.LastAccessed = DateTime.UtcNow;
                        existing.AccessCount++;
                        return existing;
                    }
                    else
                    {
                        _optimizedContexts.Remove(optimizationKey);
                    }
                }
            }

            // Analyze access patterns
            var accessPattern = await AnalyzeAccessPatternsAsync(planId, stepIds, executionSummary);
            
            // Create optimized context
            var optimizedContext = new OptimizedContext
            {
                PlanId = planId,
                StepIds = stepIds,
                OriginalContext = context,
                OptimizedData = await CreateOptimizedDataAsync(context, accessPattern),
                CreatedAt = DateTime.UtcNow,
                LastAccessed = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.Add(_optimizationExpiration),
                AccessCount = 1
            };

            // Store optimization
            lock (_optimizationLock)
            {
                _optimizedContexts[optimizationKey] = optimizedContext;
                
                // Cleanup if needed
                if (_optimizedContexts.Count > _maxOptimizedContexts)
                {
                    CleanupOldOptimizations();
                }
            }

            _logger.LogDebug("Optimized context for plan {PlanId} with {StepCount} steps, optimization score: {Score}", 
                planId, stepIds.Count, accessPattern.OptimizationScore);

            return optimizedContext;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error optimizing context for plan {PlanId}", planId);
            return new OptimizedContext
            {
                PlanId = planId,
                StepIds = stepIds,
                OriginalContext = context,
                OptimizedData = context,
                CreatedAt = DateTime.UtcNow,
                LastAccessed = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.Add(_optimizationExpiration),
                AccessCount = 1
            };
        }
    }

    /// <summary>
    /// Preloads context for anticipated step executions
    /// </summary>
    public async Task PreloadContextAsync(string planId, List<string> stepIds, Models.ExecutionSummary? executionSummary = null)
    {
        try
        {
            var stepResults = await _planPersistenceService.LoadStepResultsAsync(planId, executionSummary);
            var relevantSteps = stepResults.Where(s => stepIds.Contains(s.Id)).ToList();
            
            // Create a basic context from step results
            var context = new Dictionary<string, object>();
            foreach (var step in relevantSteps)
            {
                if (step.ActualOutputs != null)
                {
                    foreach (var output in step.ActualOutputs)
                    {
                        context[$"step_{step.Id}_{output.Key}"] = output.Value;
                    }
                }
            }
            
            // Optimize the context
            await OptimizeContextAsync(planId, stepIds, context, executionSummary);
            
            _logger.LogDebug("Preloaded context for plan {PlanId} with {StepCount} steps", planId, stepIds.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error preloading context for plan {PlanId}", planId);
        }
    }

    /// <summary>
    /// Gets optimized context for fast access
    /// </summary>
    public OptimizedContext? GetOptimizedContext(string planId, List<string> stepIds)
    {
        var optimizationKey = $"{planId}_{string.Join("_", stepIds)}";
        
        lock (_optimizationLock)
        {
            if (_optimizedContexts.TryGetValue(optimizationKey, out var optimizedContext))
            {
                if (optimizedContext.ExpiresAt > DateTime.UtcNow)
                {
                    optimizedContext.AccessCount++;
                    optimizedContext.LastAccessed = DateTime.UtcNow;
                    return optimizedContext;
                }
                else
                {
                    _optimizedContexts.Remove(optimizationKey);
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Analyzes context access patterns for optimization
    /// </summary>
    public async Task<ContextAccessPattern> AnalyzeAccessPatternsAsync(string planId, List<string> stepIds, Models.ExecutionSummary? executionSummary = null)
    {
        var pattern = new ContextAccessPattern
        {
            TotalKeys = 0,
            KeyTypes = new Dictionary<string, int>(),
            ValueSizes = new Dictionary<string, int>(),
            OptimizationScore = 0,
            FrequentlyAccessedKeys = new List<string>(),
            RarelyAccessedKeys = new List<string>(),
            TotalSize = 0
        };

        try
        {
            var stepResults = await _planPersistenceService.LoadStepResultsAsync(planId, executionSummary);
            var relevantSteps = stepResults.Where(s => stepIds.Contains(s.Id)).ToList();

            foreach (var step in relevantSteps)
            {
                if (step.ActualOutputs != null)
                {
                    foreach (var kvp in step.ActualOutputs)
                    {
                        pattern.TotalKeys++;
                        var keyType = AnalyzeKeyType(kvp.Key);
                        pattern.KeyTypes[keyType] = pattern.KeyTypes.GetValueOrDefault(keyType, 0) + 1;
                        var valueSize = GetValueSize(kvp.Value);
                        pattern.ValueSizes[kvp.Key] = valueSize;
                        pattern.TotalSize += valueSize;

                        if (IsFrequentlyAccessed(kvp.Key))
                        {
                            pattern.FrequentlyAccessedKeys.Add(kvp.Key);
                        }
                        if (IsRarelyAccessed(kvp.Key))
                        {
                            pattern.RarelyAccessedKeys.Add(kvp.Key);
                        }
                    }
                }
            }

            // Calculate optimization score
            pattern.OptimizationScore = CalculateOptimizationScore(pattern);

            return pattern;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error analyzing access pattern");
            return pattern;
        }
    }

    /// <summary>
    /// Compresses context data for storage optimization
    /// </summary>
    public async Task<CompressedContext> CompressContextAsync(Dictionary<string, object> context)
    {
        try
        {
            var compressed = new CompressedContext
            {
                OriginalSize = GetContextSize(context),
                CompressedData = new Dictionary<string, object>(),
                CompressionRatio = 0,
                CompressedAt = DateTime.UtcNow
            };

            foreach (var kvp in context)
            {
                var compressedValue = await CompressValueAsync(kvp.Value);
                compressed.CompressedData[kvp.Key] = compressedValue;
            }

            compressed.CompressedSize = GetContextSize(compressed.CompressedData);
            compressed.CompressionRatio = compressed.OriginalSize > 0 ? 
                (double)compressed.CompressedSize / compressed.OriginalSize : 0;

            _logger.LogDebug("Compressed context: {OriginalSize} -> {CompressedSize} bytes (ratio: {Ratio:F2})", 
                compressed.OriginalSize, compressed.CompressedSize, compressed.CompressionRatio);

            return compressed;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error compressing context");
            return new CompressedContext
            {
                OriginalSize = GetContextSize(context),
                CompressedData = context,
                CompressionRatio = 1.0,
                CompressedAt = DateTime.UtcNow
            };
        }
    }

    /// <summary>
    /// Decompresses context data
    /// </summary>
    public async Task<Dictionary<string, object>> DecompressContextAsync(CompressedContext compressedContext)
    {
        try
        {
            var decompressed = new Dictionary<string, object>();

            foreach (var kvp in compressedContext.CompressedData)
            {
                var decompressedValue = await DecompressValueAsync(kvp.Value);
                decompressed[kvp.Key] = decompressedValue;
            }

            return decompressed;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error decompressing context");
            return compressedContext.CompressedData;
        }
    }

    /// <summary>
    /// Gets optimization statistics
    /// </summary>
    public OptimizationStatistics GetOptimizationStatistics()
    {
        lock (_optimizationLock)
        {
            var totalOptimizations = _optimizedContexts.Count;
            var activeOptimizations = _optimizedContexts.Values.Count(o => o.ExpiresAt > DateTime.UtcNow);
            var totalAccesses = _optimizedContexts.Values.Sum(o => o.AccessCount);
            var averageOptimizationScore = _optimizedContexts.Values.Any() ? 
                _optimizedContexts.Values.Average(o => o.AccessPattern.OptimizationScore) : 0;

            return new OptimizationStatistics
            {
                TotalOptimizations = totalOptimizations,
                ActiveOptimizations = activeOptimizations,
                TotalAccesses = totalAccesses,
                AverageOptimizationScore = averageOptimizationScore,
                CacheHitRate = CalculateCacheHitRate(),
                AverageCompressionRatio = CalculateAverageCompressionRatio()
            };
        }
    }

    /// <summary>
    /// Cleans up old optimizations
    /// </summary>
    public void CleanupOldOptimizations()
    {
        lock (_optimizationLock)
        {
            var expiredOptimizations = _optimizedContexts.Values
                .Where(o => o.ExpiresAt < DateTime.UtcNow)
                .ToList();

            foreach (var optimization in expiredOptimizations)
            {
                var key = $"{optimization.PlanId}_{string.Join("_", optimization.StepIds)}";
                _optimizedContexts.Remove(key);
            }

            // Remove least accessed optimizations if still over limit
            if (_optimizedContexts.Count > _maxOptimizedContexts)
            {
                var leastAccessed = _optimizedContexts.OrderBy(kvp => kvp.Value.AccessCount)
                    .Take(_optimizedContexts.Count - _maxOptimizedContexts)
                    .ToList();

                foreach (var kvp in leastAccessed)
                {
                    _optimizedContexts.Remove(kvp.Key);
                }
            }

            _logger.LogDebug("Cleaned up {ExpiredCount} expired optimizations, remaining: {RemainingCount}", 
                expiredOptimizations.Count, _optimizedContexts.Count);
        }
    }

    private async Task<Dictionary<string, object>> CreateOptimizedDataAsync(Dictionary<string, object> context, ContextAccessPattern pattern)
    {
        var optimizedData = new Dictionary<string, object>();

        try
        {
            // Prioritize frequently accessed data
            foreach (var key in pattern.FrequentlyAccessedKeys)
            {
                if (context.ContainsKey(key))
                {
                    optimizedData[key] = context[key];
                }
            }

            // Compress rarely accessed data
            foreach (var key in pattern.RarelyAccessedKeys)
            {
                if (context.ContainsKey(key))
                {
                    var compressedValue = await CompressValueAsync(context[key]);
                    optimizedData[$"compressed_{key}"] = compressedValue;
                }
            }

            // Add optimization metadata
            optimizedData["_optimization_metadata"] = new
            {
                optimizationScore = pattern.OptimizationScore,
                frequentlyAccessedCount = pattern.FrequentlyAccessedKeys.Count,
                rarelyAccessedCount = pattern.RarelyAccessedKeys.Count,
                totalSize = pattern.TotalSize
            };

            return optimizedData;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating optimized data");
            return context;
        }
    }

    private string AnalyzeKeyType(string key)
    {
        if (key.StartsWith("step_"))
            return "step_output";
        if (key.StartsWith("context:"))
            return "context_reference";
        if (key.Contains("_"))
            return "compound_key";
        return "simple_key";
    }

    private int GetValueSize(object value)
    {
        if (value == null) return 0;
        
        if (value is string stringValue)
            return stringValue.Length;
        
        if (value is System.Collections.ICollection collection)
            return collection.Count;
        
        try
        {
            var json = JsonSerializer.Serialize(value);
            return json.Length;
        }
        catch
        {
            return 0;
        }
    }

    private bool IsFrequentlyAccessed(string key)
    {
        // Keys that are likely to be accessed frequently
        return key.Contains("result") || 
               key.Contains("output") || 
               key.Contains("data") || 
               key.Contains("status");
    }

    private bool IsRarelyAccessed(string key)
    {
        // Keys that are likely to be accessed rarely
        return key.Contains("metadata") || 
               key.Contains("debug") || 
               key.Contains("trace") || 
               key.Contains("log");
    }

    private double CalculateOptimizationScore(ContextAccessPattern pattern)
    {
        var score = 0.0;
        
        // Higher score for more diverse key types
        score += pattern.KeyTypes.Count * 0.1;
        
        // Higher score for frequently accessed keys
        score += pattern.FrequentlyAccessedKeys.Count * 0.2;
        
        // Lower score for large contexts
        score -= pattern.TotalSize / 1000.0;
        
        // Higher score for balanced access patterns
        var accessBalance = (double)pattern.FrequentlyAccessedKeys.Count / Math.Max(pattern.TotalKeys, 1);
        score += accessBalance * 0.5;
        
        return Math.Max(0, Math.Min(10, score));
    }

    private async Task<object> CompressValueAsync(object value)
    {
        if (value == null) return null;
        
        if (value is string stringValue)
        {
            // Simple string compression for long strings
            if (stringValue.Length > 100)
            {
                return $"compressed:{stringValue.Length}:{stringValue.Substring(0, 50)}...";
            }
            return stringValue;
        }
        
        if (value is System.Collections.ICollection collection)
        {
            // Compress large collections
            if (collection.Count > 10)
            {
                return $"compressed_collection:{collection.Count}_items";
            }
            return value;
        }
        
        return value;
    }

    private async Task<object> DecompressValueAsync(object value)
    {
        if (value is string stringValue)
        {
            if (stringValue.StartsWith("compressed:"))
            {
                // For now, return the compressed value as-is
                // In a real implementation, you'd have proper decompression
                return stringValue;
            }
        }
        
        return value;
    }

    private int GetContextSize(Dictionary<string, object> context)
    {
        return context.Values.Sum(v => GetValueSize(v));
    }

    private double CalculateCacheHitRate()
    {
        var totalAccesses = _optimizedContexts.Values.Sum(o => o.AccessCount);
        var totalRequests = totalAccesses + _optimizedContexts.Count; // Assuming each optimization was requested once
        return totalRequests > 0 ? (double)totalAccesses / totalRequests : 0;
    }

    private double CalculateAverageCompressionRatio()
    {
        // This would be calculated from actual compression operations
        // For now, return a placeholder value
        return 0.8; // 80% compression ratio
    }
}

public class OptimizedContext
{
    public string PlanId { get; set; } = string.Empty;
    public List<string> StepIds { get; set; } = new();
    public Dictionary<string, object> OriginalContext { get; set; } = new();
    public Dictionary<string, object> OptimizedData { get; set; } = new();
    public ContextAccessPattern AccessPattern { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime LastAccessed { get; set; }
    public DateTime ExpiresAt { get; set; }
    public int AccessCount { get; set; }
}

public class ContextAccessPattern
{
    public int TotalKeys { get; set; }
    public Dictionary<string, int> KeyTypes { get; set; } = new();
    public Dictionary<string, int> ValueSizes { get; set; } = new();
    public List<string> FrequentlyAccessedKeys { get; set; } = new();
    public List<string> RarelyAccessedKeys { get; set; } = new();
    public int TotalSize { get; set; }
    public double OptimizationScore { get; set; }
}

public class CompressedContext
{
    public Dictionary<string, object> CompressedData { get; set; } = new();
    public int OriginalSize { get; set; }
    public int CompressedSize { get; set; }
    public double CompressionRatio { get; set; }
    public DateTime CompressedAt { get; set; }
}

public class OptimizationStatistics
{
    public int TotalOptimizations { get; set; }
    public int ActiveOptimizations { get; set; }
    public int TotalAccesses { get; set; }
    public double AverageOptimizationScore { get; set; }
    public double CacheHitRate { get; set; }
    public double AverageCompressionRatio { get; set; }
} 