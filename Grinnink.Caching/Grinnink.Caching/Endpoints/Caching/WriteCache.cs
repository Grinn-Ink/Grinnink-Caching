using System.Web;

namespace Grinnink.Caching.Endpoints.Caching;

public class WriteCache : IEndpoint
{
    public Delegate Handler => (string key, object value, ICache cache) =>
    {
        var decodedKey = HttpUtility.UrlDecode(key);

        cache.Set(decodedKey, value);

        return Results.NoContent();
    };

    public HttpMethod Method => HttpMethod.Post;

    public string Name => "WriteCache";

    public string Pattern => "/cache/{key}";
}
