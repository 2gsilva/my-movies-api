using Querys.Responses;

namespace Querys.Handlers.Interfaces
{
    public interface IMovieQueryHandler
    {
        Task<ICollection<MovieResponse>> GetMovies(string movie);
    }
}
