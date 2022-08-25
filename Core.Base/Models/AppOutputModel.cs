namespace Core.Base.Models;

public class AppOutputModel<TModel>
{
    public string? Status { get; set; }
    public string? ErrorMessage { get; set; }
    public TModel? Model { get; set; }
}