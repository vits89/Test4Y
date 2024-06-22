using System;
using System.Threading;
using Moq;
using Test4Y.Core.Abstractions.ArticlesApiClient;

namespace Test4Y.WebApiApp.UnitTests.Fixtures;

public class ArticlesApiClientFixture
{
    public IArticlesApiClient ApiClient { get; }

    public ArticlesApiClientFixture()
    {
        var articles = new[]
        {
            new Article
            {
                Title = "Title 1",
                UpdatedDate = DateTime.Parse("2019-05-18"),
                ShortUrl = "https://nyti.ms/2VB2HIZ"
            },
            new Article
            {
                Title = "Title 2",
                UpdatedDate = DateTime.Parse("2019-05-17"),
                ShortUrl = "https://nyti.ms/3AB1RNF"
            },
            new Article
            {
                Title = "Title 3",
                UpdatedDate = DateTime.Parse("2019-05-17"),
                ShortUrl = "https://nyti.ms/4FS46SB"
            }
        };

        var apiClientMock = new Mock<IArticlesApiClient>();

        apiClientMock
            .Setup(c => c.GetArticlesAsync("home", It.IsAny<CancellationToken>()))
            .ReturnsAsync(articles);
        apiClientMock
            .Setup(c => c.GetArticlesAsync(It.Is((string s) => s != "home"), It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);

        ApiClient = apiClientMock.Object;
    }
}
