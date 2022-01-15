using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Domain.Models
{
    public class ComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Socket { get; set; }
        public int CategoryId { get; set; }
    }
}
