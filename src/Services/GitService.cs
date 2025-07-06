using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using Microsoft.Extensions.Logging;
using Azure.Core;
using Azure.Identity;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace McpCli.Services;

public class GitService : IGitService
{
    private readonly ILogger<GitService> _logger;
    private string? _organization;
    private string? _personalAccessToken;
    private bool _useManagedIdentity = false;

    public GitService(ILogger<GitService> logger)
    {
        _logger = logger;
    }

    public async Task<string> CloneRepositoryAsync(string repositoryUrl, string localPath, IProgress<string>? progress = null, CancellationToken cancellationToken = default)
    {
        try
        {
            progress?.Report("Preparing to clone repository...");
            
            // Clean up existing directory if it exists
            if (Directory.Exists(localPath))
            {
                progress?.Report("Removing existing directory...");
                Directory.Delete(localPath, true);
            }

            // Ensure parent directory exists
            var parentDir = Path.GetDirectoryName(localPath);
            if (!string.IsNullOrEmpty(parentDir) && !Directory.Exists(parentDir))
            {
                Directory.CreateDirectory(parentDir);
            }

            progress?.Report($"Cloning {repositoryUrl} to {localPath}...");
            
            await Task.Run(() =>
            {
                var cloneOptions = new CloneOptions();
                cloneOptions.FetchOptions.CredentialsProvider = GetCredentialsProvider();
                Repository.Clone(repositoryUrl, localPath, cloneOptions);
            }, cancellationToken);

            progress?.Report("Repository cloned successfully");
            return localPath;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error cloning repository {RepositoryUrl} to {LocalPath}", repositoryUrl, localPath);
            throw;
        }
    }

    public async Task<bool> UpdateRepositoryAsync(string localPath, CancellationToken cancellationToken = default)
    {
        try
        {
            if (!Directory.Exists(localPath))
            {
                _logger.LogWarning("Repository path does not exist: {LocalPath}", localPath);
                return false;
            }

            await Task.Run(() =>
            {
                using var repo = new Repository(localPath);
                
                // Get the remote
                var remote = repo.Network.Remotes["origin"];
                if (remote == null)
                {
                    _logger.LogWarning("No origin remote found in repository");
                    return false;
                }

                // Fetch latest changes - simplified for now
                // LibGit2Sharp.Commands.Fetch(repo, remote.Name, new string[0], null, "Fetching updates");

                // Check if we're on a branch that can be fast-forwarded
                var currentBranch = repo.Head;
                if (currentBranch.IsTracking)
                {
                    var trackedBranch = currentBranch.TrackedBranch;
                    if (trackedBranch != null)
                    {
                        // Perform fast-forward merge if possible
                        var mergeResult = repo.Merge(trackedBranch, new Signature("MCP CLI", "mcpcli@local", DateTimeOffset.Now));
                        _logger.LogInformation("Merge result: {MergeStatus}", mergeResult.Status);
                    }
                }

                return true;
            }, cancellationToken);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating repository at {LocalPath}", localPath);
            return false;
        }
    }

    public async Task<bool> IsValidRepositoryAsync(string repositoryUrl)
    {
        try
        {
            // Simple validation - check if URL looks like a valid Git repository
            if (string.IsNullOrEmpty(repositoryUrl))
                return false;

            // Check for common Git URL patterns
            var validPatterns = new[]
            {
                @"https://.*\.git$",
                @"git@.*:.*\.git$",
                @"https://dev\.azure\.com/.*/_git/.*",
                @"https://.*\.visualstudio\.com/.*/_git/.*"
            };

            foreach (var pattern in validPatterns)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(repositoryUrl, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }

            // Skip remote validation for now - would require credentials
            // await Task.Run(() =>
            // {
            //     Repository.ListRemoteReferences(repositoryUrl, GetCredentialsProvider());
            // });

            await Task.CompletedTask;
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "Repository validation failed for {RepositoryUrl}", repositoryUrl);
            return false;
        }
    }

    public async Task<bool> IsRepositoryClonedAsync(string localPath)
    {
        try
        {
            return await Task.Run(() =>
            {
                if (!Directory.Exists(localPath))
                    return false;

                return Repository.IsValid(localPath);
            });
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex, "Error checking if repository is cloned at {LocalPath}", localPath);
            return false;
        }
    }

    public string GetRepositoryNameFromUrl(string repositoryUrl)
    {
        try
        {
            var uri = new Uri(repositoryUrl);
            var segments = uri.Segments;
            
            if (segments.Length > 0)
            {
                var lastSegment = segments[^1];
                // Remove .git suffix if present
                if (lastSegment.EndsWith(".git"))
                {
                    lastSegment = lastSegment[..^4];
                }
                // Remove trailing slash if present
                if (lastSegment.EndsWith("/"))
                {
                    lastSegment = lastSegment[..^1];
                }
                return lastSegment;
            }

            // Fallback: use the last part of the path
            var path = uri.AbsolutePath.Trim('/');
            var parts = path.Split('/');
            var name = parts[^1];
            
            if (name.EndsWith(".git"))
            {
                name = name[..^4];
            }
            
            return string.IsNullOrEmpty(name) ? "repository" : name;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error extracting repository name from URL: {RepositoryUrl}", repositoryUrl);
            return "repository";
        }
    }

    public void SetAzureDevOpsCredentials(string organization, string personalAccessToken)
    {
        _organization = organization;
        _personalAccessToken = personalAccessToken;
        _useManagedIdentity = false;
        _logger.LogInformation("Azure DevOps PAT credentials configured for organization: {Organization}", organization);
    }

    public void SetAzureDevOpsCredentials(string organization, bool useManagedIdentity)
    {
        _organization = organization;
        _personalAccessToken = null;
        _useManagedIdentity = useManagedIdentity;
        _logger.LogInformation("Azure DevOps managed identity credentials configured for organization: {Organization}", organization);
    }

    private CredentialsHandler GetCredentialsProvider()
    {
        return (url, usernameFromUrl, types) =>
        {
            if (_useManagedIdentity)
            {
                // Get access token using DefaultAzureCredential
                var accessToken = GetAzureDevOpsAccessTokenAsync().GetAwaiter().GetResult();
                if (!string.IsNullOrEmpty(accessToken))
                {
                    return new UsernamePasswordCredentials
                    {
                        Username = "mcpcli",
                        Password = accessToken
                    };
                }
            }
            else if (!string.IsNullOrEmpty(_personalAccessToken))
            {
                // For Azure DevOps, username can be anything, PAT is used as password
                return new UsernamePasswordCredentials
                {
                    Username = "mcpcli",
                    Password = _personalAccessToken
                };
            }

            // Return null to use default credentials (e.g., credential manager)
            return null;
        };
    }

    private async Task<string?> GetAzureDevOpsAccessTokenAsync()
    {
        try
        {
            if (string.IsNullOrEmpty(_organization))
            {
                _logger.LogWarning("Azure DevOps organization not configured");
                return null;
            }

            var credential = new DefaultAzureCredential();
            var tokenRequestContext = new Azure.Core.TokenRequestContext(new[] { "499b84ac-1321-427f-aa17-267ca6975798/.default" });
            var token = await credential.GetTokenAsync(tokenRequestContext);
            
            _logger.LogDebug("Successfully obtained Azure DevOps access token");
            return token.Token;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to obtain Azure DevOps access token using DefaultAzureCredential");
            return null;
        }
    }
} 