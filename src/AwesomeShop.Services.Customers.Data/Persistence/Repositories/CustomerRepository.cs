using AwesomeShop.Services.Customers.Domain.Entities;
using AwesomeShop.Services.Customers.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Customers.Data.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _collection;

        public CustomerRepository(IMongoDBContext mongoDBContext)
        {
            _collection = mongoDBContext.GetCollection<Customer>("Customer");
        }

        public async Task AddAsync(Customer customer)
        {
            await _collection.InsertOneAsync(customer);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _collection.Find(o => o.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _collection.ReplaceOneAsync(o => o.Id.Equals(customer.Id), customer);
        }
    }
}