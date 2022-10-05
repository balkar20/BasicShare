using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.Shared
{
    public record Product(string ProductAlias, string BusinessChannelAlias, string GradeAlias, List<Pricing> PricingList);
}
