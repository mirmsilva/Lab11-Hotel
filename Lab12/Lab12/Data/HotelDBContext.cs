using Microsoft.EntityFrameworkCore;
using Lab12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Hotel_Room> Hotel_Room { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Room_Amenities> Room_Amenities { get; set; }
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "Sea Side Inn", StreetAddress = "808 Ocean Drive", City = "Ocean City", State = "OR", Country = "US", Phone = "253-201-2121", TotalRooms = 75 },
              new Hotel { Id = 2, Name = "Harbor Inn", StreetAddress = "213 Harbor Way", City = "Long Beach", State = "OR", Country = "US", Phone = "253-453-2587", TotalRooms = 75 }
            );
        }
    }
}
