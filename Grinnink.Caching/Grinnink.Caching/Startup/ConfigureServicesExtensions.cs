using Grinnink.Caching.Endpoints.Caching;

namespace Grinnink.Caching.Startup;

public static class ConfigureServicesExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        IServiceCollection services = builder.Services;

        services.AddSingleton<ICache, Cache>();

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder.Build();
    }
}
