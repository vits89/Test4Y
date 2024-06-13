using WebApp4Y.ViewModels;

namespace WebApp4Y.Infrastructure;

public interface INytApiClient
{
    Task<ArticleView[]> GetArticlesAsync(string section = "home");
}
