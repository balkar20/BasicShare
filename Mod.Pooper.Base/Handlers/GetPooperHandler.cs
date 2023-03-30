using MediatR;
using Serilog;
using Mod.Pooper.Base.Queries;
using Mod.Pooper.Interfaces;

namespace Mod.Pooper.Base.Handlers;

public class GetTempQueryHandler: IRequestHandler<GetTempQuery, string>
{
    // private readonly IPooperRepository _PooperRepository;
    private readonly IPooperService _PooperService;
    // private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetTempQueryHandler(ILogger logger, IPooperService PooperService)
    {
        _logger = logger;
        _PooperService = PooperService;
        // _PooperRepository = PooperRepository;
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