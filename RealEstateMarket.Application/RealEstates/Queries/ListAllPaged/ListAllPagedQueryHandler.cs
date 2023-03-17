using MediatR;
using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Domain;
using RealEstateMarket.Domain.Entities;
using RealEstateMarket.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.RealEstates.Queries.ListAllPaged
{
    public class ListAllPagedQueryHandler : IRequestHandler<ListAllPagedQuery, IEnumerable<RealEstate>>
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public ListAllPagedQueryHandler(IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        public async Task<IEnumerable<RealEstate>> Handle(ListAllPagedQuery request, CancellationToken cancellationToken)
        {
            var filter = new PaginationFilter() { PageNumber = request.pageNumber, PageSize = request.pageSize };
            return await _realEstateRepository.GetAllPagedAsync(filter);
        }
    }
}
