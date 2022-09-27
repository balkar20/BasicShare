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
using IdentityProvider.Shared;
using static System.Net.WebRequestMethods;
using Mod.Auth.Models;

//namespace IdentityProvider.Client.Pages
//{
//    public partial class Login
//    {
//        private HttpClient Http;

//        public Login(HttpClient http)
//        {
//            Http = http;
//        }

//        private int currentCount = 0;
//        private async Task<LoginModel> LogIn()
//        {
//            return await Http.GetFromJsonAsync<LoginModel>("WeatherForecast");
//        }
//    }
//}