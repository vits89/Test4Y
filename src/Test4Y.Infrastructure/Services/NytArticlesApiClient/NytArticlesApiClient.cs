using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Test4Y.Core.Abstractions.ArticlesApiClient;
using CoreArticle = Test4Y.Core.Abstractions.ArticlesApiClient.Article;

namespace Test4Y.Infrastructure.Services.NytArticlesApiClient;

public class NytArticlesApiClient : IArticlesApiClient
{
    private readonly HttpClient _httpClient;

    public NytArticlesApiClient(HttpClient httpClient, IOptions<NytApiSettings> options)
    {
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(options.Value.Url);
    }

    public async Task<IEnumerable<CoreArticle>> GetArticlesAsync(
        string section,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetFromJsonAsync<Response>($"{section}.json", cancellationToken);

        var articles = response?.Articles
            ?.Select(a => new CoreArticle
            {
                Title = a.Title,
                UpdatedDate = a.UpdatedDate,
                ShortUrl = a.ShortUrl
            })
            ?.ToArray();

        return articles ?? [];
    }
}
