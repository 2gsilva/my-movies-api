namespace my_movies_api.Domain.Models.Entities
{
    public class Movie
    {
        public ICollection<Search>? Search { get; set; }
        public string TotalResults { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
    }
}
