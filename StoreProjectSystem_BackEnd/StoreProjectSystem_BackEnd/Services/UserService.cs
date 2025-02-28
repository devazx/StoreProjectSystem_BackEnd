using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreProjectSystem_BackEnd.Data;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Models;
using System.Numerics;

namespace StoreProjectSystem_BackEnd.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private UserDbContext _userDbContext;
        //private TokenService _tokenService;


        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, UserDbContext userDbContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _userDbContext = userDbContext;
        }
        public async Task RegisterUser(CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException("Fail to Register User.");
            }
        }
        public async Task<ReadUserDto> ShowUserWithUser(string userName)
        {
            var findUser = await _userManager.FindByNameAsync(userName);

           ReadUserDto readUser = _mapper.Map<ReadUserDto>(findUser);

            if (readUser == null) throw new ApplicationException("User not exist.");
            else return readUser;
 
        }
    }
}
