using my_movies_api.Models.Querys.Responses;

namespace my_movies_api.Models.Handlers.Interfaces.Handlers
{
    public interface IMovieHandler
    {
        Task<ICollection<GetMoviesResponse>> GetMovies(string movie);
    }
}
