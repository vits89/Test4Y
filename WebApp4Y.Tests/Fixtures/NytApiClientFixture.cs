using System;
using Moq;
using WebApp4Y.Infrastructure;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Tests.Fixtures;

public class NytApiClientFixture
{
    public INytApiClient ApiClient { get; }

    public NytApiClientFixture()
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

        var apiClientMock = new Mock<INytApiClient>();

        apiClientMock
            .Setup(c => c.GetArticlesAsync(It.IsAny<string>()))
            .ReturnsAsync(articles);

        ApiClient = apiClientMock.Object;
    }
}
