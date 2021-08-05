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
        private readonly HotelDbContext _context;
        //CREATE - POST
        //DTO - in the incoming request
        public async Task<Hotel_Room> Create(Hotel_Room hotel_room)
        {
            _context.Entry(hotel_room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel_room;
        }
        //GET BY ID
        //DTO
        public async Task<HotelRoomsDto> GetHotelRoom(int hotelId, int roomId)
        {
            return await _context.Hotel_Rooms
                .Select(hr => new HotelRoomsDto
                {
                    HotelId = hr.HotelId,
                    RoomId = hr.RoomId,
                    Room = hr.Room.Hotel_Room
                    .Select(r => new RoomsDto
                    {
                        ID = r.Room.Id,
                        Name = r.Room.Name,
                        RoomSize = r.Room.Size,
                        Amenities = r.Room.Room_Amenities
                        .Select(ra => new AmenitiesDto
                        {
                            Id = ra.Amenity.Id,
                            Name = ra.Amenity.Name
                        }).ToList()
                    }).FirstOrDefault(r => r.ID == roomId)
                }).FirstOrDefaultAsync(hr => hr.HotelId == hotelId && hr.RoomId == roomId);
            
        }

        //GET ALL
        //DTO
        public async Task<List<HotelRoomsDto>> GetHotelRooms()
        {
            return await _context.Hotel_Rooms
            .Select(hr => new HotelRoomsDto
            {
                HotelId = hr.HotelId,
                RoomId = hr.RoomId,
                Room = new RoomsDto
                {
                    ID = hr.Room.Id,
                    Name = hr.Room.Name,
                    RoomSize = hr.Room.Size
                }
            }).ToListAsync();

        }

        //UPDATE - PUT
        //DTO- In the incoming request
        public async Task<Hotel_Room> UpdateHotelRoom(int id, int RoomNumber, Hotel_Room hotel_room)
        {
            _context.Entry(hotel_room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel_room;
        }

        //DELETE
        public async Task Delete(int hotelId, int roomId)
        {
            HotelRoomsDto hotel_room = await GetHotelRoom(hotelId, roomId);
            _context.Entry(hotel_room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }
    }
}