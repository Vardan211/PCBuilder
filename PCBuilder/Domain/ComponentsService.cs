using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCBuilder.DataAccess;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public class ComponentsService:IComponentsService
    {
        private readonly DataContext _context;
        private readonly ICompatibilityService _compatibilityService;
        public ComponentsService(ICompatibilityService compatibilityService, DataContext context)
        {
            _compatibilityService = compatibilityService;
            _context = context;
        }


        public ComputerBuildEntity Assembly(string name, int idGPU, int idCPU, int idMB)
        {
            var gpu = _context.Components.FirstOrDefault(r => r.Id == idGPU);
            var cpu = _context.Components.FirstOrDefault(r => r.Id == idCPU);
            var mb = _context.Components.FirstOrDefault(r => r.Id == idMB);
            var build = new ComputerBuildEntity(); 
            if (_compatibilityService.compatibility(idGPU, idCPU, idMB))
            {
                build.Name = name;
                build.GPUId = gpu.Id;
                build.CPUId = cpu.Id;
                build.MBId = mb.Id;
                build.Price = gpu.Price + cpu.Price + mb.Price;
                return build;
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
