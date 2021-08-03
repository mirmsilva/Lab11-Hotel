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
    public class Hotel_RoomController : ControllerBase
    {
        private readonly IHotel_Room _hotelRoom;

        public Hotel_RoomController(IHotel_Room hr)
        {
            //set context to the private context created above
            _hotelRoom = hr;
        }

        //GET
        [HttpGet("api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<Hotel_Room>>> GetHotelRooms()
        {
            //add a count to the list
            var list = await _hotelRoom.GetHotelRooms();
            return Ok(list);
        }

        //GET: api/Hotels/5
        [HttpGet("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<Hotel_Room>> GetHotelRoom(int id)
        {
            Hotel_Room hotel_room = await _hotelRoom.GetHotelRoom(id);
            return hotel_room;
        }

        //PUT 
        [HttpPut("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom( int hotelId, int roomNumber, Hotel_Room hotel_room)
        {
            if (hotelId != hotel_room.HotelId || roomNumber != hotel_room.RoomNumber)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelId, roomNumber, hotel_room);

            return Ok(updateHotelRoom);
        }
        //POST
        [HttpPost("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<Hotel_Room>> PostHotelRoom(Hotel_Room hotel_room)
        {
            await _hotelRoom.Create(hotel_room);

            return CreatedAtAction("GetHotelRoom", new { id = hotel_room.HotelId, hotel_room.RoomId}, hotel_room);
        }

        //DELETE
        [HttpDelete("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<Hotel>> DeleteHotelRoom (int id)
        {
            await _hotelRoom.Delete(id);
            return NoContent();
        }
    }
}