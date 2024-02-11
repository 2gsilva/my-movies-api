using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._1.Handlers;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._2.Repositories;
using my_movies_api.Models._3.Querys._3._2.Responses;
using my_movies_api.Data.Cachings;
using my_movies_api.Models.Domains;
using Newtonsoft.Json;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._3.Services;

namespace my_movies_api.Models._3.Handlers
{
    public class GetMoviesHandler : IGetMoviesHandler
    {
        private readonly IMoviesService _service;
        private readonly IMovieCaching _cache;

        public GetMoviesHandler(
            IMoviesService service, 
            IMovieCaching cache
        )
        {
            _service = service;
            _cache = cache;
        }

        public async Task<ICollection<GetMoviesResponse>> Handle(string movie)
        {
            List<GetMoviesResponse> moviesResponse = new List<GetMoviesResponse>();
            var movies = new Movie();

            var moviesCache = await _cache.GetAsync(movie);

            if (!string.IsNullOrEmpty(moviesCache))
            {
                movies = JsonConvert.DeserializeObject<Movie>(moviesCache);
            }
            else
            {
                movies = await _service.GetMovie(movie);

                if (movie is not null)
                    await _cache.SetAsync(movie, JsonConvert.SerializeObject(movies));
            }

            if (movies.Search is not null) 
            {
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
            }
            
            return moviesResponse;
        }
    }
}
