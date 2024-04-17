using my_movies_api.Models.Domains;
using Newtonsoft.Json;
using my_movies_api.Models.Handlers.Interfaces.Services;

namespace my_movies_api.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly HttpClient _httpClient;
        private const string _baseUrl = "https://omdbapi.com/";
        private const string _apiKey = "87940e02";

        public MoviesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected HttpClient HttpCliente()
        {
            return _httpClient;
        }

        public async Task<Movie> GetMovie(string movie) 
        {
            var response = await HttpCliente()
                //.GetAsync($"{_baseUrl}?s={movie}&apikey={_apiKey}");
                .GetAsync($"{_baseUrl}?type={movie}&apikey={_apiKey}");

            var result = response
                .Content
                .ReadAsStringAsync()
                .Result;

            return JsonConvert.DeserializeObject<Movie>(result);
        }
    }
}
