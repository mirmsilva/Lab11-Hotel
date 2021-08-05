using Lab12.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab12.Data;
using Lab12.Models.DTOs;

namespace Lab12.Models.Services
{
    public class RoomServices : IRoom
    {
        private readonly HotelDbContext _context;
        private readonly IAmenities _amenities;

        public RoomServices(HotelDbContext context, IAmenities amenities)
        {
            _context = context;
            _amenities = amenities;
        }
        //CREATE - POST
        //DTO - RoomsDTO in request
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        //GET ALL
        //DTO - GET RoomDto Objects
        //SHOULD ALSO RETURN THE AMENITIES
        //SHOULD THIS BE ROOM AMENITIES?
        public async Task<List<RoomsDto>> GetRooms()
        {
            return await _context.Rooms
                .Select(room => new RoomsDto
                {
                    ID = room.Id,
                    Name = room.Name,
                    RoomSize = room.Size,
                    Amenities = room.Room_Amenities
                    .Select(ra => new AmenitiesDto
                    {
                        Id = ra.Amenity.Id,
                        Name = ra.Amenity.Name

                    }).ToList()
                }).ToListAsync();
        }

        //GET BY ID
        //SHOULD ALSO RETURN THE AMENITIES
        //SHOULD THIS BE ROOM AMENITIES?
        public async Task<RoomsDto> GetRoom(int id)
        {
            return await _context.Rooms
                .Select(room => new RoomsDto
                {
                    ID = room.Id,
                    Name = room.Name,
                    RoomSize = room.Size,
                    Amenities = room.Room_Amenities
                    .Select(ra => new AmenitiesDto
                    {
                        Id = ra.Amenity.Id,
                        Name = ra.Amenity.Name
                    }).ToList()
                }).FirstOrDefaultAsync(r => r.ID == id);
        }

        //UPDATE - PUT
        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room; 
        }

        //DELETE
        public async Task Delete(int id)
        {
            RoomsDto room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        //ADD AMENITY TO ROOM
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            Room_Amenities room_Amenities = new Room_Amenities()
            {
                RoomId = roomId,
                AmenityId = amenityId
            };
            _context.Entry(room_Amenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
            
        }
        //DELETE AMENITY TO ROOM
        //IDK IF THIS IS RIGHT
        public async Task DeleteAmenityToRoom(int roomId, int amenityId)
        {
            Room_Amenities room_Amenities = new Room_Amenities()
            {
                RoomId = roomId,
                AmenityId = amenityId
            };
            _context.Entry(room_Amenities).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }
    }
}
