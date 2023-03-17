using RealEstateMarket.Domain.Primitives;
using RealEstateMarket.Domain.Validation;
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
    public sealed class RealEstate : Entity
    {
        //todo: unit of work, address
        public RealEstate(
            /*int id,*/ Guid guid, string region,
            string city, ushort zipCode, string streetName,
            uint houseNumber, string? description, uint price,
            string? email, string? phone) 
            : base (guid)
        {
            //Id = id;
            Region = region;
            City = city;
            ZipCode = zipCode;
            StreetName = streetName;
            HouseNumber = houseNumber;
            Description = description;
            Price = price;
            Email = email;
            Phone = phone;
        }

        //public int Id { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public ushort ZipCode { get; set; }
        public string StreetName { get; set; }
        public uint HouseNumber { get; set; }
        public string? Description { get; set; }
        public uint Price { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // todo: generic validation
        public Result Validation()
        {
            const string cantBeEmpty = " can't be empty.";
            var result = new Result();
            if (String.IsNullOrWhiteSpace(Region))
            {
                result.Errors.Add(String.Concat("Region", cantBeEmpty));
            }

            if (String.IsNullOrWhiteSpace(City))
            {
                result.Errors.Add(String.Concat("City", cantBeEmpty));
            }

            if (String.IsNullOrWhiteSpace(StreetName))
            {
                result.Errors.Add(String.Concat("Region", cantBeEmpty));
            }

            if (HouseNumber == 0)
            {
                result.Errors.Add("House number can't be zero.");
            }

            // Overflow?
            if (ZipCode == 0)
            {
                result.Errors.Add("Invalid zip code.");
            }

            if (Email is not null && !Regex.Match(Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").Success)
            {
                result.Errors.Add("Invalid email format.");
            }

            if (Phone is not null && !Regex.Match(Phone, @"^\+?\d+$").Success)
            {
                result.Errors.Add("Invalid phone number.");
            }

            return result;
        }
    }
}
