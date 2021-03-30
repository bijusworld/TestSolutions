using AutoMapper;
using OrderApp.API.Models;
using OrderApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.API.Profiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderModel>()
              .ForMember(o => o.OrderId, ex => ex.MapFrom(i => i.Id))
              .ReverseMap();

            CreateMap<OrderItem, OrderItemModel>()
              .ReverseMap();
        }
    }
}
