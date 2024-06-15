using Microsoft.AspNetCore.Http.HttpResults;
using Test4Y.Core.Abstractions.ArticlesApiClient;
using Test4Y.WebApiApp.ViewModels;

namespace Test4Y.WebApiApp.Endpoints;

public static class ArticleEndpoints
{
    public static IEndpointRouteBuilder MapArticleEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGroup("/article")
            .MapGet("/{shortUrl}", GetArticleByShortUrl);

        return builder;
    }

    public static async Task<Results<Ok<ArticleView>, NotFound>> GetArticleByShortUrl(
        string shortUrl,
        IArticlesApiClient apiClient,
        CancellationToken cancellationToken)
    {
        var articles = await apiClient.GetArticlesAsync("home", cancellationToken);

        var article = articles.FirstOrDefault(a => a.ShortUrl?.EndsWith(shortUrl) ?? false);

        if (article is not null)
        {
            return TypedResults.Ok(new ArticleView(article));
        }

        return TypedResults.NotFound();
    }
}
