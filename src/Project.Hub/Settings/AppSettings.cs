using System.Web;

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

        public string AppName => Configuration.GetSection("AppConfiguration")["AppDisplayName"];
        public string ConfigJsonPath => Configuration.GetSection("AppConfiguration")["ConfigPath"]);
    }
}