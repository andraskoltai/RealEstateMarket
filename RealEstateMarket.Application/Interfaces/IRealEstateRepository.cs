using RealEstateMarket.Domain;
using RealEstateMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.Interfaces
{
    public interface IRealEstateRepository
    {
        Task<IEnumerable<RealEstate>> GetAllPagedAsync(PaginationFilter paginationFilter);
        Task InsertAsync(RealEstate realEstate);
        Task<RealEstate> GetByIdAsync(Guid id);
        Task UpdateAsync(RealEstate realEstate);
        Task DeleteAsync(Guid id);
    }
}
