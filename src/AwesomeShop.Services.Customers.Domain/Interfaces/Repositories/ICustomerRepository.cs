using AwesomeShop.Services.Customers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Customers.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
         Task<Customer> GetByIdAsync(Guid id);
         Task AddAsync(Customer customer);
         Task UpdateAsync(Customer customer);
    }
}