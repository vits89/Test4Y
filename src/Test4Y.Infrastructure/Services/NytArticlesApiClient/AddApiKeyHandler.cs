using System.Web;
using Microsoft.Extensions.Options;

namespace Test4Y.Infrastructure.Services.NytArticlesApiClient;

internal class AddApiKeyHandler(IOptions<NytApiSettings> options) : DelegatingHandler
{
    private const string apiKeyParameterName = "api-key";

    private readonly NytApiSettings _apiSettings = options.Value;

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var queryParameters = HttpUtility.ParseQueryString(request.RequestUri!.Query ?? string.Empty);

        if (!queryParameters.AllKeys.Contains(apiKeyParameterName))
        {
            queryParameters.Add(apiKeyParameterName, _apiSettings.Key);

            var uriBuilder = new UriBuilder(request.RequestUri)
            {
                Query = queryParameters.ToString()
            };

            request.RequestUri = uriBuilder.Uri;
        }

        return base.SendAsync(request, cancellationToken);
    }
}
