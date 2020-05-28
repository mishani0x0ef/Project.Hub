namespace Project.Hub.Config.Entities.Common
{
    /// <summary>
    /// Define the mode that must be used to download the component (e.g latest version of desktop application from build server).
    /// </summary>
    public enum DownloadMode
    {
        /// <summary>
        /// Direct download using URL.
        /// </summary>
        Dirrect,

        /// <summary>
        /// Download from file system (could be shared storage as well).
        /// </summary>
        FileSystem
    }
}
