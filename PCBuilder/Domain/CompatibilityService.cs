using PCBuilder.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Domain
{
    public class CompatibilityService:ICompatibilityService
    {
        private readonly DataContext _context;
        public CompatibilityService(DataContext context)
        {
            _context = context;
        }
        public bool compatibility(int idGPU, int idCPU, int idMB)
        {
            var gpu = _context.Components.Find(idGPU);
            if (gpu.CategoryId != 2)
                return false;
            var cpu = _context.Components.Find(idCPU);
            if (cpu.CategoryId != 1)
                return false;
            var mb = _context.Components.Find(idMB);
            if (mb.CategoryId != 3)
                return false;
            if (cpu.Socket == mb.Socket)
                return true;
            else
            return false;
        }
    }
}
