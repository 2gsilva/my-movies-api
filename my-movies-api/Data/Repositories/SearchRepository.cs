using Microsoft.EntityFrameworkCore;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Interfaces.Repositories;

namespace my_movies_api.Data.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly MovieContext _context;

        public SearchRepository(MovieContext context) 
        {
            _context = context;
        }

        public async Task Save(Search search)
        {
            await _context.AddAsync(search);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Search>> Get()
        {
            return await _context
                .Searches
                .ToListAsync();
        }
    }
}
