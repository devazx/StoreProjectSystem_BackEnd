using AutoMapper;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Models;

namespace StoreProjectSystem_BackEnd.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReadUserDto>()
                .ForMember(dto => dto.Products,
                opt => opt.MapFrom(dto => dto.StoredProductsId));
        }
    }
}
