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
        [HttpPost]
        [Route("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<Hotel_Room>> PostHotelRoom(Hotel_Room hotel_room)
        {
            await _hotelRoom.Create(hotel_room);

            return CreatedAtAction("GetHotelRoom", new { id = hotel_room.HotelId, hotel_room.RoomId }, hotel_room);
        }

        //GET ALL
        [HttpGet]
        [Route("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<Hotel_Room>>> GetHotelRooms()
        {
            //add a count to the list
            var list = await _hotelRoom.GetHotelRooms();
            return Ok(list);
        }

        //GET BY ID
        [HttpGet("{id}")]
        [Route("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<Hotel_Room>> GetHotelRoom(int id)
        {
            Hotel_Room hotel_room = await _hotelRoom.GetHotelRoom(id);
            return hotel_room;
        }

        //PUT - UPDATE
        //DTO - In the incoming request from client
        [HttpPut("{id}")]
        [Route("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult> PutHotelRoom( int hotelId, int roomNumber, Hotel_Room hotel_room)
        {
            if (hotelId != hotel_room.HotelId || roomNumber != hotel_room.RoomNumber)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelId, roomNumber, hotel_room);

            return Ok(updateHotelRoom);
        }

        //DELETE
        [HttpDelete("{id}")]
        [Route("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<Hotel_Room>> DeleteHotelRoom (int id)
        {
            await _hotelRoom.Delete(id);
            return NoContent();
        }
    }
}