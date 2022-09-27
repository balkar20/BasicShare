using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Auth.Models
{
    public class RegisterResponseModel
    {
        public IList<string> Errors { get; set; }

        public bool IsSuccess { get; set; }

        public string Token { get; set; }
    }
}
