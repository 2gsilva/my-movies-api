using AutoMapper;
using my_movies_api.Application.Commands.Requests;
using my_movies_api.Application.Querys.Responses;
using my_movies_api.Domain.Models.Entities;

namespace my_movies_api._4_Infrastructure.Cross_Cutting.AutoMapperConfigs
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
