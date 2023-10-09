using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.Order.Models;

namespace Mod.Order.Base.Mapping;

public class OrderEventProfile: Profile
{
    public OrderEventProfile()
    {
        CreateMap<OrderModel, OrderEntity>().ReverseMap();
    }
}