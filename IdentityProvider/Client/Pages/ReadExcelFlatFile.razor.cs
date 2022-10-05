using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using IdentityProvider.Client;
using IdentityProvider.Client.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Data;
using IdentityProvider.Shared;
using TinyCsvParser;
using System.Text;
using System.IO;
using static MudBlazor.CategoryTypes;

namespace IdentityProvider.Client.Pages
{
    public partial class ReadExcelFlatFile
    {
        private List<DropDownModel<BusinessChannelViewModel>> DdBusnessChannelList = new();
        Dictionary<string, BusinessChannelViewModel> buisnessChannelDictionary = new();
        Stack<BusinessChannelViewModel> BuisnessChannelViewModelStack = new();
        //DataTable dt = new DataTable();

        List<ProductPricingViewModel> productPricingViewModelList = new();
        private DropDownModel<BusinessChannelViewModel> SelectedModel;
        
        private async Task BusinessChannelOptionChanged(DropDownModel<BusinessChannelViewModel> arg)
        {
            SelectedModel = arg;
            productPricingViewModelList = SelectedModel.Data.ProductStack.SelectMany(u => u.PricingList,
                (product, pricing) =>
                    new ProductPricingViewModel(
                        product.ProductAlias,
                        product.GradeAlias,
                        pricing.Rate, pricing.PriceByCommitment15,
                        pricing.PriceByCommitment30,
                        pricing.PriceByCommitment45,
                        pricing.PriceByCommitment60
                    )).ToList();    
        }

        private async void LoadFiles(InputFileChangeEventArgs e)
        { 
            using (var stream = e.File.OpenReadStream(540000))
            {
                byte[] buffer = new byte[64 * 1024];
                int bytesRead;
                
                using var ms = new MemoryStream(540000);
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytesRead);
                }
                ms.Position = 0;
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
                FlatFileMapping csvMapper = new FlatFileMapping();
                CsvParser<FlatFileViewModel> csvParser = new CsvParser<FlatFileViewModel>(csvParserOptions, csvMapper);
                var result = csvParser.ReadFromStream(ms, Encoding.ASCII).ToList();

                foreach (var item in result)
                {
                    if (item.Result is null)
                        throw new NullReferenceException(nameof(item.Result));

                    if (string.Equals(item.Result.BpRd, "BP"))
                    {
                        var product = new Product(item.Result.ProductAlias, item.Result.BusinessChannelAlias, item.Result.GradeAlias, new List<Pricing>());
                        if (buisnessChannelDictionary.ContainsKey(item.Result.BusinessChannelAlias))
                        {
                            buisnessChannelDictionary[item.Result.BusinessChannelAlias].ProductStack.Push(product);
                            continue;
                        }

                        var productStack = new Stack<Product>();
                        productStack.Push(product);
                        var businessChannel = new BusinessChannelViewModel(item.Result.BusinessChannelAlias, productStack);
                        BuisnessChannelViewModelStack.Push(businessChannel);
                        buisnessChannelDictionary.Add(item.Result.BusinessChannelAlias, businessChannel);
                    }

                    if (string.Equals(item.Result.BpRd, "RD"))
                    {
                        if (BuisnessChannelViewModelStack.TryPeek(out BusinessChannelViewModel buisnessChannelViewModel))
                        {
                            buisnessChannelViewModel.ProductStack.TryPeek(out Product product);
                            product?.PricingList.Add(new Pricing(
                                item.Result.Rate, 
                                item.Result.PriceByCommitment15,
                                item.Result.PriceByCommitment30,
                                item.Result.PriceByCommitment45,
                                item.Result.PriceByCommitment60
                            ));
                        }
                    }
                }
                
                DdBusnessChannelList = buisnessChannelDictionary.Select(d =>
                    new DropDownModel<BusinessChannelViewModel>()
                    {
                        Data = d.Value,
                        DropDownValue = d.Key
                    }).ToList();
            }
        }
    }

}