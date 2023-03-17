using MediatR;
using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Domain.Entities;
using RealEstateMarket.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.RealEstates.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, Result>
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public CreateCommandHandler(IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        public async Task<Result> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var createdRealEstate = new RealEstate(
                Guid.NewGuid(),
                request.region,
                request.city,
                request.zipCode,
                request.streetName,
                request.houseNumber,
                request.description,
                request.price,
                request.email,
                request.phone
                );

            var validationResult = createdRealEstate.Validation();

            if (validationResult.IsSuccesful)
            {
                await _realEstateRepository.InsertAsync(createdRealEstate);
            }

            return validationResult;
        }
    }
}
