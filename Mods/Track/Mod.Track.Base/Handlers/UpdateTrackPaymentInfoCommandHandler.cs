using Core.Transfer;
using MediatR;
using Mod.Track.Base.Commands;
using Mod.Track.Interfaces;
using Mod.Track.Models;

namespace Mod.Track.Base.Handlers;

public class UpdateTrackPaymentInfoCommandHandler: IRequestHandler<UpdateTrackPaymentInfoCommand, BaseResponseResult>
{
    private readonly ITrackWriteService _TrackService;
    
    public UpdateTrackPaymentInfoCommandHandler(ITrackWriteService TrackService) => _TrackService = TrackService;

    public async Task<BaseResponseResult> Handle(UpdateTrackPaymentInfoCommand request, CancellationToken cancellationToken)
    {
        var result = new BaseResponseResult()
        {
            IsSuccess = false
        };

        await _TrackService.UpdateTrackPaymentInfo(request.TrackPaymentInfoModel);
        result.IsSuccess = true;
        
        return result;
    }
}