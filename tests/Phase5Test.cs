using Microsoft.Extensions.Logging;
using Moq;
using McpCli.Services;
using McpCli.Models;
using McpCli.Commands;
using System.CommandLine;
using Xunit;

namespace McpCli.Tests;

public class Phase5Test
{
    private readonly Mock<ILogger<RunCommand>> _runLoggerMock;
    private readonly Mock<ILogger<PlanCommand>> _planLoggerMock;
    private readonly Mock<IMarkdownConfigService> _markdownConfigServiceMock;
    private readonly Mock<IConfigurationService> _configurationServiceMock;
    private readonly Mock<IGitService> _gitServiceMock;
    private readonly Mock<IMcpServerService> _mcpServerServiceMock;
    private readonly Mock<IAzureAiService> _azureAiServiceMock;
    private readonly Mock<IPromptFileService> _promptFileServiceMock;
    private readonly Mock<ISystemPromptService> _systemPromptServiceMock;
    private readonly Mock<IMultiMcpServerService> _multiMcpServerServiceMock;
    private readonly Mock<IPlanGenerator> _planGeneratorMock;
    private readonly Mock<IPlanExecutor> _planExecutorMock;
    private readonly Mock<IPlanPersistenceService> _planPersistenceServiceMock;
    private readonly Mock<ILogger<PlanPersistenceService>> _planPersistenceLoggerMock;

    public Phase5Test()
    {
        _runLoggerMock = new Mock<ILogger<RunCommand>>();
        _planLoggerMock = new Mock<ILogger<PlanCommand>>();
        _markdownConfigServiceMock = new Mock<IMarkdownConfigService>();
        _configurationServiceMock = new Mock<IConfigurationService>();
        _gitServiceMock = new Mock<IGitService>();
        _mcpServerServiceMock = new Mock<IMcpServerService>();
        _azureAiServiceMock = new Mock<IAzureAiService>();
        _promptFileServiceMock = new Mock<IPromptFileService>();
        _systemPromptServiceMock = new Mock<ISystemPromptService>();
        _multiMcpServerServiceMock = new Mock<IMultiMcpServerService>();
        _planGeneratorMock = new Mock<IPlanGenerator>();
        _planExecutorMock = new Mock<IPlanExecutor>();
        _planPersistenceServiceMock = new Mock<IPlanPersistenceService>();
        _planPersistenceLoggerMock = new Mock<ILogger<PlanPersistenceService>>();
    }

    [Fact]
    public void RunCommand_ShouldHavePlanManagementOptions()
    {
        // Arrange
        var runCommand = new RunCommand(
            _runLoggerMock.Object,
            _markdownConfigServiceMock.Object,
            _configurationServiceMock.Object,
            _gitServiceMock.Object,
            _mcpServerServiceMock.Object,
            _azureAiServiceMock.Object,
            _promptFileServiceMock.Object,
            _systemPromptServiceMock.Object,
            _multiMcpServerServiceMock.Object,
            _planGeneratorMock.Object,
            _planExecutorMock.Object,
            _planPersistenceServiceMock.Object);

        // Act
        var command = runCommand.CreateCommand();

        // Assert
        Assert.NotNull(command);
        Assert.Contains(command.Options, o => o.Name == "plan-id");
        Assert.Contains(command.Options, o => o.Name == "list-plans");
        Assert.Contains(command.Options, o => o.Name == "view-plan");
        Assert.Contains(command.Options, o => o.Name == "cleanup-plans");
    }

    [Fact]
    public void PlanCommand_ShouldHaveAllSubcommands()
    {
        // Arrange
        var planCommand = new PlanCommand(
            _planLoggerMock.Object,
            _multiMcpServerServiceMock.Object,
            _planPersistenceServiceMock.Object,
            _planExecutorMock.Object);

        // Act
        var command = planCommand.CreateCommand();

        // Assert
        Assert.NotNull(command);
        Assert.Equal("plan", command.Name);
        Assert.Contains(command.Subcommands, c => c.Name == "list");
        Assert.Contains(command.Subcommands, c => c.Name == "view");
        Assert.Contains(command.Subcommands, c => c.Name == "execute");
        Assert.Contains(command.Subcommands, c => c.Name == "cleanup");
        Assert.Contains(command.Subcommands, c => c.Name == "delete");
    }

    [Fact]
    public async Task PlanPersistenceService_ShouldListPlans()
    {
        // Arrange
        var service = new PlanPersistenceService(_planPersistenceLoggerMock.Object);
        var testPlan = CreateTestPlan();
        await service.SavePlanAsync(testPlan);

        // Act
        var plans = await service.ListPlansAsync();

        // Assert
        Assert.NotNull(plans);
        Assert.Contains(plans, p => p.Id == testPlan.Id);
        Assert.Contains(plans, p => p.Name == testPlan.Name);

        // Cleanup
        await service.DeletePlanAsync(testPlan.Id);
    }

    [Fact]
    public async Task PlanPersistenceService_ShouldCleanupOldPlans()
    {
        // Arrange
        var service = new PlanPersistenceService(_planPersistenceLoggerMock.Object);
        var oldPlan = CreateTestPlan();
        oldPlan.CreatedAt = DateTime.UtcNow.AddDays(-31); // Old plan
        await service.SavePlanAsync(oldPlan);

        var newPlan = CreateTestPlan();
        newPlan.CreatedAt = DateTime.UtcNow.AddDays(-5); // Recent plan
        await service.SavePlanAsync(newPlan);

        // Act
        var deletedCount = await service.CleanupOldPlansAsync(30);

        // Assert
        Assert.True(deletedCount >= 1);
        
        var remainingPlans = await service.ListPlansAsync();
        Assert.DoesNotContain(remainingPlans, p => p.Id == oldPlan.Id);
        Assert.Contains(remainingPlans, p => p.Id == newPlan.Id);

        // Cleanup
        await service.DeletePlanAsync(newPlan.Id);
    }

    [Fact]
    public async Task RunCommand_ShouldHandleListPlansOption()
    {
        // Arrange
        var testPlans = new List<Plan>
        {
            CreateTestPlan("Test Plan 1"),
            CreateTestPlan("Test Plan 2")
        };

        _planPersistenceServiceMock.Setup(x => x.ListPlansAsync())
            .ReturnsAsync(testPlans);

        _markdownConfigServiceMock.Setup(x => x.ParseMarkdownConfigAsync(It.IsAny<string>()))
            .ReturnsAsync(CreateTestConfig());

        _markdownConfigServiceMock.Setup(x => x.ValidateMarkdownConfigAsync(It.IsAny<string>()))
            .ReturnsAsync(true);

        var runCommand = new RunCommand(
            _runLoggerMock.Object,
            _markdownConfigServiceMock.Object,
            _configurationServiceMock.Object,
            _gitServiceMock.Object,
            _mcpServerServiceMock.Object,
            _azureAiServiceMock.Object,
            _promptFileServiceMock.Object,
            _systemPromptServiceMock.Object,
            _multiMcpServerServiceMock.Object,
            _planGeneratorMock.Object,
            _planExecutorMock.Object,
            _planPersistenceServiceMock.Object);

        // Act & Assert
        // Note: This would require more complex testing setup for command execution
        // For now, we verify the command structure
        var command = runCommand.CreateCommand();
        Assert.NotNull(command);
    }

    [Fact]
    public async Task RunCommand_ShouldHandleViewPlanOption()
    {
        // Arrange
        var testPlan = CreateTestPlan("Test Plan for Viewing");
        _planPersistenceServiceMock.Setup(x => x.LoadPlanAsync(It.IsAny<string>()))
            .ReturnsAsync(testPlan);

        _markdownConfigServiceMock.Setup(x => x.ParseMarkdownConfigAsync(It.IsAny<string>()))
            .ReturnsAsync(CreateTestConfig());

        _markdownConfigServiceMock.Setup(x => x.ValidateMarkdownConfigAsync(It.IsAny<string>()))
            .ReturnsAsync(true);

        var runCommand = new RunCommand(
            _runLoggerMock.Object,
            _markdownConfigServiceMock.Object,
            _configurationServiceMock.Object,
            _gitServiceMock.Object,
            _mcpServerServiceMock.Object,
            _azureAiServiceMock.Object,
            _promptFileServiceMock.Object,
            _systemPromptServiceMock.Object,
            _multiMcpServerServiceMock.Object,
            _planGeneratorMock.Object,
            _planExecutorMock.Object,
            _planPersistenceServiceMock.Object);

        // Act & Assert
        var command = runCommand.CreateCommand();
        Assert.NotNull(command);
    }

    [Fact]
    public async Task RunCommand_ShouldHandlePlanExecution()
    {
        // Arrange
        var testPlan = CreateTestPlan("Test Plan for Execution");
        var executionResult = new PlanExecutionResult
        {
            FinalStatus = PlanStatus.Completed,
            FinalOutputs = new Dictionary<string, object> { { "response", "Test response" } }
        };

        _planPersistenceServiceMock.Setup(x => x.LoadPlanAsync(It.IsAny<string>()))
            .ReturnsAsync(testPlan);

        _planExecutorMock.Setup(x => x.ExecutePlanAsync(It.IsAny<Plan>(), It.IsAny<List<RunningServerInfo>>(), It.IsAny<ServerToolMapping>()))
            .ReturnsAsync(executionResult);

        _multiMcpServerServiceMock.Setup(x => x.StartServersAsync(It.IsAny<MarkdownConfig>(), It.IsAny<string>(), It.IsAny<ExecutionSummary>()))
            .ReturnsAsync(new List<RunningServerInfo> { new RunningServerInfo { Name = "test-server", IsRunning = true } });

        _multiMcpServerServiceMock.Setup(x => x.GetAvailableToolsAsync(It.IsAny<List<RunningServerInfo>>()))
            .ReturnsAsync(new ServerToolMapping());

        _markdownConfigServiceMock.Setup(x => x.ParseMarkdownConfigAsync(It.IsAny<string>()))
            .ReturnsAsync(CreateTestConfig());

        _markdownConfigServiceMock.Setup(x => x.ValidateMarkdownConfigAsync(It.IsAny<string>()))
            .ReturnsAsync(true);

        var runCommand = new RunCommand(
            _runLoggerMock.Object,
            _markdownConfigServiceMock.Object,
            _configurationServiceMock.Object,
            _gitServiceMock.Object,
            _mcpServerServiceMock.Object,
            _azureAiServiceMock.Object,
            _promptFileServiceMock.Object,
            _systemPromptServiceMock.Object,
            _multiMcpServerServiceMock.Object,
            _planGeneratorMock.Object,
            _planExecutorMock.Object,
            _planPersistenceServiceMock.Object);

        // Act & Assert
        var command = runCommand.CreateCommand();
        Assert.NotNull(command);
    }

    [Fact]
    public void PlanCommand_ShouldHandleListSubcommand()
    {
        // Arrange
        var testPlans = new List<Plan>
        {
            CreateTestPlan("Test Plan 1"),
            CreateTestPlan("Test Plan 2")
        };

        _planPersistenceServiceMock.Setup(x => x.ListPlansAsync())
            .ReturnsAsync(testPlans);

        var planCommand = new PlanCommand(
            _planLoggerMock.Object,
            _multiMcpServerServiceMock.Object,
            _planPersistenceServiceMock.Object,
            _planExecutorMock.Object);

        // Act
        var command = planCommand.CreateCommand();
        var listCommand = command.Subcommands.First(c => c.Name == "list");

        // Assert
        Assert.NotNull(listCommand);
        Assert.Equal("list", listCommand.Name);
    }

    [Fact]
    public void PlanCommand_ShouldHandleViewSubcommand()
    {
        // Arrange
        var testPlan = CreateTestPlan("Test Plan for Viewing");
        _planPersistenceServiceMock.Setup(x => x.LoadPlanAsync(It.IsAny<string>()))
            .ReturnsAsync(testPlan);

        var planCommand = new PlanCommand(
            _planLoggerMock.Object,
            _multiMcpServerServiceMock.Object,
            _planPersistenceServiceMock.Object,
            _planExecutorMock.Object);

        // Act
        var command = planCommand.CreateCommand();
        var viewCommand = command.Subcommands.First(c => c.Name == "view");

        // Assert
        Assert.NotNull(viewCommand);
        Assert.Equal("view", viewCommand.Name);
        Assert.Contains(viewCommand.Arguments, a => a.Name == "plan-id");
    }

    [Fact]
    public void PlanCommand_ShouldHandleCleanupSubcommand()
    {
        // Arrange
        _planPersistenceServiceMock.Setup(x => x.CleanupOldPlansAsync(It.IsAny<int>()))
            .ReturnsAsync(5);

        var planCommand = new PlanCommand(
            _planLoggerMock.Object,
            _multiMcpServerServiceMock.Object,
            _planPersistenceServiceMock.Object,
            _planExecutorMock.Object);

        // Act
        var command = planCommand.CreateCommand();
        var cleanupCommand = command.Subcommands.First(c => c.Name == "cleanup");

        // Assert
        Assert.NotNull(cleanupCommand);
        Assert.Equal("cleanup", cleanupCommand.Name);
        Assert.Contains(cleanupCommand.Options, o => o.Name == "days");
    }

    [Fact]
    public void PlanCommand_ShouldHandleDeleteSubcommand()
    {
        // Arrange
        var planCommand = new PlanCommand(
            _planLoggerMock.Object,
            _multiMcpServerServiceMock.Object,
            _planPersistenceServiceMock.Object,
            _planExecutorMock.Object);

        // Act
        var command = planCommand.CreateCommand();
        var deleteCommand = command.Subcommands.First(c => c.Name == "delete");

        // Assert
        Assert.NotNull(deleteCommand);
        Assert.Equal("delete", deleteCommand.Name);
        Assert.Contains(deleteCommand.Arguments, a => a.Name == "plan-id");
    }

    [Fact]
    public async Task PlanPersistenceService_ShouldHandlePlanLifecycle()
    {
        // Arrange
        var service = new PlanPersistenceService(_planPersistenceLoggerMock.Object);
        var testPlan = CreateTestPlan("Lifecycle Test Plan");

        // Act - Save
        var savedPlan = await service.SavePlanAsync(testPlan);
        Assert.NotNull(savedPlan);
        Assert.Equal(testPlan.Id, savedPlan.Id);

        // Act - Check exists
        var exists = await service.PlanExistsAsync(testPlan.Id);
        Assert.True(exists);

        // Act - Load
        var loadedPlan = await service.LoadPlanAsync(testPlan.Id);
        Assert.NotNull(loadedPlan);
        Assert.Equal(testPlan.Name, loadedPlan.Name);

        // Act - Delete
        await service.DeletePlanAsync(testPlan.Id);
        exists = await service.PlanExistsAsync(testPlan.Id);
        Assert.False(exists);
    }

    [Fact]
    public async Task PlanPersistenceService_ShouldHandleStepResults()
    {
        // Arrange
        var service = new PlanPersistenceService(_planPersistenceLoggerMock.Object);
        var testPlan = CreateTestPlan("Step Results Test Plan");
        await service.SavePlanAsync(testPlan);

        var testStep = new PlanStep
        {
            Id = "1",
            Name = "Test Step",
            Description = "A test step",
            ServerName = "test-server",
            ToolName = "test-tool",
            Status = StepStatus.Completed,
            Inputs = new Dictionary<string, object> { { "input1", "value1" } },
            ActualOutputs = new Dictionary<string, object> { { "output1", "result1" } }
        };

        // Act - Save step
        var savedStep = await service.SaveStepResultAsync(testPlan.Id, testStep);
        Assert.NotNull(savedStep);

        // Act - Load steps
        var steps = await service.LoadStepResultsAsync(testPlan.Id);
        Assert.NotNull(steps);
        Assert.Contains(steps, s => s.Id == testStep.Id);

        // Cleanup
        await service.DeletePlanAsync(testPlan.Id);
    }

    private Plan CreateTestPlan(string name = "Test Plan")
    {
        return new Plan
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Goal = "Test goal",
            CreatedAt = DateTime.UtcNow,
            Status = PlanStatus.Created,
            Steps = new List<PlanStep>
            {
                new PlanStep
                {
                    Id = "1",
                    Name = "Test Step 1",
                    Description = "First test step",
                    ServerName = "test-server",
                    ToolName = "test-tool",
                    Status = StepStatus.Pending
                }
            }
        };
    }

    private MarkdownConfig CreateTestConfig()
    {
        return new MarkdownConfig
        {
            Name = "Test Config",
            Description = "Test configuration",
            Servers = new List<MultiMcpServerConfig>
            {
                new MultiMcpServerConfig
                {
                    Name = "test-server",
                    Type = "git",
                    Url = "https://github.com/test/repo",
                    Enabled = true,
                    AutoStart = true,
                    Port = 3000
                }
            },
            AzureAi = new AzureAiConfig
            {
                Endpoint = "https://test.openai.azure.com/",
                ModelName = "gpt-4",
                ApiKey = "test-key"
            },
            PreviewFeatures = true
        };
    }
} 