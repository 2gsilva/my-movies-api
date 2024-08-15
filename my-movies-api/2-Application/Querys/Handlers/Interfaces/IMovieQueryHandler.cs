using my_movies_api.Application.Querys.Responses;

namespace my_movies_api.Application.Querys.Handlers.Interfaces
{
    public interface IMovieQueryHandler
    {
        Task<ICollection<MovieResponse>> GetMovies(string movie);
    }
}
