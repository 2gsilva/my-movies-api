using my_movies_api.Domain.Models.Abstracts;

namespace Querys.Responses
{
    public class MovieResponse : MovieAbstract
    {
        public string Id { get; set; } = string.Empty;
    }
}
