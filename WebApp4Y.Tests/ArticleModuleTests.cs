using System.Threading.Tasks;
using Nancy;
using Nancy.Testing;
using WebApp4Y.Helpers;
using WebApp4Y.Modules;
using WebApp4Y.Tests.Helpers;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Tests;

public class ArticleModuleTests
{
    private readonly Browser _browser;

    public ArticleModuleTests()
    {
        ITopStoriesApiHelper fakeTopStoriesApiHelper = new FakeTopStoriesApiHelper();

        _browser = new Browser(c =>
        {
            c.Module<ArticleModule>();
            c.Dependency(fakeTopStoriesApiHelper);
        }, c => c.Accept("application/json"));
    }

    [Fact]
    public async Task Test1()
    {
        var response = await _browser.Get("/article/2VB2HIZ");

        var article = response.Body.DeserializeJson<ArticleView>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        Assert.Equal("Heading 1", article.Heading);
    }

    [Fact]
    public async Task Test2()
    {
        var response = await _browser.Get("/article/XXXXXXX");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
