﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.DataAccess.Entities
{
    public class ComponentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Socket { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }

    
}
