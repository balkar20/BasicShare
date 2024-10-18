using Core.Transfer;
using Infrastructure.Interfaces;
using MediatR;
using Mod.Track.Base.Commands;
using Mod.Track.Interfaces;
using Mod.Track.Models;

namespace Mod.Track.Base.Handlers;

public class CreateTrackCommandHandler: IRequestHandler<CreateTrackCommand, ResponseResultWithData<TrackIdModel>>
{
    private ITrackWriteService _TrackService;

    // public CreateTrackCommandHandler(ITrackRepository TrackRepository, IRabbitMqProducer rabbitMqProducer)
    public CreateTrackCommandHandler(ITrackWriteService TrackService)
    {
        // _TrackRepository = TrackRepository;
        _TrackService = TrackService;
    }

    public async Task<ResponseResultWithData<TrackIdModel>> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
    {
        var result = new ResponseResultWithData<TrackIdModel>
        {
            IsSuccess = false,
        };
        
        result.Data = await _TrackService.CreateTrack(request.Track);
        result.IsSuccess = true;
        
        return result;
    }
}