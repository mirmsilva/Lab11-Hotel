using Lab12.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab12.Data;


namespace Lab12.Models.Services
{
    public class RoomServices : IRoom
    {
        private HotelDbContext _context;

        //CREATE
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        //GET BY ID
        public async Task<Room> GetRoom(int id)
        {
            return await _context.Room
                .Include(r => r.Amenities)
                .FirstOrDefaultAsync(ra => ra.Id = id);
        }
        
        //GET LIST
        public async Task<List<Room>> GetRooms()
        {
            return await _context.Room
                .Include(r => r.Amenities)
                .FirstOrDefaultAsync();
        }

        //UPDATE
        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room; 
        }

        //DELETE
        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
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
            _context.Entry(room_Amenities).State = EntityState.Deleted
            await _context.SaveChangesAsync();

        }
    }
}
