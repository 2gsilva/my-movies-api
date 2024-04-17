using my_movies_api.Models.Domains;

namespace my_movies_api.Models.Handlers.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task Save(Movie movie);
        Task<ICollection<Movie>> Get();
        //Task<Movie> Get(string id);
    }
}
