using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.DataAccess.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string OrderStatus { get; set; }
    }
}
