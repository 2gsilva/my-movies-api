using Microsoft.EntityFrameworkCore;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Interfaces.Repositories;

namespace my_movies_api.Data.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly MovieContext _context;

        public FavoriteRepository(MovieContext context) 
        {
            _context = context;
        }

        public async Task Save(Favorite favorite)
        {
            await _context.AddAsync(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Favorite>> Get()
        {
            return await _context
                .Favorites
                .Include(f => f.Search)
                .ToListAsync();
        }
    }
}
