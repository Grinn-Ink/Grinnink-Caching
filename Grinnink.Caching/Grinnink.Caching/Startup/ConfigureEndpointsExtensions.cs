using Grinnink.Caching.Endpoints;

namespace Grinnink.Caching.Startup;

public static class ConfigureEndpointsExtensions
{
    public static WebApplication ConfigureEndpoints(this WebApplication app)
    {
        Type endpointType = typeof(IEndpoint);

        IEnumerable<Type> endpointTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => !type.IsInterface && type.IsAssignableTo(endpointType));

        foreach (Type type in endpointTypes)
        {
            var endpoint = Activator.CreateInstance(type) as IEndpoint;

            ArgumentNullException.ThrowIfNull(endpoint);

            switch (endpoint.Method)
            {
                case Endpoints.HttpMethod.Delete:
                    app.MapDelete(endpoint.Pattern, endpoint.Handler).WithName(endpoint.Name);
                    break;

                case Endpoints.HttpMethod.Get:
                    app.MapGet(endpoint.Pattern, endpoint.Handler).WithName(endpoint.Name);
                    break;

                case Endpoints.HttpMethod.Post:
                    app.MapPost(endpoint.Pattern, endpoint.Handler).WithName(endpoint.Name);
                    break;

                case Endpoints.HttpMethod.Put:
                    app.MapPut(endpoint.Pattern, endpoint.Handler).WithName(endpoint.Name);
                    break;
            }
        }

        return app;
    }
}

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}