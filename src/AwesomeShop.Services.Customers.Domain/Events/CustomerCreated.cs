using AwesomeShop.Services.Customers.Domain.Interfaces.Events;
using System;

namespace AwesomeShop.Services.Customers.Domain.Events
{
    public class CustomerCreated : IDomainEvent
    {
        public CustomerCreated(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }
        
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}