using my_movies_api.Models.Domains;

namespace my_movies_api.Models.Interfaces.Repositories
{
    public interface ISearchRepository
    {
        Task Save(Search search);
        Task<ICollection<Search>> Get();
    }
}
