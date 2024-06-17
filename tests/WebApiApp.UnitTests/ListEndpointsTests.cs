using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Test4Y.WebApiApp.Endpoints;
using Test4Y.WebApiApp.UnitTests.Fixtures;
using Test4Y.WebApiApp.ViewModels;

namespace Test4Y.WebApiApp.UnitTests;

public class ListEndpointsTests(ArticlesApiClientFixture apiClientFixture) : IClassFixture<ArticlesApiClientFixture>
{
    [Fact]
    public async Task GetArticles_ForSpecifiedSection_ReturnsArticles()
    {
        var result = await ListEndpoints.GetArticles("home", apiClientFixture.ApiClient, CancellationToken.None);

        var articles = result.Value;

        Assert.Equal(3, articles.Count());
    }

    [Fact]
    public async Task GetFirstArticle_ForExistingSection_ReturnsFirstArticle()
    {
        var results = await ListEndpoints.GetFirstArticle("home", apiClientFixture.ApiClient, CancellationToken.None);

        var result = results.Result;

        Assert.IsType<Ok<ArticleView>>(result);

        var article = ((Ok<ArticleView>)result).Value;

        Assert.Equal("Title 1", article.Heading);
    }

    [Fact]
    public async Task GetFirstArticle_ForNonExistingSection_ReturnsNoContentResult()
    {
        var results = await ListEndpoints.GetFirstArticle("XXX", apiClientFixture.ApiClient, CancellationToken.None);

        Assert.IsType<NoContent>(results.Result);
    }

    [Fact]
    public async Task GetArticlesByUpdatedDate_ForExistingUpdatedDate_ReturnsFilteredArticles()
    {
        var results = await ListEndpoints.GetArticlesByUpdatedDate(
            "home",
            DateTime.Parse("2019-05-17"),
            apiClientFixture.ApiClient,
            CancellationToken.None);

        var result = results.Result;

        Assert.IsType<Ok<IEnumerable<ArticleView>>>(result);

        var articles = ((Ok<IEnumerable<ArticleView>>)result).Value;

        Assert.Equal(2, articles.Count());
    }

    [Fact]
    public async Task GetArticlesByUpdatedDate_ForNonExistingUpdatedDate_ReturnsNoContentResult()
    {
        var results = await ListEndpoints.GetArticlesByUpdatedDate(
            "home",
            DateTime.Parse("2019-05-19"),
            apiClientFixture.ApiClient,
            CancellationToken.None);

        Assert.IsType<NoContent>(results.Result);
    }
}
