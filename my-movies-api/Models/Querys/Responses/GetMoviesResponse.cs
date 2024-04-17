using my_movies_api.Models.Abstracts;

namespace my_movies_api.Models.Querys.Responses
{
    public class GetMoviesResponse : MovieAbstract
    {
        public string Id { get; set; } = string.Empty;
    }
}
