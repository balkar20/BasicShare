using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace IdentityProvider.Shared
{
    public class FlatFileMapping : CsvMapping<FlatFileViewModel>
    {
        public FlatFileMapping()
                : base()
        {
            MapProperty(0, x => x.BusinessChannelAlias);
            MapProperty(1, x => x.ProductAlias);
            MapProperty(2, x => x.GradeAlias);
            MapProperty(3, x => x.Rate);
            MapProperty(4, x => x.PriceByCommitment15);
            MapProperty(5, x => x.PriceByCommitment30);
            MapProperty(6, x => x.PriceByCommitment45);
            MapProperty(7, x => x.PriceByCommitment60);
        }
    }
}
