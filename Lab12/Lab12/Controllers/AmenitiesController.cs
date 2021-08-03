using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12.Data;
using Lab12.Models;
using Microsoft.EntityFrameworkCore;
using Lab12.Models.Interfaces;

namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenities _amenity;

        public AmenitiesController(IAmenities a)
        { 
            _amenity = a;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenities>>> GetAmenities()
        {
            var list = await _amenity.GetAmenities();
            return Ok(list);
        }

        //GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenities>> GetAmenity(int id)
        {
            Amenities amenity = await _amenity.GetAmenity(id);
            return amenity;
        }

        //PUT 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenity)
        {
            if( id != amenity.Id)
            {
                return BadRequest();
            }
            var updateAmenity = await _amenity.UpdateAmenity(id, amenity);
            return Ok(updateAmenity);

        }
        //POST
        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenity)
        {
            await _amenity.Create(amenity);

            return CreatedAtAction("GetAmenity", new { id = amenity.Id }, amenity);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
        {
            await _amenity.Delete(id);

            return NoContent();
        }
    }
}
