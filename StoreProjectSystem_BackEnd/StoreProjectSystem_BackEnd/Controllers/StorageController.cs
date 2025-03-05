using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreProjectSystem_BackEnd.Data;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Models;
using StoreProjectSystem_BackEnd.Services;

namespace StoreProjectSystem_BackEnd.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StorageController : ControllerBase
    {
        private StorageContext _storageContext;
        private IMapper _mapper;
        private EndProductService _endProductService;

        public StorageController(IMapper mapper, StorageContext storageContext, EndProductService endProductService)
        {
            _mapper = mapper;
            _storageContext = storageContext;
            _endProductService = endProductService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateEndProductDto createProductDto)
        {
            await _endProductService.RegisterProduct(createProductDto);
            return CreatedAtAction(nameof(GetProductWithId), new { Id = createProductDto.Id }, createProductDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetProductWithId(string Id)
        {
            var result = await _endProductService.GetProductId(Id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
