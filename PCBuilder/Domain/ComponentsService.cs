using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public class ComponentsService:IComponentsService
    {
        private List<OtherComponentsEntity> GPU { get; set; } = new List<OtherComponentsEntity>
        {
            new OtherComponentsEntity
            {
                Id = 1, Name = "GTX 1660", Price = 43300
            },
            new OtherComponentsEntity
            {
                Id = 2, Name = "RTX 2060", Price = 56900
            },
            new OtherComponentsEntity
            {
                Id = 3, Name = "RTX 3090", Price = 225990
            },
        };
        private List<CPU_MB_ComponentsEntity> CPU { get; set; } = new List<CPU_MB_ComponentsEntity>
        {
            new CPU_MB_ComponentsEntity
            {
                Id = 1, Name = "Intel Core i3 10100f",Socket = "LGA 1200", Price = 7599
            },
            new CPU_MB_ComponentsEntity
            {
                Id = 2, Name = "Ryzen 5 3400g", Socket = "AM4", Price = 20000
            },
            new CPU_MB_ComponentsEntity
            {
                Id = 3, Name = "Ryzen 7 5800x",Socket = "AM4", Price = 35799
            },
        };
        private List<CPU_MB_ComponentsEntity> MotherBoard { get; set; } = new List<CPU_MB_ComponentsEntity>
        {
            new CPU_MB_ComponentsEntity
            {
                Id = 1, Name = "Asus Prime b450m-k",Socket = "AM4", Price = 4620
            },
            new CPU_MB_ComponentsEntity
            {
                Id = 2, Name = "Asus TUF Gaming b460-plus", Socket = "LGA 1200", Price = 20000
            },
            new CPU_MB_ComponentsEntity
            {
                Id = 3, Name = "Gigabyte H310M S2",Socket = "LGA 1150", Price = 3320
            },
        };
        
        public void AddGPU(OtherComponentsEntity otherComponentsEntity)
        {
            GPU.Add(otherComponentsEntity);
        }
        public void AddCPUorMB(CPU_MB_ComponentsEntity cpu_mb, string type)
        {
            if (type == "CPU")
                CPU.Add(cpu_mb);
            else
                MotherBoard.Add(cpu_mb);
        }
        public bool compatibility(int idGPU, int idCPU, int idMB)
        {
            var gpu = GPU.SingleOrDefault(r => r.Id == idGPU);
            var cpu = CPU.SingleOrDefault(r => r.Id == idCPU);
            var mb = MotherBoard.SingleOrDefault(r => r.Id == idMB);
            if (cpu.Socket == mb.Socket)
                return true;
            else
                return false;
        }
        public ComputerBuildEntity assembling(string name, int idGPU, int idCPU, int idMB)
        {
            var gpu = GPU.SingleOrDefault(r => r.Id == idGPU);
            var cpu = CPU.SingleOrDefault(r => r.Id == idCPU);
            var mb = MotherBoard.SingleOrDefault(r => r.Id == idMB);
            ComputerBuildEntity Mybuld = new ComputerBuildEntity(); 
            if (compatibility(idGPU, idCPU, idMB))
            {
                Mybuld.Name = name;
                Mybuld.GPU = gpu.Name;
                Mybuld.CPU = cpu.Name;
                Mybuld.MB = mb.Name;
                Mybuld.Price = gpu.Price + cpu.Price + mb.Price;
                return Mybuld;
            }
            else
                return Mybuld = null;
        }

    }
}
