using my_movies_api.Domain.Models.Entities;

namespace my_movies_api.Domain.Models.Interfaces.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovie(string movie);
    }
}
