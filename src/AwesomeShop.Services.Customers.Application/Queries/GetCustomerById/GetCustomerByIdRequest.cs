using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Customers.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse>
    {
        public GetCustomerByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
