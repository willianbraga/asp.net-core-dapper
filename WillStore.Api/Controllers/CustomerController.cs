using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WillStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using WillStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using WillStore.Domain.StoreContext.Entities;
using WillStore.Domain.StoreContext.Handlers;
using WillStore.Domain.StoreContext.Queries;
using WillStore.Domain.StoreContext.Repositories;

namespace WillStore.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository customerRepository, CustomerHandler handler)
        {
            _customerRepository = customerRepository;
            _handler = handler;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<ListCustomerQueryResult> GetAll()
        {
            return _customerRepository.GetCustomerList();
        }

        [HttpGet]
        [Route("getbyid/{customerId}")]
        public GetCustomerQueryResult GetById(Guid customerId)
        {
            return _customerRepository.GetCustomerById(customerId);
        }

        [HttpGet]
        [Route("getbyid/{customerId}/orders")]
        public IEnumerable<ListCustomerOrderQueryResult> GetCustomerOrders(Guid customerId)
        {
            return _customerRepository.GetCustomerOrder(customerId);
        }

        [HttpPost]
        [Route("")]
        public IActionResult SaveCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            if (result.Invalid)
                return BadRequest(_handler.Notifications);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult EditCustomer([FromBody] EditCustomerCommand command)
        {
            var result = (EditCustomerCommand)_handler.Handle(command);
            if (result.Invalid)
                return BadRequest(_handler.Notifications);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{customerId}")]
        public IActionResult DeleteCustomer(DeleteCustomerCommand customerId)
        {
            var result = (DeleteCustomerCommandResult)_handler.Handle(customerId);
            if (result.Invalid)
                return BadRequest(_handler.Notifications);
            return Ok(result);
        }
    }
}