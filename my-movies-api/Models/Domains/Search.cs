using Newtonsoft.Json;

namespace my_movies_api.Models.Domains
{
    public class Search
    {
        [JsonProperty("imdbID")]
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Poster { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }
    }
}
