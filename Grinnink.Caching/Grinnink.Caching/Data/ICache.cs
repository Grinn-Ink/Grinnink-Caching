namespace Grinnink.Caching.Data;

public interface ICache
{
    object Get(string key);

    void Set(string key, object value);
}
