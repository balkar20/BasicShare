using MediatR;
using Mod.Pooper.Base.Commands;
using Mod.Pooper.Interfaces;
using Mod.Pooper.Models;

namespace Mod.Pooper.Base.Handlers;

public class CreatePooperCommandHandler: IRequestHandler<CreatePooperCommand, PooperModel>
{
    private readonly IPooperRepository _PooperRepository;

    public CreatePooperCommandHandler(IPooperRepository PooperRepository) => _PooperRepository = PooperRepository;
    
    public async Task<PooperModel> Handle(CreatePooperCommand request, CancellationToken cancellationToken)
    {
        return await _PooperRepository.AddAsync(request.Pooper);
    }
}