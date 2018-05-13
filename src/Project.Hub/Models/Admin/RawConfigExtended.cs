using Project.Hub.Config.Entities;

namespace Project.Hub.Models.Admin
{
    public class RawConfigExtended : RawConfig
    {
        public string AdminNewPasswordHash { get; set; }

        public RawConfigExtended() { }

        public RawConfigExtended(RawConfig baseConfig, string newPasswordHash = null)
        {
            HubConfigText = baseConfig.HubConfigText;
            NLogConfigText = baseConfig.NLogConfigText;
            LatestLog = baseConfig.LatestLog;

            AdminNewPasswordHash = newPasswordHash;
        }
    }
}
