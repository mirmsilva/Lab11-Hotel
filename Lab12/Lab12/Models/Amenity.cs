using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List <Room_Amenities> Room_Amenities { get; set; }

 

    }
}
