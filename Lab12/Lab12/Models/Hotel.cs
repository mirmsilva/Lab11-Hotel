using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//import this when you use Required
using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public Hotel_Room Hotel_Room { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int TotalRooms { get; set; }

    }
}
