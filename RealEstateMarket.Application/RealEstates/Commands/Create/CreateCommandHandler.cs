using MediatR;
using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Domain.Entities;
using RealEstateMarket.Domain.Validation;
using RealEstateMarket.Domain.Value_Objects;
using RealEstateMarket.Domain.Value_Objects.Ids;
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
                new RealEstateId(Guid.NewGuid()),
                new Address(request.region, request.city, request.zipCode, request.streetName, request.houseNumber),
                request.description,
                request.price,
                new Contacts(request.email, request.phone)
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
