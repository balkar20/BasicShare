namespace ParallelProcessing.Models;

public class BatchOfTracks
{
    public Queue<Track> Tracks { get; set; }
    
    public TimeFrame TimeFrame { get; set; }
}