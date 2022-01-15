using System.Collections.Generic;
using System.Threading.Tasks;
using PCBuilder.Domain.Models;

namespace PCBuilder.Domain
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAll(string role, string username);
        Task Add(OrderDto orderDto,string role, string username);
        Task Delete(OrderDto orderDto);
        Task Change(OrderDto orderDto);
    }
}
