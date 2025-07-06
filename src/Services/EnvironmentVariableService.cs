using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using McpCli.Models;

namespace McpCli.Services;

public class EnvironmentVariableService : IEnvironmentVariableService
{
    private readonly ILogger<EnvironmentVariableService> _logger;
    
    // Define which fields are considered secrets and must use environment variables
    private static readonly HashSet<string> SecretFields = new(StringComparer.OrdinalIgnoreCase)
    {
        "ApiKey",
        "PersonalAccessToken",
        "Password",
        "Secret",
        "Token",
        "Key"
    };

    public EnvironmentVariableService(ILogger<EnvironmentVariableService> logger)
    {
        _logger = logger;
    }

    public string ResolveEnvironmentVariables(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var result = input;

        // Support multiple environment variable formats:
        // ${VAR_NAME} - Unix/Linux style
        // $VAR_NAME - Simple Unix style  
        // %VAR_NAME% - Windows style
        // ${VAR_NAME:default_value} - With default value

        var patterns = new[]
        {
            // ${VAR_NAME:default} or ${VAR_NAME}
            new { Pattern = @"\$\{([A-Z_][A-Z0-9_]*?)(?::([^}]*))?\}", Format = "Unix with braces" },
            // %VAR_NAME%
            new { Pattern = @"%([A-Z_][A-Z0-9_]*)%", Format = "Windows" },
            // $VAR_NAME (but not followed by { to avoid conflicts)
            new { Pattern = @"\$([A-Z_][A-Z0-9_]*)(?![{])", Format = "Simple Unix" }
        };

        foreach (var patternInfo in patterns)
        {
            var regex = new Regex(patternInfo.Pattern, RegexOptions.IgnoreCase);
            result = regex.Replace(result, match =>
            {
                var variableName = match.Groups[1].Value;
                var defaultValue = match.Groups.Count > 2 ? match.Groups[2].Value : null;
                
                var envValue = GetEnvironmentVariable(variableName, defaultValue);
                
                if (envValue != null)
                {
                    _logger.LogDebug("Resolved environment variable {VariableName} using {Format} format", 
                        variableName, patternInfo.Format);
                    return envValue;
                }
                else
                {
                    _logger.LogWarning("Environment variable {VariableName} not found and no default provided", variableName);
                    return match.Value; // Return original if not found
                }
            });
        }

        return result;
    }

    public string? GetEnvironmentVariable(string name, string? defaultValue = null)
    {
        var value = Environment.GetEnvironmentVariable(name);
        
        if (value != null)
        {
            _logger.LogDebug("Found environment variable {VariableName}", name);
            return value;
        }
        
        if (defaultValue != null)
        {
            _logger.LogDebug("Using default value for environment variable {VariableName}", name);
            return defaultValue;
        }
        
        _logger.LogDebug("Environment variable {VariableName} not found and no default provided", name);
        return null;
    }

    public bool ValidateRequiredEnvironmentVariables(IEnumerable<string> requiredVariables, out List<string> missingVariables)
    {
        missingVariables = new List<string>();
        
        foreach (var variable in requiredVariables)
        {
            if (string.IsNullOrEmpty(GetEnvironmentVariable(variable)))
            {
                missingVariables.Add(variable);
            }
        }
        
        if (missingVariables.Any())
        {
            _logger.LogWarning("Missing required environment variables: {MissingVariables}", 
                string.Join(", ", missingVariables));
            return false;
        }
        
        return true;
    }

    public bool ContainsEnvironmentVariables(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        var patterns = new[]
        {
            @"\$\{[A-Z_][A-Z0-9_]*(?::[^}]*)?\}",  // ${VAR_NAME} or ${VAR_NAME:default}
            @"%[A-Z_][A-Z0-9_]*%",                 // %VAR_NAME%
            @"\$[A-Z_][A-Z0-9_]*(?![{])"          // $VAR_NAME (not followed by {)
        };

        return patterns.Any(pattern => Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase));
    }

    public bool ValidateSecretField(string fieldName, string? value, out string errorMessage)
    {
        errorMessage = string.Empty;
        
        if (string.IsNullOrEmpty(value))
        {
            return true; // Empty values are allowed
        }

        if (!IsSecretField(fieldName))
        {
            return true; // Non-secret fields can have any value
        }

        if (!ContainsEnvironmentVariables(value))
        {
            errorMessage = $"Secret field '{fieldName}' must use environment variables only. " +
                          $"Use formats like '${{VAR_NAME}}' or '%VAR_NAME%' instead of hardcoded values.";
            _logger.LogError("Secret field validation failed: {ErrorMessage}", errorMessage);
            return false;
        }

        // Check if the value contains any non-environment variable content
        var resolvedValue = ResolveEnvironmentVariables(value);
        if (resolvedValue == value && !string.IsNullOrEmpty(value))
        {
            // If the value didn't change after resolution, it means no environment variables were found
            // This could happen if the environment variable format is invalid
            errorMessage = $"Secret field '{fieldName}' contains invalid environment variable format. " +
                          $"Use formats like '${{VAR_NAME}}' or '%VAR_NAME%'.";
            _logger.LogError("Secret field validation failed: {ErrorMessage}", errorMessage);
            return false;
        }

        return true;
    }

    public bool ValidateSecretFields(object config, out List<string> errors)
    {
        errors = new List<string>();
        
        if (config == null)
        {
            return true;
        }

        var visitedObjects = new HashSet<object>();
        ValidateObjectSecretFields(config, "", errors, visitedObjects);
        
        if (errors.Any())
        {
            _logger.LogError("Secret field validation failed with {ErrorCount} errors", errors.Count);
            return false;
        }

        return true;
    }

    private void ValidateObjectSecretFields(object obj, string prefix, List<string> errors, HashSet<object> visitedObjects)
    {
        if (obj == null)
        {
            return;
        }

        // Prevent infinite recursion by tracking visited objects
        if (visitedObjects.Contains(obj))
        {
            return;
        }
        visitedObjects.Add(obj);

        var type = obj.GetType();
        
        // Skip primitive types and common framework types to avoid infinite recursion
        if (type.IsPrimitive || type == typeof(string) || type.IsEnum || 
            type.Namespace?.StartsWith("System") == true)
        {
            return;
        }
        
        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!property.CanRead || property.GetIndexParameters().Length > 0)
                continue;

            try
            {
                var propertyName = string.IsNullOrEmpty(prefix) ? property.Name : $"{prefix}.{property.Name}";
                var value = property.GetValue(obj);

                if (value == null)
                    continue;

                if (property.PropertyType == typeof(string))
                {
                    var stringValue = value as string;
                    if (!ValidateSecretField(property.Name, stringValue, out var errorMessage))
                    {
                        errors.Add($"{propertyName}: {errorMessage}");
                    }
                }
                else if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    // Recursively validate nested objects
                    ValidateObjectSecretFields(value, propertyName, errors, visitedObjects);
                }
                else if (property.PropertyType.IsGenericType)
                {
                    var genericType = property.PropertyType.GetGenericTypeDefinition();
                    if (genericType == typeof(Dictionary<,>))
                    {
                        ValidateDictionarySecretFields(value, propertyName, errors);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogDebug("Skipping property {PropertyName} during validation due to error: {Error}", property.Name, ex.Message);
                // Skip properties that cause issues
                continue;
            }
        }
    }

    private void ValidateDictionarySecretFields(object dictionary, string prefix, List<string> errors)
    {
        var type = dictionary.GetType();
        
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            var keyType = type.GetGenericArguments()[0];
            var valueType = type.GetGenericArguments()[1];
            
            if (keyType == typeof(string) && valueType == typeof(string))
            {
                var dict = dictionary as Dictionary<string, string>;
                if (dict != null)
                {
                    foreach (var kvp in dict)
                    {
                        if (!ValidateSecretField(kvp.Key, kvp.Value, out var errorMessage))
                        {
                            errors.Add($"{prefix}[{kvp.Key}]: {errorMessage}");
                        }
                    }
                }
            }
            else if (keyType == typeof(string) && valueType == typeof(object))
            {
                var dict = dictionary as Dictionary<string, object>;
                if (dict != null)
                {
                    foreach (var kvp in dict)
                    {
                        if (kvp.Value is string stringValue)
                        {
                            if (!ValidateSecretField(kvp.Key, stringValue, out var errorMessage))
                            {
                                errors.Add($"{prefix}[{kvp.Key}]: {errorMessage}");
                            }
                        }
                    }
                }
            }
        }
    }

    private static bool IsSecretField(string fieldName)
    {
        return SecretFields.Any(secretField => 
            fieldName.EndsWith(secretField, StringComparison.OrdinalIgnoreCase) ||
            fieldName.Equals(secretField, StringComparison.OrdinalIgnoreCase));
    }

    public T ResolveEnvironmentVariablesInObject<T>(T obj) where T : class
    {
        if (obj == null)
        {
            return obj!;
        }

        var type = obj.GetType();
        
        // Handle string properties
        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (property.CanRead && property.CanWrite && property.GetIndexParameters().Length == 0)
            {
                try
                {
                    if (property.PropertyType == typeof(string))
                    {
                        var currentValue = property.GetValue(obj) as string;
                        if (!string.IsNullOrEmpty(currentValue))
                        {
                            var resolvedValue = ResolveEnvironmentVariables(currentValue);
                            if (resolvedValue != currentValue)
                            {
                                property.SetValue(obj, resolvedValue);
                                _logger.LogDebug("Resolved environment variables in property {PropertyName}", property.Name);
                            }
                        }
                    }
                    else if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                    {
                        // Recursively handle nested objects
                        var nestedObj = property.GetValue(obj);
                        if (nestedObj != null)
                        {
                            ResolveEnvironmentVariablesInObject(nestedObj);
                        }
                    }
                    else if (property.PropertyType.IsGenericType)
                    {
                        // Handle collections like Dictionary<string, string>
                        var genericType = property.PropertyType.GetGenericTypeDefinition();
                        if (genericType == typeof(Dictionary<,>))
                        {
                            var dictionary = property.GetValue(obj);
                            if (dictionary != null)
                            {
                                ResolveDictionaryEnvironmentVariables(dictionary);
                            }
                        }
                        else if (genericType == typeof(List<>) && property.PropertyType.GetGenericArguments()[0] == typeof(string))
                        {
                            var list = property.GetValue(obj) as List<string>;
                            if (list != null)
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (!string.IsNullOrEmpty(list[i]))
                                    {
                                        list[i] = ResolveEnvironmentVariables(list[i]);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogDebug("Skipping property {PropertyName} due to error: {Error}", property.Name, ex.Message);
                    // Skip properties that cause issues
                    continue;
                }
            }
        }
        
        return obj;
    }

    private void ResolveDictionaryEnvironmentVariables(object dictionary)
    {
        var type = dictionary.GetType();
        
        // Handle Dictionary<string, string>
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            var keyType = type.GetGenericArguments()[0];
            var valueType = type.GetGenericArguments()[1];
            
            if (keyType == typeof(string) && valueType == typeof(string))
            {
                var dict = dictionary as Dictionary<string, string>;
                if (dict != null)
                {
                    var keysToUpdate = new List<string>();
                    foreach (var kvp in dict)
                    {
                        if (!string.IsNullOrEmpty(kvp.Value))
                        {
                            var resolvedValue = ResolveEnvironmentVariables(kvp.Value);
                            if (resolvedValue != kvp.Value)
                            {
                                keysToUpdate.Add(kvp.Key);
                            }
                        }
                    }
                    
                    foreach (var key in keysToUpdate)
                    {
                        dict[key] = ResolveEnvironmentVariables(dict[key]);
                    }
                }
            }
            else if (keyType == typeof(string) && valueType == typeof(object))
            {
                var dict = dictionary as Dictionary<string, object>;
                if (dict != null)
                {
                    var keysToUpdate = new List<string>();
                    foreach (var kvp in dict)
                    {
                        if (kvp.Value is string stringValue && !string.IsNullOrEmpty(stringValue))
                        {
                            var resolvedValue = ResolveEnvironmentVariables(stringValue);
                            if (resolvedValue != stringValue)
                            {
                                keysToUpdate.Add(kvp.Key);
                            }
                        }
                    }
                    
                    foreach (var key in keysToUpdate)
                    {
                        if (dict[key] is string stringValue)
                        {
                            dict[key] = ResolveEnvironmentVariables(stringValue);
                        }
                    }
                }
            }
        }
    }
} 