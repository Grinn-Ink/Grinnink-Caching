namespace Grinnink.Caching.Endpoints;

public interface IEndpoint
{
    Delegate Handler { get; }

    HttpMethod Method { get; }

    string Name { get; }

    string Pattern { get; }
}
