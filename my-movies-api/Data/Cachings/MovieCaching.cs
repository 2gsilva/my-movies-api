using Microsoft.Extensions.Caching.Distributed;
using my_movies_api.Data.Cachings.Interfaces;

namespace my_movies_api.Data.Cachings
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
                // Define o tempo de expiração para 30 segundos a partir de agora
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30)
            };

            await _cache.SetStringAsync(key, value, options);
        }
    }
}
