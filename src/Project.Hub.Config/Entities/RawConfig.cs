namespace Project.Hub.Config.Entities
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
    }
}
