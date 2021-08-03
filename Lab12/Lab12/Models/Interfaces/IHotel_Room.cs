using Lab12.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.Interfaces
{
    public interface IHotel_Room
    {
        Task<Hotel_Room> Create(Hotel_Room hotel_room);

        //GET ALL
        Task<List<HotelRoomsDto>> GetHotelRooms();

        //GET BY ID
        Task<HotelRoomsDto> GetHotelRoom(int id);

        //UPDATE
        Task<HotelRoomsDto> UpdateHotelRoom(int id, int RoomNumber, Hotel_Room hotel_room);

        //DELETE
        Task Delete(int id);
    }
}
