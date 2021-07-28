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
        public IActionResult Get()
        {
            var result = _buildService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(ComputerBuildEntity buildEntity)
        {
            _buildService.Add(buildEntity);
            return Ok();
        }
    }
}