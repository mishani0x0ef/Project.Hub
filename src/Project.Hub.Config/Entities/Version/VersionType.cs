namespace Project.Hub.Config.Entities.Version
{
    public enum VersionType
    {
        /// <summary>
        /// .NET assembly.
        /// </summary>
        Assembly = 0,

        /// <summary>
        /// Resolve version using proxy Version.Hub deployed on remote server.
        /// </summary>
        VersionHub,

        /// <summary>
        /// PowerShell script that resolve an version according to the interval logic and return it.
        /// </summary>
        PowerShell,
    }
}
