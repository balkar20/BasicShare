using AutoMapper;
using Core.Base.DataBase.Entities;
using Core.Base.Output;
using MediatR;
using Microsoft.Extensions.Logging;
using Mod.Product.Base.Queries;
using Mod.Product.Base.ViewModels;
using Mod.Product.Interfaces;
using ModProduct.Models;

namespace Mod.Product.Base.Handlers;

public class GetTempQueryHandler: IRequestHandler<GetTempQuery, string>
{
    // private readonly IProductRepository _productRepository;
    // private readonly IProductService _productService;
    // private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetTempQueryHandler()
    {
        // _productRepository = productRepository;
        // _productService = productService;
        // _mapper = mapper;
    }
    
    public async Task<string> Handle(GetTempQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogError("-------------Error---------------");
            return "juyguyuyg";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "err";
        }
    }
}