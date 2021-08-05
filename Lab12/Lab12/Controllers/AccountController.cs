using Lab12.Models.DTOs;
using Lab12.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUser userService;

        public AccountController(IUser service)
        {
            userService = service;
        }

        //REGISTER AS A USER
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterUserDto data)
        {
            var user = await userService.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        //LOGIN HERE
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto data)
        {
            var user = await userService.Login(data.Username, data.Password);
            //If the user does not exsist let them know
            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }


    }
}
