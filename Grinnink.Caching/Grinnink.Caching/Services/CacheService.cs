using ICacheService = Grinnink.Caching.Data.ICache;
using Grinnink.Caching.Protos;
using Grpc.Core;
using System.Text.Json;

namespace Grinnink.Caching.Services;

public class CacheService : Cache.CacheBase
{
    private readonly ICacheService cache;
    private readonly ILogger<CacheService> logger;

    public CacheService(ILogger<CacheService> logger, ICacheService cache)
    {
        ArgumentNullException.ThrowIfNull(cache);

        this.cache = cache;
        this.logger = logger;
    }

    public override Task<CacheReadResponse> ReadCache(CacheReadRequest request, ServerCallContext context)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Key)) ArgumentNullException.ThrowIfNull(request.Key);

            return Task.FromResult(new CacheReadResponse
            {
                Value = JsonSerializer.Serialize(cache.Get(request.Key))
            });
        }
        catch (Exception exception)
        {
            logger.LogError(exception, message: "An exception occurred when reading the cache on key {key}.", request.Key);

            return Task.FromResult(new CacheReadResponse()
            {
                Value = null
            });
        }
    }

    public override Task<CacheWriteResponse> WriteCache(CacheWriteRequest request, ServerCallContext context)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(request.Key)) ArgumentNullException.ThrowIfNull(request.Key);

            return Task.FromResult(new CacheWriteResponse
            {
                Message = "Success"
            });
        }
        catch (Exception exception)
        {
            logger.LogError(
                exception,
                message: "An exception occurred when writing to the cache for key {key} and data {data}.",
                request.Key,
                request.Value
            );

            return Task.FromResult(new CacheWriteResponse()
            {
                Message = null
            });
        }
    }
}
