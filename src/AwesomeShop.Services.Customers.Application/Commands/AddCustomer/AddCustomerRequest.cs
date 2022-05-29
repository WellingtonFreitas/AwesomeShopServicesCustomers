using MediatR;
using System;

namespace AwesomeShop.Services.Customers.Application.Commands.AddCustomer
{
    public class AddCustomerRequest : IRequest<AddCustomerResponse>
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}