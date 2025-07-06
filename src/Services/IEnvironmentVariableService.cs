namespace McpCli.Services;

public interface IEnvironmentVariableService
{
    /// <summary>
    /// Resolves environment variable references in a string
    /// Supports formats: ${VAR_NAME}, $VAR_NAME, %VAR_NAME%
    /// </summary>
    string ResolveEnvironmentVariables(string input);
    
    /// <summary>
    /// Gets an environment variable value with optional default
    /// </summary>
    string? GetEnvironmentVariable(string name, string? defaultValue = null);
    
    /// <summary>
    /// Validates that all required environment variables are set
    /// </summary>
    bool ValidateRequiredEnvironmentVariables(IEnumerable<string> requiredVariables, out List<string> missingVariables);
    
    /// <summary>
    /// Resolves environment variables in a configuration object recursively
    /// </summary>
    T ResolveEnvironmentVariablesInObject<T>(T obj) where T : class;
    
    /// <summary>
    /// Checks if a string contains environment variable references
    /// </summary>
    bool ContainsEnvironmentVariables(string input);
    
    /// <summary>
    /// Validates that a secret field only contains environment variable references
    /// </summary>
    bool ValidateSecretField(string fieldName, string? value, out string errorMessage);
    
    /// <summary>
    /// Validates that all secret fields in a configuration only contain environment variable references
    /// </summary>
    bool ValidateSecretFields(object config, out List<string> errors);
} 