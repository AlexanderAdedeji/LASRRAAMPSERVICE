
using System.Collections.Generic;


namespace LasrraAMPService.Models
{
    public class AMPAgents
    {
        public string token { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public Dictionary<string, string> user_type { get; set; }
        public int created_by_id { get; set; }

    }
}

