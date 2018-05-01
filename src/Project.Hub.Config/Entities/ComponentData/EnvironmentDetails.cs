using System.Collections.Generic;

namespace Project.Hub.Config.Entities.ComponentData
{
    public class EnvironmentDetails : BaseConfig
    {
        public string Version { get; set; }
        public string Link { get; set; }

        public override bool Equals(object obj)
        {
            var env = obj as EnvironmentDetails;
            return env != null && env.Name == Name;
        }

        public override int GetHashCode()
        {
            return 627873129 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
