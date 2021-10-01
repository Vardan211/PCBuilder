using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Domain.Models
{
    public class ComputerBuildDto
    {
        public string name { get; set; }
        public int gpuId { get; set; }
        public int cpuId { get; set; }
        public int mbId { get; set; }
    }
}
