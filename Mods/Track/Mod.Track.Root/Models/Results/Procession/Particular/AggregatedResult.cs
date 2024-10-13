namespace ParallelProcessing.Models.Results.Procession.Particular;

public class AggregatedResult
{
    public VehicleTypeProcessionResult TypeProcessionResult { get; set; }
    public VehicleTrafficProcessionResult TrafficProcessionResult { get; set; }
    public VehicleSeasonProcessionResult SeasonProcessionResult { get; set; }
    public VehicleMarkProcessionResult MarkProcessionResult { get; set; }
    public VehicleDangerProcessionResult DangerProcessionResult { get; set; }
    public VehicleColorProcessionResult ColorProcession { get; set; }
}