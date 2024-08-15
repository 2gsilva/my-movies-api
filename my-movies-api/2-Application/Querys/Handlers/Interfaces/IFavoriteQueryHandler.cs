using my_movies_api.Application.Querys.Responses;

namespace my_movies_api.Application.Querys.Handlers.Interfaces
{
    public interface IFavoriteQueryHandler
    {
        Task<ICollection<FavoriteResponse>> GetFavorites();
    }
}
