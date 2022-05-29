using AwesomeShop.Services.Customers.Domain.Interfaces.Events;
using AwesomeShop.Services.Customers.Domain.ValueObjects;
using System;

namespace AwesomeShop.Services.Customers.Domain.Events
{
    public class CustomerUpdated : IDomainEvent
    {
        public CustomerUpdated(Guid id, string phoneNumber, Address address)
        {
            Id = id;
            Address = address;
        }

        public Guid Id { get; private set; }
        public Address Address { get; private set; }
    }
}