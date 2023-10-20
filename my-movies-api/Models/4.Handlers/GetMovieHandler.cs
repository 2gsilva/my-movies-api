using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._1.Handlers;
using my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._2.Repositories;
using my_movies_api.Models._3.Querys._3._2.Responses;

namespace my_movies_api.Models._3.Handlers
{
    public class GetMoviesHandler : IGetMoviesHandler
    {
        private readonly IMovieRepository _repository;

        public GetMoviesHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public ICollection<GetMoviesResponse> Handle() 
        {
            var movies = _repository.Get();

            List<GetMoviesResponse> moviesResponse = new List<GetMoviesResponse>();

            foreach (var movie in movies) 
            {
                moviesResponse.Add(new GetMoviesResponse 
                {
                    Id = movie.Id,
                    Titulo = movie.Titulo,
                    Descricao = movie.Descricao
                });
            }

            return moviesResponse;
        }
    }
}
