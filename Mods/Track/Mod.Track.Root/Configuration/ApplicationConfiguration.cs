namespace ParallelProcessing.Configuration;

public class ApplicationConfiguration
{
    public int MaxParallelConsumeCount { get; set; }
    
    public int BoundedCapacity { get; set; }
    
    public TimeSpan ProduceSpeed { get; set; }
    
    public TimeSpan ConsumeSpeed { get; set; }
    
    public bool PropagateCompletion { get; set; }
    
    public VehicleTypeAnalyseConfig VehicleTypeAnalyseConfig { get; set; }
    
    public VehicleColorAnalyseConfig VehicleColorAnalyseConfig { get; set; }
    
    public VehicleDangerAnalyseConfig VehicleDangerAnalyseConfig { get; set; }
    
    public VehicleSeasonAnalyseConfig VehicleSeasonAnalyseConfig { get; set; }
    
    public VehicleTrafficAnalyseConfig VehicleTrafficAnalyseConfig { get; set; }
    
    public VehicleMarkAnalyseConfig VehicleMarkAnalyseConfig { get; set; }
}