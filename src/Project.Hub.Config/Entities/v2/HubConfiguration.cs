using Project.Hub.Config.Entities.Version;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.v2
{
    public class EnvironmentDescription : BaseConfig
    {
    }

    public class CommonService : BaseConfig
    {
        public string Url { get; set; }
        public string FaviconFallback { get; set; }
    }

    public class WebsiteEnvironment
    {
        public string Environment { get; set; }
        public string Url { get; set; }
        public VersionOptions VersionOptions { get; set; }
    }

    public class Website : BaseConfig
    {
        public string FaviconFallback { get; set; }
        public IEnumerable<WebsiteEnvironment> Environments { get; set; }
    }

    public class HubConfiguration
    {
        public IEnumerable<EnvironmentDescription> Environments { get; set; }
        public IEnumerable<CommonService> CommonServices { get; set; }
        public IEnumerable<Website> Websites { get; set; }
    }
}
