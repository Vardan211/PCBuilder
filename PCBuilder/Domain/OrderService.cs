using PCBuilder.DataAccess;
using PCBuilder.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Domain
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }
        public async Task Add(OrderEntity orderEntity, string role, string username)
        {
            if (role == "user")
            {
                orderEntity.UserName = username;
            }
            orderEntity.OrderStatusId = "Processing";
            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Change(OrderEntity orderEntity)
        {
            _context.Orders.Update(orderEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(OrderEntity orderEntity)
        {
            _context.Orders.Remove(orderEntity);
            await _context.SaveChangesAsync();
        }

        public List<OrderEntity> GetAll(string role, string username)
        {
            if (role == "admin")
            {
                return _context.Orders.ToList();
            }
            return _context.Orders.Where(i => i.UserName == username).ToList();
        }
    }
}
