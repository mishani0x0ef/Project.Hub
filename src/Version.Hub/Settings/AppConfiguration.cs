using Version.Hub.Config;

namespace Version.Hub.Settings
{
    public class AppConfiguration : IConfigPathResolver
    {
        public string AppDisplayName { get; set; }
        public string ConfigPath { get; set; }
    }
}
