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
using Lab12.Models.Interfaces;
using Lab12.Models.DTOs;

namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IHotel _hotel;

        public HotelController(IHotel h, HotelDbContext c)
        {
            //set context to the private context created above
            _hotel = h;
            _context = c;
        }
        //POST - CREATE
        [HttpPost("api/Hotel")]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await _hotel.Create(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }
        //GET ALL
        [HttpGet("api/Hotels")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            //add a count to the list
            var list = await _hotel.GetHotels();
            return Ok(list);
        }

        //GET BY ID
        [HttpGet("api/Hotels/{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            Hotel hotel = await _hotel.GetHotel(id);
            return hotel;
        }

        //PUT - UDPATE
        [HttpPut("api/id/{id}/Hotel/{hotel}")]
        public async Task<IActionResult> PutHotel( int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            var updateHotel = await _hotel.UpdateHotel(id, hotel);

            return Ok(updateHotel);
        }

        //DELETE
        [HttpDelete("api/Hotels/{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel (int id)
        {
            await _hotel.Delete(id);
            return NoContent();
        }
    }
}