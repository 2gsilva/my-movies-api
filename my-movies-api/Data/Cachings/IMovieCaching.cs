namespace my_movies_api.Data.Cachings
{
    public interface IMovieCaching
    {
        Task SetAsync(string key, string value);
        Task<string> GetAsync(string key);
    }
}
