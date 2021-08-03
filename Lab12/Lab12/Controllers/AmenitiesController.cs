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
using Lab12.Models.DTOs;

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

        //GET LIST
        [HttpGet("api/amenities/")]
        public async Task<ActionResult<IEnumerable<AmenitiesDto>>> GetAmenities()
        {
            var list = await _amenity.GetAmenities();
            return Ok(list);
        }

        //GET BY ID
        [HttpGet("api/amenities/{id}")]
        public async Task<ActionResult<AmenitiesDto>> GetAmenity(int id)
        {
            AmenitiesDto amenity = await _amenity.GetAmenity(id);
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
        [HttpPost("api/amenities/")]
        public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenity)
        {
            await _amenity.Create(amenity);

            return CreatedAtAction("GetAmenity", new { id =amenity.Id }, amenity);
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
