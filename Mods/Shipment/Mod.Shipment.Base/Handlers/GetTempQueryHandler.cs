using MediatR;
using Mod.Shipment.Base.Queries;
using Mod.Shipment.Interfaces;

namespace Mod.Shipment.Base.Handlers;

public class GetTempQueryHandler: IRequestHandler<GetTempQuery, string>
{
    // private readonly IShipmentRepository _productRepository;
    private readonly IShipmentService _productService;
    // private readonly IMapper _mapper;
    // private readonly ILogger _logger;

    // public GetTempQueryHandler(ILogger logger, IShipmentService productService)
    public GetTempQueryHandler(IShipmentService productService)
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