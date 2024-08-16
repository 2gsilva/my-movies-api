using AutoMapper;
using Commands.Requests;
using my_movies_api.Domain.Models.Entities;
using Querys.Responses;

namespace AutoMapperConfigs
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MovieResponse, Search>().ReverseMap();
            CreateMap<FavoriteResponse, Favorite>().ReverseMap();
            CreateMap<FavoriteRequest, Favorite>().ReverseMap();
        }
    }
}
