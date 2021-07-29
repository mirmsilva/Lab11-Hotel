using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models
{
    //This is a join table
    public class Room_Amenities
    {
        //bring in Room & Amenities Objects
        public Room Rooms { get; set; }
        public Amenities Amenity { get; set; }

        //bring in Amenities ID
        public Amenities Amenity { get; set; }

        //bring in Room ID
        public Room Rooms { get; set; }
    }
}
