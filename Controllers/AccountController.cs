using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YJKBooks.Contexts;
using YJKBooks.Entities;
using YJKBooks.Extensions;
using YJKBooks.Models;
using YJKBooks.Services;

namespace YJKBooks.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<User> userManager, TokenService tokenService, ApplicationDbContext  context)
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsersDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user==null || ! await _userManager.CheckPasswordAsync(user,loginDto.Password))
                return Unauthorized();
            
            var userBasket = await RetrieveFavouriteBookList(loginDto.Username);
            var anonBasket = await RetrieveFavouriteBookList(Request.Cookies["userId"]);

            if (anonBasket != null) 
            {
                //overwrite userBasket to anonBasket (add item from anonbasket to user)
                if (userBasket != null) 
                {
                    userBasket.Items.AddRange(anonBasket.Items);
                } 
                else
                {
                    //change the userId in the anon to user name, anonbasket transfer to user 
                    anonBasket.UserId = user.UserName;
                    _context.FavouriteBookList.Add(anonBasket);
                }
                               
                Response.Cookies.Delete("userId");
                await _context.SaveChangesAsync();
            }
           userBasket = await RetrieveFavouriteBookList(user.UserName);
            //once we have successfully login generate a token and return userDto
            return new UsersDto
            {
                Email= user.Email,
                Token =await  _tokenService.GenerateToken(user),
                FavouriteBooks = userBasket?.MapFavouriteBookListToDto()
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = new User{UserName = registerDto.Username, Email = registerDto.Email};

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }
            await _userManager.AddToRoleAsync(user, "Member");

            return StatusCode(201);
        }

        // this will protect the route at the end point
        [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult<UsersDto>> GetCurrentUser()
        {
            //User object we can access in _userManager (not the entity)
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userBasket = await RetrieveFavouriteBookList(User.Identity.Name);

            return new UsersDto
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user),
                FavouriteBooks = userBasket?.MapFavouriteBookListToDto()
            };
        }

        private async Task<FavouriteBookList> RetrieveFavouriteBookList(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                Response.Cookies.Delete("userId");
                return null;
            }

            return await _context.FavouriteBookList
                .Include(i => i.Items)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync(x => x.UserId == userId);
            //first or defaultwill return the first one match the userid 
            //or if there is no match return null
        }

       
    }
}