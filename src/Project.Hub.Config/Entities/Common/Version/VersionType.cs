namespace Project.Hub.Config.Entities.Common.Version
{
    public enum VersionType
    {
        /// <summary>
        /// .NET assembly.
        /// </summary>
        Assembly = 0,

        /// <summary>
        /// PowerShell script that resolve an version according to the interval logic and return it.
        /// </summary>
        PowerShell,

        /// <summary>
        /// Resolve from json file.
        /// </summary>
        JsonFile
    }
}
