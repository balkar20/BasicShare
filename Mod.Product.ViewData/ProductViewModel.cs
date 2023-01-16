using Mod.Pricing.Models;

namespace ModProduct.Models;

public record ProductViewModel(string ProductAlias, List<PricingModel> PricingList);