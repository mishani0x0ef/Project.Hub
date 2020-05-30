using Project.Hub.Config.Entities.Common;
using System;

namespace Project.Hub.Config.Util
{
    public static class BaseConfigExtension
    {
        /// <summary>
        /// Check if base configuration contains search text.
        /// </summary>
        /// <param name="config">Configuration to check.</param>
        /// <param name="searchText">Text to search for.</param>
        /// <returns>True if configuration contains search text.</returns>
        public static bool IsMatchSearch(this BaseConfig config, string searchText) =>
            config != null && config.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
