using Microsoft.AspNetCore.Http.HttpResults;
using Test4Y.Core.Abstractions.ArticlesApiClient;
using Test4Y.WebApiApp.ViewModels;

namespace Test4Y.WebApiApp.Endpoints;

public static class ListEndpoints
{
    public static IEndpointRouteBuilder MapListEndpoints(this IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("/list/{section}");

        groupBuilder.MapGet("/", GetArticles);
        groupBuilder.MapGet("/first", GetFirstArticle);
        groupBuilder.MapGet("/{updatedDate:datetime}", GetArticlesByUpdatedDate);

        return builder;
    }

    public static async Task<Ok<IEnumerable<ArticleView>>> GetArticles(
        string section,
        IArticlesApiClient apiClient,
        CancellationToken cancellationToken)
    {
        var articles = await apiClient.GetArticlesAsync(section, cancellationToken);

        return TypedResults.Ok(articles.Select(a => new ArticleView(a)));
    }

    public static async Task<Results<Ok<ArticleView>, NoContent>> GetFirstArticle(
        string section,
        IArticlesApiClient apiClient,
        CancellationToken cancellationToken)
    {
        var articles = await apiClient.GetArticlesAsync(section, cancellationToken);

        var article = articles.FirstOrDefault();

        if (article is not null)
        {
            return TypedResults.Ok(new ArticleView(article));
        }

        return TypedResults.NoContent();
    }

    public static async Task<Results<Ok<IEnumerable<ArticleView>>, NoContent>> GetArticlesByUpdatedDate(
        string section,
        DateTime updatedDate,
        IArticlesApiClient apiClient,
        CancellationToken cancellationToken)
    {
        var articles = await apiClient.GetArticlesAsync(section, cancellationToken);

        var articlesFiltered = articles.Where(a => a.UpdatedDate.Date == updatedDate);

        if (articlesFiltered.Any())
        {
            return TypedResults.Ok(articlesFiltered.Select(a => new ArticleView(a)));
        }

        return TypedResults.NoContent();
    }
}
