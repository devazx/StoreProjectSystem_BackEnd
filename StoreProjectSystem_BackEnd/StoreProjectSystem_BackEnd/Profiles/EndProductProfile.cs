using AutoMapper;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Models;

namespace StoreProjectSystem_BackEnd.Profiles
{
    public class EndProductProfile : Profile
    {
        public EndProductProfile() 
        {
            CreateMap<CreateEndProductDto, EndProduct>();
        }
    }
}
