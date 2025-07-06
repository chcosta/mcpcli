using McpCli.Models;

namespace McpCli.Services;

public interface IConfigurationService
{
    Task<McpCliConfig> LoadConfigurationAsync();
    Task SaveConfigurationAsync(McpCliConfig config);
    Task<bool> IsConfigurationValidAsync();
    Task<string> GetConfigurationPathAsync();
    Task InitializeDefaultConfigurationAsync();
    Task<T> GetConfigurationValueAsync<T>(string key);
    Task SetConfigurationValueAsync<T>(string key, T value);
} 