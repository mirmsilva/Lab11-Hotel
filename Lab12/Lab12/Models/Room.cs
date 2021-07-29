using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class Room
    {
        //This is the PK of each room
        public int Id { get; set; }

        //bring in Room & Amenities Objects
        public Room Rooms { get; set; }
        public Amenities Amenity { get; set; }

        [Required]
        //Name of the hotel room
        public string Name { get; set; }

        [Required]
        public RoomSize Size { get; set;}


    }
}
