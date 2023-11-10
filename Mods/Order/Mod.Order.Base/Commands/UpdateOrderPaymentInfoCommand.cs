using Core.Transfer;
using MediatR;
using Mod.Order.Models;

namespace Mod.Order.Base.Commands;

public record UpdateOrderPaymentInfoCommand(OrderPaymentInfoModel OrderPaymentInfoModel) : IRequest<BaseResponseResult>;