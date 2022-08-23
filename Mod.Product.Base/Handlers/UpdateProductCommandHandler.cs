using MediatR;
using Mod.Product.Base.Commands;
using Mod.Product.Interfaces;
using ModProduct.Models;

namespace Mod.Product.Base.Handlers;

public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, ProductModel>
{
    private readonly IProductRepository _productRepository;
    
    public UpdateProductCommandHandler(IProductRepository productRepository) => _productRepository = productRepository;

    public async Task<ProductModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.Update(request.Product);
    }
}