using Newtonsoft.Json;

namespace my_movies_api.Models._1.Domains
{
    public class Search
    {
        [JsonProperty("imdbID")]
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Poster { get; set; } = string.Empty;
    }
}
