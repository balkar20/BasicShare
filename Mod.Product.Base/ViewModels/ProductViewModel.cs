using Core.Base.Output;

namespace Mod.Product.Base.ViewModels;

public record ProductViewModel(string Id, string BusinessChannelAlias, string ProductAlias);
// {
//     public long Id { get; set; }
//     public string BusinessChannelAlias { get; set; }
//     public string? Description { get; set; }
// }