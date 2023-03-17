using MediatR;
using RealEstateMarket.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.RealEstates.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public DeleteCommandHandler(IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            await _realEstateRepository.DeleteAsync(request.id);
        }
    }
}
