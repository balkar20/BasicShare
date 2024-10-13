using Core.Base.Configuration;
using Core.Base.DataBase.Entities;
using Microsoft.Extensions.Options;
using Mod.Track.Interfaces;
using Mod.Track.Interfaces;
using Mod.Track.Models;
using Serilog;

namespace Mod.Track.Base.Repositories;

public class TrackReadService: ITrackReadService
{
    private readonly ITrackRepository _repository;
    private readonly ILogger _logger;
    private readonly TrackApiConfiguration _configuration;

    public TrackReadService(
        ILogger logger,
        IOptions<TrackApiConfiguration> options,
        ITrackRepository repository)
    {
        _repository = repository;
        _logger = logger;
        _configuration = options.Value;
    }

    public async Task<List<TrackModel>> GetAllTracks()
    {
        var orders =  await _repository.GetAllMappedToModelAsync<TrackEntity>(o => o.OrderBy(j => j.Description), null, null, null);
        return orders.ToList();
    }
}