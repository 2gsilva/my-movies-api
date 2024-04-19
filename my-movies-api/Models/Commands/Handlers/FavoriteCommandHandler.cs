using my_movies_api.Models.Commands.Handlers.Interfaces;
using my_movies_api.Models.Commands.Requests;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Interfaces.Repositories;

namespace my_movies_api.Models.Commands.Handlers
{
    public class FavoriteCommandHandler : IFavoriteCommandHandler
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteCommandHandler(
            IFavoriteRepository favoriteRepository
        )
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task AddFavorite(FavoriteRequest favorite)
        {
            await _favoriteRepository.Save(new Favorite
            {
                Search = favorite.Search,
                Avaliacao = favorite.Avaliacao,
                Descricao = favorite.Descricao
            });
        }
    }
}
