namespace Project.Hub.Config.Entities.Common.Version
{
    /// <summary>
    /// Version options that represents how to resolve version for a specific component.
    /// </summary>
    public class VersionOptions
    {
        /// <summary>
        /// Describe the way version could be resolved (e.g from .NET DLL or package.json)
        /// </summary>
        public VersionType Type { get; set; }

        /// <summary>
        /// Path to resource that contain version. Depends on the `Type` could be used:
        /// DLL - for `Assembly`
        /// </summary>
        public string Path { get; set; }
    }
}
