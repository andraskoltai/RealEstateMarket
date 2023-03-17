using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.RealEstates.Commands.Delete
{
    public record DeleteCommand(Guid id) : IRequest;
}
