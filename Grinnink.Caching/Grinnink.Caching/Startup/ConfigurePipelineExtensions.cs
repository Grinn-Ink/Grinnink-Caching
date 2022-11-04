using Grinnink.Caching.Services;
using Microsoft.Extensions.Primitives;

namespace Grinnink.Caching.Startup;

public static class ConfigurePipelineExtensions
{
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        app.MapGrpcService<GreeterService>();
        app.MapGrpcService<CacheService>();

        app.MapGet("/", () => "Do it right, yo.");

        return app;
    }
}
