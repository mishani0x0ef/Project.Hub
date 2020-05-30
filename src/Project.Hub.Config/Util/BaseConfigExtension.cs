using Project.Hub.Config.Entities.Common;
using System;

namespace Project.Hub.Config.Util
{
    public static class BaseConfigExtension
    {
        /// <summary>
        /// Check if base configuration contains search query.
        /// </summary>
        /// <param name="config">Configuration to check.</param>
        /// <param name="query">Text to search for.</param>
        /// <returns>True if configuration contains search query.</returns>
        public static bool IsMatchSearch(this BaseConfig config, string query) =>
            config != null && config.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
