using my_movies_api.Models.Commands.Requests;

namespace my_movies_api.Models.Commands.Handlers.Interfaces
{
    public interface IFavoriteCommandHandler
    {
        Task AddFavorite(FavoriteRequest favorite);
    }
}
