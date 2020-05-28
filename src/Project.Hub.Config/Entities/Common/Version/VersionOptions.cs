namespace Project.Hub.Config.Entities.Common.Version
{
    public class VersionOptions
    {
        /// <summary>
        /// Describe the way version could be resolved (e.g from .NET dll or package.json)
        /// </summary>
        public VersionType Type { get; set; }

        /// <summary>
        /// Path to resource that contain version. Dependps on `Type` could be used:
        /// DLL - for `Assembly`
        /// </summary>
        public string Path { get; set; }
    }
}
