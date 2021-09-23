using System.Linq;
using System.Security.Claims;
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
        public IActionResult Get()
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.Name);

            var result = _buildService.GetAll(role, userid);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult Add(ComputerBuildEntity buildEntity)
        {
            var role = HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _buildService.Add(buildEntity, role, userid);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(ComputerBuildEntity buildEntity)
        {
            _buildService.Delete(buildEntity);
            return Ok();
        }
        [HttpPut]
        public IActionResult Change(ComputerBuildEntity computerBuildEntity)
        {
            _buildService.Change(computerBuildEntity);
            return Ok();
        }
    }
}