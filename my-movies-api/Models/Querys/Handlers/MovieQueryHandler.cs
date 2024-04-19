using my_movies_api.Data.Cachings.Interfaces;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Interfaces.Services;
using my_movies_api.Models.Querys.Handlers.Interfaces;
using my_movies_api.Models.Querys.Responses;
using Newtonsoft.Json;

namespace my_movies_api.Models.Querys.Handlers
{
    public class MovieQueryHandler : IMovieQueryHandler
    {
        private readonly IMoviesService _service;
        private readonly IMovieCaching _cache;

        public MovieQueryHandler(
            IMoviesService service,
            IMovieCaching cache
        )
        {
            _service = service;
            _cache = cache;
        }

        public async Task<ICollection<MovieResponse>> GetMovies(string movie)
        {
            var moviesResponse = new List<MovieResponse>();
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
                moviesResponse.Add(new MovieResponse
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
