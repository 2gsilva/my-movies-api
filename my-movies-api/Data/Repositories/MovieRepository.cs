using Microsoft.EntityFrameworkCore;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._2.Repositories;
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

        public async Task Save(Movie movie)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Movie>> Get()
        {
            return await _context
                .Movies
                .ToListAsync();
        }

        public async Task<Movie> Get(string id)
        {
            return await _context
                .Movies
                .FirstOrDefaultAsync( e => e.Id.ToString() == id);
        }
    }
}
