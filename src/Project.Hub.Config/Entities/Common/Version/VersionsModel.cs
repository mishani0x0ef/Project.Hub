using System;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.Common.Version
{
    /// <summary>
    /// Describe versions profile of all environments.
    /// </summary>
    public class VersionsModel
    {
        /// <summary>
        /// All available environments.
        /// </summary>
        public HashSet<string> Environments { get; set; }

        /// <summary>
        /// All available components with versions.
        /// </summary>
        public HashSet<Component> Components { get; set; }

        /// <summary>
        /// Date and time when version was last updated.
        /// </summary>
        public DateTimeOffset LastUpdated { get; set; }
    }
}
