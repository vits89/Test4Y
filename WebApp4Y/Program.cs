using WebApp4Y.Endpoints;
using WebApp4Y.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNytApiClient((settings, configuration) =>
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
