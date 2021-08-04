using Lab12.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.Interfaces
{
    public interface IAmenities
    {
        //CREATE -POST
        //DTO - In the request
        Task<AmenitiesDto> Create(Amenity amenities);
        //GET ALL
        Task<List<Amenity>> GetAmenities();
        //GET BY ID
        Task<Amenity> GetAmenity(int id);

        //UPDATE -PUT
        Task<Amenity> UpdateAmenity(int id, Amenity amenities);

        //DELETE
        Task Delete(int id);
    }
}
