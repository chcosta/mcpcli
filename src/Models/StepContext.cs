using System.Text.Json;
using System.Text.RegularExpressions;

namespace McpCli.Models;

/// <summary>
/// Represents the context and result of a single step execution
/// </summary>
public class StepContext
{
    public int StepNumber { get; set; }
    public string ToolName { get; set; } = string.Empty;
    public Dictionary<string, object> Parameters { get; set; } = new();
    public string Purpose { get; set; } = string.Empty;
    public string RawResult { get; set; } = string.Empty;
    public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;
    public bool IsSuccess { get; set; } = true;
    public string? ErrorMessage { get; set; }
    
    /// <summary>
    /// Parsed structured data from the result
    /// </summary>
    public Dictionary<string, object> ParsedData { get; set; } = new();
    
    /// <summary>
    /// Extracted values using various patterns
    /// </summary>
    public Dictionary<string, List<string>> ExtractedValues { get; set; } = new();
}

/// <summary>
/// Manages context across multiple step executions
/// </summary>
public class ContextLibrary
{
    private readonly List<StepContext> _steps = new();
    private readonly Dictionary<string, IContextExtractor> _extractors = new();

    public ContextLibrary()
    {
        // Register default extractors
        RegisterExtractor("id", new IdExtractor());
        RegisterExtractor("date", new DateExtractor());
        RegisterExtractor("number", new NumberExtractor());
        RegisterExtractor("json", new JsonExtractor());
        RegisterExtractor("url", new UrlExtractor());
        RegisterExtractor("email", new EmailExtractor());
    }

    public void RegisterExtractor(string key, IContextExtractor extractor)
    {
        _extractors[key] = extractor;
    }

    public void AddStepResult(StepContext stepContext)
    {
        _steps.Add(stepContext);
        
        // Extract values using all registered extractors
        foreach (var extractor in _extractors)
        {
            var extractedValues = extractor.Value.Extract(stepContext.RawResult);
            if (extractedValues.Any())
            {
                stepContext.ExtractedValues[extractor.Key] = extractedValues;
            }
        }
        
        // Try to parse as JSON for structured data
        TryParseStructuredData(stepContext);
    }

    public StepContext? GetStep(int stepNumber)
    {
        return _steps.FirstOrDefault(s => s.StepNumber == stepNumber);
    }

    public List<StepContext> GetAllSteps()
    {
        return _steps.ToList();
    }

    public string? ResolveVariable(string variableName)
    {
        // Parse variable name: FIELD_FROM_STEP_N or FIELD_FROM_STEP_N_TYPE
        var match = Regex.Match(variableName, @"^(.+?)_FROM_STEP_(\d+)(?:_(.+))?$", RegexOptions.IgnoreCase);
        if (!match.Success)
        {
            return null;
        }

        var fieldName = match.Groups[1].Value.ToLower();
        var stepNumber = int.Parse(match.Groups[2].Value);
        var extractorType = match.Groups[3].Success ? match.Groups[3].Value.ToLower() : null;

        return ResolveFromStep(stepNumber, fieldName, extractorType);
    }

    private string? ResolveFromStep(int stepNumber, string fieldName, string? extractorType)
    {
        var step = GetStep(stepNumber);
        if (step == null)
        {
            return null;
        }

        // Try different resolution strategies in order of preference
        
        // 1. Direct field lookup in parsed data
        if (step.ParsedData.ContainsKey(fieldName))
        {
            return step.ParsedData[fieldName]?.ToString();
        }

        // 2. Case-insensitive field lookup in parsed data
        var caseInsensitiveKey = step.ParsedData.Keys.FirstOrDefault(k => 
            string.Equals(k, fieldName, StringComparison.OrdinalIgnoreCase));
        if (caseInsensitiveKey != null)
        {
            return step.ParsedData[caseInsensitiveKey]?.ToString();
        }

        // 3. Extracted values by type
        if (extractorType != null && step.ExtractedValues.ContainsKey(extractorType))
        {
            return step.ExtractedValues[extractorType].FirstOrDefault();
        }

        // 4. Smart field name matching
        return SmartFieldMatch(step, fieldName);
    }

    private string? SmartFieldMatch(StepContext step, string fieldName)
    {
        var fieldLower = fieldName.ToLower();
        
        // Common field name mappings
        var fieldMappings = new Dictionary<string, string[]>
        {
            ["id"] = ["id", "pullrequestid", "requestid", "number"],
            ["date"] = ["date", "closeddate", "createddate", "completedate", "closedate"],
            ["title"] = ["title", "name", "subject"],
            ["description"] = ["description", "desc", "body"],
            ["status"] = ["status", "state"],
            ["author"] = ["author", "creator", "createdby"],
            ["branch"] = ["branch", "sourcebranch", "targetbranch"]
        };

        // Find matching field mapping
        foreach (var mapping in fieldMappings)
        {
            if (mapping.Value.Contains(fieldLower))
            {
                // Try to find this type of data in extracted values
                foreach (var extractedType in step.ExtractedValues)
                {
                    if (mapping.Key == extractedType.Key)
                    {
                        return extractedType.Value.FirstOrDefault();
                    }
                }
                
                // Try to find in parsed data
                foreach (var parsedKey in step.ParsedData.Keys)
                {
                    if (mapping.Value.Contains(parsedKey.ToLower()))
                    {
                        return step.ParsedData[parsedKey]?.ToString();
                    }
                }
            }
        }

        return null;
    }

    private void TryParseStructuredData(StepContext stepContext)
    {
        try
        {
            // Try to parse as JSON
            var jsonDoc = JsonDocument.Parse(stepContext.RawResult);
            ExtractFromJsonElement(jsonDoc.RootElement, stepContext.ParsedData);
        }
        catch
        {
            // Not valid JSON, try other structured formats
            TryParseKeyValuePairs(stepContext);
        }
    }

    private void ExtractFromJsonElement(JsonElement element, Dictionary<string, object> target, string prefix = "")
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in element.EnumerateObject())
                {
                    var key = string.IsNullOrEmpty(prefix) ? property.Name : $"{prefix}.{property.Name}";
                    ExtractFromJsonElement(property.Value, target, key);
                }
                break;
            
            case JsonValueKind.Array:
                var array = element.EnumerateArray().ToList();
                target[prefix] = array.Select(e => e.ToString()).ToList();
                
                // Also extract individual items
                for (int i = 0; i < array.Count; i++)
                {
                    ExtractFromJsonElement(array[i], target, $"{prefix}[{i}]");
                }
                break;
            
            default:
                target[prefix] = element.ToString();
                break;
        }
    }

    private void TryParseKeyValuePairs(StepContext stepContext)
    {
        var lines = stepContext.RawResult.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var line in lines)
        {
            var colonIndex = line.IndexOf(':');
            if (colonIndex > 0)
            {
                var key = line.Substring(0, colonIndex).Trim();
                var value = line.Substring(colonIndex + 1).Trim();
                
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    stepContext.ParsedData[key] = value;
                }
            }
        }
    }
}

/// <summary>
/// Interface for extracting specific types of data from step results
/// </summary>
public interface IContextExtractor
{
    List<string> Extract(string text);
}

/// <summary>
/// Extracts ID-like values (numbers, UUIDs, etc.)
/// </summary>
public class IdExtractor : IContextExtractor
{
    public List<string> Extract(string text)
    {
        var ids = new List<string>();
        
        // Extract various ID patterns
        var patterns = new[]
        {
            @"\b\d{4,}\b", // 4+ digit numbers
            @"\b[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\b", // UUIDs
            @"""(?:id|ID|Id|pullRequestId|PullRequestId|requestId|RequestId)"":\s*(\d+)", // JSON IDs
            @"(?:id|ID|Id|pullRequestId|PullRequestId|requestId|RequestId):\s*(\d+)" // Key-value IDs
        };

        foreach (var pattern in patterns)
        {
            var matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                var value = match.Groups.Count > 1 ? match.Groups[1].Value : match.Value;
                if (!ids.Contains(value))
                {
                    ids.Add(value);
                }
            }
        }

        return ids;
    }
}

/// <summary>
/// Extracts date values in various formats
/// </summary>
public class DateExtractor : IContextExtractor
{
    public List<string> Extract(string text)
    {
        var dates = new List<string>();
        
        var patterns = new[]
        {
            @"\b\d{4}-\d{2}-\d{2}\b", // ISO dates
            @"\b\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}", // ISO datetime
            @"""(?:date|Date|closedDate|createdDate|completeDate|closeDate)"":\s*""([^""]+)""", // JSON dates
            @"(?:date|Date|closedDate|createdDate|completeDate|closeDate):\s*([^\s,]+)" // Key-value dates
        };

        foreach (var pattern in patterns)
        {
            var matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                var value = match.Groups.Count > 1 ? match.Groups[1].Value : match.Value;
                if (!dates.Contains(value))
                {
                    dates.Add(value);
                }
            }
        }

        return dates;
    }
}

/// <summary>
/// Extracts numeric values
/// </summary>
public class NumberExtractor : IContextExtractor
{
    public List<string> Extract(string text)
    {
        var numbers = new List<string>();
        var matches = Regex.Matches(text, @"\b\d+(?:\.\d+)?\b");
        
        foreach (Match match in matches)
        {
            if (!numbers.Contains(match.Value))
            {
                numbers.Add(match.Value);
            }
        }

        return numbers;
    }
}

/// <summary>
/// Extracts JSON objects and arrays
/// </summary>
public class JsonExtractor : IContextExtractor
{
    public List<string> Extract(string text)
    {
        var jsonObjects = new List<string>();
        
        // Find JSON objects and arrays
        var patterns = new[]
        {
            @"\{[^{}]*\}", // Simple objects
            @"\[[^\[\]]*\]" // Simple arrays
        };

        foreach (var pattern in patterns)
        {
            var matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                try
                {
                    JsonDocument.Parse(match.Value);
                    jsonObjects.Add(match.Value);
                }
                catch
                {
                    // Not valid JSON, skip
                }
            }
        }

        return jsonObjects;
    }
}

/// <summary>
/// Extracts URLs
/// </summary>
public class UrlExtractor : IContextExtractor
{
    public List<string> Extract(string text)
    {
        var urls = new List<string>();
        var pattern = @"https?://[^\s<>""]+";
        var matches = Regex.Matches(text, pattern);
        
        foreach (Match match in matches)
        {
            if (!urls.Contains(match.Value))
            {
                urls.Add(match.Value);
            }
        }

        return urls;
    }
}

/// <summary>
/// Extracts email addresses
/// </summary>
public class EmailExtractor : IContextExtractor
{
    public List<string> Extract(string text)
    {
        var emails = new List<string>();
        var pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
        var matches = Regex.Matches(text, pattern);
        
        foreach (Match match in matches)
        {
            if (!emails.Contains(match.Value))
            {
                emails.Add(match.Value);
            }
        }

        return emails;
    }
} 