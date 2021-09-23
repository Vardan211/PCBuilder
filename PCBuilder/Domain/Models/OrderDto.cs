using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Domain.Models
{
    public class OrderDto
    {
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public string OrderStatus { get; set; }
    }
}
