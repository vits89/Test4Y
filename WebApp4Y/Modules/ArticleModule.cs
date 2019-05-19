using System.Linq;
using Nancy;
using WebApp4Y.Helpers;

namespace WebApp4Y.Modules
{
    public class ArticleModule : NancyModule
    {
        private readonly ITopStoriesApiHelper _nytTopStoriesApiHelper;

        public ArticleModule(ITopStoriesApiHelper nytTopStoriesApiHelper) : base("/article")
        {
            _nytTopStoriesApiHelper = nytTopStoriesApiHelper;

            Get("/{shortUrl}", async parameters =>
            {
                string shortUrl = parameters.shortUrl;

                var articles = await _nytTopStoriesApiHelper.GetArticlesAsync();

                if (articles == null)
                {
                    return HttpStatusCode.InternalServerError;
                }

                var article = articles.FirstOrDefault(a => a.Link?.EndsWith(shortUrl) ?? false);

                if (article != null)
                {
                    return article;
                }

                return HttpStatusCode.NotFound;
            });
        }
    }
}
