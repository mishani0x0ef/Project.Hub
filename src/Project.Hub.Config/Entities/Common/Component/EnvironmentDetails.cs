using System.Collections.Generic;

namespace Project.Hub.Config.Entities.Common.Component
{
    /// <summary>
    /// Details about component on the specific environment.
    /// </summary>
    public class EnvironmentDetails : BaseConfig
    {
        /// <summary>
        /// Current version of the component on the current environment.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Link to website/downloads on the current environment.
        /// </summary>
        public string Link { get; set; }

        public override bool Equals(object obj)
        {
            return obj is EnvironmentDetails env && env.Name == Name;
        }

        public override int GetHashCode()
        {
            return 627873129 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
