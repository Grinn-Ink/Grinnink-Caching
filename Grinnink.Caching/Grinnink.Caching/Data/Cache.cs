using System.Collections.Concurrent;

namespace Grinnink.Caching.Data;

public class Cache : ICache
{
    private readonly IDictionary<string, object> cache;

    public Cache() => cache = new ConcurrentDictionary<string, object>();

    public object Get(string key) => cache[key];

    public void Set(string key, object value) => cache.Add(key, value);
}
