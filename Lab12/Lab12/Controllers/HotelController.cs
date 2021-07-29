using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//added these three
using Lab12.Data;
using Lab12.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        //create a private context variable. why?idk...
        private readonly HotelDbContext _context;

        public HotelController(HotelDbContext context)
        {
            //set context to the private context created above
            _context = context;
        }

        //GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            return await _context.Hotel.ToListAsync();
        }

        //GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);

            if(hotel == null)
            {
                return NotFound();
            }
            return hotel;
        }

        //PUT 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel( int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel (int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.Id == id);
        }
    }
}