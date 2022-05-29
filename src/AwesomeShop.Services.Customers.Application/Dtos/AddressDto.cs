using AwesomeShop.Services.Customers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Customers.Application.Dtos
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Address ToEntity() => new Address(Street, Number, City, State, ZipCode);

        public static AddressDto ToDto(Address address)
            => new AddressDto
            {
                Street = address?.Street,
                Number = address?.Number,
                City = address?.City,
                State = address?.State,
                ZipCode = address?.ZipCode
            };
    }
}
