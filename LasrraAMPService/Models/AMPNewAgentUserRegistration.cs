using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LasrraAMPService.Models
{
    public class AMPNewAgentUserRegistration
    {
        public string token { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string lasrra_id { get; set; }
        public string user_type_id { get; set; }
        public string agent_id { get; set; }
    }
}
