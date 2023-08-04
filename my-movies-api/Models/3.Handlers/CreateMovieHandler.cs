using my_movies_api.Models._3.Handlers._3._1.Interfaces._3._1._2.Repositories;
using my_movies_api.Models.Commands.Requests;
using my_movies_api.Models.Commands.Responses;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Handlers.Interfaces.Handlers;

namespace my_movies_api.Models.Handlers
{
    public class CreateMovieHandler : ICreateMovieHandler
    {
        private readonly IMovieRepository _repository;

        public CreateMovieHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public CreateMovieResponse Handle(CreateMovieRequest command)
        {
            var movie = new Movie
            {
                Titulo = command.Titulo,
                Descricao = command.Descricao
            };

            _repository.Save(movie);

            return new CreateMovieResponse 
            {
                Id = movie.Id,
                Titulo = movie.Titulo,
                Descricao = movie.Descricao
            };
        }
    }
}
