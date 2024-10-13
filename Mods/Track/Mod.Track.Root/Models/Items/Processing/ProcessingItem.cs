using ParallelProcessing.Models.Items.Base;

namespace ParallelProcessing.Models.Items.Processing;

public class ProcessingItem:ApplicationItem<string>
{
    
}

public class TypeProcessingItem : ProcessingItem
{
    public string VehicleMark { get; set; }
    
    public string VehicleNumber { get; set; }
    
    public string VehicleModel { get; set; }
    
    public string VehicleColor { get; set; }
    
    public VehicleType VehicleType { get; set; }
}