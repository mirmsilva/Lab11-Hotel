using Lab12.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.Interfaces
{
    public interface IRoom
    {
        //CREATE
        Task<Room> Create(Room room);

        //GET ALL
        Task<List<RoomsDto>> GetRooms();

        //GET BY ID
        Task<RoomsDto> GetRoom(int id);

        //UPDATE
        Task<RoomsDto> UpdateRoom(int id, Room room);
        Task AddAmenityToRoom(int roomId, int amenityId);

        //DELETE
        Task Delete(int id);
        Task DeleteAmenityToRoom(int roomId, int amenityId);
    }
}
