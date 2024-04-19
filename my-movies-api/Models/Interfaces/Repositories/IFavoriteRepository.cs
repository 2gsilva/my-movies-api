using my_movies_api.Models.Domains;

namespace my_movies_api.Models.Interfaces.Repositories
{
    public interface IFavoriteRepository
    {
        Task Save(Favorite favorite);
        Task<ICollection<Favorite>> Get();
    }
}
