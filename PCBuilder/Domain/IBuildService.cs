using System.Collections.Generic;
using System.Threading.Tasks;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public interface IBuildService
    {
        Task<List<ComputerBuildEntity>> GetAll(string role, string username);
        Task Add(ComputerBuildEntity computerBuildEntity, string role, string username);
        Task Delete(ComputerBuildEntity computerBuildEntity);
        Task Change(ComputerBuildEntity computerBuildEntity);
    }
}