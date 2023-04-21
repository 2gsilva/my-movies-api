using my_movies_api.Models;

namespace my_movies_api.Repositories
{
    public class MovieRepository
    {
        public ICollection<Movie> GetAll() 
        {  
            return new List<Movie>()
            {
                new Movie{Id = 1, Title =  "Filme 1"},
                new Movie{Id = 2, Title = "Filme 2"},
                new Movie{Id = 3, Title = "Filme 3"}
            };
        }
    }
}
