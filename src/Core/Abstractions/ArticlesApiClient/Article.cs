namespace Test4Y.Core.Abstractions.ArticlesApiClient;

public class Article
{
    public string Title { get; set; } = string.Empty;
    public DateTime UpdatedDate { get; set; }
    public string? ShortUrl { get; set; }
}
