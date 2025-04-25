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

        /// <summary>
        /// Create a new User in database
        /// </summary>
        /// <param name="dto"> json necessary for create a User</param>
        /// <returns>IActionResult</returns>
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto dto)
        {
            await _userService.RegisterUser(dto);
            return CreatedAtAction(nameof(FindWithUser),
                new { username = dto.UserName }, dto);
        }
        /// <summary>
        /// Service for Find User
        /// </summary>
        /// <param name="UserName"> User Name is necessary for find in database</param>
        /// <returns>IActionResult</returns>
        [HttpGet("{UserName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReadUserDto>> FindWithUser(string UserName)
        {
            var result = await _userService.ShowUserWithUser(UserName);
            if (result is null) return NotFound();

            return Ok(result);
        }
        /// <summary>
        /// Service for return all users in database
        /// </summary>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReadUserDto>> AllUsers()
        {
            var result = _userService.ShowAllUsers();
            if (result is null) return NotFound();

            return Ok(result.Result);
        }
        /// <summary>
        /// Patch for edit a information at User, but utilized a param in JsonPatch
        /// </summary>
        /// <param name="NameUser"></param>
        /// <param name="patch"></param>
        /// <returns></returns>
        [HttpPatch("{NameUser}")]
        public async Task<IActionResult> UpdateUser(string NameUser, JsonPatchDocument<UpdateUserDto> patch)
        {
            var userFind = _storageContext.user.FirstOrDefault(x => x.UserName == NameUser);

            var updateUser = _mapper.Map<UpdateUserDto>(userFind);

            patch.ApplyTo(updateUser, ModelState);

            if (!TryValidateModel(updateUser)) return ValidationProblem(ModelState);

            var result = _userService.UpdateDbUser(updateUser, userFind);
            if (result.Equals(false)) return NoContent();
            return NoContent();
        }
        /// <summary>
        /// Find User with User for Delete in database
        /// </summary>
        /// <param name="UserName">String for location name in db</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string UserName)
        {

            var result = _userService.DeleteUserService(UserName);

            if(result is null) return NoContent();
            return Ok();
        }
    }
}
