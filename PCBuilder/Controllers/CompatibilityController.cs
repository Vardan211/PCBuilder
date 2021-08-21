using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompatibilityController : ControllerBase
    {
        private readonly ICompatibilityService _compatibilityService;
        public CompatibilityController(ICompatibilityService compatibilityService)
        {
            _compatibilityService = compatibilityService;
        }
        [HttpPost("check-compatibility")]
        public IActionResult Compatiblity(int idGPU, int idCPU, int idMB)
        {
            if (_compatibilityService.compatibility(idGPU, idCPU, idMB))
                return Ok();
            else
                return BadRequest("isn't compatible or wrong id");
        }
    }
}
