using System.Net.Http;
using System.Threading.Tasks;
using WebApp4Y.Models;

namespace WebApp4Y.Infrastructure
{
    public class HttpClient4Nyt : IHttpClient4Nyt
    {
        private readonly ApiOptions _apiOptions;

        public HttpClient4Nyt(ApiOptions apiOptions)
        {
            _apiOptions = apiOptions;
        }

        public async Task<HttpResponseMessage> GetArticlesAsync(string section)
        {
            var uri = $"{_apiOptions.Url}/{section}.json?api-key={_apiOptions.Key}";

            return await SendGetRequestAsync(uri);
        }

        private async Task<HttpResponseMessage> SendGetRequestAsync(string uri)
        {
            using (var client = new HttpClient())
            {
                return await client.GetAsync(uri);
            }
        }
    }
}
