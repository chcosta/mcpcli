using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly ILogger<ConfigurationService> _logger;
    private readonly IEnvironmentVariableService _environmentVariableService;
    private readonly string _configPath;
    private McpCliConfig? _cachedConfig;

    public ConfigurationService(ILogger<ConfigurationService> logger, IEnvironmentVariableService environmentVariableService)
    {
        _logger = logger;
        _environmentVariableService = environmentVariableService;
        _configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".mcpcli", "config.json");
    }

    public async Task<McpCliConfig> LoadConfigurationAsync()
    {
        if (_cachedConfig != null)
            return _cachedConfig;

        try
        {
            if (!File.Exists(_configPath))
            {
                await InitializeDefaultConfigurationAsync();
            }

            var json = await File.ReadAllTextAsync(_configPath);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            _cachedConfig = JsonSerializer.Deserialize<McpCliConfig>(json, options) ?? new McpCliConfig();
            
            // Resolve environment variables in the configuration
            _environmentVariableService.ResolveEnvironmentVariablesInObject(_cachedConfig);
            
            return _cachedConfig;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading configuration from {ConfigPath}", _configPath);
            return new McpCliConfig();
        }
    }

    public async Task SaveConfigurationAsync(McpCliConfig config)
    {
        try
        {
            var directory = Path.GetDirectoryName(_configPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(config, options);
            await File.WriteAllTextAsync(_configPath, json);
            _cachedConfig = config;

            _logger.LogInformation("Configuration saved to {ConfigPath}", _configPath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving configuration to {ConfigPath}", _configPath);
            throw;
        }
    }

    public async Task<bool> IsConfigurationValidAsync()
    {
        try
        {
            var config = await LoadConfigurationAsync();
            
            // Check if Azure AI configuration is valid
            var hasAzureAi = !string.IsNullOrEmpty(config.AzureAi.Endpoint) && 
                           (!string.IsNullOrEmpty(config.AzureAi.ApiKey) || config.AzureAi.UseManagedIdentity);
            
            // Check if Azure DevOps configuration is valid
            var hasAzureDevOps = !string.IsNullOrEmpty(config.AzureDevOps.Organization) && 
                               (!string.IsNullOrEmpty(config.AzureDevOps.PersonalAccessToken) || config.AzureDevOps.UseManagedIdentity);
            
            return hasAzureAi && hasAzureDevOps;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating configuration");
            return false;
        }
    }

    public async Task<string> GetConfigurationPathAsync()
    {
        return await Task.FromResult(_configPath);
    }

    public async Task InitializeDefaultConfigurationAsync()
    {
        var defaultConfig = new McpCliConfig
        {
            AzureAi = new AzureAiConfig
            {
                Endpoint = "",
                ApiKey = "",
                DeploymentName = "",
                ModelName = "gpt-4",
                UseManagedIdentity = false
            },
            AzureDevOps = new AzureDevOpsConfig
            {
                Organization = "",
                PersonalAccessToken = "",
                DefaultProject = "",
                UseManagedIdentity = false
            },
            Mcp = new McpConfig
            {
                WorkingDirectory = "./mcp-servers",
                DefaultPort = 3000,
                TimeoutSeconds = 30,
                AutoCleanup = true
            }
        };

        await SaveConfigurationAsync(defaultConfig);
    }

    public async Task<T> GetConfigurationValueAsync<T>(string key)
    {
        var config = await LoadConfigurationAsync();
        var value = GetValueByPath(config, key);
        
        if (value is T typedValue)
            return typedValue;
        
        if (value != null && typeof(T) == typeof(string))
            return (T)(object)value.ToString()!;
        
        return default(T)!;
    }

    public async Task SetConfigurationValueAsync<T>(string key, T value)
    {
        var config = await LoadConfigurationAsync();
        SetValueByPath(config, key, value);
        await SaveConfigurationAsync(config);
        _cachedConfig = null; // Clear cache to force reload
    }

    private object? GetValueByPath(object obj, string path)
    {
        var parts = path.Split('.');
        object? current = obj;
        
        foreach (var part in parts)
        {
            if (current == null) return null;
            
            var property = current.GetType().GetProperty(part, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return null;
            
            current = property.GetValue(current);
        }
        
        return current;
    }

    private void SetValueByPath(object obj, string path, object? value)
    {
        var parts = path.Split('.');
        object current = obj;
        
        for (int i = 0; i < parts.Length - 1; i++)
        {
            var property = current.GetType().GetProperty(parts[i], BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) 
                throw new ArgumentException($"Property '{parts[i]}' not found in configuration");
            
            current = property.GetValue(current) ?? throw new ArgumentException($"Property '{parts[i]}' is null");
        }
        
        var finalProperty = current.GetType().GetProperty(parts[^1], BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        if (finalProperty == null)
            throw new ArgumentException($"Property '{parts[^1]}' not found in configuration");
        
        // Convert value to the correct type if needed
        var convertedValue = ConvertValue(value, finalProperty.PropertyType);
        finalProperty.SetValue(current, convertedValue);
    }

    private object? ConvertValue(object? value, Type targetType)
    {
        if (value == null) return null;
        
        // If types match, return as-is
        if (targetType.IsAssignableFrom(value.GetType()))
            return value;
        
        // Handle string to boolean conversion
        if (targetType == typeof(bool) && value is string stringValue)
        {
            if (bool.TryParse(stringValue, out bool boolResult))
                return boolResult;
            throw new ArgumentException($"Cannot convert '{stringValue}' to boolean");
        }
        
        // Handle string to int conversion
        if (targetType == typeof(int) && value is string intStringValue)
        {
            if (int.TryParse(intStringValue, out int intResult))
                return intResult;
            throw new ArgumentException($"Cannot convert '{intStringValue}' to integer");
        }
        
        // Handle other conversions using Convert.ChangeType
        try
        {
            return Convert.ChangeType(value, targetType);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Cannot convert '{value}' to {targetType.Name}", ex);
        }
    }
} 