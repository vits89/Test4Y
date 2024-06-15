namespace Test4Y.Core.Abstractions.ArticlesApiClient;

public interface IArticlesApiClient
{
    Task<IEnumerable<Article>> GetArticlesAsync(string section, CancellationToken cancellationToken);
}
