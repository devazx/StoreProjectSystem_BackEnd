using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
                .ForMember(prod => prod.Products,
                opt => opt.MapFrom(prods => prods.StoredProducts));

            CreateMap<User, UpdateUserDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
