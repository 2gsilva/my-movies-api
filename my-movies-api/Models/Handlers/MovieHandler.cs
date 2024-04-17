using my_movies_api.Data.Cachings;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Handlers.Interfaces.Handlers;
using my_movies_api.Models.Handlers.Interfaces.Services;
using my_movies_api.Models.Querys.Responses;
using Newtonsoft.Json;

namespace my_movies_api.Models.Handlers
{
    public class MovieHandler : IMovieHandler
    {
        private readonly IMoviesService _service;
        private readonly IMovieCaching _cache;

        public MovieHandler(
            IMoviesService service,
            IMovieCaching cache
        )
        {
            _service = service;
            _cache = cache;
        }

        public async Task<ICollection<GetMoviesResponse>> GetMovies(string movie)
        {
            List<GetMoviesResponse> moviesResponse = new List<GetMoviesResponse>();
            var movies = new Movie();

            var moviesCache = await _cache.GetAsync(movie);

            if (!string.IsNullOrEmpty(moviesCache))
            {
                movies = JsonConvert.DeserializeObject<Movie>(moviesCache);      
            }

            if (movies.Search is null)
            {
                movies = await _service.GetMovie(movie);
                await _cache.SetAsync(movie, JsonConvert.SerializeObject(movies));
            }
            
            foreach (var m in movies.Search)
            {
                moviesResponse.Add(new GetMoviesResponse
                {
                    Id = m.Id,
                    Title = m.Title,
                    Year = m.Year,
                    Poster = m.Poster
                });
            }
            

            return moviesResponse;
        }
    }
}
