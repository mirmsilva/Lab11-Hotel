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
        //POST - CREATE
        //DTO - In the request
        [HttpPost]
        [Route("api/amenities/")]
        public async Task<ActionResult<Amenity>> PostAmenities(Amenity amenity)
        {
            await _amenity.Create(amenity);

            return CreatedAtAction("GetAmenity", new { id = amenity.Id }, amenity);
        }

        //GET LIST
        [HttpGet]
        [Route("api/amenities/")]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            var list = await _amenity.GetAmenities();
            return Ok(list);
        }

        //GET BY ID
        [HttpGet("{id}")]
        [Route("api/amenities/{id}")]
        public async Task<ActionResult<Amenity>> GetAmenity(int id)
        {
            Amenity amenity = await _amenity.GetAmenity(id);
            return amenity;
        }

        //PUT - UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenity amenity)
        {
            if( id != amenity.Id)
            {
                return BadRequest();
            }
            var updateAmenity = await _amenity.UpdateAmenity(id, amenity);
            return Ok(updateAmenity);

        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenity>> DeleteAmenities(int id)
        {
            await _amenity.Delete(id);

            return NoContent();
        }
    }
}
