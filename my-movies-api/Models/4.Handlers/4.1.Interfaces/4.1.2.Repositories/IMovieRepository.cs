using my_movies_api.Models.Domains;

namespace my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._2.Repositories
{
    public interface IMovieRepository
    {
        Task Save(Movie movie);
        Task<ICollection<Movie>> Get();
        //Task<Movie> Get(string id);
    }
}
    