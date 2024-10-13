using System.Collections.Concurrent;
using ParallelProcessing.Models;
using ParallelProcessing.Models.Results;

namespace ParallelProcessing.Services.Storage.Abstractions;

public interface ISharedMemoryStorage
{
    ConcurrentDictionary<string, Track> ProcessingItemsStorage{ get; set; }
    ConcurrentDictionary<string, VehicleTypeProcessionResult> ProcessionTypeResultStorage{ get; set; }
    ConcurrentDictionary<string, VehicleMarkProcessionResult> ProcessionMarkResultStorage{ get; set; }
    ConcurrentDictionary<string, VehicleColorProcessionResult> ProcessionColorResultStorage{ get; set; }
    ConcurrentDictionary<string, VehicleSeasonProcessionResult> ProcessionSeasonResultStorage{ get; set; }
    ConcurrentDictionary<string, VehicleDangerProcessionResult> ProcessionDangerResultStorage{ get; set; }
    ConcurrentDictionary<string, VehicleTrafficProcessionResult> ProcessionTrafficResultStorage{ get; set; }
}