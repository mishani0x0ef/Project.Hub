namespace Project.Hub.Config.Entities.Common.Version
{
    /// <summary>
    /// Represents the way component's version should be resolved.
    /// </summary>
    public enum VersionType
    {
        /// <summary>
        /// .NET assembly.
        /// Useful if you Hub have access to application's DLL file to check it.
        /// </summary>
        Assembly = 0,

        /// <summary>
        /// PowerShell script that resolve an version according to the interval logic and return it.
        /// </summary>
        PowerShell,

        /// <summary>
        /// Resolve from structured JSON-file that already contains version.
        /// Useful when you have background script that can check versions and generate results in JSON format.
        /// </summary>
        JsonFile
    }
}
