using Microsoft.Extensions.Options;
using WebApp4Y.Models;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Infrastructure;

public class NytApiClient : INytApiClient
{
    private readonly NytApiSettings _apiSettings;

    private readonly HttpClient _httpClient;

    public NytApiClient(HttpClient httpClient, IOptions<NytApiSettings> options)
    {
        _apiSettings = options.Value;

        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(_apiSettings.Url);
    }

    public async Task<ArticleView[]> GetArticlesAsync(string section = "home")
    {
        var response = await _httpClient.GetFromJsonAsync<NytResponse>($"/{section}.json");

        return response?.Results ?? [];
    }
}
