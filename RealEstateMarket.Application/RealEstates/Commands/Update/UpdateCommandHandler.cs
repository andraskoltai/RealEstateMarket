using MediatR;
using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Domain.Entities;
using RealEstateMarket.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.RealEstates.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Result>
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public UpdateCommandHandler(IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        public async Task<Result> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var updatedRealEstate = await _realEstateRepository.GetByIdAsync(request.id);
            var result = new Result();
            if (updatedRealEstate == null)
            {
                result.Errors.Add("Invalid real estate id.");
                return result;
            }

            updatedRealEstate.Region = request.region;
            updatedRealEstate.City = request.city;
            updatedRealEstate.ZipCode = request.zipCode;
            updatedRealEstate.StreetName = request.streetName;
            updatedRealEstate.HouseNumber = request.houseNumber;
            updatedRealEstate.Description = request.description;
            updatedRealEstate.Price = request.price;
            updatedRealEstate.Email = request.email;
            updatedRealEstate.Phone = request.phone;

            if (!updatedRealEstate.Validation().IsSuccesful)
            {
                return updatedRealEstate.Validation();
            }

            await _realEstateRepository.UpdateAsync(updatedRealEstate);
            return result;
        }
    }
}
