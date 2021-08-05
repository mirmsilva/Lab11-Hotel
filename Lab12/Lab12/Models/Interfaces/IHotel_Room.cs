using Lab12.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.Interfaces
{
    public interface IHotel_Room
    {
        //CREATE - POST
        //DTO - in the incoming request
        Task<Hotel_Room> Create(Hotel_Room hotel_room);

        //GET ALL
        //DTO
        Task<List<HotelRoomsDto>> GetHotelRooms();

        //GET BY ID
        //DTO
        Task<HotelRoomsDto> GetHotelRoom(int hotelId, int roomId);

        //UPDATE - PUT
        //DTO- In the incoming request
        Task<Hotel_Room> UpdateHotelRoom(int id, int RoomNumber, Hotel_Room hotel_room);

        //DELETE
        Task Delete(int hotelId, int roomId);
    }
}
