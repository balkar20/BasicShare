using MediatR;
using Mod.MotorControlsModule.Base.Queries;
using Mod.MotorControlsModule.Interfaces;

namespace Mod.MotorControlsModule.Base.Handlers;

public class GetTempQueryHandler: IRequestHandler<GetTempQuery, string>
{
    // private readonly IMotorControlsModuleRepository _productRepository;
    private readonly IMotorControlsModuleService _productService;
    // private readonly IMapper _mapper;
    // private readonly ILogger _logger;

    // public GetTempQueryHandler(ILogger logger, IMotorControlsModuleService productService)
    public GetTempQueryHandler(IMotorControlsModuleService productService)
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