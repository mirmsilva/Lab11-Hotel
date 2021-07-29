using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models
{
    public class Amenities
    {
        public int Id { get; set; }

        public Room_Amenities Room_Amenities { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
