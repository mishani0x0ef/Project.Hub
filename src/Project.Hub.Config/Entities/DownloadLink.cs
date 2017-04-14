namespace Project.Hub.Config.Entities
{
    public class DownloadLink : BaseConfig
    {
        public DownloadMode Mode { get; set; }
        public DownloadType Type { get; set; }
        public string DownloadPath { get; set; }

        public DownloadLink()
        {
        }

        public DownloadLink(string name, string description = null) : base(name, description)
        {
        }
    }
}
