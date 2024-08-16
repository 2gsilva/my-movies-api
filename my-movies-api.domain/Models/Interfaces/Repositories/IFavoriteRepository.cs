using my_movies_api.Domain.Models.Entities;

namespace my_movies_api.Domain.Models.Interfaces.Repositories
{
    public interface IFavoriteRepository
    {
        Task Save(Favorite favorite);
        Task<ICollection<Favorite>> Get();
    }
}
