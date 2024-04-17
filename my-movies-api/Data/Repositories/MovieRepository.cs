using Microsoft.EntityFrameworkCore;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Handlers.Interfaces.Repositories;

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
    }
}
