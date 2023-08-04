using my_movies_api.Models._3.Handlers._3._1.Interfaces._3._1._2.Repositories;
using my_movies_api.Models.Domains;

namespace my_movies_api.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context) 
        {
            _context = context;
        }

        public void Save(Movie movie)
        {
            _context.Add(movie);
            _context.SaveChanges();
        }
    }
}
