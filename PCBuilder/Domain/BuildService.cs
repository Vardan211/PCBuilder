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
        private readonly IUserService _userService;
        
        public BuildService(ICompatibilityService compatibilityService, DataContext context, IUserService userService)
        {
            _compatibilityService = compatibilityService;
            _context = context;
            _userService = userService;
        }
        public async Task<List<ComputerBuildEntity>> GetAll(string role, string username)
        {
            var user = await _userService.GetUserByUsername(username);

            if(role == "admin")
            {
                return _context.Builds.ToList();
            }
            return _context.Builds.Where(i => i.UserId == user.Id).ToList();
        }

        public async Task Add(ComputerBuildEntity computerBuildEntity,string role, string username)
        {
            var user = await _userService.GetUserByUsername(username);

            if (_compatibilityService.compatibility((int)computerBuildEntity.GPUId, (int)computerBuildEntity.CPUId, (int)computerBuildEntity.MBId))
            {
                var gpu = _context.Components.Find(computerBuildEntity.GPUId);
                var cpu = _context.Components.Find(computerBuildEntity.CPUId);
                var mb = _context.Components.Find(computerBuildEntity.MBId);
                if(role == "user")
                {
                    computerBuildEntity.UserId = user.Id;
                }
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