using MediatR;
using Mod.Pooper.Base.Commands;
using Mod.Pooper.Interfaces;
using Mod.Pooper.Models;

namespace Mod.Pooper.Base.Handlers;

public class UpdatePooperCommandHandler: IRequestHandler<UpdatePooperCommand, PooperModel>
{
    private readonly IPooperRepository _PooperRepository;
    
    public UpdatePooperCommandHandler(IPooperRepository PooperRepository) => _PooperRepository = PooperRepository;

    public async Task<PooperModel> Handle(UpdatePooperCommand request, CancellationToken cancellationToken)
    {
        return await _PooperRepository.UpdateAsync(request.Pooper);
    }
}