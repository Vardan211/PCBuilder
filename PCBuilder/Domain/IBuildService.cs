using System.Collections.Generic;
using System.Threading.Tasks;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public interface IBuildService
    {
        List<ComputerBuildEntity> GetAll(string role, int userId);
        Task Add(ComputerBuildEntity computerBuildEntity, string role, int userId);
        Task Delete(ComputerBuildEntity computerBuildEntity);
        Task Change(ComputerBuildEntity computerBuildEntity);
    }
}