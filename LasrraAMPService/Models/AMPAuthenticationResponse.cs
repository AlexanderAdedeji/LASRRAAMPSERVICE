using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LasrraAMPService.Models
{
    public class AMPAuthenticationResponse
    {
        public string email { get; set; }
        public Dictionary<string, string> user_type { get; set; }
        public string token { get; set; }

    }

}
