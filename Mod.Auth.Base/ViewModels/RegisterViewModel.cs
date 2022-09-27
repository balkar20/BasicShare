using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Auth.Models
{
    public record RegisterViewModel(string Email, string UserName, string Password, string? PhoneNumber, string? Male, int? Year)
    {
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string? PhoneNumber { get; set; }
        //public string? Male { get; set; }
        //public int? Year { get; set; }
    }
}
