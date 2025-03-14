using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheService
    {
        private IMemoryCache _cache;
        private readonly HashSet<string> _keys; // Key'leri tutan liste
        public MemoryCacheManager()
        {
            _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
            _keys = new HashSet<string>();
        }
        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }
        public void Add(string key, object data, int duration = 60)
        {
            if(data == null)
            {
                return;
            }

            _cache.Set(key, data, TimeSpan.FromMinutes(duration));
            _keys.Add(key);
        }
        public bool IsAdd(string key)
        {
            return _cache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
            _keys.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            // Burası çalışmayan kod. Eski .NET sürümlerinde çalışıyordu. EntriesCollection Prop artık kullanılmıyormuş.
            /* 
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (cacheEntriesCollectionDefinition == null)
            {
                throw new Exception("EntriesCollection property not found. The implementation might have changed in this .NET version.");
            }
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
            }
            */

            // Yeni kod _key hashset'ini kullanarak çalışıyor.
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = _keys.Where(k => regex.IsMatch(k)).ToList();

            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
                _keys.Remove(key);
            }
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }
    }
}
