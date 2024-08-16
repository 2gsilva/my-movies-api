using Microsoft.Extensions.Caching.Distributed;
using my_movies_api.Infrastructure.Data.Cachings.Interfaces;

namespace my_movies_api.Infrastructure.Data.Cachings
{
    public class MovieCaching : IMovieCaching
    {
        private readonly IDistributedCache _cache;

        public MovieCaching(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetAsync(string key)
        {
            return await _cache.GetStringAsync(key) ??
                string.Empty;
        }

        public async Task SetAsync(string key, string value)
        {
            var options = new DistributedCacheEntryOptions
            {
                // Define o tempo de expiração para 30 minutos
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
            };

            await _cache.SetStringAsync(key, value, options);
        }

        public async Task DeleteAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}
