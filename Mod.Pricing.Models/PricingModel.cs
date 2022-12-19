using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Pricing.Models; 
public record PricingModel(string? Rate, string? PriceByCommitment15, string? PriceByCommitment30, string? PriceByCommitment45, string? PriceByCommitment60);
    //{
    //    public string? GradeAlias { get; set; }
    //    public string? Rate { get; set; }
    //    public string? PriceByCommitment15 { get; set; }
    //    public string? PriceByCommitment30 { get; set; }
    //    public string? PriceByCommitment45 { get; set; }
    //    public string? PriceByCommitment60 { get; set; }
    //}

