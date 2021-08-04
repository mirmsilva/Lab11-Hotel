using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models
{
    //This is a join table
    public class Room_Amenities
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }


        //bring in Room & Amenities Objects
        public Room Room { get; set; }
        public Amenity Amenity { get; set; }

    }
}
