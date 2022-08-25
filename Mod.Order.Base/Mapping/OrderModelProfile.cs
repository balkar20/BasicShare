using AutoMapper;
using Core.Base.DataBase.Entities;
using Mod.Order.Models;

namespace Mod.Order.Base.Mapping;

public class OrderModelProfile: Profile
{
    public OrderModelProfile()
    {
        CreateMap<OrderModel, OrderEntity>().ReverseMap();
    }
}