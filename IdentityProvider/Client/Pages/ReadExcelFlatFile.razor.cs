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

namespace IdentityProvider.Client.Pages
{
    public partial class ReadExcelFlatFile
    {
        DataTable dt = new DataTable();

        List<FlatFileViewModel> flatFileViewModels = new List<FlatFileViewModel>();
        private async void LoadFiles(InputFileChangeEventArgs e)
        {
            
            
            using (var stream = e.File.OpenReadStream())
            {
                byte[] buffer = new byte[64 * 1024]; // 32K buffer for example
                int bytesRead;
                //await stream.ReadAsync(buffer);
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

                flatFileViewModels = result.Select(x => new FlatFileViewModel() {
                    BusinessChannelAlias = x.Result.BusinessChannelAlias,
                    ProductAlias = x.Result.ProductAlias, 
                    GradeAlias = x.Result.GradeAlias,
                    Rate = x.Result.Rate,
                    PriceByCommitment15 = x.Result.PriceByCommitment15,
                    PriceByCommitment30 = x.Result.PriceByCommitment30,
                    PriceByCommitment45 = x.Result.PriceByCommitment45, 
                    PriceByCommitment60 = x.Result.PriceByCommitment60
                }).Take(30).ToList();    
            }

            //Console.WriteLine("Name " + "ID   " + "City  " + "Country");
            //foreach (var details in result)
            //{
            //    //Console.WriteLine(details.Result.BusinessChannelAlias + " " + details.Result.ProductAlias + " " + details.Result.GradeAlias + " " + details.Result.Rate + " " + details.Result.PriceByCommitment15 + " " + details.Result.PriceByCommitment30 + " " + details.Result.PriceByCommitment + " " + details.Result.PriceByCommitment4);
            //}
        }
    }
}