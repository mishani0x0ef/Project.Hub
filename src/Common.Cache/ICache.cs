using Microsoft.Extensions.Caching.Memory;

namespace Common.Cache
{
    public interface ICache : IMemoryCache
    {
        /// <summary>
        /// Remove all cache entries.
        /// </summary>
        void Clear();
    }
}
