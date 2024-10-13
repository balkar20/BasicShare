using ParallelProcessing.Models;

namespace ParallelProcessing.ClientDevices.Abstractions;

public interface ITrackDevice
{
    public Task<BatchOfTracks> GiveMeTrackDataBunch(string batchType, int amountOfProcessors);
}