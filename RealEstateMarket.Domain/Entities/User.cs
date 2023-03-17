using RealEstateMarket.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Domain.Entities
{
    public class User : Entity
    {
        public User(/*int id,*/ Guid guid, string firstName,
            string lastName, string email, string password, 
            string? phone) 
            : base (guid)
        {
            //Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
        }

        //public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string? Phone { get; private set; }
    }
}
