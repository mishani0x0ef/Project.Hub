using Project.Hub.Config.Interfaces;

namespace Project.Hub.Settings
{
    public class AppConfiguration : IOptionsProvider
    {
        public string AppDisplayName { get; set; }
        public string ConfigPath { get; set; }
        public int VersionsCacheExpirationInHours { get; set; }
        public string DisplayTimeZone { get; set; }
        public string LogsPath { get; set; }
        public string PowerShellPath { get; set; }
    }
}
