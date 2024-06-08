using MediatR;
using Mod.CameraModule.Base.Queries;
using Mod.CameraModule.Interfaces;

namespace Mod.CameraModule.Base.Handlers;

public class GetTempQueryHandler: IRequestHandler<GetTempQuery, string>
{
    // private readonly ICameraModuleRepository _productRepository;
    private readonly ICameraModuleService _productService;
    // private readonly IMapper _mapper;
    // private readonly ILogger _logger;

    // public GetTempQueryHandler(ILogger logger, ICameraModuleService productService)
    public GetTempQueryHandler(ICameraModuleService productService)
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