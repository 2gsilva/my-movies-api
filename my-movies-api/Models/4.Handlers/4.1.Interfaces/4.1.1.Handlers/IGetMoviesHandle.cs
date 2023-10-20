using my_movies_api.Models._3.Querys._3._2.Responses;

namespace my_movies_api.Models._4.Handlers._4._1.Interfaces._4._1._1.Handlers
{
    public interface IGetMoviesHandler
    {
        ICollection<GetMoviesResponse> Handle();
    }
}
