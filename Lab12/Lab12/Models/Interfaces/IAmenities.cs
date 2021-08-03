using Lab12.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.Interfaces
{
    public interface IAmenities
    {
        //CREATE
        Task<AmenitiesDto> Create(Amenities amenities);
        //GET ALL
        Task<List<AmenitiesDto>> GetAmenities();
        //GET BY ID
        Task<AmenitiesDto> GetAmenity(int id);

        //UPDATE
        Task<Amenities> UpdateAmenity(int id, Amenities amenities);

        //DELETE
        Task Delete(int id);
    }
}
