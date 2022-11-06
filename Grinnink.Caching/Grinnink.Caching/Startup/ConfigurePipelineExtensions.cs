namespace Grinnink.Caching.Startup;

public static class ConfigurePipelineExtensions
{
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        //app.UseApiKey();

        app.ConfigureEndpoints();

        return app;
    }
}
