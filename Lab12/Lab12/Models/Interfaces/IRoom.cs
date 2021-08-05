using Lab12.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.Interfaces
{
    public interface IRoom
    {
        //CREATE - POST
        //DTO - RoomsDTO
        Task<Room> Create(Room room);

        //GET ALL
        //DTO - GET RoomDto Objects
        Task<List<RoomsDto>> GetRooms();

        //GET BY ID
        //DTO
        Task<RoomsDto> GetRoom(int id);

        //UPDATE - PUT
        Task<Room> UpdateRoom(int id, Room room);
        Task AddAmenityToRoom(int roomId, int amenityId);

        //DELETE
        Task Delete(int id);
        Task DeleteAmenityToRoom(int roomId, int amenityId);
    }
}
