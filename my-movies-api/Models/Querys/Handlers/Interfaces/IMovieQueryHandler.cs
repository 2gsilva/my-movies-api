using my_movies_api.Models.Querys.Responses;

namespace my_movies_api.Models.Querys.Handlers.Interfaces
{
    public interface IMovieQueryHandler
    {
        Task<ICollection<MovieResponse>> GetMovies(string movie);
    }
}
