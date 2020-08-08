using System;

namespace Project.Hub.Config.Util
{
    public static class StringExtension
    {
        /// <summary>
        /// Determine whether two string objects has the same value regardless casing (case insensitive).
        /// </summary>
        public static bool EqualsIgnoreCase(this string a, string b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }
    }
}
