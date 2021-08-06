using Lab12.Models.DTOs;
using Lab12.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lab12.Models.Services
{
    public class IdentityUserService : IUser
    {
        private UserManager<ApplicationUser> userManager;
        //Bring in the tokenService
        private JwtTokenService tokenService;

        //Add Tokenservice to the parameter
        public IdentityUserService(UserManager<ApplicationUser> manager, JwtTokenService jwtTokenService)
        {
            userManager = manager;
            tokenService = jwtTokenService;
        }

        public async Task<UserDto> Login(string username, string password)
        {
            // CHECK IF THE USER IS IN THE DB
            var user = await userManager.FindByNameAsync(username);
            // CHECK IF THE PASSWORD IS LEGIT
            if (await userManager.CheckPasswordAsync(user, password))
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    //Add the token property you added to userDto
                    Token = await tokenService.GetTokenAsync(user, System.TimeSpan.FromMinutes(60))
                };
            }
            return null;
        }
        //ModelStateDictionary allows us to create unlimited key/value pairs to indicate the state of data model
        public async Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };
            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRolesAsync(user, data.Roles);

                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await tokenService.GetTokenAsync(user, System.TimeSpan.FromMinutes(30)),
                    Roles = await userManager.GetRolesAsync(user)
                };
            }
            //dictionary of error keys
            //This is boilerplate
            foreach (var error in result.Errors)
            {
                var errorKey =
                  error.Code.Contains("Password") ? nameof(data.Password) :
                  error.Code.Contains("Email") ? nameof(data.Email) :
                  error.Code.Contains("UserName") ? nameof(data.Username) :
                  "";

                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
        }
        public async Task<UserDto> GetUserAsync(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName
            };
        }

    }
}
