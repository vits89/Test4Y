using Microsoft.AspNetCore.Http.HttpResults;
using Test4Y.Core.Abstractions.ArticlesApiClient;
using Test4Y.WebApiApp.ViewModels;

namespace Test4Y.WebApiApp.Endpoints;

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
        IArticlesApiClient apiClient,
        CancellationToken cancellationToken)
    {
        var articles = await apiClient.GetArticlesAsync(section, cancellationToken);

        var articlesCounts = articles
            .GroupBy(a => a.UpdatedDate.Date)
            .OrderByDescending(g => g.Key)
            .Select(g => new ArticleGroupByDateView
            {
                Date = g.Key.ToString("yyyy-MM-dd"),
                Total = g.Count()
            });

        return TypedResults.Ok(articlesCounts);
    }
}
