using Test4Y.Infrastructure.Services.NytArticlesApiClient;
using Test4Y.WebApiApp.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNytArticlesApiClient((settings, configuration) =>
{
    configuration.GetSection("NytApi").Bind(settings);
});

var app = builder.Build();

app
    .MapHomeEndpoints()
    .MapArticleEndpoints()
    .MapGroupEndpoints()
    .MapListEndpoints();

app.Run();
