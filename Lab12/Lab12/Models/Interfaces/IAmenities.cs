using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Models.Interfaces
{
    public interface IAmenities
    {
        //CREATE
        Task<Amenities> Create(Amenities amenities);
        //GET ALL
        Task<List<Amenities>> GetAmenities();
        //GET BY ID
        Task<Amenities> GetAmenity(int id);

        //UPDATE
        Task<Amenities> UpdateAmenity(int id, Amenities amenities);

        //DELETE
        Task Delete(int id);
    }
}
