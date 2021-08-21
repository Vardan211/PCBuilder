using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Domain
{
    public interface ICompatibilityService
    {
        public bool compatibility(int idGPU, int idCPU, int idMB);
    }
}
