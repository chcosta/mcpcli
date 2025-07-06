using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class AzureAiService : IAzureAiService
{
    private readonly ILogger<AzureAiService> _logger;
    private OpenAIClient? _client;
    private AzureAiConfig? _config;

    public AzureAiService(ILogger<AzureAiService> logger)
    {
        _logger = logger;
    }

    public async Task<bool> TestConnectionAsync()
    {
        try
        {
            if (_client == null || _config == null)
            {
                _logger.LogWarning("Azure AI client not initialized");
                return false;
            }

            // Test the connection by making a simple request
            var chatOptions = new ChatCompletionsOptions
            {
                DeploymentName = _config.DeploymentName,
                Messages = { new ChatRequestSystemMessage("Test connection") },
                MaxTokens = 1
            };
            var response = await _client.GetChatCompletionsAsync(chatOptions);

            return response.Value != null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error testing Azure AI connection");
            return false;
        }
    }

    public async Task<string> SendPromptAsync(string prompt, CancellationToken cancellationToken = default)
    {
        try
        {
            if (_client == null || _config == null)
            {
                throw new InvalidOperationException("Azure AI client not initialized. Call UpdateConfiguration first.");
            }

            var chatOptions = new ChatCompletionsOptions
            {
                DeploymentName = _config.DeploymentName,
                Messages = { new ChatRequestUserMessage(prompt) },
                MaxTokens = 4000,
                Temperature = 0.7f
            };

            var response = await _client.GetChatCompletionsAsync(chatOptions, cancellationToken);
            
            if (response.Value?.Choices?.Count > 0)
            {
                return response.Value.Choices[0].Message.Content ?? "No response content";
            }

            return "No response received";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending prompt to Azure AI");
            throw;
        }
    }

    public async Task<string> SendPromptWithToolsAsync(string prompt, IEnumerable<McpToolCall> tools, CancellationToken cancellationToken = default)
    {
        try
        {
            if (_client == null || _config == null)
            {
                throw new InvalidOperationException("Azure AI client not initialized. Call UpdateConfiguration first.");
            }

            var chatOptions = new ChatCompletionsOptions
            {
                DeploymentName = _config.DeploymentName,
                Messages = { new ChatRequestUserMessage(prompt) },
                MaxTokens = 4000,
                Temperature = 0.7f
            };

            // Add tool definitions if provided
            foreach (var tool in tools)
            {
                // Note: This is a simplified implementation
                // Full MCP tool integration would require more complex mapping
                var toolDefinition = new ChatCompletionsFunctionToolDefinition
                {
                    Name = tool.Name,
                    Description = $"MCP tool: {tool.Name}",
                    Parameters = BinaryData.FromObjectAsJson(tool.Arguments ?? new Dictionary<string, object>())
                };
                chatOptions.Tools.Add(toolDefinition);
            }

            var response = await _client.GetChatCompletionsAsync(chatOptions, cancellationToken);
            
            if (response.Value?.Choices?.Count > 0)
            {
                return response.Value.Choices[0].Message.Content ?? "No response content";
            }

            return "No response received";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending prompt with tools to Azure AI");
            throw;
        }
    }

    public void UpdateConfiguration(AzureAiConfig config)
    {
        try
        {
            _config = config;

            if (string.IsNullOrEmpty(config.Endpoint))
            {
                _logger.LogWarning("Azure AI endpoint not configured");
                return;
            }

            if (config.UseManagedIdentity)
            {
                _logger.LogInformation("Using managed identity for Azure AI authentication");
                _client = new OpenAIClient(new Uri(config.Endpoint), new DefaultAzureCredential());
            }
            else if (!string.IsNullOrEmpty(config.ApiKey))
            {
                _logger.LogInformation("Using API key for Azure AI authentication");
                _client = new OpenAIClient(new Uri(config.Endpoint), new Azure.AzureKeyCredential(config.ApiKey));
            }
            else
            {
                _logger.LogWarning("No authentication method configured for Azure AI");
                return;
            }

            _logger.LogInformation("Azure AI client initialized successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating Azure AI configuration");
            throw;
        }
    }
} 