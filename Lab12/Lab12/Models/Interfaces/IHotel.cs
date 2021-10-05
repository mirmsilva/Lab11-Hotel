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
        //CREATE - POST
        Task<Hotel> Create(Hotel hotel);

        //GET ALL
        Task<List<Hotel>> GetHotels();

        //GET BY ID
        Task<Hotel> GetHotel(int id);

        //GET BY NAME
        Task<HotelSmsDto> GetHotelByName(string name);


        //UPDATE - PUT
        Task<Hotel> UpdateHotel(int id, Hotel hotel);

        //DELETE
        Task Delete(int id);
    }
}
