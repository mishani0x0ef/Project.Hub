namespace Project.Hub.Config.Interfaces
{
    /// <summary>
    /// Provide access to web-application's options (configuration).
    /// </summary>
    public interface IOptionsProvider
    {
        /// <summary>
        /// Path to hub configuration file that describe environments and site's content.
        /// </summary>
        string ConfigPath { get; }

        /// <summary>
        /// Path to log files folder.
        /// </summary>
        string LogsPath { get; }

        /// <summary>
        /// Path to powershell executable (can be "powershell" if not used any beta version or Core-version that have different path).
        /// </summary>
        string PowerShellPath { get; }
    }
}
