using Project.Hub.Config.Entities.Common;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.v2
{
    /// <summary>
    /// Component that present on different environments and has info about each of them.
    /// </summary>
    /// <typeparam name="T">Type of environment info.</typeparam>
    public class EnvironmentalComponent<T> : BaseConfig, ITagged where T : IEnvironmentable
    {
        /// <summary>
        /// List of environments current component is present on.
        /// </summary>
        public IEnumerable<T> Environments { get; set; }

        public string FaviconFallback { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
