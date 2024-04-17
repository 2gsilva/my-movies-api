using my_movies_api.Models.Commands.Requests;
using my_movies_api.Models.Commands.Responses;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Handlers.Interfaces.Handlers;
using my_movies_api.Models.Handlers.Interfaces.Repositories;

namespace my_movies_api.Models.Handlers.Commands
{
    public class CreateMovieHandler : ICreateMovieHandler
    {
        private readonly IMovieRepository _repository;

        public CreateMovieHandler(
            IMovieRepository repository
        )
        {
            _repository = repository;
        }
    }
}
