using Project.Hub.Config.Entities.Common.Version;
using System.Linq;

namespace Project.Hub.Config.Util
{
    public static class ComponentExtension
    {
        /// <summary>
        /// Look for specific environment in component and resolve it's version.
        /// If no version for environment - return default value.
        /// </summary>
        public static ComponentVersion GetEnvironmentVersionOrDefault(this Component component, string environment, string defaultVersion = "-")
        {
            var version = component?.Versions?.FirstOrDefault(v => v.EnvironmentName == environment);
            return version ?? new ComponentVersion { EnvironmentName = environment, Version = defaultVersion };
        }
    }
}
