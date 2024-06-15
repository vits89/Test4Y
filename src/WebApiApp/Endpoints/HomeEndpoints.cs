namespace Test4Y.WebApiApp.Endpoints;

public static class HomeEndpoints
{
    public static IEndpointRouteBuilder MapHomeEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/", () => TypedResults.Json("Hello World!"));

        return builder;
    }
}
