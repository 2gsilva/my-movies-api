namespace my_movies_api.Models.Commands.Responses
{
    public class CreateMovieResponse
    {
        public string Title { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Poster { get; set; } = string.Empty;
    }
}
