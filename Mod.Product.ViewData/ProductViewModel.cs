using Mod.Pricing.Models;

namespace Mod.Product.Models;

public record ProductViewModel(string ProductAlias, List<PricingModel> PricingList);