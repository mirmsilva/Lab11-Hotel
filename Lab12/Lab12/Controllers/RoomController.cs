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
    public class RoomController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomController(IRoom r) 
        {
            _room = r; 
        }
        //POST- CREATE
        //DTO - RoomsDTO should be included in the request
        [HttpPost]
        [Route("api/rooms/")]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await _room.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        //GET ALL
        //DTO - Get array of RoomDto Objects
        [HttpGet]
        [Route("api/rooms/")]
        public async Task<ActionResult<IEnumerable<RoomsDto>>> GetRooms()
        {  
            var list = await _room.GetRooms();
            return Ok(list);
        }
        //GET BY ID
        [HttpGet("{id}")]
        [Route("api/rooms/{roomId}")]
        public async Task<ActionResult<RoomsDto>> GetRoom(int id)
        {
            RoomsDto room = await _room.GetRoom(id);
            return room;
        }

        //PUT - UPDATE
        [HttpPut("{id}")]
        [Route("api/rooms/{roomId}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            var updateRoom = await _room.UpdateRoom(id, room);
            return Ok(updateRoom);
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
            await _room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();
        }
        
        //DELETE AMENITY TO ROOM
        [HttpDelete]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<ActionResult<Room>> DeleteAmenityToRoom(int roomId, int amenityId)
        {
            await _room.DeleteAmenityToRoom(roomId, amenityId);

            return NoContent();
        }
    }
}
