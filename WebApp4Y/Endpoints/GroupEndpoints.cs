using Microsoft.AspNetCore.Http.HttpResults;
using WebApp4Y.Infrastructure;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Endpoints;

public static class GroupEndpoints
{
    public static IEndpointRouteBuilder MapGroupEndpoints(this IEndpointRouteBuilder builder)
    {
        builder
            .MapGroup("/group")
            .MapGet("/{section}", GetArticlesCountsGroupedByUpdatedDate);

        return builder;
    }

    public static async Task<Ok<IEnumerable<ArticleGroupByDateView>>> GetArticlesCountsGroupedByUpdatedDate(
        string section,
        INytApiClient apiClient)
    {
        var articles = await apiClient.GetArticlesAsync(section);

        var articleViews = articles.GroupBy(a => a.Updated.Date)
            .OrderByDescending(g => g.Key)
            .Select(g => new ArticleGroupByDateView
            {
                Date = g.Key.ToString("yyyy-MM-dd"),
                Total = g.Count()
            });

        return TypedResults.Ok(articleViews);
    }
}
