using my_movies_api.Models.Querys.Responses;

namespace my_movies_api.Models.Querys.Handlers.Interfaces
{
    public interface IFavoriteQueryHandler
    {
        Task<ICollection<FavoriteResponse>> GetFavorites();
    }
}
