using Db.Entities;
using MediatR;

namespace ModProduct.Commands;

public class CreateProductCommand: IRequest<Product>
{
    public Product Product { get; set; } 
}