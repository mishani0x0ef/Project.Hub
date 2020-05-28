namespace Project.Hub.Config.Entities.Common
{
    public class RawConfig
    {
        /// <summary>
        /// Raw config textual representation.
        /// </summary>
        public string HubConfigText { get; set; }

        /// <summary>
        /// Raw NLog config.
        /// </summary>
        public string NLogConfigText { get; set; }

        /// <summary>
        /// Textual representation of the latest log.
        /// </summary>
        public string LatestLog { get; set; }
    }
}
