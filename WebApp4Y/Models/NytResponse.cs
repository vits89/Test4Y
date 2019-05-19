using System;
using Newtonsoft.Json;
using WebApp4Y.ViewModels;

namespace WebApp4Y.Models
{
    public class NytResponse
    {
        public string Copyright { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("num_results")]
        public int NumResults { get; set; }

        public ArticleView[] Results { get; set; }
        public string Section { get; set; }
        public string Status { get; set; }
    }
}
