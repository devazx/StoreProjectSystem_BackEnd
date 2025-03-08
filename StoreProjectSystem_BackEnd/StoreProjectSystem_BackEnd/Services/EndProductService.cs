using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StoreProjectSystem_BackEnd.Data;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Models;

namespace StoreProjectSystem_BackEnd.Services
{
    public class EndProductService
    {
        private IMapper _mapper;
        private StorageContext _storageContext;

        public EndProductService(StorageContext storageContext, IMapper mapper)
        {
            _storageContext = storageContext;
            _mapper = mapper;
        }

        public async Task RegisterProduct(CreateEndProductDto dto)
        {
            EndProduct endProduct = _mapper.Map<EndProduct>(dto);
            await _storageContext.AddAsync(endProduct);
            await _storageContext.SaveChangesAsync();
        }

        public async Task<ReadEndProductDto> GetProductId(Guid id)
        {
            EndProduct endProduct = await _storageContext.endProduct.FirstOrDefaultAsync(x => x.Id == id);

            ReadEndProductDto endProd =  _mapper.Map<ReadEndProductDto>(endProduct);

            if (endProd == null) throw new ApplicationException("Product don`t exist");
            return endProd;

        }
    }
}
