using Microsoft.Extensions.Logging;
using System.IO;

namespace McpCli.Services;

public class RepositoryRootService : IRepositoryRootService
{
    private readonly ILogger<RepositoryRootService> _logger;
    private string? _repositoryRoot;

    public RepositoryRootService(ILogger<RepositoryRootService> logger)
    {
        _logger = logger;
    }

    public string GetRepositoryRoot()
    {
        if (_repositoryRoot != null)
            return _repositoryRoot;

        // Start from the current directory and search upwards for .reporoot
        var currentDir = Directory.GetCurrentDirectory();
        var searchDir = currentDir;

        while (!string.IsNullOrEmpty(searchDir))
        {
            var reporootPath = Path.Combine(searchDir, ".reporoot");
            if (File.Exists(reporootPath))
            {
                _repositoryRoot = searchDir;
                _logger.LogDebug("Found repository root at: {RepositoryRoot}", _repositoryRoot);
                return _repositoryRoot;
            }

            // Move up one directory
            var parentDir = Directory.GetParent(searchDir);
            if (parentDir == null)
                break;
            
            searchDir = parentDir.FullName;
        }

        // If no .reporoot found, use current directory as fallback
        _repositoryRoot = currentDir;
        _logger.LogWarning("No .reporoot file found, using current directory as repository root: {RepositoryRoot}", _repositoryRoot);
        return _repositoryRoot;
    }

    public string ResolvePath(string relativePath)
    {
        if (string.IsNullOrEmpty(relativePath))
            return GetRepositoryRoot();

        // If it's already an absolute path, return as-is
        if (Path.IsPathRooted(relativePath))
            return relativePath;

        // Resolve relative to repository root
        var repositoryRoot = GetRepositoryRoot();
        var resolvedPath = Path.GetFullPath(Path.Combine(repositoryRoot, relativePath));
        
        _logger.LogDebug("Resolved relative path '{RelativePath}' to '{ResolvedPath}'", relativePath, resolvedPath);
        return resolvedPath;
    }

    public bool IsRelativePath(string path)
    {
        if (string.IsNullOrEmpty(path))
            return false;

        // Check if it starts with relative path indicators
        if (path.StartsWith("./") || path.StartsWith("../"))
            return true;

        // Check if it's not an absolute path (doesn't start with drive letter or /)
        return !Path.IsPathRooted(path);
    }

    public string GetRelativePath(string absolutePath)
    {
        if (string.IsNullOrEmpty(absolutePath))
            return string.Empty;

        var repositoryRoot = GetRepositoryRoot();
        
        try
        {
            var relativePath = Path.GetRelativePath(repositoryRoot, absolutePath);
            _logger.LogDebug("Converted absolute path '{AbsolutePath}' to relative path '{RelativePath}'", absolutePath, relativePath);
            return relativePath;
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Could not convert absolute path '{AbsolutePath}' to relative path from repository root '{RepositoryRoot}'", absolutePath, repositoryRoot);
            return absolutePath;
        }
    }
} 