using Microsoft.EntityFrameworkCore;
using my_movies_api.Models.Domains;

namespace my_movies_api.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) 
        { }
        
        public DbSet<Movie> Movies { get; set; }
    }
}
