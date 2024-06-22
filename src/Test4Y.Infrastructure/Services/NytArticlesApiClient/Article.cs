using System.Text.Json.Serialization;

namespace Test4Y.Infrastructure.Services.NytArticlesApiClient;

internal class Article
{
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("updated_date")]
    public DateTime UpdatedDate { get; set; }

    [JsonPropertyName("short_url")]
    public string? ShortUrl { get; set; }
}
