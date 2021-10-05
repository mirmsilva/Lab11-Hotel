using Lab12.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Lab12.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState);
        public Task<UserDto> Login(string username, string password);
        public Task<UserDto> GetUserAsync(ClaimsPrincipal principal);
    }
}

