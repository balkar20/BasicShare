using IdentityProvider.Shared.Interfaces;

namespace IdentityProvider.Shared;

public class PooperViewModel: IViewModel
{
public string Id { get; set; }

public string PooperAlias { get; set; }

public string? Description { get; set; }
         
public int AmountOfPoops { get; set; }

public string? Image { get; set; }

public List<string>? Claims { get; set; }
}
