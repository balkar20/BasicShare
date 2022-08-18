using Db.Entities;
using Db.Interfaces;
using MediatR;
using ModProduct.Commands;
// using ModProduct.Models;
using ModProduct.Repositories;

namespace ModProduct.Handlers;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository _productRepository;
    public CreateProductCommandHandler(IProductRepository productRepository) => _productRepository = productRepository;
    
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.AddAsync(request.Product);
    }
}