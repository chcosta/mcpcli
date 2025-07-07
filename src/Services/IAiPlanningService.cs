using McpCli.Models;

namespace McpCli.Services;

public interface IAiPlanningService
{
    /// <summary>
    /// Processes a user prompt using AI planning and execution
    /// </summary>
    /// <param name="serverInfo">MCP server information</param>
    /// <param name="userPrompt">User's original prompt</param>
    /// <param name="config">Markdown configuration</param>
    /// <returns>Final AI response</returns>
    Task<string> ProcessPromptWithAIAsync(McpServerInfo serverInfo, string userPrompt, MarkdownConfig config);

    /// <summary>
    /// Processes a user prompt using AI planning and execution with execution summary tracking
    /// </summary>
    /// <param name="serverInfo">MCP server information</param>
    /// <param name="userPrompt">User's original prompt</param>
    /// <param name="config">Markdown configuration</param>
    /// <param name="executionSummary">Execution summary to track tool usage</param>
    /// <returns>Final AI response</returns>
    Task<string> ProcessPromptWithAIAsync(McpServerInfo serverInfo, string userPrompt, MarkdownConfig config, ExecutionSummary executionSummary);

    /// <summary>
    /// Executes an AI-generated tool plan
    /// </summary>
    /// <param name="serverInfo">MCP server information</param>
    /// <param name="aiResponse">AI-generated execution plan</param>
    /// <param name="config">Markdown configuration containing tool defaults</param>
    /// <returns>Combined tool execution results</returns>
    Task<string> ExecuteAIToolPlanAsync(McpServerInfo serverInfo, string aiResponse, MarkdownConfig config);

    /// <summary>
    /// Executes a tool with pattern recognition for special parameters
    /// </summary>
    /// <param name="serverInfo">MCP server information</param>
    /// <param name="toolName">Name of the tool to execute</param>
    /// <param name="parameters">Tool parameters</param>
    /// <param name="config">Markdown configuration containing tool defaults</param>
    /// <returns>Tool execution result</returns>
    Task<string> ExecuteToolWithPatternRecognitionAsync(McpServerInfo serverInfo, string toolName, Dictionary<string, object> parameters, MarkdownConfig config);

    /// <summary>
    /// Gets the AI planning prompt for a user request
    /// </summary>
    /// <param name="config">Markdown configuration</param>
    /// <param name="userPrompt">User's original prompt</param>
    /// <param name="availableTools">Available tools from MCP server</param>
    /// <returns>AI planning prompt</returns>
    Task<string> GetAiPlanningPromptAsync(MarkdownConfig config, string userPrompt, string availableTools);
} 