using RealEstateMarket.Application.Interfaces;
using RealEstateMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Login(string email, string password)
        {
            return await _userRepository.GetByEmailAndPassword(email, password);
        }

        public async Task<User?> Register(string firstName, string lastName, string email, string password, string? phone)
        {
            if (await _userRepository.GetByEmailAndPassword(email, password) == null)
            {
                return null;
            }

            var userCreated = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Phone = phone,
                Id = Guid.NewGuid(),
            };

            await _userRepository.InsertAsync(userCreated);
            return userCreated;
        }
    }
}
