using Test4Y.Core.Abstractions.ArticlesApiClient;

namespace Test4Y.WebApiApp.ViewModels;

public class ArticleView(Article article)
{
    public string Heading { get; set; } = article.Title;
    public DateTime Updated { get; set; } = article.UpdatedDate;
    public string? Link { get; set; } = article.ShortUrl;
}
