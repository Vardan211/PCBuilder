using Microsoft.EntityFrameworkCore;
using PCBuilder.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.DataAccess
{
    public class DataContext:DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ComponentEntity> Components { get; set; }
        public DbSet<ComputerBuildEntity> Builds { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {

        }
    }
}
