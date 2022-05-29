using AwesomeShop.Services.Customers.Application.Dtos;
using AwesomeShop.Services.Customers.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Customers.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler :
          IRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            return new GetCustomerByIdResponse(customer.Id, customer.FullName, customer.BirthDate, AddressDto.ToDto(customer.Address));
        }
    }
}