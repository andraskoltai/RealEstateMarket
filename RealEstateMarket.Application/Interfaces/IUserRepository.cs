using RealEstateMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task InsertAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<User?> GetByEmailAndPassword(string email, string password);
    }
}
