using MediatR;
using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Application.RealEstates.Queries.ListAllPaged;
using RealEstateMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.RealEstates.Queries.ListById
{
    public class ListByIdQueryHandler : IRequestHandler<ListByIdQuery, RealEstate>
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public ListByIdQueryHandler(IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        public async Task<RealEstate> Handle(ListByIdQuery request, CancellationToken cancellationToken)
        {
            return await _realEstateRepository.GetByIdAsync(request.id);
        }
    }
}
