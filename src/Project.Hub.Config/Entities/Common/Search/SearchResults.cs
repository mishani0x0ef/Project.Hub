using Project.Hub.Config.Entities.v2;
using System.Linq;

namespace Project.Hub.Config.Entities.Common.Search
{
    /// <summary>
    /// Represents results of search.
    /// </summary>
    public class SearchResults
    {
        /// <summary>
        /// Text that was used for search.
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Results that matches search text.
        /// </summary>
        public HubConfiguration Results { get; set; }

        /// <summary>
        /// Total count of results that match search text.
        /// </summary>
        public int Count =>
            Results.Environments.Count()
            + Results.Websites.Count()
            + Results.Apis.Count()
            + Results.Downloads.Count();

        /// <summary>
        /// Define if search has any results.
        /// </summary>
        public bool HasResults => Count > 0;
    }
}
