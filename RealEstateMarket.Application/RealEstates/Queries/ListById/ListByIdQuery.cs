using MediatR;
using RealEstateMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.RealEstates.Queries.ListById
{
    public record ListByIdQuery(Guid id) : IRequest<RealEstate>;
}
