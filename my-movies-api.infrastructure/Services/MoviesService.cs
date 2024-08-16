using Newtonsoft.Json;
using my_movies_api.Domain.Models.Interfaces.Services;
using my_movies_api.Domain.Models.Entities;

namespace my_movies_api.Infrastructure.Services
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
                .GetAsync($"{_baseUrl}?s={movie}&apikey={_apiKey}");

            var result = response
                .Content
                .ReadAsStringAsync()
                .Result;

            return JsonConvert.DeserializeObject<Movie>(result);
        }

        //public async Task<Movie> GetMovie(string movie)
        //{
        //    var search = new List<Search>();

        //    search.Add(new Search
        //    {
        //        Id = "tt0096697 ",
        //        Title = "The Simpsons: Hit & Run",
        //        Year = "2003",
        //        Poster = "https://m.media-amazon.com/images/M/MV5BNmM3YzIwYzEtOWYxNS00NGE4LWJlOTQtNDZhMjNlZjFhNmU1XkEyXkFqcGdeQXVyMjYwNDA2MDE@._V1_SX300.jpg"
        //    });

        //    return new Movie
        //    {
        //        TotalResults = "1",
        //        Search = search,
        //        Response = "true"               
        //    };
        //}
    }
}
