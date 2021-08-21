using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCBuilder.DataAccess;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public class BuildService : IBuildService
    {
        private readonly DataContext _context;
        private readonly ICompatibilityService _compatibilityService;
        public BuildService(ICompatibilityService compatibilityService, DataContext context)
        {
            _compatibilityService = compatibilityService;
            _context = context;
        }
        public List<ComputerBuildEntity> GetAll()
        {
            return _context.Builds.ToList();
        }

        public async Task Add(ComputerBuildEntity computerBuildEntity)
        {
            
            if (_compatibilityService.compatibility((int)computerBuildEntity.GPUId, (int)computerBuildEntity.CPUId, (int)computerBuildEntity.MBId))
            {
                await _context.Builds.AddAsync(computerBuildEntity);
                await _context.SaveChangesAsync();
            }
            throw new Exception("Build is not compatible");
        }
        public async Task Delete(ComputerBuildEntity computerBuildEntity)
        {
            _context.Builds.Remove(computerBuildEntity);
            await _context.SaveChangesAsync();
        }
        public async Task Change(ComputerBuildEntity computerBuildEntity)
        {
            _context.Builds.Update(computerBuildEntity);
            await _context.SaveChangesAsync();
        }
    }
}