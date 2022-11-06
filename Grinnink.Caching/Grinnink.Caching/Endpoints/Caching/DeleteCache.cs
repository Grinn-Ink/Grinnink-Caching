using System.Web;

namespace Grinnink.Caching.Endpoints.Caching;

public class DeleteCache : IEndpoint
{
    public Delegate Handler => (string key, ICache cache) =>
    {
        var decodedKey = HttpUtility.UrlDecode(key);

        cache.Remove(decodedKey);

        return Results.NoContent();
    };

    public HttpMethod Method => HttpMethod.Delete;

    public string Name => "DeleteCache";

    public string Pattern => "/cache/{key}";
}
