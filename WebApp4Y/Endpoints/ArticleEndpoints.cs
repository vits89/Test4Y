using Microsoft.AspNetCore.Http.HttpResults;
using WebApp4Y.Infrastructure;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Endpoints;

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
        INytApiClient apiClient)
    {
        var articles = await apiClient.GetArticlesAsync();

        var article = articles.FirstOrDefault(a => a.Link?.EndsWith(shortUrl) ?? false);

        if (article is not null)
        {
            return TypedResults.Ok(article);
        }

        return TypedResults.NotFound();
    }
}
