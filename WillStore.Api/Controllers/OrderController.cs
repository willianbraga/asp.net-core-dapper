using System;
using Microsoft.AspNetCore.Mvc;

namespace WillStore.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Route("getbyid/{customerCPF}")]
        public IActionResult GetCustomerById(Guid customerId)
        {
            return Ok();
        }
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