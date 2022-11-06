using System.Collections.Concurrent;

namespace Grinnink.Caching.Endpoints.Caching;

public class Cache : ICache
{
    private readonly IDictionary<string, object> cache;

    public Cache() => cache = new ConcurrentDictionary<string, object>();

    public object? Get(string key)
    {
        if (cache.TryGetValue(key, out var value))
        {
            return value;
        }

        return null;
    }

    public void Remove(string key)
    {
        if (cache.ContainsKey(key))
        {
            cache.Remove(key);
        }
    }

    public void Set(string key, object value)
    {
        if (cache.ContainsKey(key))
        {
            cache[key] = value;
        }
        else
        {
            cache.Add(key, value);
        }
    }
}
