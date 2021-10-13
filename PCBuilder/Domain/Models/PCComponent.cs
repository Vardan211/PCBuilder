using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Domain.Models
{
    public class PCComponent
    {
        public int GpuId { get; set; }
        public int CpuId { get; set; }
        public int MotherboardId { get; set; }

    }
}
