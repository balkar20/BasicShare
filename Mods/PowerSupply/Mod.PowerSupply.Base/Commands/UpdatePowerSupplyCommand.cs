using Core.Transfer;
using MediatR;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Base.Commands;

public record UpdatePowerSupplyCommand(PowerSupplyModel PowerSupply) : IRequest<BaseResponseResult>;