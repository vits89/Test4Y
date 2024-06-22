using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Test4Y.WebApiApp.Endpoints;
using Test4Y.WebApiApp.UnitTests.Fixtures;

namespace Test4Y.WebApiApp.UnitTests;

public class GroupEndpointsTests(ArticlesApiClientFixture apiClientFixture) : IClassFixture<ArticlesApiClientFixture>
{
    [Fact]
    public async Task GetArticlesCountsGroupedByUpdatedDate_ArticlesCounts_ReturnsCorrectResult()
    {
        var result = await GroupEndpoints.GetArticlesCountsGroupedByUpdatedDate(
            "home",
            apiClientFixture.ApiClient,
            CancellationToken.None);

        var articlesCounts = result.Value.ToArray();

        Assert.Equal(2, articlesCounts.Length);

        Assert.Equal(1, articlesCounts[0].Total);
        Assert.Equal(2, articlesCounts[1].Total);
    }
}
