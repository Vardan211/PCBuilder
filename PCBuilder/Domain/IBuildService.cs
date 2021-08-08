using System.Collections.Generic;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public interface IBuildService
    {
        List<ComputerBuildEntity> GetAll();
        void Add(ComputerBuildEntity computerBuildEntity);
        void Delete(int id);
        void Change(int id,ComputerBuildEntity computerBuildEntity);
    }
}