using WebApp4Y.Infrastructure;
using WebApp4Y.Models;

namespace WebApp4Y.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddNytApiClient(
        this IServiceCollection services,
        Action<NytApiSettings, IConfiguration> configureOptions)
    {
        services
            .AddOptions<NytApiSettings>()
            .Configure(configureOptions);

        services.AddTransient<AddApiKeyHandler>();

        services
            .AddHttpClient<INytApiClient, NytApiClient>()
            .AddHttpMessageHandler<AddApiKeyHandler>();
    }
}
