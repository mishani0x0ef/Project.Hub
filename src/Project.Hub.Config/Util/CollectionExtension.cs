using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Hub.Config.Util
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Find distinct values based on particular property.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source">Collection to get distinct values from.</param>
        /// <param name="keySelector">Function to resolve property that should has unique value within resulting collection.</param>
        /// <returns>Collection that contains only unique value of specific property.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source
                .GroupBy(keySelector)
                .Select(g => g.First());
        }
    }
}
