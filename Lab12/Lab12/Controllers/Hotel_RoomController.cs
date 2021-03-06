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
        //POST - CREATE
        //DTO - in the incoming request from the client
        [HttpPost("/api/Hotels/{hotel_room}/Rooms")]

        public async Task<ActionResult<Hotel_Room>> PostHotelRoom(Hotel_Room hotel_room)
        {
            await _hotelRoom.Create(hotel_room);

            return CreatedAtAction("GetHotelRoom", new { id = hotel_room.HotelId, hotel_room.RoomId }, hotel_room);
        }

        //GET ALL
        //DTO
        [HttpGet]
        [Route("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomsDto>>> GetHotelRooms()
        {
            //add a count to the list
            var list = await _hotelRoom.GetHotelRooms();
            return Ok(list);
        }

        //GET BY ID
        //DTO
        [HttpGet("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomsDto>> GetHotelRoom( int hotelId, int roomId)
        {
            HotelRoomsDto hotel_room = await _hotelRoom.GetHotelRoom(hotelId, roomId);
            return hotel_room;
        }

        //PUT - UPDATE
        //DTO - In the incoming request from client
        [HttpPut("/api/Hotels/{hotelId}/Rooms/{roomId}")]
        public async Task<ActionResult> PutHotelRoom( int hotelId, int roomId, Hotel_Room hotel_room)
        {
            if (hotelId != hotel_room.HotelId || roomId != hotel_room.RoomId)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelId, roomId, hotel_room);

            return Ok(updateHotelRoom);
        }

        //DELETE
        [HttpDelete("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<Hotel_Room>> DeleteHotelRoom (int hotelId, int roomId)
        {
            await _hotelRoom.Delete(hotelId, roomId);
            return NoContent();
        }
    }
}