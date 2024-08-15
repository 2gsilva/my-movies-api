using AutoMapper;
using my_movies_api.Application.Querys.Handlers.Interfaces;
using my_movies_api.Application.Querys.Responses;
using my_movies_api.Domain.Models.Entities;
using my_movies_api.Domain.Models.Interfaces.Repositories;
using my_movies_api.Infrastructure.Data.Cachings.Interfaces;
using Newtonsoft.Json;

namespace my_movies_api.Application.Querys.Handlers
{
    public class FavoriteQueryHandler : IFavoriteQueryHandler
    {
        private readonly IMovieCaching _cache;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IMapper _mapper;
        private List<Favorite> _favorites;

        public FavoriteQueryHandler(
            IMovieCaching cache,
            IFavoriteRepository favoriteRepository,
            IMapper mapper
        )
        {
            _cache = cache;
            _favoriteRepository = favoriteRepository;
            _mapper = mapper;
            _favorites = new List<Favorite>();
        }

        public async Task<ICollection<FavoriteResponse>> GetFavorites()
        {
            try
            {
                var favoritesCache = await _cache.GetAsync("favorite");

                if (!string.IsNullOrEmpty(favoritesCache))
                {
                    _favorites = JsonConvert.DeserializeObject<List<Favorite>>(favoritesCache);
                }
                else
                {
                    _favorites = (List<Favorite>)await _favoriteRepository.Get();

                    if (_favorites.Any())
                        await _cache.SetAsync("favorite", JsonConvert.SerializeObject(_favorites));
                }
            }
            catch (Exception ex)
            {
                throw new($"Erro inesperado: {ex.Message}");
            }

            return _mapper.Map<ICollection<FavoriteResponse>>(_favorites);
        }
    }
}
