// using MediatR;

using Core.Base.Output;
using MediatR;
using Mod.Pooper.Base.ViewModels;

namespace Mod.Pooper.Base.Queries;

public record GetAllPoopersQuery : IRequest<OutputViewModelWithData<List<PooperViewModel>>>;