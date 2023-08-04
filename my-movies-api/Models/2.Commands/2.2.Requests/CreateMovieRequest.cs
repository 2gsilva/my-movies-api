namespace my_movies_api.Models.Commands.Requests
{
    public class CreateMovieRequest
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
