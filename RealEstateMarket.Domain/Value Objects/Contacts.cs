using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateMarket.Domain.Value_Objects
{
    public class Contacts
    {
        public Contacts() { }
        public Contacts(string? email, string? phone)
        {
            Email = email;
            Phone = phone;
        }

        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
