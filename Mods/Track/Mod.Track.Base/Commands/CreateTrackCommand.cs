using MediatR;
using Mod.Track.Models;
using Core.Transfer;

namespace Mod.Track.Base.Commands;

public record CreateTrackCommand(TrackModel Track) : IRequest<ResponseResultWithData<TrackIdModel>>;