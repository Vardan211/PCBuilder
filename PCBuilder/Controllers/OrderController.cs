using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.DataAccess.Entities;
using PCBuilder.Domain;
using PCBuilder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PCBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public IActionResult Get()
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _orderService.GetAll(role, userid);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = "user, admin")]
        public IActionResult Add(OrderEntity orderEntity)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            _orderService.Add(orderEntity, role, userid);
            return Ok();
            
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(OrderEntity orderEntity)
        {
            _orderService.Delete(orderEntity);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public IActionResult Change(OrderEntity orderEntity)
        {
            _orderService.Change(orderEntity);
            return Ok();
        }

    }
}
