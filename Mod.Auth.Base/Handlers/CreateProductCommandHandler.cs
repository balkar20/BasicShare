using MediatR;
using Mod.Auth.Base.Commands;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

public class CreateAuthCommandHandler: IRequestHandler<CreateAuthCommand, UserModel>
{
    private readonly IAuthRepository _productRepository;

    public CreateAuthCommandHandler(IAuthRepository productRepository) => _productRepository = productRepository;
    
    public async Task<UserModel> Handle(CreateAuthCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.AddAsync(request.Auth);
    }
}