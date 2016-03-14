using System;
using System.Runtime.Caching;
using Parliament.Common.Extensions;

namespace Parliament.Common.Caching
{
    public static class MemoryCacheManager
    {
        private static readonly ObjectCache _memoryCache = MemoryCache.Default;

        public static T GetItem<T>(string key) 
            where T : class
        {
            return _memoryCache[key] as T;
        }

        public static void SetItem<T>(string key, T obj, DateTime? expires = null) 
            where T : class
        {
            _memoryCache.AddOrGetExisting(key, obj, expires ?? DateTime.Now.AddHours(1));
        }

        public static void ClearAll()
        {
            _memoryCache.ForEach(x => _memoryCache.Remove(x.Key));            
        }

        public static DateTime GetCacheExpiry(int expiryHours)
        {
            return DateTime.Now.AddHours(expiryHours);
        }
    }
}