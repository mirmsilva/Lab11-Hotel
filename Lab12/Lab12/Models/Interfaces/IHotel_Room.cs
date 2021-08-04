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
        Task<List<Hotel_Room>> GetHotelRooms();

        //GET BY ID
        Task<Hotel_Room> GetHotelRoom(int id);

        //UPDATE - PUT
        //DTO- In the incoming request
        Task<HotelRoomsDto> UpdateHotelRoom(int id, int RoomNumber, Hotel_Room hotel_room);

        //DELETE
        Task Delete(int id);
    }
}
