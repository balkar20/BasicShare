using Core.Transfer;
using MediatR;
using Mod.Order.Base.Commands;
using Mod.Order.Interfaces;
using Mod.Order.Models;

namespace Mod.Order.Base.Handlers;

public class UpdateOrderPaymentInfoCommandHandler: IRequestHandler<UpdateOrderPaymentInfoCommand, BaseResponseResult>
{
    private readonly IOrderWriteService _orderService;
    
    public UpdateOrderPaymentInfoCommandHandler(IOrderWriteService orderService) => _orderService = orderService;

    public async Task<BaseResponseResult> Handle(UpdateOrderPaymentInfoCommand request, CancellationToken cancellationToken)
    {
        var result = new BaseResponseResult()
        {
            IsSuccess = false
        };

        await _orderService.UpdateOrderPaymentInfo(request.OrderPaymentInfoModel);
        result.IsSuccess = true;
        
        return result;
    }
}