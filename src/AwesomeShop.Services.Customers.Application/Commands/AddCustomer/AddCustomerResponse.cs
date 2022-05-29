using System;

namespace AwesomeShop.Services.Customers.Application.Commands.AddCustomer
{
    public class AddCustomerResponse
    {
        public AddCustomerResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
