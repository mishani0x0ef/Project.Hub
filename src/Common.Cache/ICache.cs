using Microsoft.Extensions.Caching.Memory;

namespace Common.Cache
{
    public interface ICache : IMemoryCache
    {
        /// <summary>
        /// Remove all cahce entries.
        /// </summary>
        void Clear();
    }
}
