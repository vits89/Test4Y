using Microsoft.AspNetCore.Http.HttpResults;
using WebApp4Y.Infrastructure;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Endpoints;

public static class ListEndpoints
{
    public static IEndpointRouteBuilder MapListEndpoints(this IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("/list/{section}");

        groupBuilder.MapGet("/", GetArticles);
        groupBuilder.MapGet("/first", GetFirstArticle);
        groupBuilder.MapGet("/{updatedDate:datetime(yyyy-MM-dd)}", GetArticlesByUpdatedDate);

        return builder;
    }

    public static async Task<Ok<ArticleView[]>> GetArticles(string section, INytApiClient apiClient)
    {
        var articles = await apiClient.GetArticlesAsync(section);

        return TypedResults.Ok(articles);
    }

    public static async Task<Results<Ok<ArticleView>, NoContent>> GetFirstArticle(
        string section,
        INytApiClient apiClient)
    {
        var articles = await apiClient.GetArticlesAsync(section);

        if (articles.Length > 0)
        {
            return TypedResults.Ok(articles.First());
        }

        return TypedResults.NoContent();
    }

    public static async Task<Results<Ok<IEnumerable<ArticleView>>, NoContent>> GetArticlesByUpdatedDate(
        string section,
        DateTime updatedDate,
        INytApiClient apiClient)
    {
        var articles = await apiClient.GetArticlesAsync(section);

        var articlesFiltered = articles.Where(a => a.Updated.Date == updatedDate);

        if (articlesFiltered.Any())
        {
            return TypedResults.Ok(articlesFiltered);
        }

        return TypedResults.NoContent();
    }
}
