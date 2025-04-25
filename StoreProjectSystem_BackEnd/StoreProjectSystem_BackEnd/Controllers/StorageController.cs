using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        /// <summary>
        /// Create a Product connect with a User
        /// </summary>
        /// <param name="createProductDto">Json with information about product</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateEndProductDto createProductDto)
        {
            await _endProductService.RegisterProduct(createProductDto);
            return CreatedAtAction(nameof(GetProductWithId), new { Id = createProductDto.Id }, createProductDto);
        }
        /// <summary>
        /// Return a product with ID parameters
        /// </summary>
        /// <param name="Id">ID is created automatic with GUID</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductWithId(Guid Id)
        {
            var result = await _endProductService.GetProductId(Id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        /// <summary>
        /// Remove Product with Id (Guid)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteProductWithId(Guid Id)
        {
            var result = await _endProductService.DeleteProductId(Id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
