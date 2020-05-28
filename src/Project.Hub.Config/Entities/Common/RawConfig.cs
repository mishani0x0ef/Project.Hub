namespace Project.Hub.Config.Entities.Common
{
    /// <summary>
    /// Provide set of configurations in textual representation.
    /// </summary>
    public class RawConfig
    {
        /// <summary>
        /// Textual representation of the hub configuration.
        /// Raw configuration in JSON format.
        /// </summary>
        public string HubConfigText { get; set; }

        /// <summary>
        /// Raw NLog configuration.
        /// </summary>
        public string NLogConfigText { get; set; }

        /// <summary>
        /// Textual representation of the latest log.
        /// </summary>
        public string LatestLog { get; set; }
    }
}
