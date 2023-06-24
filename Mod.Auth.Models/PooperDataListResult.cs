namespace Mod.Auth.Models;

public class PooperDataListResult
{
    public List<PooperModel> PooperModels { get; set; }

    public int TotalDataCount { get; set; }

    public int DataCount { get; set; }
}