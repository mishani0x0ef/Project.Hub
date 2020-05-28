﻿using Project.Hub.Config.Entities.Common;
using Project.Hub.Config.Entities.Common.Version;
using Project.Hub.Config.Entities.v2;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.v1
{
    /// <summary>
    /// Configuration of the specific component (website, downloads).
    /// </summary>
    public class ComponentConfig : BaseConfig, ITagged
    {
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Describe component version resolution options.
        /// </summary>
        public VersionOptions VersionOptions { get; set; }

        /// <summary>
        /// Gets if options to resolve component's version is provided.
        /// </summary>
        public bool IsVersionProvider => !string.IsNullOrWhiteSpace(VersionOptions?.Path);

        public ComponentConfig()
        {
        }

        public ComponentConfig(string name, string description = null)
        {
            Name = name;
            Description = description;
        }
    }
}
