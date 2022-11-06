namespace Grinnink.Caching.Endpoints.Caching;

public interface ICache
{
    object? Get(string key);

    void Remove(string key);

    void Set(string key, object value);
}
