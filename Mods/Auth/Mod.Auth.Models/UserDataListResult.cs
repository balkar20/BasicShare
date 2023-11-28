namespace Mod.Auth.Models;

public class UserDataListResult
{
    public List<UserModel> UserModels { get; set; }
    
    public List<string?> Claims { get; set; }

    public int TotalDataCount { get; set; }

    public int DataCount { get; set; }
}