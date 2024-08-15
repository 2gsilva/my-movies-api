using AutoMapper;
using my_movies_api.Application.Commands.Handlers.Interfaces;
using my_movies_api.Application.Commands.Requests;
using my_movies_api.Domain.Models.Entities;
using my_movies_api.Domain.Models.Interfaces.Repositories;
using my_movies_api.Infrastructure.Data.Cachings.Interfaces;
using Newtonsoft.Json;

namespace my_movies_api.Application.Commands.Handlers
{
    public class FavoriteCommandHandler : IFavoriteCommandHandler
    {
        private readonly IMovieCaching _cache;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IMapper _mapper;

        public FavoriteCommandHandler(
            IMovieCaching cache,
            IFavoriteRepository favoriteRepository,
            IMapper mapper
        )
        {
            _cache = cache;
            _favoriteRepository = favoriteRepository;
            _mapper = mapper;
        }

        public async Task AddFavorite(FavoriteRequest favorite)
        {
            try 
            {
                await _favoriteRepository
                .Save(
                    _mapper.Map<Favorite>(favorite)
                );
            }
            catch (Exception ex)
            {
                throw new($"Erro inesperado: {ex.Message}");
            }

            var favoritesCache = await _cache.GetAsync("favorite");
            
            if(favoritesCache is not null)
               await _cache.DeleteAsync("favorite");
        }
    }
}
