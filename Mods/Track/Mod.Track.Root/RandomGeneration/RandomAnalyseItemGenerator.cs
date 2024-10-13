using ParallelProcessing.Models;
using ParallelProcessing.Models.Items.Analysing;

namespace ParallelProcessing.RandomGeneration;

public class RandomAnalyseItemGenerator
{
    public TypeAnalysingItem GenerateRandomColorAnalysingResultFromTrack(Track track)
    {
        return new TypeAnalysingItem()
        {
            VehicleMark = GetRandomStringStartsWith($"VehicleMark:"),
            VehicleNumber = GetRandomStringStartsWith($"VehicleNumber:"),
            VehicleModel = GetRandomStringStartsWith($"VehicleModel:"),
            VehicleType = VehicleType.Lightweight,
        };
    }
    
    public TypeAnalysingItem GenerateRandomTypeAnalysingResultFromTrack(Track track)
    {
        return new TypeAnalysingItem()
        {
            VehicleMark = GetRandomStringStartsWith($"VehicleMark:"),
            VehicleNumber = GetRandomStringStartsWith($"VehicleNumber:"),
            VehicleModel = GetRandomStringStartsWith($"VehicleModel:"),
            VehicleType = VehicleType.Lightweight,
        };
    }

    public TypeAnalysingItem GenerateRandomMarkAnalysingResultFromTrack(Track track)
    {
        return new TypeAnalysingItem()
        {
            VehicleMark = GetRandomStringStartsWith($"VehicleMark:"),
            VehicleNumber = GetRandomStringStartsWith($"VehicleNumber:"),
            VehicleModel = GetRandomStringStartsWith($"VehicleModel:"),
            VehicleType = VehicleType.Lightweight,
        };
    }

    // public SeasonAnalysingItem GenerateRandomSeasonAnalysingResultFromTrack(Track track)
    // {
    //     return new SeasonAnalyseResult()
    //     {
    //         Message = GetRandomStringStartsWith($"Season result Number:")
    //     };
    // }
    //
    // public TrafficAnalysingItem GenerateRandomTrafficAnalysingResultFromTrack(Track track)
    // {
    //     return new TrafficAnalyseResult()
    //     {
    //         Message = GetRandomStringStartsWith($"Traffic result Number:")
    //     };
    // }
    //
    // public DangerAnalysingItem GenerateRandomDangerAnalysingResultFromTrack(Track track)
    // {
    //     return new DangerAnalyseResult()
    //     {
    //         Message = GetRandomStringStartsWith($"Danger result Number:")
    //     };
    // }

    public string GetRandomStringStartsWith(string str)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string randomString = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return $"{str}  {randomString}";
    }
}

