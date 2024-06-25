using my_movies_api.Data.Cachings.Interfaces;
using my_movies_api.Models.Domains;
using my_movies_api.Models.Interfaces.Repositories;
using my_movies_api.Models.Querys.Handlers.Interfaces;
using my_movies_api.Models.Querys.Responses;
using Newtonsoft.Json;

namespace my_movies_api.Models.Querys.Handlers
{
    public class FavoriteQueryHandler : IFavoriteQueryHandler
    {
        private readonly IMovieCaching _cache;
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteQueryHandler(
            IMovieCaching cache,
            IFavoriteRepository favoriteRepository
        )
        {
            _cache = cache;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<ICollection<FavoriteResponse>> GetFavorites()
        {
            var favoritesResponse = new List<FavoriteResponse>();
            var favorites = new List<Favorite>();

            try
            {
                var favoritesCache = await _cache.GetAsync("favorite");

                if (!string.IsNullOrEmpty(favoritesCache))
                {
                    favorites = JsonConvert.DeserializeObject<List<Favorite>>(favoritesCache);
                }
                else 
                {
                    favorites = (List<Favorite>)await _favoriteRepository.Get();

                    if(favorites.Any())
                        await _cache.SetAsync("favorite", JsonConvert.SerializeObject(favorites));
                }
            }
            catch(Exception ex)
            {
                throw new($"Erro inesperado: {ex.Message}");
            }

            foreach (var f in favorites)
            {
                favoritesResponse.Add(new FavoriteResponse
                {
                    Id = f.Id,
                    Search = f.Search,
                    Avaliacao = f.Avaliacao,
                    Descricao = f.Descricao
                });
            }

            return favoritesResponse;
        }
    }
}
