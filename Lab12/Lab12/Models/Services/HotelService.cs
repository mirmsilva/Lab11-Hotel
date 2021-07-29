﻿using Lab12.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab12.Data;

namespace Lab12.Models.Services
{
    public class HotelService : IHotel
    {
        private HotelDbContext _context;

        public HotelService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return hotel;
        }

        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotel.FindAsync(id);
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityStateModified;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id)
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
