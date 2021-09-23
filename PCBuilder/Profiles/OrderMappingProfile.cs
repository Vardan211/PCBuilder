using AutoMapper;
using PCBuilder.DataAccess.Entities;
using PCBuilder.Domain.Models;

namespace PCBuilder.Profiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderDto, OrderEntity>(MemberList.None).ReverseMap();
            
            CreateMap<UserDto, ApplicationUser>(MemberList.None).ReverseMap();
        }
    }
}