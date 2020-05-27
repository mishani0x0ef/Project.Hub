using Project.Hub.Config.Entities.v1;
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

    public interface IEnvironmentable
    {
        string Environment { get; set; }
    }

    public class WebsiteEnvironment : IEnvironmentable
    {
        public string Environment { get; set; }
        public string Url { get; set; }
        public VersionOptions VersionOptions { get; set; }
    }

    public class DownloadEnvironment : IEnvironmentable
    {
        public string Environment { get; set; }
        public string DownloadPath { get; set; }
        public VersionOptions VersionOptions { get; set; }
    }

    public class EnvironmentalComponent<T> : BaseConfig where T : IEnvironmentable
    {
        public string FaviconFallback { get; set; }
        public IEnumerable<T> Environments { get; set; }
    }

    public class Download : EnvironmentalComponent<DownloadEnvironment>
    {
        public DownloadType Type { get; set; }
        public DownloadMode Mode { get; set; }
    }

    public class HubConfiguration
    {
        public IEnumerable<EnvironmentDescription> Environments { get; set; }
        public IEnumerable<CommonService> CommonServices { get; set; }
        public IEnumerable<EnvironmentalComponent<WebsiteEnvironment>> Websites { get; set; }
        public IEnumerable<EnvironmentalComponent<WebsiteEnvironment>> Apis { get; set; }
        public IEnumerable<Download> Downloads { get; set; }
    }
}
