using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public interface IComponentsService
    {
        void AddGPU(OtherComponentsEntity otherComponentsEntity);
        void AddCPUorMB(CPU_MB_ComponentsEntity cpu_mb,string type);
        bool compatibility(int idGPU, int idCPU, int idMB);
        ComputerBuildEntity assembling(string name,int idGPU, int idCPU, int idMB);
    }
}
