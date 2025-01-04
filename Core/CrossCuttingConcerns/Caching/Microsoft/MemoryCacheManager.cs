﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheService
    {
        protected ObjectCache cache => MemoryCache.Default;
        public T Get<T>(string key)
        {
            return (T)cache[key];
        }
        public void Add(string key, object data, int duration = 60)
        {
            if(data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(duration)
            };

            cache.Add(new CacheItem(key, data), policy);
        }
        public bool IsAdd(string key)
        {
            return cache.Contains(key);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList();
            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }
        public void Clear()
        {
            foreach (var item in cache)
            {
                Remove(item.Key);
            }
        }
    }
}
