using AutoMapper;
using my_movies_api.Application.Querys.Handlers.Interfaces;
using my_movies_api.Application.Querys.Responses;
using my_movies_api.Domain.Models.Entities;
using my_movies_api.Domain.Models.Interfaces.Services;
using my_movies_api.Infrastructure.Data.Cachings.Interfaces;
using Newtonsoft.Json;

namespace my_movies_api.Application.Querys.Handlers
{
    public class MovieQueryHandler : IMovieQueryHandler
    {
        private readonly IMoviesService _service;
        private readonly IMovieCaching _cache;
        private readonly IMapper _mapper;
        private Movie _movie;

        public MovieQueryHandler(
            IMoviesService service,
            IMovieCaching cache,
            IMapper mapper
        )
        {
            _service = service;
            _cache = cache;
            _mapper = mapper;
            _movie = new Movie();
        }

        public async Task<ICollection<MovieResponse>> GetMovies(string movie)
        {
            try
            {
                var moviesCache = await _cache.GetAsync(movie);

                if (!string.IsNullOrEmpty(moviesCache))
                {
                    _movie = JsonConvert.DeserializeObject<Movie>(moviesCache);
                }

                if (_movie?.Search is null)
                {
                    _movie = await _service.GetMovie(movie);
                    await _cache.SetAsync(movie, JsonConvert.SerializeObject(_movie));
                }
            }
            catch (Exception ex)
            {
                throw new($"Erro inesperado: {ex.Message}");
            }

            return _mapper.Map<ICollection<MovieResponse>>(_movie?.Search);
        }
    }
}
