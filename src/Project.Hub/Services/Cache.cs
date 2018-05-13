using Common.Cache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Project.Hub.Services
{
    public class Cache : ICache
    {
        private readonly IMemoryCache _cache;
        private HashSet<object> keys;

        private readonly object _clearLock = new object();

        public Cache(IOptions<MemoryCacheOptions> options)
        {
            _cache = new MemoryCache(options);
            keys = new HashSet<object>();
        }

        public ICacheEntry CreateEntry(object key)
        {
            var entry = _cache.CreateEntry(key);
            keys.Add(key);
            return entry;
        }

        public void Remove(object key)
        {
            _cache.Remove(key);
            keys.Remove(key);
        }

        public bool TryGetValue(object key, out object value)
        {
            return _cache.TryGetValue(key, out value);
        }

        public void Clear()
        {
            lock (_clearLock)
            {
                for (int i = keys.Count - 1; i >= 0; i--)
                {
                    Remove(keys.ElementAt(i));
                }
            }
        }

        public void Dispose()
        {
            _cache.Dispose();
            keys = null;
        }
    }
}
