using AutoMapper;
using Microsoft.OpenApi.Extensions;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Models;

namespace StoreProjectSystem_BackEnd.Profiles
{
    public class EndProductProfile : Profile
    {
        public EndProductProfile() 
        {
            CreateMap<CreateEndProductDto, EndProduct>();

            CreateMap<EndProduct, ReadEndProductDto>()
                .ForMember(x => x.TypeProduct, opt => opt.MapFrom(typ => typ.TypeProduct.ToString()));
                
        }
    }
}
