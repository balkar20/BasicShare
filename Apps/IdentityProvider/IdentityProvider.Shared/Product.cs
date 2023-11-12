namespace IdentityProvider.Shared
{
    public record Product(string ProductAlias, string BusinessChannelAlias, string GradeAlias, List<Pricing> PricingList);
}
