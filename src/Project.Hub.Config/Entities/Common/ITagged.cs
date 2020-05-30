using System.Collections.Generic;

namespace Project.Hub.Config.Entities.Common
{
    /// <summary>
    /// Define that implementer has tags.
    /// </summary>
    public interface ITagged
    {
        /// <summary>
        /// Collection of tags that describes current item.
        /// </summary>
        IEnumerable<string> Tags { get; set; }
    }
}
