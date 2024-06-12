namespace WebApp4Y.Infrastructure;

public interface IHttpClient4Nyt
{
    Task<HttpResponseMessage> GetArticlesAsync(string section);
}
