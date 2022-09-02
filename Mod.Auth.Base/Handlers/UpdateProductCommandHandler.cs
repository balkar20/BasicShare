using MediatR;
using Mod.Auth.Base.Commands;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class UpdateAuthCommandHandler: IRequestHandler<UpdateAuthCommand, UserModel>
{
    private readonly IAuthRepository _productRepository;
    
    public UpdateAuthCommandHandler(IAuthRepository productRepository) => _productRepository = productRepository;

    public async Task<UserModel> Handle(UpdateAuthCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.UpdateAsync(request.Auth);
    }
}