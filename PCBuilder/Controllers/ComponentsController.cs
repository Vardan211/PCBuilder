using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCBuilder.DataAccess.Entities;
using PCBuilder.Domain;

namespace PCBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        private readonly IComponentsService _componentsService;
        public ComponentsController(IComponentsService componentsService)
        {
            _componentsService= componentsService;
        }

        [HttpPost("Add GPU")]
        public IActionResult Add(OtherComponentsEntity gpu)
        {
            _componentsService.AddGPU(gpu);
            return Ok();
        }
        [HttpPost("Add MB or CPU")]
        public IActionResult AddMB_CPU(CPU_MB_ComponentsEntity component, string type)
        {
            _componentsService.AddCPUorMB(component,type);
            return Ok();
        }
        [HttpPost("Compatibility")]
        public IActionResult Compatiblity(int idGPU, int idCPU, int idMB)
        {
            if (_componentsService.compatibility(idGPU, idCPU, idMB))
                return Ok();
            else
                return BadRequest("isn't compatible");
        }
        [HttpPost("Assembling")]
        public IActionResult Assembling(string name, int idGPU, int idCPU, int idMB)
        {
            var result = _componentsService.assembling(name, idGPU, idCPU, idMB);
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
