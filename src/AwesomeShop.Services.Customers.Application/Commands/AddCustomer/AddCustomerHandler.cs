using AwesomeShop.Services.Customers.Domain.Entities;
using AwesomeShop.Services.Customers.Domain.Interfaces.MessageBus;
using AwesomeShop.Services.Customers.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Customers.Application.Commands.AddCustomer
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerRequest, AddCustomerResponse>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEventProcessor _eventProcessor;
        public AddCustomerHandler(ICustomerRepository repository, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }

        public async Task<AddCustomerResponse> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.FullName, request.BirthDate, request.Email);

            await _repository.AddAsync(customer);

            _eventProcessor.Process(customer.Events);

            return new AddCustomerResponse(customer.Id);
        }
    }
}