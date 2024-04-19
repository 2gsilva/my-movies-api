using my_movies_api.Models.Domains;

namespace my_movies_api.Models.Interfaces.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovie(string movie);
    }
}
