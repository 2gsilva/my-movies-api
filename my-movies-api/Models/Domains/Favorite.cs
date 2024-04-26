using my_movies_api.Models.Abstracts;
using my_movies_api.Models.Enums;

namespace my_movies_api.Models.Domains
{
    public class Favorite : Core
    {
        public Search? Search { get; set; }
        public Avaliacao? Avaliacao { get; set; }
        public string? Descricao { get; set; } = string.Empty; 
    }
}
