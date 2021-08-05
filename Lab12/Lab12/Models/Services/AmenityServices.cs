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
    public class AmenityServices : IAmenities
    {
        private readonly HotelDbContext _context; 

        public AmenityServices(HotelDbContext context)
        {
            _context = context;
        }
        //CREATE - POST
        //DTO - In the request
        public async Task<Amenity> Create(Amenity amenities)
        {
            _context.Entry(amenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenities;
        }
        //GET ALL
        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        //GET BY ID
        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            return amenity; 
        }
        //UPDATE - PUT
        public async Task<Amenity> UpdateAmenity(int id, Amenity amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenities;
        }

        //DELETE
        public async Task Delete(int id)
        {
            Amenity amenity= await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
