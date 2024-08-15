using Microsoft.EntityFrameworkCore;
using my_movies_api.Domain.Models.Entities;

namespace my_movies_api.Infrastructure.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        { }

        public DbSet<Search> Searches { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }
}
