using Commands.Requests;

namespace Commands.Handlers.Interfaces
{
    public interface IFavoriteCommandHandler
    {
        Task AddFavorite(FavoriteRequest favorite);
    }
}
