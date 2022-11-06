using System.Web;

namespace Grinnink.Caching.Endpoints.Caching;

public class ReadCache : IEndpoint
{
    public Delegate Handler => (string key, ICache cache) =>
    {
        var decodedKey = HttpUtility.UrlDecode(key);

        var data = cache.Get(decodedKey);

        return Results.Ok(data);
    };

    public HttpMethod Method => HttpMethod.Get;

    public string Name => "ReadCache";

    public string Pattern => "/cache/{key}";
}
