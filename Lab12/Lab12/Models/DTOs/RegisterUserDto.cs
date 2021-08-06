using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.DTOs
{
    //This will be used by the register method to create an account
    public class RegisterUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
   
        public string PhoneNumber { get; set; }

        //John said not to put this here but I'm not sure where else to put it
        public List<string> Roles { get; set; }
    }
}
