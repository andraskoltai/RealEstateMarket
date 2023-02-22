﻿using Microsoft.EntityFrameworkCore;
using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<RealEstate>> GetAllAsync()
        {
            return await _context.RealEstates.ToListAsync();
        }

        public async Task<RealEstate> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _context.RealEstates.FirstOrDefaultAsync(re => re.Id == id);
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