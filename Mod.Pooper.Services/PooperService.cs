using Core.Base.ConfigurationInterfaces;
using Core.Base.DataBase.Entities;
using Serilog;
using Mod.Pooper.Interfaces;
using Mod.Pooper.Models;

namespace Mod.Pooper.Base.Repositories;

public class PooperService: IPooperService
{
    private readonly IPooperRepository _repository;
    private readonly ILogger _logger;
    private readonly IPooperApiConfiguration _configuration;

    public PooperService(
        ILogger logger,
        IPooperApiConfiguration configuration,
        IPooperRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<List<PooperModel>> GetAllPoopers()
    {
        var Poopers =  await _repository.GetAllMappedToModelAsync<PooperEntity>(o => o.OrderBy(j => j.AmountOfPoops), null, null, null);
        return Poopers.ToList();
    }
}