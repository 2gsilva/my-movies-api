using my_movies_api.Domain.Models.Entities;

namespace my_movies_api.Domain.Models.Interfaces.Repositories
{
    public interface ISearchRepository
    {
        Task Save(Search search);
        Task<ICollection<Search>> Get();
    }
}
