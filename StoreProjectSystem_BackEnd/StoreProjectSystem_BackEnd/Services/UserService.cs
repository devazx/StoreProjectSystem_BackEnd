using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        //private TokenService _tokenService;


        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, StorageContext userDbContext, EndProductService endProductService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _userDbContext = userDbContext;
            _endProductService = endProductService;

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
            else return readUser;
 
        }

        public async Task<IEnumerable> ShowAllUsers()
        {
            var findUsers = _mapper.Map<List<ReadUserDto>>(_userDbContext.Users.ToList());

            return findUsers;
        }

        public async Task<ReadUserDto> UpdateProductUser(string userName, Guid ProductId)
        {
            var findUser = await ShowUserWithUser(userName.ToUpper());

            var findProduct = await _endProductService.GetProductId(ProductId);

            ReadEndProductDto findProdDto = _mapper.Map<ReadEndProductDto>(findProduct);

            findUser.Products.Add(findProdDto);

            return findUser;
        }

    }
}
