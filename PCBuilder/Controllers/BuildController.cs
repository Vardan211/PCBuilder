using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.DataAccess.Entities;
using PCBuilder.Domain;

namespace PCBuilder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildController : ControllerBase
    {
        private readonly IBuildService _buildService;
       
        public BuildController(IBuildService buildService)
        {
            _buildService = buildService;
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public async Task<IActionResult> Get()
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var username = HttpContext.User.FindFirstValue(ClaimTypes.Name);

            var result = await _buildService.GetAll(role, username);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Add(ComputerBuildEntity buildEntity)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _buildService.Add(buildEntity, role, userid);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(ComputerBuildEntity buildEntity)
        {
            await _buildService.Delete(buildEntity);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Change(ComputerBuildEntity computerBuildEntity)
        {
            await _buildService.Change(computerBuildEntity);
            return Ok();
        }
    }
}