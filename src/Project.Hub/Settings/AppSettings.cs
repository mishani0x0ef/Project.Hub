using System.Configuration;
using System.Web.Hosting;

namespace Project.Hub.Settings
{
    public class AppSettings
    {
        private static readonly object Locker = new object();
        private static AppSettings _instance;

        public static AppSettings Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                lock (Locker)
                {
                    return _instance ?? (_instance = new AppSettings());
                }
            }
        }

        public string AppName => ConfigurationManager.AppSettings["appDisplayName"];
        public string ConfigJsonPath => HostingEnvironment.MapPath(ConfigurationManager.AppSettings["configPath"]);
    }
}