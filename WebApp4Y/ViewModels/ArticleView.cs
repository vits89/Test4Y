using System;
using Newtonsoft.Json;

namespace WebApp4Y.ViewModels
{
    public class ArticleView
    {
        [JsonProperty("title")]
        public string Heading { get; set; }

        [JsonProperty("updated_date")]
        public DateTime Updated { get; set; }

        [JsonProperty("short_url")]
        public string Link { get; set; }
    }
}
