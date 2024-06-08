// using MediatR;

using Core.Base.Output;
using Core.Transfer;
using MediatR;
using Mod.PowerSupply.Base.ViewModels;
using Mod.PowerSupply.Models;

namespace Mod.PowerSupply.Base.Queries;

public record GetAllPowerSupplysQuery : IRequest<ResponseResultWithData<List<PowerSupplyModel>>>;