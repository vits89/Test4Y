using System.Text.Json.Serialization;

namespace WebApp4Y.ViewModels;

public class ArticleView
{
    [JsonPropertyName("title")]
    public string Heading { get; set; } = string.Empty;

    [JsonPropertyName("updated_date")]
    public DateTime Updated { get; set; }

    [JsonPropertyName("short_url")]
    public string? Link { get; set; }
}
