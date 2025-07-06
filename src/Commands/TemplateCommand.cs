using System.CommandLine;
using Microsoft.Extensions.Logging;
using McpCli.Services;

namespace McpCli.Commands;

public class TemplateCommand
{
    private readonly ILogger<TemplateCommand> _logger;
    private readonly IMarkdownConfigService _markdownConfigService;
    private readonly IConfigurationService _configurationService;

    public TemplateCommand(
        ILogger<TemplateCommand> logger,
        IMarkdownConfigService markdownConfigService,
        IConfigurationService configurationService)
    {
        _logger = logger;
        _markdownConfigService = markdownConfigService;
        _configurationService = configurationService;
    }

    public Command CreateCommand()
    {
        var nameOption = new Option<string>(
            name: "--name",
            description: "Name for the configuration template")
        {
            IsRequired = true
        };
        nameOption.AddAlias("-n");

        var descriptionOption = new Option<string>(
            name: "--description",
            description: "Description for the configuration template",
            getDefaultValue: () => "");
        descriptionOption.AddAlias("-d");

        var outputOption = new Option<string>(
            name: "--output",
            description: "Output file path for the template (default: <name>.md)");
        outputOption.AddAlias("-o");

        var useCurrentConfigOption = new Option<bool>(
            name: "--use-current-config",
            description: "Use current configuration values as template defaults (secrets will be replaced with placeholders)",
            getDefaultValue: () => false);
        useCurrentConfigOption.AddAlias("-c");

        var command = new Command("template", "Generate a Markdown configuration template")
        {
            nameOption,
            descriptionOption,
            outputOption,
            useCurrentConfigOption
        };

        command.SetHandler(async (name, description, output, useCurrentConfig) =>
        {
            await ExecuteAsync(name, description, output, useCurrentConfig);
        }, nameOption, descriptionOption, outputOption, useCurrentConfigOption);

        return command;
    }

    private async Task ExecuteAsync(string name, string description, string? output, bool useCurrentConfig)
    {
        try
        {
            _logger.LogInformation("Generating template for {Name}", name);

            string template;
            if (useCurrentConfig)
            {
                // Generate template using current configuration values
                template = await _markdownConfigService.GenerateTemplateFromConfigAsync(name, description, _configurationService);
            }
            else
            {
                // Generate template with default placeholder values
                template = await _markdownConfigService.GenerateTemplateAsync(name, description);
            }

            // Determine output file path
            var outputPath = output ?? $"{name.Replace(" ", "-").ToLower()}.md";

            // Write the template to file
            await File.WriteAllTextAsync(outputPath, template);

            Console.WriteLine($"Configuration template generated: {outputPath}");
            Console.WriteLine();
            if (useCurrentConfig)
            {
                Console.WriteLine("Template generated using current configuration values.");
                Console.WriteLine("Secret values have been replaced with placeholders - please update them:");
                Console.WriteLine("- Azure AI API Key");
                Console.WriteLine("- Azure DevOps Personal Access Token (if used)");
                Console.WriteLine();
            }
            Console.WriteLine("Next steps:");
            Console.WriteLine("1. Edit the generated file to update any placeholder values");
            Console.WriteLine("2. Update the repository URL to point to your MCP server");
            Console.WriteLine("3. Customize the MCP server settings as needed");
            Console.WriteLine("4. Add your default prompts in the code blocks");
            Console.WriteLine($"5. Run: mcpcli run --config \"{outputPath}\" --list-prompts");
            Console.WriteLine($"6. Execute: mcpcli run --config \"{outputPath}\" --prompt \"Your prompt here\"");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating template");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
} 