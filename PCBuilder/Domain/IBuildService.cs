using System.Collections.Generic;
using System.Threading.Tasks;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public interface IBuildService
    {
        List<ComputerBuildEntity> GetAll();
        Task Add(ComputerBuildEntity computerBuildEntity);
        Task Delete(ComputerBuildEntity computerBuildEntity);
        Task Change(ComputerBuildEntity computerBuildEntity);
    }
}