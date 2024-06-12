using Nancy.Owin;
using WebApp4Y.Helpers;
using WebApp4Y.Models;

var builder = WebApplication.CreateBuilder(args);

var apiOptions = ConfigurationBinder.Get<ApiOptions>(builder.Configuration.GetSection("Api"))!;

var app = builder.Build();

app.UseOwin(b => b.UseNancy(o => o.Bootstrapper = new CustomBootstrapper(apiOptions)));

app.Run();
