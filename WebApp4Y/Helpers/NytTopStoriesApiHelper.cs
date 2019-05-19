using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApp4Y.Infrastructure;
using WebApp4Y.Models;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Helpers
{
    public class NytTopStoriesApiHelper : ITopStoriesApiHelper
    {
        private readonly IHttpClient4Nyt _httpClient4Nyt;

        public NytTopStoriesApiHelper(IHttpClient4Nyt httpClient4Nyt)
        {
            _httpClient4Nyt = httpClient4Nyt;
        }

        public async Task<ArticleView[]> GetArticlesAsync(string section = "home")
        {
            var response = await _httpClient4Nyt.GetArticlesAsync(section);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var value = await response.Content.ReadAsStringAsync();

            var nytResponse = JsonConvert.DeserializeObject<NytResponse>(value);

            return nytResponse.Results;
        }
    }
}
