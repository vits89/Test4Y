using Test4Y.Infrastructure.Services.NytArticlesApiClient;
using Test4Y.WebApiApp.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddNytArticlesApiClient((settings, configuration) =>
{
    configuration.GetSection("NytApi").Bind(settings);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .MapGroup(string.Empty)
    .WithOpenApi()
    .MapHomeEndpoints()
    .MapArticleEndpoints()
    .MapGroupEndpoints()
    .MapListEndpoints();

app.Run();
