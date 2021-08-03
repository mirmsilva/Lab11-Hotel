using Lab12.Data;
using Lab12.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab12.Models.DTOs;

namespace Lab12.Models.Services
{
    public class AmenitiesServices : IAmenities
    {
        private HotelDbContext _context; 

        public AmenitiesServices(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<AmenitiesDto> Create(AmenitiesDto amenities)
        {
            _context.Entry(amenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task<List<AmenitiesDto>> GetAmenities()
        {
            AmenitiesDto amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<AmenitiesDto> GetAmenity(int id)
        {
            AmenitiesDto amenity = await _context.Amenities.FindAsync(id);
            return amenity; 
        }

        public async Task<Amenities> UpdateAmenity(int id, Amenities amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task Delete(int id)
        {
            Amenities amenity= await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
