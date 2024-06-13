using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApp4Y.Endpoints;
using WebApp4Y.Tests.Fixtures;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Tests;

public class ListEndpointsTests(NytApiClientFixture apiClientFixture) : IClassFixture<NytApiClientFixture>
{
    [Fact]
    public async Task GetArticles_ForSpecifiedSection_ReturnsArticles()
    {
        var result = await ListEndpoints.GetArticles("home", apiClientFixture.ApiClient);

        var articles = result.Value;

        Assert.Equal(3, articles.Length);
    }

    [Fact]
    public async Task GetFirstArticle_ForSpecifiedSection_ReturnsFirstArticle()
    {
        var results = await ListEndpoints.GetFirstArticle("home", apiClientFixture.ApiClient);

        var result = results.Result;

        Assert.IsType<Ok<ArticleView>>(result);

        var article = ((Ok<ArticleView>)result).Value;

        Assert.Equal("Heading 1", article.Heading);
    }

    [Fact]
    public async Task GetArticlesByUpdatedDate_ForSpecifiedSectionAndUpdatedDate_ReturnsFilteredArticles()
    {
        var results = await ListEndpoints.GetArticlesByUpdatedDate(
            "home",
            DateTime.Parse("2019-05-17"),
            apiClientFixture.ApiClient);

        var result = results.Result;

        Assert.IsType<Ok<IEnumerable<ArticleView>>>(result);

        var articles = ((Ok<IEnumerable<ArticleView>>)result).Value.ToArray();

        Assert.Equal(2, articles.Length);
    }
}
