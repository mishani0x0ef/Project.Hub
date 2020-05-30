using Project.Hub.Config.Entities.Common;
using System.Linq;

namespace Project.Hub.Config.Util
{
    public static class TaggedExtension
    {
        /// <summary>
        /// Check if item contains specific tag.
        /// </summary>
        /// <param name="tagged">Item to check.</param>
        /// <param name="tag">Tag name to search for.</param>
        /// <returns>True if item contains specific tag.</returns>
        public static bool ContainsTag(this ITagged tagged, string tag)
        {
            return tagged?.Tags != null && !string.IsNullOrWhiteSpace(tag) && tagged.Tags.Contains(tag);
        }
    }
}
