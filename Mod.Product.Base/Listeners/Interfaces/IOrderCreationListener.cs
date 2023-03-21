using Core.Transfer.Mods.Order;

namespace Mod.Product.Base.Listeners.Interfaces;

public interface IOrderCreationListener: IListener
{
    void Handle(OrderModel orderModel);
}