using System.Text.Json.Serialization;

namespace Test4Y.Infrastructure.Services.NytArticlesApiClient;

internal class Response
{
    [JsonPropertyName("results")]
    public Article[] Articles { get; set; } = [];
}
