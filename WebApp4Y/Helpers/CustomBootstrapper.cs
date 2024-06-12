using Nancy;
using Nancy.TinyIoc;
using WebApp4Y.Infrastructure;
using WebApp4Y.Models;

namespace WebApp4Y.Helpers;

public class CustomBootstrapper(ApiOptions apiOptions) : DefaultNancyBootstrapper
{
    private readonly IHttpClient4Nyt _httpClient4Nyt = new HttpClient4Nyt(apiOptions);

    protected override void ConfigureApplicationContainer(TinyIoCContainer container)
    {
        base.ConfigureApplicationContainer(container);

        container.Register(_httpClient4Nyt);
    }
}
