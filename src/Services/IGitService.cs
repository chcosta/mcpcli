namespace McpCli.Services;

public interface IGitService
{
    Task<string> CloneRepositoryAsync(string repositoryUrl, string localPath, IProgress<string>? progress = null, CancellationToken cancellationToken = default);
    Task<bool> UpdateRepositoryAsync(string localPath, CancellationToken cancellationToken = default);
    Task<bool> IsValidRepositoryAsync(string repositoryUrl);
    Task<bool> IsRepositoryClonedAsync(string localPath);
    string GetRepositoryNameFromUrl(string repositoryUrl);
    void SetAzureDevOpsCredentials(string organization, string personalAccessToken);
    void SetAzureDevOpsCredentials(string organization, bool useManagedIdentity);
} 