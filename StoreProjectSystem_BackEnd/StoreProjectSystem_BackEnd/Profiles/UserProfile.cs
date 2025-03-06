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
                .ForMember(Prod => Prod.Products,
                opt => opt.MapFrom(prod => prod.StoredProducts));
        }
    }
}
