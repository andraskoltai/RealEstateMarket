using RealEstateMarket.Domain.Primitives;
using RealEstateMarket.Domain.Validation;
using RealEstateMarket.Domain.Value_Objects;
using RealEstateMarket.Domain.Value_Objects.Ids;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RealEstateMarket.Domain.Entities
{
    public sealed class RealEstate
    {
        //todo: unit of work, address
        public RealEstate()
        { }
        public RealEstate(
            RealEstateId id, Address address, string? description,
            uint price, Contacts contacts) 
        {
            Id = id;
            Address = address;
            Description = description;
            Price = price;
            Contacts = contacts;
        }
        public RealEstateId Id { get; set; }
        public Address Address { get; set; }
        public string? Description { get; set; }
        public uint Price { get; set; }
        public Contacts Contacts { get; set; }

        // todo: generic validation
        public Result Validation()
        {
            const string cantBeEmpty = " can't be empty.";
            var result = new Result();
            if (String.IsNullOrWhiteSpace(Address.Region))
            {
                result.Errors.Add(String.Concat("Region", cantBeEmpty));
            }

            if (String.IsNullOrWhiteSpace(Address.City))
            {
                result.Errors.Add(String.Concat("City", cantBeEmpty));
            }

            if (String.IsNullOrWhiteSpace(Address.StreetName))
            {
                result.Errors.Add(String.Concat("Region", cantBeEmpty));
            }

            if (Address.HouseNumber == 0)
            {
                result.Errors.Add("House number can't be zero.");
            }

            // Overflow?
            if (Address.ZipCode == 0)
            {
                result.Errors.Add("Invalid zip code.");
            }

            if (Contacts.Email is not null && !Regex.Match(Contacts.Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").Success)
            {
                result.Errors.Add("Invalid email format.");
            }

            if (Contacts.Phone is not null && !Regex.Match(Contacts.Phone, @"^\+?\d+$").Success)
            {
                result.Errors.Add("Invalid phone number.");
            }

            return result;
        }
    }
}
