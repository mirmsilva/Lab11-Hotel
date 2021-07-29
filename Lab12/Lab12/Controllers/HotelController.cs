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

namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelController(IHotel h)
        {
            //set context to the private context created above
            _hotel = h;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            //add a count to the list
            var list = await _hotel.GetHotels();
            return Ok(list);
        }

        //GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            Hotel hotel = await _hotel.GetHotel(id);
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

            var updateHotel = await _hotel.UpdateHotel(id, hotel);

            return Ok(updateHotel);
        }
        //POST
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await _hotel.Create(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel (int id)
        {
            await _hotel.Delete(id);
            return NoContent();
        }
    }
}