using TinyCsvParser.Mapping;

namespace IdentityProvider.Shared
{
    public class FlatFileMapping : CsvMapping<FlatFileViewModel>
    {
        public FlatFileMapping()
                : base()
        {
            //MapProperty(0, x =>  x == null ? "" : x.BusinessChannelAlias);
            //MapProperty(1, x => x == null ? "" : x.ProductAlias);
            //MapProperty(2, x => x == null ? "" : x.GradeAlias);
            //MapProperty(3, x => x == null ? 0 : x.Rate);
            //MapProperty(4, x => x == null ? 0 : x.PriceByCommitment15);
            //MapProperty(5, x => x == null ? 0 : x.PriceByCommitment30);
            //MapProperty(6, x => x == null ? 0 : x.PriceByCommitment45);
            //MapProperty(7, x => x == null ? 0 : x.PriceByCommitment60);
            MapProperty(0, x => x.BpRd);
            MapProperty(1, x => x.BusinessChannelAlias);
            MapProperty(2, x => x.ProductAlias);
            MapProperty(3, x => x.GradeAlias);
            MapProperty(4, x => x.Rate);
            MapProperty(5, x => x.PriceByCommitment15);
            MapProperty(6, x => x.PriceByCommitment30);
            MapProperty(7, x => x.PriceByCommitment45);
            MapProperty(8, x => x.PriceByCommitment60);
        }
    }
}
