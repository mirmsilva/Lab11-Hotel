using Lab12.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//this will be used by Hotel Services
namespace Lab12.Models.Interfaces
{
    public interface IHotel
    {
        //CREATE
        Task<Hotel> Create(Hotel hotel);

        //GET ALL
        Task<List<HotelsDto>> GetHotels();

        //GET BY ID
        Task<HotelsDto> GetHotel(int id);

        //UPDATE
        Task<Hotel> UpdateHotel(int id, Hotel hotel);

        //DELETE
        Task Delete(int id);
    }
}
