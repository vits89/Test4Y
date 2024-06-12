using System.Text.Json;
using WebApp4Y.Infrastructure;
using WebApp4Y.Models;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Helpers;

public class NytTopStoriesApiHelper(IHttpClient4Nyt httpClient4Nyt) : ITopStoriesApiHelper
{
    public async Task<ArticleView[]> GetArticlesAsync(string section = "home")
    {
        var response = await httpClient4Nyt.GetArticlesAsync(section);

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var value = await response.Content.ReadAsStringAsync();

        var nytResponse = JsonSerializer.Deserialize<NytResponse>(value)!;

        return nytResponse.Results;
    }
}
