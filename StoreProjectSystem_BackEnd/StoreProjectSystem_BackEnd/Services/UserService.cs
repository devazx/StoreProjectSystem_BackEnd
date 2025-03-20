using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreProjectSystem_BackEnd.Data;
using StoreProjectSystem_BackEnd.Data.Dtos;
using StoreProjectSystem_BackEnd.Models;
using System.Collections;
using System.Numerics;

namespace StoreProjectSystem_BackEnd.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserService _userService;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private StorageContext _userDbContext;
        private EndProductService _endProductService;
        private StorageContext _storageContext;
        //private TokenService _tokenService;


        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, StorageContext userDbContext, EndProductService endProductService, StorageContext storageContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _userDbContext = userDbContext;
            _endProductService = endProductService;
            _storageContext = storageContext;
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
            var findUser = await _userManager.FindByNameAsync(userName.ToUpper());

           ReadUserDto readUser = _mapper.Map<ReadUserDto>(findUser);

            if (readUser == null) throw new ApplicationException("User not exist.");
            
            return readUser;
 
        }

        public async Task<IEnumerable> ShowAllUsers()
        {
            var findUsers = _mapper.Map<List<ReadUserDto>>(_userDbContext.user.ToList());

            return findUsers;
        }

        public async Task<bool> UpdateDbUser(UpdateUserDto updateUser, User userFind)
        {
            try
            {
                _mapper.Map(updateUser, userFind);
                _userDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

        }
    }
}
