using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Pricing.Models;

namespace ModProduct.Models;

public record Product(string ProductAlias, string BusinessChannelAlias, string GradeAlias, List<PricingModel> PricingList);
