using System;
using System.Reflection;

namespace Project.Hub.Api.Settings
{
    /// <inheritdoc/>
    public class AppSettings : IAppSettings
    {
        /// <summary>
        /// Represent an instance of the settings object.
        /// </summary>
        public static IAppSettings Instance => _instance.Value;

        private static readonly Lazy<IAppSettings> _instance = new Lazy<IAppSettings>(() => new AppSettings());

        private AppSettings() { }

        /// <inheritdoc/>
        public Version Version => new Version(
            GetType().Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version
        );
    }
}
