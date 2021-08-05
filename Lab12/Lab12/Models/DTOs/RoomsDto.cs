using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.DTOs
{
    public class RoomsDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RoomSize { get; set; }
        public List<AmenitiesDto> Amenities { get; set; }
    }
}
