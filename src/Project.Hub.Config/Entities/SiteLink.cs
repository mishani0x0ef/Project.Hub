namespace Project.Hub.Config.Entities
{
    public class SiteLink : BaseConfig
    {
        public string Url { get; set; }

        public SiteLink()
        {
        }

        public SiteLink(string name, string url, string description = null) : base(name, description)
        {
            Url = url;
        }
    }
}
