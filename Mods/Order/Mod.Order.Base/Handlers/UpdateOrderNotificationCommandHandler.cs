using Core.Transfer;
using MediatR;
using Mod.Order.Base.Commands;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Base.Handlers;

public class UpdateOrderNotificationCommandHandler: IRequestHandler<UpdateOrderNotificationCommand, BaseResponseResult>
{
    private readonly IOrderWriteService _orderService;
    public UpdateOrderNotificationCommandHandler(IOrderWriteService orderService) => _orderService = orderService;

    public async Task<BaseResponseResult> Handle(UpdateOrderNotificationCommand request, CancellationToken cancellationToken)
    {
        var result = new BaseResponseResult()
        {
            IsSuccess = false
        };

        await _orderService.UpdateOrderNotification(request.OrderNotificationModel);
        result.IsSuccess = true;
        
        return result;
    }
}