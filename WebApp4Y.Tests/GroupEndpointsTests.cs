using System.Linq;
using System.Threading.Tasks;
using WebApp4Y.Endpoints;
using WebApp4Y.Tests.Fixtures;

namespace WebApp4Y.Tests;

public class GroupEndpointsTests(NytApiClientFixture apiClientFixture) : IClassFixture<NytApiClientFixture>
{
    [Fact]
    public async Task GetArticlesCountsGroupedByUpdatedDate_ArticlesCounts_ReturnsCorrectResult()
    {
        var result = await GroupEndpoints.GetArticlesCountsGroupedByUpdatedDate("home", apiClientFixture.ApiClient);

        var articleGroups = result.Value.ToArray();

        Assert.Equal(2, articleGroups.Length);

        Assert.Equal(1, articleGroups[0].Total);
        Assert.Equal(2, articleGroups[1].Total);
    }
}
