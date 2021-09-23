using PCBuilder.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PCBuilder.DataAccess.Entities;
using PCBuilder.Domain.Models;

namespace PCBuilder.Domain
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public OrderService(DataContext context, IUserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task Add(OrderDto orderDto, string role, string username)
        {
            var user = await _userService.GetUserByUsername(username);
            var orderEntity = _mapper.Map<OrderEntity>(orderDto);
            
            if (role == "user")
            {
                orderEntity.UserId = user.Id;
            }
            
            orderEntity.OrderStatus = "Processing";
            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Change(OrderDto orderDto)
        {
            var entity = _mapper.Map<OrderEntity>(orderDto);
            
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(OrderDto orderDto)
        {
            var entity = _mapper.Map<OrderEntity>(orderDto);
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDto>> GetAll(string role, string username)
        {
            var user = await _userService.GetUserByUsername(username);

            if (role == "admin")
            {
                var adminOrders = _context.Orders.ToList();
                return _mapper.Map<List<OrderDto>>(adminOrders);
            }
            
            var orders = _context.Orders.Where(i => i.UserId == user.Id).ToList();

            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
