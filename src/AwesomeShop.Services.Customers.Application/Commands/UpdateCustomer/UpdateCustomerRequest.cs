using AwesomeShop.Services.Customers.Application.Dtos;
using MediatR;
using System;

namespace AwesomeShop.Services.Customers.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; }
    }
}