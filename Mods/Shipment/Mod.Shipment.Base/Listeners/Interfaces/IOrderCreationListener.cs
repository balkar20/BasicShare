using Core.Base.EventSourcing.Intefaces;
using Core.Transfer.Mods.Order;

namespace Mod.Shipment.Base.Listeners.Interfaces;

public interface IOrderCreationListener: IListener
{
    void Handle(OrderModel orderModel);
}