using MediatR;
using RealEstateMarket.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.RealEstates.Commands.Create
{
    public record CreateCommand(string region,
            string city, ushort zipCode, string streetName,
            uint houseNumber, string? description, uint price,
            string? email, string? phone) : IRequest<Result>;
}
