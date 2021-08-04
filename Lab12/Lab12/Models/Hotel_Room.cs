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
        public List<Room> Room { get; set; }
        public Hotel Hotel { get;set; }

        public int RoomNumber { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
       
        //public decimal Rate { get; set; }
        //public bool PetFriendly { get; set; }




    }
}
