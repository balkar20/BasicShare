using ParallelProcessing.Models.Results;
using ParallelProcessing.Models.Results.Analyse.Abstractions;

namespace ParallelProcessing.RandomGeneration;

public class RandomProcessionResultGenerator
{
    public VehicleTypeProcessionResult GenerateRandomTypeProcessionResultFromTrack(IAnalysingResult analysingResult)
    {
        return new VehicleTypeProcessionResult()
        {
            IsSucceed = true,
            Message = GetRandomStringStartsWith($"TypeProcessionResult :"),
        };
    }
    public VehicleColorProcessionResult GenerateRandomColorProcessionResultFromTrack(IAnalysingResult analysingResult)
    {
        return new VehicleColorProcessionResult()
        {
            IsSucceed = true,
            Message = GetRandomStringStartsWith($"ColorProcessionResult :"),
        };
    }

    public VehicleMarkProcessionResult GenerateRandomMarkProcessionResultFromTrack(IAnalysingResult analysingResult)
    {
        return new VehicleMarkProcessionResult()
        {
            IsSucceed = true,
            Message = GetRandomStringStartsWith($"MarkProcessionResult :"),
        };
    }

    public VehicleSeasonProcessionResult GenerateRandomSeasonProcessionResultFromTrack(IAnalysingResult analysingResult)
    {
        return new VehicleSeasonProcessionResult()
        {
            IsSucceed = true,
            Message = GetRandomStringStartsWith($"SeasonProcessionResult :"),
        };
    }

    public VehicleTrafficProcessionResult GenerateRandomTrafficProcessionResultFromTrack(IAnalysingResult analysingResult)
    {
        return new VehicleTrafficProcessionResult()
        {
            IsSucceed = true,
            Message = GetRandomStringStartsWith($"TrafficProcessionResult :"),
        };
    }

    public VehicleDangerProcessionResult GenerateRandomDangerProcessionResultFromTrack(IAnalysingResult analysingResult)
    {
        return new VehicleDangerProcessionResult()
        {
            IsSucceed = true,
            Message = GetRandomStringStartsWith($"DangerProcessionResult :"),
        };
    }

    private string GetRandomStringStartsWith(string str)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string randomString = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return $"{str} {randomString}";
    }
}

