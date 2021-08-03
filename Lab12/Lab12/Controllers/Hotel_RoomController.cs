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
    public class Hotel_RoomController : ControllerBase
    {
        private readonly IHotel_Room _hotelRoom;

        public Hotel_RoomController(IHotel_Room hr)
        {
            //set context to the private context created above
            _hotelRoom = hr;
        }

        //GET LIST
        [HttpGet("api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomsDto>>> GetHotelRooms()
        {
            //add a count to the list
            var list = await _hotelRoom.GetHotelRooms();
            return Ok(list);
        }

        //GET BY ROOM NUMBER
        [HttpGet("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomsDto>> GetHotelRoom(int id)
        {
            HotelRoomsDto hotel_room = await _hotelRoom.GetHotelRoom(id);
            return hotel_room;
        }

        //PUT 
        [HttpPut("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult> PutHotelRoom( int hotelId, int roomNumber, HotelRoomsDto hotel_room)
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
        public async Task<ActionResult<HotelRoomsDto>> PostHotelRoom(Hotel_Room hotel_room)
        {
            await _hotelRoom.Create(hotel_room);

            return CreatedAtAction("GetHotelRoom", new { id = hotel_room.HotelId, hotel_room.RoomId}, hotel_room);
        }

        //DELETE
        [HttpDelete("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomsDto>> DeleteHotelRoom (int id)
        {
            await _hotelRoom.Delete(id);
            return NoContent();
        }
    }
}