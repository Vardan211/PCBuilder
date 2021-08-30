using System.Linq;
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
        [Authorize(Roles = "user")]
        public IActionResult Get()
        {
            var username = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))?.Value;
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"))?.Value;

            var result = _buildService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(ComputerBuildEntity buildEntity)
        {
            _buildService.Add(buildEntity);
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