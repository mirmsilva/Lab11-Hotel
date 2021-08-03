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
        public string Name { get; set; }
        public RoomSize Size { get; set; }

        public List<Hotel_Room> Hotel_Room { get; set; }
        public List<Room_Amenities> Room_Amenities { get; set; }

    }
}
