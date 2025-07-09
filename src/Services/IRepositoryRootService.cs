namespace McpCli.Services;

public interface IRepositoryRootService
{
    /// <summary>
    /// Gets the absolute path to the repository root directory
    /// </summary>
    /// <returns>The absolute path to the repository root</returns>
    string GetRepositoryRoot();
    
    /// <summary>
    /// Resolves a relative path to an absolute path relative to the repository root
    /// </summary>
    /// <param name="relativePath">The relative path to resolve</param>
    /// <returns>The absolute path resolved relative to the repository root</returns>
    string ResolvePath(string relativePath);
    
    /// <summary>
    /// Checks if a path is relative (starts with ./ or ../ or doesn't start with a drive letter or /)
    /// </summary>
    /// <param name="path">The path to check</param>
    /// <returns>True if the path is relative, false otherwise</returns>
    bool IsRelativePath(string path);
    
    /// <summary>
    /// Gets the relative path from the repository root to the specified absolute path
    /// </summary>
    /// <param name="absolutePath">The absolute path</param>
    /// <returns>The relative path from repository root</returns>
    string GetRelativePath(string absolutePath);
} 