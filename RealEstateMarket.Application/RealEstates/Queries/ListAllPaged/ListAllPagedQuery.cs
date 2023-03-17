using MediatR;
using RealEstateMarket.Domain.Entities;
using RealEstateMarket.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.RealEstates.Queries.ListAllPaged
{
    public record ListAllPagedQuery(int pageNumber, int pageSize) : IRequest<IEnumerable<RealEstate>>;
}
