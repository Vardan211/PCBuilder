using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Domain;
using PCBuilder.Domain.Models;
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
        public async Task<IActionResult> Get()
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _orderService.GetAll(role, userid);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = "user, admin")]
        public async Task<IActionResult> Add(OrderDto orderDto)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _orderService.Add(orderDto, role, userid);
            return Ok();
            
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(OrderDto orderDto)
        {
            _orderService.Delete(orderDto);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Change(OrderDto orderDto)
        {
            await _orderService.Change(orderDto);
            return Ok();
        }

    }
}
