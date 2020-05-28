namespace Project.Hub.Config.Entities.Common
{
    /// <summary>
    /// Defines type of the component that can be downloaded.
    /// </summary>
    public enum DownloadType
    {
        /// <summary>
        /// Desktop application, windows service, zip-archive, installer, etc.
        /// </summary>
        Application,

        /// <summary>
        /// File that contains configuration for remote desktop connection.
        /// Useful for sharing access to servers.
        /// </summary>
        RemoteDesktop
    }
}
