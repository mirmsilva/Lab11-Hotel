using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models
{
    public class Hotel_Room
    {
        // bring in room & Hotel objects
        public Room Rooms { get; set; }
        public Hotel Hotels { get;set; }

        //create Space for the Hotel ID
        [Required]
        public int HotelId { get; set; }

        [Required]
        public int RoomNumber { get; set; }
        
        //create Space for the Room ID
        [Required]
        public int RoomId { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public bool PetFriendly { get; set; }




    }
}
