using Core.Transfer;
using MediatR;
using Mod.Track.Base.Commands;
using Mod.Track.Interfaces;
using Mod.Track.Models;

namespace Mod.Track.Base.Handlers;

public class UpdateTrackNotificationCommandHandler: IRequestHandler<UpdateTrackNotificationCommand, BaseResponseResult>
{
    private readonly ITrackWriteService _TrackService;
    public UpdateTrackNotificationCommandHandler(ITrackWriteService TrackService) => _TrackService = TrackService;

    public async Task<BaseResponseResult> Handle(UpdateTrackNotificationCommand request, CancellationToken cancellationToken)
    {
        var result = new BaseResponseResult()
        {
            IsSuccess = false
        };

        await _TrackService.UpdateTrackNotification(request.TrackNotificationModel);
        result.IsSuccess = true;
        
        return result;
    }
}