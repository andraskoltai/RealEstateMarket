using RealEstateMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<User?> Register(string firstName, string lastName, string email, string password, string? phone);
        Task<User?> Login(string email, string password);
    }
}
