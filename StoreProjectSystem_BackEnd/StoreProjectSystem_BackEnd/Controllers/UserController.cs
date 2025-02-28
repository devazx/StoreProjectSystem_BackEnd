using Microsoft.AspNetCore.Mvc;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Services;

namespace StoreProjectSystem_BackEnd.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        public UserService _userService;

        public UserController(UserService registerService)
        {
            _userService = registerService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(CreateUserDto dto)
        {
            await _userService.RegisterUser(dto);
            return Ok("registered user.");
        }
    }
}
