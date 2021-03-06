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
    public class HotelService : IHotel
    {
        private readonly HotelDbContext _context;

        public HotelService(HotelDbContext context)
        {
            _context = context;
        }
        
        //CREATE - POST
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return hotel;
        }

        //GET ALL
        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        //GET BY ID
        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }
        //GET BY NAME
        public async Task<HotelSmsDto> GetHotelByName(string name)
        {
            return await _context.Hotels
                .Select(hr => new HotelSmsDto
                {
                    Name = hr.Name,
                    StreetAddress = hr.StreetAddress
                }).FirstOrDefaultAsync(hr => hr.Name == name);
        }

        //UPDATE - PUT
        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }

        //DELETE
        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
