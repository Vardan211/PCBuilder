using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Domain;
using PCBuilder.Domain.Models;

namespace PCBuilder.Controllers
{
    [Route("identity")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var result = await _userService.Login(request);
            
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDto request)
        {
            var result = await _userService.Register(request);
            
            return Ok(result);
        }
    }
}