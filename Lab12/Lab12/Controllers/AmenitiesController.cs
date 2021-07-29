using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12.Data;
using Lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public AmenitiesController(HotelDbContext context)
        { 
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenities>>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        //GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenities>> GetAmenities(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);

            if (amenity == null)
            {
                return NotFound();
            }
            return amenity;
        }

        //PUT 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }
            _context.Entry(amenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenitiesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        //POST
        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = amenity.Id }, amenity);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool AmenitiesExists(int id)
        {
            return _context.Amenities.Any(e => e.Id == id);
        }
    }
}
