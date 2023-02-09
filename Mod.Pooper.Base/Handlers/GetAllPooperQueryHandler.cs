using AutoMapper;
using Core.Base.Output;
using MediatR;
using Serilog;
using Mod.Pooper.Base.Queries;
using Mod.Pooper.Base.ViewModels;
using Mod.Pooper.Interfaces;
using Mod.Pooper.Models;

namespace Mod.Pooper.Base.Handlers;

public class GetAllPoopersQueryHandler: IRequestHandler<GetAllPoopersQuery, OutputViewModelWithData<List<PooperViewModel>>>
{
    private readonly IPooperService _PooperService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public GetAllPoopersQueryHandler(ILogger logger, IMapper mapper, IPooperService PooperService)
    {
        _logger = logger;
        _mapper = mapper;
        _PooperService = PooperService;
    }
    
    public async Task<OutputViewModelWithData<List<PooperViewModel>>> Handle(GetAllPoopersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var Poopers =  await _PooperService.GetAllPoopers();
            var data = Poopers.Select(p => _mapper.Map<PooperModel, PooperViewModel>(p)).ToList();
            return  new OutputViewModelWithData<List<PooperViewModel>>(true, null, data);
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return new OutputViewModelWithData<List<PooperViewModel>>(false, e.Message, null);
        }
    }
}