using System.Collections.Generic;
using System.Linq;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public class BuildService : IBuildService
    {
        private List<ComputerBuildEntity> Builds { get; set; } = new List<ComputerBuildEntity>
        {
            new ComputerBuildEntity
            {
                Id = 1, Name = "First Build",  Price = 100290
            },
            new ComputerBuildEntity
            {
                Id = 2, Name = "Second Build", Price = 100290
            },
            new ComputerBuildEntity
            {
                Id = 3, Name = "Third Build", Price = 100290
            }
        };
        
        public List<ComputerBuildEntity> GetAll()
        {
            return Builds;
        }

        public void Add(ComputerBuildEntity computerBuildEntity)
        {
            Builds.Add(computerBuildEntity);
        }
        public void Delete(int id)
        {
            var itemToRemove = Builds.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
                Builds.Remove(itemToRemove);
        }
        public void Change(int id,ComputerBuildEntity computerBuildEntity)
        {
            foreach(ComputerBuildEntity pc in Builds.Where(w => w.Id == id))
            {
                pc.Id = computerBuildEntity.Id;
                pc.Name = computerBuildEntity.Name;
                pc.Price = computerBuildEntity.Price;
            }
        }
    }
}