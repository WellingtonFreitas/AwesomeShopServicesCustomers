using AwesomeShop.Services.Customers.Application.Dtos;
using System;

namespace AwesomeShop.Services.Customers.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdResponse
    {
        public GetCustomerByIdResponse(Guid id, string fullName, DateTime birthDate, AddressDto address)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            Address = address;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public AddressDto Address { get; private set; }
    }
}
