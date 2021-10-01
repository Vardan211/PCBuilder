using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PCBuilder.DataAccess.Entities;
using PCBuilder.Domain.Models;

namespace PCBuilder.Domain
{
    public interface IComponentsService
    {
        Task Add(ComponentEntity component);
        Task Remove(ComponentEntity component);
        Task Update(ComponentEntity component);
        List<ComponentEntity> GetAll();
        List<ComponentEntity> GetByType(int categoryId);
        List<ComponentEntity> GetById(int id);
        ComputerBuildEntity Assembly(ComputerBuildDto buildDto);
    }
}
