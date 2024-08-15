using my_movies_api.Application.Commands.Requests;

namespace my_movies_api.Application.Commands.Handlers.Interfaces
{
    public interface IFavoriteCommandHandler
    {
        Task AddFavorite(FavoriteRequest favorite);
    }
}
