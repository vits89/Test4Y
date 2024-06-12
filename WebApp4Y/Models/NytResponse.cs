using System.Text.Json.Serialization;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Models;

public class NytResponse
{
    public string Copyright { get; set; } = string.Empty;

    [JsonPropertyName("last_updated")]
    public DateTime LastUpdated { get; set; }

    [JsonPropertyName("num_results")]
    public int NumResults { get; set; }

    public ArticleView[] Results { get; set; } = [];
    public string Section { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
