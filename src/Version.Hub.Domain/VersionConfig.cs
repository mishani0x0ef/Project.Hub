namespace Version.Hub.Domain.Entities
{
    public class VersionConfig
    {
        /// <summary>
        /// Uniq name of component to get version for.
        /// </summary>
        public string UniqName { get; set; }

        /// <summary>
        /// Path to resource that provide version.
        /// Path to DLL for .net projects.
        /// </summary>
        public string Path { get; set; }
    }
}
