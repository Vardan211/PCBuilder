﻿using Microsoft.AspNetCore.Http;
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

        [HttpPost("build")]
        public IActionResult Assembling(string name, int idGPU, int idCPU, int idMB)
        {
            var result = _componentsService.Assembly(name, idGPU, idCPU, idMB);
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet ("get-by-category")]
        public IActionResult GetAll(int categoryId)
        {
            var result = _componentsService.GetByType(categoryId);
            return Ok(result);
        }
        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            var result = _componentsService.GetById(id);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _componentsService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ComponentEntity component)
        {
            await _componentsService.Add(component);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(ComponentEntity component)
        {
            await _componentsService.Remove(component);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(ComponentEntity component)
        {
            await _componentsService.Update(component);
            return Ok();
        }
    }
}