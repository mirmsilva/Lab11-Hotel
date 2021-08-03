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
        Task<List<Room>> GetRooms();

        //GET BY ID
        Task<Room> GetRoom(int id);

        //UPDATE
        Task<Room> UpdateRoom(int id, Room room);
        Task AddAmenityToRoom(int roomId, int amenityId);

        //DELETE
        Task Delete(int id);
        Task DeleteAmenityToRoom(int roomId, int amenityId);
    }
}
