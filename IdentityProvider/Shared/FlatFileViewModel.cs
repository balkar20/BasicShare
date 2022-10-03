﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.Shared
{
    public class FlatFileViewModel
    {
        public string? BusinessChannelAlias { get; set; }
        public string? ProductAlias { get; set; }
        public char? GradeAlias { get; set; }
        public decimal? Rate { get; set; }
        public decimal? PriceByCommitment15 { get; set; }
        public decimal? PriceByCommitment30 { get; set; }
        public decimal? PriceByCommitment45 { get; set; }
        public decimal? PriceByCommitment60 { get; set; }
    }
}
