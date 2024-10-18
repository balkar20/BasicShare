// using MediatR;
// using Mod.Track.Base.Queries;
// using Mod.Track.Interfaces;
// using Mod.Track.Models;
//
// namespace Mod.Track.Base.Handlers;
//
// public class GetAllTracksQueryHandler: IRequestHandler<GetAllTracksQuery, List<TrackModel>>
// {
//     private readonly ITrackRepository _TrackRepository;
//     private readonly ITrackService _TrackService;
//
//     public GetAllTracksQueryHandler(ITrackRepository TrackRepository, ITrackService TrackService)
//     {
//         _TrackRepository = TrackRepository;
//         _TrackService = TrackService;
//     }
//     
//     public async Task<List<TrackModel>> Handle(GetAllTracksQuery request, CancellationToken cancellationToken)
//     {
//         return await _TrackService.GetAllTracks();
//     }
// }