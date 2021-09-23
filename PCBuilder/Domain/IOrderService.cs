using PCBuilder.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Domain
{
    public interface IOrderService
    {
        List<OrderEntity> GetAll(string role, string username);
        Task Add(OrderEntity orderEntity,string role, string username);
        Task Delete(OrderEntity orderEntity);
        Task Change(OrderEntity orderEntity);
    }
}
