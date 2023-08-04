using my_movies_api.Models.Commands.Requests;
using my_movies_api.Models.Commands.Responses;

namespace my_movies_api.Models.Handlers.Interfaces.Handlers
{
    public interface ICreateMovieHandler
    {
        CreateMovieResponse Handle(CreateMovieRequest command);
    }
}
