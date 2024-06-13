namespace WebApp4Y.Endpoints;

public static class HomeEndpoints
{
    public static IEndpointRouteBuilder MapHomeEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/", () => "Hello World!");

        return builder;
    }
}
