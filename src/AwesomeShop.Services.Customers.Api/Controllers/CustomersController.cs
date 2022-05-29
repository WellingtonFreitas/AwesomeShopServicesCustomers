using AwesomeShop.Services.Customers.Application.Commands.AddCustomer;
using AwesomeShop.Services.Customers.Application.Commands.UpdateCustomer;
using AwesomeShop.Services.Customers.Application.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Customers.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCustomerRequest request)
        {
            var result = await _mediator.Send(request);

            return Created($"api/customers/{result.Id}", value: null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetCustomerByIdRequest(id);

            var customerViewModel = await _mediator.Send(query);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return Ok(customerViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCustomerRequest command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }
    }
}