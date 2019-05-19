using System;
using System.Linq;
using Nancy;
using WebApp4Y.Helpers;

namespace WebApp4Y.Modules
{
    public class ListModule : NancyModule
    {
        private readonly ITopStoriesApiHelper _nytTopStoriesApiHelper;

        public ListModule(ITopStoriesApiHelper nytTopStoriesApiHelper) : base("/list/{section}")
        {
            _nytTopStoriesApiHelper = nytTopStoriesApiHelper;

            Get("/", async parameters =>
            {
                string section = parameters.section;

                var articles = await _nytTopStoriesApiHelper.GetArticlesAsync(section);

                if (articles != null)
                {
                    return articles;
                }

                return HttpStatusCode.InternalServerError;
            });

            Get("/first", async parameters =>
            {
                string section = parameters.section;

                var articles = await _nytTopStoriesApiHelper.GetArticlesAsync(section);

                if (articles == null)
                {
                    return HttpStatusCode.InternalServerError;
                }

                var article = articles.FirstOrDefault();

                if (article != null)
                {
                    return article;
                }

                return HttpStatusCode.NotFound;
            });

            Get("/{updatedDate:datetime(yyyy-MM-dd)}", async parameters =>
            {
                string section = parameters.section;
                DateTime updatedDate = parameters.updatedDate;

                var articles = await _nytTopStoriesApiHelper.GetArticlesAsync(section);

                if (articles != null)
                {
                    return articles.Where(a => a.Updated.Date == updatedDate);
                }

                return HttpStatusCode.InternalServerError;
            });
        }
    }
}
