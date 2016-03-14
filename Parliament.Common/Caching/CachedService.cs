using System;
using Parliament.Common.Caching.Settings;
using Parliament.Common.Interfaces;

namespace Parliament.Common.Caching
{
    public abstract class CachedService
    {
        public virtual bool? CacheEnabled => PrefixedCacheSettings.CacheEnabled;

        public virtual TimeSpan? CacheDuration
        {
            get
            {
                var cacheInMinutes = PrefixedCacheSettings.CacheInMinutes;
                if (!cacheInMinutes.HasValue) return null;
                return TimeSpan.FromMinutes(cacheInMinutes.Value);
            }
        }
     
        protected readonly CacheSettings DefaultCacheSettings;
        protected readonly OptionalCacheSettings PrefixedCacheSettings;

        protected CachedService(IConfigurationBuilder configurationBuilder, string prefix)
        {
            if (string.IsNullOrEmpty(prefix)) throw new MissingFieldException("Prefix must be supplied to use cached service");
            PrefixedCacheSettings = configurationBuilder.GetConfiguration<OptionalCacheSettings>(prefix);
            DefaultCacheSettings = configurationBuilder.GetConfiguration<CacheSettings>("Default");
        }

        public T GetCached<T>(string cacheName)
                       where T : class
        {
            return IsCacheEnabled() ? MemoryCacheManager.GetItem<T>(cacheName) : null;
        }

        public T GetCached<T>(string cacheName, Func<T> setterResponse)
            where T : class
        {
            var cacheUntil = DateTime.Now.Add(CacheDuration ?? TimeSpan.FromMinutes(DefaultCacheSettings.CacheInMinutes));
            return GetCached(cacheName, setterResponse, cacheUntil);
        }

        public T GetCached<T>(string cacheName, Func<T> setterResponse, DateTime cacheUntil)
            where T : class
        {
            var cachedItem = GetCached<T>(cacheName);
            if (cachedItem != null) return cachedItem;

            var uncachedResult = setterResponse();
            
            if (IsCacheEnabled()) MemoryCacheManager.SetItem(cacheName, uncachedResult, cacheUntil);

            return uncachedResult;
        }

        private bool IsCacheEnabled()
        {
            return CacheEnabled ?? DefaultCacheSettings.CacheEnabled;
        }
    }
}