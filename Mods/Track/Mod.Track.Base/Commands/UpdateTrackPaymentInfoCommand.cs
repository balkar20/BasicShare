using Core.Transfer;
using MediatR;
using Mod.Track.Models;

namespace Mod.Track.Base.Commands;

public record UpdateTrackPaymentInfoCommand(TrackPaymentInfoModel TrackPaymentInfoModel) : IRequest<BaseResponseResult>;