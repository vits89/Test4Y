using System.Threading.Tasks;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Helpers
{
    public interface ITopStoriesApiHelper
    {
        Task<ArticleView[]> GetArticlesAsync(string section = "home");
    }
}
