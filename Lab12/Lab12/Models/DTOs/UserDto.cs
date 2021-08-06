using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.DTOs
{
    //This is returned by the service when we register
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
    }
}
