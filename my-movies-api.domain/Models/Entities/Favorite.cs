using my_movies_api.Domain.Models.Abstracts;
using my_movies_api.Domain.Models.Enums;

namespace my_movies_api.Domain.Models.Entities
{
    public class Favorite : Core
    {
        public Search? Search { get; set; }
        public Avaliacao? Avaliacao { get; set; }
        public string? Descricao { get; set; } = string.Empty;
    }
}
