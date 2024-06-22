using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test4Y.Core.Abstractions.ArticlesApiClient;

namespace Test4Y.Infrastructure.Services.NytArticlesApiClient;

public static class ServiceCollectionExtensions
{
    public static void AddNytArticlesApiClient(
        this IServiceCollection services,
        Action<NytApiSettings, IConfiguration> configureOptions)
    {
        services
            .AddOptions<NytApiSettings>()
            .Configure(configureOptions);

        services.AddTransient<AddApiKeyHandler>();

        services
            .AddHttpClient<IArticlesApiClient, NytArticlesApiClient>()
            .AddHttpMessageHandler<AddApiKeyHandler>();
    }
}
