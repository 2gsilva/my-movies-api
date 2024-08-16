using Querys.Responses;

namespace Querys.Handlers.Interfaces
{
    public interface IFavoriteQueryHandler
    {
        Task<ICollection<FavoriteResponse>> GetFavorites();
    }
}
