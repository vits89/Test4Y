using Nancy;
using WebApp4Y.Helpers;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Modules;

public class GroupModule : NancyModule
{
    private readonly ITopStoriesApiHelper _nytTopStoriesApiHelper;

    public GroupModule(ITopStoriesApiHelper nytTopStoriesApiHelper) : base("/group")
    {
        _nytTopStoriesApiHelper = nytTopStoriesApiHelper;

        Get("/{section}", async parameters =>
        {
            string section = parameters.section;

            var articles = await _nytTopStoriesApiHelper.GetArticlesAsync(section);

            if (articles is null)
            {
                return HttpStatusCode.InternalServerError;
            }

            return articles
                .GroupBy(a => a.Updated.Date)
                .OrderByDescending(g => g.Key)
                .Select(g => new ArticleGroupByDateView
                {
                    Date = g.Key.ToString("yyyy-MM-dd"),
                    Total = g.Count()
                });
        });
    }
}
