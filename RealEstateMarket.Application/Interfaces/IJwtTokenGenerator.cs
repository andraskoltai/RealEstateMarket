using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid id, string firstName, string lastName);
    }
}
