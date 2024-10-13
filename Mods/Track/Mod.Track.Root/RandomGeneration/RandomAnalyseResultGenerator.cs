using ParallelProcessing.Models;
using ParallelProcessing.Models.Results.Analyse;

namespace ParallelProcessing.RandomGeneration;

public class RandomAnalyseResultGenerator
{
        
    public TypeAnalyseResult GenerateRandomTypeAnalysingResultFromTrack(Track track)
    {
        return new TypeAnalyseResult()
        {
            Message = GetRandomStringStartsWith($"Type result Number:")
        };
    }
    
    public ColorAnalyseResult GenerateRandomColorAnalysingResultFromTrack(Track track)
    {
        return new ColorAnalyseResult()
        {
            Message = GetRandomStringStartsWith($"Color result Number:")
        };
    }

    public MarkAnalyseResult GenerateRandomMarkAnalysingResultFromTrack(Track track)
    {
        return new MarkAnalyseResult()
        {
            Message = GetRandomStringStartsWith($"Mark result Number:")
        };
    }

    public SeasonAnalyseResult GenerateRandomSeasonAnalysingResultFromTrack(Track track)
    {
        return new SeasonAnalyseResult()
        {
            Message = GetRandomStringStartsWith($"Season result Number:")
        };
    }

    public TrafficAnalyseResult GenerateRandomTrafficAnalysingResultFromTrack(Track track)
    {
        return new TrafficAnalyseResult()
        {
            Message = GetRandomStringStartsWith($"Traffic result Number:")
        };
    }

    public DangerAnalyseResult GenerateRandomDangerAnalysingResultFromTrack(Track track)
    {
        return new DangerAnalyseResult()
        {
            Message = GetRandomStringStartsWith($"Danger result Number:")
        };
    }

    public string GetRandomStringStartsWith(string str)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string randomString = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return $"{str} {randomString}";
    }
}

