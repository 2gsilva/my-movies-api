namespace my_movies_api.Infrastructure.Data.Cachings.Interfaces
{
    public interface IMovieCaching
    {
        Task SetAsync(string key, string value);
        Task<string> GetAsync(string key);
        Task DeleteAsync(string key);
    }
}
