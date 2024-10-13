namespace ParallelProcessing.Configuration;

public class VehicleTypeAnalyseConfig: IVehicleAnalyseConfig
{
    public TimeSpan TimeForAnalyse { get; set; }
}