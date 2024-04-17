namespace my_movies_api.Models.Abstracts
{
    public abstract class MovieAbstract
    {
        public string Title { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Poster { get; set; } = string.Empty;
    }
}
