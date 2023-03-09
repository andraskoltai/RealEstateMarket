using Microsoft.EntityFrameworkCore;
using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Domain;
using RealEstateMarket.Domain.Entities;

namespace RealEstateMarket.Infrastructure.Data
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private RealEstateMarketContext _context;

        public RealEstateRepository(RealEstateMarketContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task DeleteAsync(Guid id)
        {
            var realEstate = await GetByIdAsync(id);
            _context.RealEstates.Remove(realEstate);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RealEstate>> GetAllPagedAsync(PaginationFilter paginationFilter)
        {
            return await _context.RealEstates
                .OrderBy(re=>re.Id)
                .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<RealEstate> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _context.RealEstates.FirstOrDefaultAsync(re => re.Guid == id);
        }

        public async Task InsertAsync(RealEstate realEstate)
        {
            if (realEstate == null)
            {
                throw new ArgumentNullException(nameof(realEstate));
            }

            _context.Add(realEstate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RealEstate realEstate)
        {
            _context.Entry(realEstate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
