using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProjectSystem_BackEnd.Data;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Models;
using StoreProjectSystem_BackEnd.Services;

namespace StoreProjectSystem_BackEnd.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        public UserService _userService;
        public IMapper _mapper;
        public StorageContext _storageContext;

        public UserController(UserService registerService, IMapper mapper, StorageContext storageContext)
        {
            _userService = registerService;
            _mapper = mapper;
            _storageContext = storageContext;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(CreateUserDto dto)
        {
            await _userService.RegisterUser(dto);
            return Ok("registered user.");
        }

        [HttpGet("{UserName}")]
        public async Task<ActionResult<ReadUserDto>> FindWithUser(string UserName)
        {
            var result = await _userService.ShowUserWithUser(UserName);
            if (result is null) return NotFound();  
                    
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<ReadUserDto>> AllUsers()
        {
            var result = _userService.ShowAllUsers();
            if (result is null) return NotFound();
            
            return Ok(result.Result);
        }
        [HttpPatch("{NameUser}")]
        public async Task<IActionResult> UpdateUser(string NameUser, JsonPatchDocument<UpdateUserDto> path)
        {
            var userFind = await _storageContext.user.FirstOrDefaultAsync(x => x.UserName == NameUser);

            var updateUser = _mapper.Map<UpdateUserDto>(userFind);

            path.ApplyTo(updateUser);

            if (!TryValidateModel(updateUser)) return ValidationProblem(ModelState);

            _mapper.Map(updateUser, userFind);
            _storageContext.SaveChanges();
            return NoContent();
        }
    }
}
