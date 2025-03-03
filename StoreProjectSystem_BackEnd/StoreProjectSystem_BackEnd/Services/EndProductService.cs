using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Models;

namespace StoreProjectSystem_BackEnd.Services
{
    public class EndProductService
    {
        private Mapper _mapper;
        private DbContext _dbContext;

        public EndProductService(DbContext dbContext, Mapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task RegisterProduct(CreateEndProductDto dto)
        {
            EndProduct endProduct = _mapper.Map<EndProduct>(dto);
            await _dbContext.AddAsync(endProduct);
            await _dbContext.SaveChangesAsync();

        }
    }
}
