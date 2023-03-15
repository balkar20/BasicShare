using MediatR;
using Serilog;
using Mod.Product.Base.Queries;
using Mod.Product.Interfaces;

namespace Mod.Product.Base.Handlers;

public class GetTempQueryHandler: IRequestHandler<GetTempQuery, string>
{
    // private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;
    // private readonly IMapper _mapper;
    // private readonly ILogger _logger;

    // public GetTempQueryHandler(ILogger logger, IProductService productService)
    public GetTempQueryHandler(IProductService productService)
    {
        // _logger = logger;
        // _productService = productService;
        // _productRepository = productRepository;
        // _mapper = mapper;
    }
    
    public async Task<string> Handle(GetTempQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // _logger.LogError("-------------Error---------------");
            return "juyguyuyg";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "err";
        }
    }
}