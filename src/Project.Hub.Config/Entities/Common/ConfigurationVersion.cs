namespace Project.Hub.Config.Entities.Common
{
    /// <summary>
    /// Basic model that describe file version that is used for configuration.
    /// </summary>
    public class ConfigurationVersion
    {
        /// <summary>
        /// Version of the JSON configuration.
        /// Used to identify different file formats.
        /// </summary>
        public string Version { get; set; } = string.Empty;
    }
}
