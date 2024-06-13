using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApp4Y.Endpoints;
using WebApp4Y.Tests.Fixtures;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Tests;

public class ArticleEndpointsTests(NytApiClientFixture apiClientFixture) : IClassFixture<NytApiClientFixture>
{
    [Fact]
    public async Task GetArticleByShortUrl_ForExistingShortUrl_ReturnsFoundArticle()
    {
        var results = await ArticleEndpoints.GetArticleByShortUrl("2VB2HIZ", apiClientFixture.ApiClient);

        var result = results.Result;

        Assert.IsType<Ok<ArticleView>>(result);

        var articleView = ((Ok<ArticleView>)result).Value;

        Assert.Equal("Heading 1", articleView.Heading);
    }

    [Fact]
    public async Task GetArticleByShortUrl_ForNonExistingShortUrl_ReturnsNotFoundResult()
    {
        var results = await ArticleEndpoints.GetArticleByShortUrl("XXXXXXX", apiClientFixture.ApiClient);

        Assert.IsType<NotFound>(results.Result);
    }
}
