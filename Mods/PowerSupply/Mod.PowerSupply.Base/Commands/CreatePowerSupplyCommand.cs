using Core.Transfer;
using MediatR;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Base.Commands;

public record CreatePowerSupplyCommand(PowerSupplyModel PowerSupply) : IRequest<BaseResponseResult>;