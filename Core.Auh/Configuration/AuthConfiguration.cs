using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Auh.Configuration
{
    public class AuthConfiguration
    {
        public const string HostConfiguration = "AuthConfiguration";

        public int ExpiryInMinutes { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string SecurityKey { get; set; }
    }
}
