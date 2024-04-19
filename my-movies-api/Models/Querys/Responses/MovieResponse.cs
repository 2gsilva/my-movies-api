using my_movies_api.Models.Abstracts;

namespace my_movies_api.Models.Querys.Responses
{
    public class MovieResponse : MovieAbstract
    {
        public string Id { get; set; } = string.Empty;
    }
}
