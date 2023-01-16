using Mod.Pricing.Models;

namespace ModProduct.Models;

public record Product(string ProductAlias, string BusinessChannelAlias, string GradeAlias, List<PricingModel> PricingList);
