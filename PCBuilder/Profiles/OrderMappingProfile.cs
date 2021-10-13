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
            CreateMap<ComputerBuildDto, ComponentEntity>(MemberList.None).ReverseMap();
            CreateMap<ComputerBuildDto, ComputerBuildEntity>(MemberList.None).ReverseMap();
            CreateMap<ComponentDto, ComponentEntity>(MemberList.None).ReverseMap();
        }
    }
}