using MudBlazor;

namespace ClientBase;

public class ViewContext
{
    public IClientViewDataService ClientViewDataService { get; set; }
}

public interface IClientViewDataService
{
    public MudForm BaseMudForm { get; set; }
}

public class ClientViewDataService : IClientViewDataService
{
    public MudForm BaseMudForm { get; set; }
}