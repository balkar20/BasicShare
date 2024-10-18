using MediatR;
using Mod.Track.Models;

namespace Mod.Track.Base.Queries;

public record GetAllTracksQuery : IRequest<List<TrackModel>>;