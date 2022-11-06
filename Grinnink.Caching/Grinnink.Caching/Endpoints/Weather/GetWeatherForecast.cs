using Grinnink.Caching.Startup;

namespace Grinnink.Caching.Endpoints.Weather;

public class GetWeatherForecast : IEndpoint
{
    private readonly string[] summaries;
    public GetWeatherForecast()
    {
        summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }

    public Delegate Handler => () =>
    {
        WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateTime.Now.AddDays(index),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();

        return forecast;
    };

    public HttpMethod Method => HttpMethod.Get;

    public string Name => "GetWeatherForecast";

    public string Pattern => "/weatherforecast";
}
