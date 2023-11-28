using IdentityProvider.Shared.Interfaces;

namespace IdentityProvider.Shared;

public class  UserViewModel: IViewModel
{
public string Id { get; set; }

public string UserName { get; set; }

public string? Description { get; set; }
         
public int AmountOfPoints { get; set; }

public string? Image { get; set; }

public List<string>? Claims { get; set; }
}
