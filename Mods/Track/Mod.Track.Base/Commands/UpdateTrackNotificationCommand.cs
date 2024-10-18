using Core.Transfer;
using MediatR;
using Mod.Track.Models;

namespace Mod.Track.Base.Commands;

public record UpdateTrackNotificationCommand(TrackNotificationModel TrackNotificationModel) : IRequest<BaseResponseResult>;