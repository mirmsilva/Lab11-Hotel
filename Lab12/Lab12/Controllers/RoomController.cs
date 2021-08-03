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
    public class RoomController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomController(IRoom r) 
        {
            _room = r; 
        }

        //GET LIST
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {   //used this before I had created services & Interfaces
            //return await _context.Room.ToListAsync();
            var list = await _room.GetRooms();
            return Ok(list);
        }

        //GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            Room room = await _room.GetRoom(id);
            return room; 
        }

        //PUT 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            var updateRoom = await _room.UpdateRoom(id, room);
            return Ok(updateRoom);
        }
        //POST
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await _room.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            await _room.Delete(id);

            return NoContent();
        }

        //POST AMENITY TO ROOM
        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult>AddAmenityToRoom( int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, roomId);
            return NoContent();
        }
        
        //DELETE AMENITY TO ROOM
          [HttpDelete("{id}")]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<ActionResult<Room>> DeleteAmenityToRoom(int roomId, int amenityId)
        {
            await _room.DeleteAmenityToRoom(roomId, amenityId);

            return NoContent();
        }
    }
}
