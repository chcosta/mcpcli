using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using McpCli.Commands;
using McpCli.Services;

namespace McpCli;

class Program
{
    static async Task<int> Main(string[] args)
    {
        // Set up dependency injection
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        // Create root command
        var rootCommand = new RootCommand("MCP CLI - Connect to Azure AI Foundry models via MCP servers")
        {
            Name = "mcpcli"
        };

        // Add commands
        var connectCommand = serviceProvider.GetRequiredService<ConnectCommand>();
        var configCommand = serviceProvider.GetRequiredService<ConfigCommand>();
        var listCommand = serviceProvider.GetRequiredService<ListCommand>();
        var stopCommand = serviceProvider.GetRequiredService<StopCommand>();
        var runCommand = serviceProvider.GetRequiredService<RunCommand>();
        var templateCommand = serviceProvider.GetRequiredService<TemplateCommand>();

        rootCommand.AddCommand(connectCommand.CreateCommand());
        rootCommand.AddCommand(configCommand.CreateCommand());
        rootCommand.AddCommand(listCommand.CreateCommand());
        rootCommand.AddCommand(stopCommand.CreateCommand());
        rootCommand.AddCommand(runCommand.CreateCommand());
        rootCommand.AddCommand(templateCommand.CreateCommand());

        // Execute the command
        try
        {
            return await rootCommand.InvokeAsync(args);
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An unexpected error occurred");
            Console.WriteLine($"Error: {ex.Message}");
            return 1;
        }
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        // Logging
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information);
        });

        // HTTP Client
        services.AddHttpClient();

        // Services - we'll implement these next
        services.AddScoped<IConfigurationService, ConfigurationService>();
        services.AddScoped<IAzureAiService, AzureAiService>();
        services.AddScoped<IGitService, GitService>();
        services.AddScoped<IMcpServerService, McpServerService>();
        services.AddScoped<IMarkdownConfigService, MarkdownConfigService>();
        services.AddScoped<IPromptFileService, PromptFileService>();
        services.AddScoped<ISystemPromptService, SystemPromptService>();
        services.AddScoped<IEnvironmentVariableService, EnvironmentVariableService>();
        services.AddScoped<IAiPlanningService, AiPlanningService>();

        // Commands
        services.AddScoped<ConnectCommand>();
        services.AddScoped<ConfigCommand>();
        services.AddScoped<ListCommand>();
        services.AddScoped<StopCommand>();
        services.AddScoped<RunCommand>();
        services.AddScoped<TemplateCommand>();
    }
}
