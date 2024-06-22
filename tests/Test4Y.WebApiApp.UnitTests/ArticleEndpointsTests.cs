using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Test4Y.WebApiApp.Endpoints;
using Test4Y.WebApiApp.UnitTests.Fixtures;
using Test4Y.WebApiApp.ViewModels;

namespace Test4Y.WebApiApp.UnitTests;

public class ArticleEndpointsTests(ArticlesApiClientFixture apiClientFixture) : IClassFixture<ArticlesApiClientFixture>
{
    [Fact]
    public async Task GetArticleByShortUrl_ForExistingShortUrl_ReturnsFoundArticle()
    {
        var results =
            await ArticleEndpoints.GetArticleByShortUrl("2VB2HIZ", apiClientFixture.ApiClient, CancellationToken.None);

        var result = results.Result;

        Assert.IsType<Ok<ArticleView>>(result);

        var article = ((Ok<ArticleView>)result).Value;

        Assert.Equal("Title 1", article.Heading);
    }

    [Fact]
    public async Task GetArticleByShortUrl_ForNonExistingShortUrl_ReturnsNotFoundResult()
    {
        var results =
            await ArticleEndpoints.GetArticleByShortUrl("XXXXXXX", apiClientFixture.ApiClient, CancellationToken.None);

        Assert.IsType<NotFound>(results.Result);
    }
}
