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

        [HttpGet("Get All")]
        public IActionResult Get()
        {
            var result = _buildService.GetAll();
            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(ComputerBuildEntity buildEntity)
        {
            _buildService.Add(buildEntity);
            return Ok();
        }
        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            _buildService.Delete(id);
            return Ok();
        }
        [HttpPost("Change")]
        public IActionResult Change(int id,ComputerBuildEntity computerBuildEntity)
        {
            _buildService.Change(id,computerBuildEntity);
            return Ok();
        }
    }
}