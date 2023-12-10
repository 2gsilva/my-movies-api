using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._1.Handlers;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._2.Repositories;
using my_movies_api.Models._3.Querys._3._2.Responses;
using my_movies_api.Data.Cachings;
using my_movies_api.Models.Domains;
using Newtonsoft.Json;

namespace my_movies_api.Models._3.Handlers
{
    public class GetMoviesHandler : IGetMoviesHandler
    {
        private readonly IMovieRepository _repository;
        private readonly IMovieCaching _cache;

        public GetMoviesHandler(
            IMovieRepository repository, 
            IMovieCaching cache
        )
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<ICollection<GetMoviesResponse>> Handle() 
        {
            var movies = await _repository.Get(); 
                
            List<GetMoviesResponse> moviesResponse = new List<GetMoviesResponse>();

            foreach (var movie in movies) 
            {
                moviesResponse.Add(new GetMoviesResponse 
                {
                    Id = movie.Id,
                    Titulo = movie.Titulo,
                    Descricao = movie.Descricao
                });
            }

            return moviesResponse;
        }

        public async Task<GetMovieResponse> Handle(string id)
        {
            Movie? movie;

            var moviesCache = await _cache.GetAsync(id.ToString());

            if (!string.IsNullOrEmpty(moviesCache))
            {
                movie = JsonConvert.DeserializeObject<Movie>(moviesCache);
            }
            else
            {
                movie = await _repository.Get(id);

                if (movie is not null)
                    await _cache.SetAsync(id.ToString(), JsonConvert.SerializeObject(movie));
            }

            return movie is not null ?
            new GetMovieResponse()
            {
                Id = movie.Id,
                Titulo = movie.Titulo,
                Descricao = movie.Descricao
            } :
            null;
        }
    }
}
