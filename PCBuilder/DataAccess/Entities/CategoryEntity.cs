using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.DataAccess.Entities
{
    public class CategoryEntity
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<ComponentEntity> ComponentEntities { get; set; }
    }
}
