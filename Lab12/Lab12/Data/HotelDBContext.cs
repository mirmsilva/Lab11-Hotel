using Microsoft.EntityFrameworkCore;
using Lab12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Lab12.Data
{
    //Will now use the Identity Db Context
    public class HotelDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Hotel_Room> Hotel_Rooms { get; set; }
        public DbSet<Room_Amenities> Room_Amenities { get; set; }
        public HotelDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This was boilerplate that we needed to add back in
            base.OnModelCreating(modelBuilder);

            //HOTEL
            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "Sea Side Inn", StreetAddress = "808 Ocean Drive", City = "Ocean City", State = "OR", Country = "US", Phone = "253-201-2121", TotalRooms = 75 },
              new Hotel { Id = 2, Name = "Harbor Inn", StreetAddress = "213 Harbor Way", City = "Long Beach", State = "OR", Country = "US", Phone = "253-453-2587", TotalRooms = 75 });
            //AMENITIES
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { Id = 1, Name = "MiniBar" },
                new Amenity { Id = 2, Name = "Coffee Maker" },
                new Amenity { Id = 3, Name = "AC" },
                new Amenity { Id = 4, Name = "Iron" });
            //ROOM
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Seaside Studio", Size = 0 },
                new Room { Id = 2, Name = "Beach Side Room", Size = 1 },
                new Room { Id = 3, Name = "Sandy Penthouse", Size =2 });
            
            //ROOM AMENITIES
            modelBuilder.Entity<Room_Amenities>().HasKey(
                roomAmenity => new { roomAmenity.RoomId, roomAmenity.AmenityId });

            //HOTEL ROOM
            modelBuilder.Entity<Hotel_Room>().HasKey(
                hotelRoom => new { hotelRoom.HotelId, hotelRoom.RoomId });

            modelBuilder.Entity<Hotel_Room>().HasData(
                new Hotel_Room { HotelId = 1, RoomId = 2, RoomNumber = 100 },
                new Hotel_Room { HotelId = 1, RoomId = 3, RoomNumber = 101 },
                new Hotel_Room { HotelId = 2, RoomId = 2, RoomNumber = 102 });
        }
    }
}
