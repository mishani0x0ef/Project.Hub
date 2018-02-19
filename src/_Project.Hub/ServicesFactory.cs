using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Providers;
using Project.Hub.Settings;

namespace Project.Hub
{
    public class ServicesFactory
    {
        private IConfigurationProvider ConfigurationProvider { get; set; }

        private static readonly object Locker = new object();
        private static ServicesFactory _instance;

        public static ServicesFactory Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                lock (Locker)
                {
                    return _instance ?? (_instance = new ServicesFactory());
                }
            }
        }

        private ServicesFactory()
        {
            Initialize();
        }

        public IConfigurationProvider GetConfigurationProvider()
        {
            return ConfigurationProvider;
        }

        private void Initialize()
        {
            ConfigurationProvider = new JsonConfigurationProvider(AppSettings.Instance.ConfigJsonPath);
        }
    }
}