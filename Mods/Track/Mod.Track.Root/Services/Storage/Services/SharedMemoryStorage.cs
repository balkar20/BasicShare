using System.Collections.Concurrent;
using ParallelProcessing.Models;
using ParallelProcessing.Models.Results;
using ParallelProcessing.Services.Storage.Abstractions;

namespace ParallelProcessing.Services;

/// <summary>
/// Shared Memory Operation should be Thread safe
/// </summary>
public class SharedMemoryStorage : ISharedMemoryStorage
{
    public ConcurrentDictionary<string, Track> ProcessingItemsStorage { get; set; } = new();
    
    public ConcurrentDictionary<string, VehicleTypeProcessionResult> ProcessionTypeResultStorage { get; set; } = new();
    
    public ConcurrentDictionary<string, VehicleMarkProcessionResult> ProcessionMarkResultStorage { get; set; } = new();

    public ConcurrentDictionary<string, VehicleColorProcessionResult> ProcessionColorResultStorage { get; set; } = new();

    public ConcurrentDictionary<string, VehicleSeasonProcessionResult> ProcessionSeasonResultStorage { get; set; } = new();

    public ConcurrentDictionary<string, VehicleDangerProcessionResult> ProcessionDangerResultStorage { get; set; } = new();

    public ConcurrentDictionary<string, VehicleTrafficProcessionResult> ProcessionTrafficResultStorage { get; set; } = new();
}