using Google.Protobuf.WellKnownTypes;
using Grinnink.Caching.Data;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Collections.Concurrent;

namespace Grinnink.Caching.Startup;

public static class ConfigureServicesExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        IServiceCollection services = builder.Services;

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

        // Add services to the container.
        services.AddGrpc();

        // The in-memory cache... lol
        services.AddSingleton<ICache, Cache>();

        return builder.Build();
    }
}
