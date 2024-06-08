using MediatR;
using Mod.PowerSupply.Base.Queries;
using Mod.PowerSupply.Interfaces;

namespace Mod.PowerSupply.Base.Handlers;

public class GetTempQueryHandler: IRequestHandler<GetTempQuery, string>
{
    // private readonly IPowerSupplyRepository _productRepository;
    private readonly IPowerSupplyService _productService;
    // private readonly IMapper _mapper;
    // private readonly ILogger _logger;

    // public GetTempQueryHandler(ILogger logger, IPowerSupplyService productService)
    public GetTempQueryHandler(IPowerSupplyService productService)
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