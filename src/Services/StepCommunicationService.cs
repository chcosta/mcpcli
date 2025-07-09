using Microsoft.Extensions.Logging;
using McpCli.Models;
using System.Text.Json;

namespace McpCli.Services;

public class StepCommunicationService
{
    private readonly ILogger<StepCommunicationService> _logger;
    private readonly IPlanPersistenceService _planPersistenceService;
    private readonly IAzureAiService _azureAiService;
    private readonly Dictionary<string, StepCommunicationChannel> _communicationChannels = new();
    private readonly object _channelLock = new();

    public StepCommunicationService(
        ILogger<StepCommunicationService> logger,
        IPlanPersistenceService planPersistenceService,
        IAzureAiService azureAiService)
    {
        _logger = logger;
        _planPersistenceService = planPersistenceService;
        _azureAiService = azureAiService;
    }

    /// <summary>
    /// Creates a communication channel between steps
    /// </summary>
    public StepCommunicationChannel CreateCommunicationChannel(string planId, string channelName, List<string> stepIds)
    {
        lock (_channelLock)
        {
            var channelKey = $"{planId}_{channelName}";
            
            var channel = new StepCommunicationChannel
            {
                PlanId = planId,
                ChannelName = channelName,
                StepIds = stepIds,
                CreatedAt = DateTime.UtcNow,
                Status = ChannelStatus.Active
            };

            _communicationChannels[channelKey] = channel;
            
            _logger.LogInformation("Created communication channel {ChannelName} for plan {PlanId} with {StepCount} steps", 
                channelName, planId, stepIds.Count);

            return channel;
        }
    }

    /// <summary>
    /// Sends data from one step to another through a communication channel
    /// </summary>
    public async Task<bool> SendDataAsync(string planId, string channelName, string fromStepId, string toStepId, object data)
    {
        try
        {
            var channelKey = $"{planId}_{channelName}";
            
            lock (_channelLock)
            {
                if (!_communicationChannels.TryGetValue(channelKey, out var channel))
                {
                    _logger.LogWarning("Communication channel {ChannelName} not found for plan {PlanId}", channelName, planId);
                    return false;
                }

                if (!channel.StepIds.Contains(fromStepId) || !channel.StepIds.Contains(toStepId))
                {
                    _logger.LogWarning("Step {FromStepId} or {ToStepId} not in channel {ChannelName}", fromStepId, toStepId, channelName);
                    return false;
                }

                var message = new StepMessage
                {
                    Id = Guid.NewGuid().ToString(),
                    FromStepId = fromStepId,
                    ToStepId = toStepId,
                    Data = data,
                    Timestamp = DateTime.UtcNow,
                    Status = MessageStatus.Sent
                };

                channel.Messages.Add(message);
                channel.LastActivity = DateTime.UtcNow;
            }

            _logger.LogDebug("Sent data from step {FromStepId} to step {ToStepId} through channel {ChannelName}", 
                fromStepId, toStepId, channelName);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending data from step {FromStepId} to step {ToStepId}", fromStepId, toStepId);
            return false;
        }
    }

    /// <summary>
    /// Receives data for a specific step from communication channels
    /// </summary>
    public async Task<List<StepMessage>> ReceiveDataAsync(string planId, string stepId)
    {
        var receivedMessages = new List<StepMessage>();

        try
        {
            lock (_channelLock)
            {
                var relevantChannels = _communicationChannels.Values
                    .Where(c => c.PlanId == planId && c.StepIds.Contains(stepId))
                    .ToList();

                foreach (var channel in relevantChannels)
                {
                    var messages = channel.Messages
                        .Where(m => m.ToStepId == stepId && m.Status == MessageStatus.Sent)
                        .ToList();

                    foreach (var message in messages)
                    {
                        message.Status = MessageStatus.Received;
                        message.ReceivedAt = DateTime.UtcNow;
                        receivedMessages.Add(message);
                    }

                    channel.LastActivity = DateTime.UtcNow;
                }
            }

            _logger.LogDebug("Received {MessageCount} messages for step {StepId} in plan {PlanId}", 
                receivedMessages.Count, stepId, planId);

            return receivedMessages;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error receiving data for step {StepId}", stepId);
            return receivedMessages;
        }
    }

    /// <summary>
    /// Processes and transforms data between steps using AI
    /// </summary>
    public async Task<object> ProcessDataTransformationAsync(string planId, string fromStepId, string toStepId, object data, string transformationPrompt)
    {
        try
        {
            var aiPrompt = $@"
Transform the following data from step '{fromStepId}' to be suitable for step '{toStepId}':

Original Data: {JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true })}

Transformation Instructions: {transformationPrompt}

Return the transformed data in the most appropriate format for the target step.
";

            var response = await _azureAiService.SendPromptAsync(aiPrompt);
            
            // Try to parse as JSON first, fallback to string
            try
            {
                return JsonSerializer.Deserialize<object>(response) ?? response;
            }
            catch
            {
                return response;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing data transformation from step {FromStepId} to step {ToStepId}", fromStepId, toStepId);
            return data; // Return original data if transformation fails
        }
    }

    /// <summary>
    /// Validates data format and content for step communication
    /// </summary>
    public async Task<ContextValidationResult> ValidateCommunicationDataAsync(object data, string stepId, Dictionary<string, object> expectedFormat)
    {
        var errors = new List<string>();
        var warnings = new List<string>();

        try
        {
            // Basic validation
            if (data == null)
            {
                errors.Add("Data cannot be null");
                return new ContextValidationResult { IsValid = false, Errors = errors, Warnings = warnings };
            }

            // Type validation
            var dataType = data.GetType();
            if (expectedFormat.ContainsKey("type"))
            {
                var expectedType = expectedFormat["type"].ToString();
                if (!ValidateDataType(dataType, expectedType))
                {
                    errors.Add($"Expected type {expectedType}, got {dataType.Name}");
                }
            }

            // Size validation
            if (expectedFormat.ContainsKey("maxSize"))
            {
                var maxSize = Convert.ToInt32(expectedFormat["maxSize"]);
                var dataSize = GetDataSize(data);
                if (dataSize > maxSize)
                {
                    errors.Add($"Data size {dataSize} exceeds maximum {maxSize}");
                }
            }

            // Content validation using AI
            if (data is string stringData && stringData.Length > 50)
            {
                var contentValidation = await ValidateContentWithAiAsync(stringData, stepId);
                errors.AddRange(contentValidation.Errors);
                warnings.AddRange(contentValidation.Warnings);
            }

            return new ContextValidationResult { IsValid = errors.Count == 0, Errors = errors, Warnings = warnings };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating communication data for step {StepId}", stepId);
            return new ContextValidationResult { IsValid = false, Errors = new List<string> { ex.Message }, Warnings = warnings };
        }
    }

    /// <summary>
    /// Gets communication statistics for monitoring
    /// </summary>
    public CommunicationStatistics GetCommunicationStatistics(string planId)
    {
        lock (_channelLock)
        {
            var planChannels = _communicationChannels.Values
                .Where(c => c.PlanId == planId)
                .ToList();

            var totalMessages = planChannels.Sum(c => c.Messages.Count);
            var sentMessages = planChannels.Sum(c => c.Messages.Count(m => m.Status == MessageStatus.Sent));
            var receivedMessages = planChannels.Sum(c => c.Messages.Count(m => m.Status == MessageStatus.Received));
            var activeChannels = planChannels.Count(c => c.Status == ChannelStatus.Active);

            return new CommunicationStatistics
            {
                PlanId = planId,
                TotalChannels = planChannels.Count,
                ActiveChannels = activeChannels,
                TotalMessages = totalMessages,
                SentMessages = sentMessages,
                ReceivedMessages = receivedMessages,
                AverageMessageSize = CalculateAverageMessageSize(planChannels),
                LastActivity = planChannels.Any() ? planChannels.Max(c => c.LastActivity) : DateTime.UtcNow
            };
        }
    }

    /// <summary>
    /// Cleans up old communication channels and messages
    /// </summary>
    public void CleanupOldChannels(TimeSpan maxAge)
    {
        lock (_channelLock)
        {
            var cutoffTime = DateTime.UtcNow.Subtract(maxAge);
            var oldChannels = _communicationChannels.Values
                .Where(c => c.LastActivity < cutoffTime)
                .ToList();

            foreach (var channel in oldChannels)
            {
                var channelKey = $"{channel.PlanId}_{channel.ChannelName}";
                _communicationChannels.Remove(channelKey);
                
                _logger.LogDebug("Cleaned up old communication channel {ChannelName} for plan {PlanId}", 
                    channel.ChannelName, channel.PlanId);
            }
        }
    }

    /// <summary>
    /// Broadcasts data to multiple steps in a channel
    /// </summary>
    public async Task<bool> BroadcastDataAsync(string planId, string channelName, string fromStepId, List<string> toStepIds, object data)
    {
        var successCount = 0;
        
        foreach (var toStepId in toStepIds)
        {
            var success = await SendDataAsync(planId, channelName, fromStepId, toStepId, data);
            if (success) successCount++;
        }

        _logger.LogDebug("Broadcasted data from step {FromStepId} to {SuccessCount}/{TotalCount} steps in channel {ChannelName}", 
            fromStepId, successCount, toStepIds.Count, channelName);

        return successCount == toStepIds.Count;
    }

    /// <summary>
    /// Gets pending messages for a step
    /// </summary>
    public List<StepMessage> GetPendingMessages(string planId, string stepId)
    {
        lock (_channelLock)
        {
            var pendingMessages = new List<StepMessage>();

            var relevantChannels = _communicationChannels.Values
                .Where(c => c.PlanId == planId && c.StepIds.Contains(stepId))
                .ToList();

            foreach (var channel in relevantChannels)
            {
                var messages = channel.Messages
                    .Where(m => m.ToStepId == stepId && m.Status == MessageStatus.Sent)
                    .ToList();

                pendingMessages.AddRange(messages);
            }

            return pendingMessages;
        }
    }

    /// <summary>
    /// Acknowledges receipt of a message
    /// </summary>
    public void AcknowledgeMessage(string planId, string channelName, string messageId)
    {
        lock (_channelLock)
        {
            var channelKey = $"{planId}_{channelName}";
            
            if (_communicationChannels.TryGetValue(channelKey, out var channel))
            {
                var message = channel.Messages.FirstOrDefault(m => m.Id == messageId);
                if (message != null)
                {
                    message.Status = MessageStatus.Acknowledged;
                    message.AcknowledgedAt = DateTime.UtcNow;
                    
                    _logger.LogDebug("Acknowledged message {MessageId} in channel {ChannelName}", messageId, channelName);
                }
            }
        }
    }

    private bool ValidateDataType(Type actualType, string expectedType)
    {
        return expectedType.ToLowerInvariant() switch
        {
            "string" => actualType == typeof(string),
            "int" => actualType == typeof(int),
            "double" => actualType == typeof(double),
            "bool" => actualType == typeof(bool),
            "datetime" => actualType == typeof(DateTime),
            "object" => true,
            _ => actualType.Name.Equals(expectedType, StringComparison.OrdinalIgnoreCase)
        };
    }

    private int GetDataSize(object data)
    {
        if (data is string stringData)
        {
            return stringData.Length;
        }
        
        if (data is System.Collections.ICollection collection)
        {
            return collection.Count;
        }
        
        try
        {
            var json = JsonSerializer.Serialize(data);
            return json.Length;
        }
        catch
        {
            return 0;
        }
    }

    private async Task<ContextValidationResult> ValidateContentWithAiAsync(string content, string stepId)
    {
        var errors = new List<string>();
        var warnings = new List<string>();

        try
        {
            var aiPrompt = $@"
Validate the following content for step '{stepId}':

Content: {content}

Check for:
1. Appropriate content and format
2. Sensible values and ranges
3. Potential issues or inconsistencies
4. Security concerns

Respond with 'VALID' if the content is appropriate, or describe any issues found.
";

            var response = await _azureAiService.SendPromptAsync(aiPrompt);
            
            if (!response.Trim().Equals("VALID", StringComparison.OrdinalIgnoreCase))
            {
                warnings.Add($"AI validation warning: {response.Trim()}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error performing AI content validation for step {StepId}", stepId);
        }

        return new ContextValidationResult { IsValid = errors.Count == 0, Errors = errors, Warnings = warnings };
    }

    private double CalculateAverageMessageSize(List<StepCommunicationChannel> channels)
    {
        var allMessages = channels.SelectMany(c => c.Messages).ToList();
        if (!allMessages.Any()) return 0;

        var totalSize = allMessages.Sum(m => GetDataSize(m.Data));
        return (double)totalSize / allMessages.Count;
    }
}

public class StepCommunicationChannel
{
    public string PlanId { get; set; } = string.Empty;
    public string ChannelName { get; set; } = string.Empty;
    public List<string> StepIds { get; set; } = new();
    public List<StepMessage> Messages { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime LastActivity { get; set; }
    public ChannelStatus Status { get; set; }
}

public class StepMessage
{
    public string Id { get; set; } = string.Empty;
    public string FromStepId { get; set; } = string.Empty;
    public string ToStepId { get; set; } = string.Empty;
    public object Data { get; set; } = new();
    public DateTime Timestamp { get; set; }
    public DateTime? ReceivedAt { get; set; }
    public DateTime? AcknowledgedAt { get; set; }
    public MessageStatus Status { get; set; }
}

public enum ChannelStatus
{
    Active,
    Inactive,
    Closed
}

public enum MessageStatus
{
    Sent,
    Received,
    Acknowledged,
    Failed
}

public class CommunicationStatistics
{
    public string PlanId { get; set; } = string.Empty;
    public int TotalChannels { get; set; }
    public int ActiveChannels { get; set; }
    public int TotalMessages { get; set; }
    public int SentMessages { get; set; }
    public int ReceivedMessages { get; set; }
    public double AverageMessageSize { get; set; }
    public DateTime LastActivity { get; set; }
} 