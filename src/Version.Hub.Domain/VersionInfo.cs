namespace Version.Hub.Domain
{
    public class VersionInfo
    {
        /// <summary>
        /// Uniq name of component to get version for.
        /// </summary>
        public string UniqName { get; set; }

        /// <summary>
        /// Version textual representation (supported not only numeric versions).
        /// </summary>
        public string Version;
    }
}
