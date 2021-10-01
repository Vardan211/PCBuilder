using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PCBuilder.DataAccess;
using PCBuilder.DataAccess.Entities;
using PCBuilder.Domain.Models;

namespace PCBuilder.Domain
{
    public class ComponentsService:IComponentsService
    {
        private readonly DataContext _context;
        private readonly ICompatibilityService _compatibilityService;
        private readonly IMapper _mapper;
        public ComponentsService(ICompatibilityService compatibilityService, DataContext context, IMapper mapper)
        {
            _compatibilityService = compatibilityService;
            _context = context;
            _mapper = mapper;
        }


        public ComputerBuildEntity Assembly (ComputerBuildDto buildDto)
        {
            var gpu = _context.Components.FirstOrDefault(r => r.Id == buildDto.gpuId);
            var cpu = _context.Components.FirstOrDefault(r => r.Id == buildDto.cpuId);
            var mb = _context.Components.FirstOrDefault(r => r.Id == buildDto.mbId);

            if (_compatibilityService.compatibility(buildDto.gpuId, buildDto.cpuId, buildDto.mbId))
            {
                var buildEntity = _mapper.Map<ComputerBuildEntity>(buildDto);
                buildEntity.Price = gpu.Price + cpu.Price + mb.Price;
                return buildEntity;
            }
            else
            return null;
        }

        public async Task Add(ComponentEntity component)
        {
            await _context.Components.AddAsync(component);
            await _context.SaveChangesAsync();
        }
        public async Task Remove(ComponentEntity component)
        {
            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ComponentEntity component)
        {
            _context.Components.Update(component);
            await _context.SaveChangesAsync();
        }

        public List<ComponentEntity> GetAll()
        {
            return _context.Components.ToList();
        }
        public List<ComponentEntity> GetByType(int categoryId)
        {
            return _context.Components.Where(i => i.CategoryId == categoryId).ToList();
        }
        public List<ComponentEntity> GetById(int id)
        {
            return _context.Components.Where(i => i.Id == id).ToList();
            
        }


    }
}
