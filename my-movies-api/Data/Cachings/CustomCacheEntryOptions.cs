using Microsoft.Extensions.Caching.Distributed;

namespace my_movies_api.Data.Cachings
{
    public class CustomCacheEntryOptions : DistributedCacheEntryOptions
    {
        public CustomCacheEntryOptions()
        {
            // Definindo o tempo de expiração padrão
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30); 
        }
    }
}
