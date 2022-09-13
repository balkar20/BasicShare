using MediatR;
using Mod.Auth.Base.Commands;
using Mod.Auth.Interfaces;
using Mod.Auth.Models;

namespace Mod.Auth.Base.Handlers;

//public class CreateAuthCommandHandler: IRequestHandler<CreateAuthCommand, AuthModel>
//{
//    //private readonly IAuthRepository _productRepository;

//    //public CreateAuthCommandHandler(IAuthRepository productRepository) => _productRepository = productRepository;
    
//    //public async Task<AuthModel> Handle(CreateAuthCommand request, CancellationToken cancellationToken)
//    //{
//    //    return await _productRepository.AddAsync(request.Auth);
//    //}
//}