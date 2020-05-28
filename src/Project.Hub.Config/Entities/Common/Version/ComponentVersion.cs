using System.Collections.Generic;

namespace Project.Hub.Config.Entities.Common.Version
{
    /// <summary>
    /// Describe component version for specific environment.
    /// </summary>
    public class ComponentVersion
    {
        public string EnvironmentName { get; set; }
        public string Version { get; set; }

        public ComponentVersion()
        {
        }

        public ComponentVersion(string environment, string version)
        {
            EnvironmentName = environment;
            Version = version;
        }

        public override bool Equals(object obj)
        {
            var version = obj as ComponentVersion;
            return version != null && version.EnvironmentName == EnvironmentName;
        }

        public override int GetHashCode()
        {
            return 627873129 + EqualityComparer<string>.Default.GetHashCode(EnvironmentName);
        }
    }
}
