using Project.Hub.Config.Interfaces;

namespace Project.Hub.Settings
{
    public class AppConfiguration : IConfigPathResolver
    {
        public string AppDisplayName { get; set; }
        public string ConfigPath { get; set; }
    }
}
