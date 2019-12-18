using Nancy;
using Nancy.Testing;
using Xunit;
using WebApp4Y.Helpers;
using WebApp4Y.Modules;
using WebApp4Y.ViewModels;
using WebApp4Y.Tests.Helpers;

namespace WebApp4Y.Tests
{
    public class GroupModuleTests
    {
        private readonly Browser _browser;

        public GroupModuleTests()
        {
            ITopStoriesApiHelper fakeTopStoriesApiHelper = new FakeTopStoriesApiHelper();

            _browser = new Browser(c =>
            {
                c.Module<GroupModule>();
                c.Dependency(fakeTopStoriesApiHelper);
            }, c => c.Accept("application/json"));
        }

        [Fact]
        public async void Test1()
        {
            var response = await _browser.Get("/group/home");

            var articleGroups = response.Body.DeserializeJson<ArticleGroupByDateView[]>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.Equal(2, articleGroups.Length);

            Assert.Equal(1, articleGroups[0].Total);
            Assert.Equal(2, articleGroups[1].Total);
        }
    }
}
