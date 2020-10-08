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
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class OrderController : ControllerBase
    {

        public OrderController()
        { }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("getbyid/{OrderId}")]
        public IActionResult GetById(Guid OrderId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("")]
        public IActionResult SaveOrder()
        {
            return Ok();
        }
        [HttpPut]
        [Route("{OrderId}")]
        public IActionResult EditOrder()
        {
            return Ok();
        }
        [HttpDelete]
        [Route("{OrderId}")]
        public IActionResult DeleteOrder()
        {
            return Ok();
        }
    }
}