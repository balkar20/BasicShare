using MediatR;
using Mod.Product.Base.Commands;
using Mod.Product.Base.Models;
using Mod.Product.Base.Repositories;

namespace Mod.Product.Base.Handlers;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, ProductModel>
{
    private readonly IProductRepository _productRepository;
    public CreateProductCommandHandler(IProductRepository productRepository) => _productRepository = productRepository;
    
    public async Task<ProductModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.AddAsync(request.Product);
    }
}