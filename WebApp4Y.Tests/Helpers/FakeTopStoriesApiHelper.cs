using System;
using System.Threading.Tasks;
using WebApp4Y.Helpers;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Tests.Helpers
{
    class FakeTopStoriesApiHelper : ITopStoriesApiHelper
    {
        public Task<ArticleView[]> GetArticlesAsync(string section = "home")
        {
            var articles = new[]
            {
                new ArticleView
                {
                    Heading = "Heading 1",
                    Updated = DateTime.Parse("2019-05-18"),
                    Link = "https://nyti.ms/2VB2HIZ"
                },
                new ArticleView
                {
                    Heading = "Heading 2",
                    Updated = DateTime.Parse("2019-05-17"),
                    Link = "https://nyti.ms/3AB1RNF"
                },
                new ArticleView
                {
                    Heading = "Heading 3",
                    Updated = DateTime.Parse("2019-05-17"),
                    Link = "https://nyti.ms/4FS46SB"
                }
            };

            return Task.FromResult(articles);
        }
    }
}
