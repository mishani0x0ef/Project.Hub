using Project.Hub.Config.Entities.Common;

namespace Project.Hub.Config.Entities.v1
{
    public class DownloadLink : ComponentConfig
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
