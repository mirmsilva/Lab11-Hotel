using Lab12.Data;
using Lab12.Models.DTOs;
using Lab12.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.Services
{
    public class Hotel_RoomServices : IHotel_Room
    {
        private HotelDbContext _context;
        //CREATE - POST
        //DTO - in the incoming request
        public async Task<Hotel_Room> Create(Hotel_Room hotel_room)
        {
            _context.Entry(hotel_room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel_room;
        }
        //GET BY ID
        public async Task<Hotel_Room> GetHotelRoom(int id)
        {
            Hotel_Room hotel_room = await _context.Hotel_Rooms.FindAsync(id);
            return hotel_room;
        }

        //GET ALL
        public async Task<List<Hotel_Room>> GetHotelRooms()
        {
            var hotel_rooms = await _context.Hotel_Rooms.ToListAsync();
            return hotel_rooms;

        }

        //UPDATE - PUT
        //DTO- In the incoming request
        public async Task<HotelRoomsDto> UpdateHotelRoom(int id, int RoomNumber, Hotel_Room hotel_room)
        {
            _context.Entry(hotel_room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel_room;
        }

        //DELETE
        public async Task Delete(int id)
        {
            Hotel_Room hotel_room = await GetHotelRoom(id);
            _context.Entry(hotel_room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }
    }
}