using my_movies_api.Models.Querys.Responses;

namespace my_movies_api.Models.Handlers.Interfaces.Handlers
{
    public interface IGetMoviesHandler
    {
        Task<ICollection<GetMoviesResponse>> Handle(string movie);
    }
}
