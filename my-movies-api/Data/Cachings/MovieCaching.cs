using Microsoft.Extensions.Caching.Distributed;

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
            await _cache.SetStringAsync(key, value);
        }
    }
}
