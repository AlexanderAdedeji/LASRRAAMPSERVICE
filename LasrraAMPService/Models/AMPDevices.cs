
using System.Collections.Generic;


namespace LasrraAMPService.Models
{



    public class AMPDevices
    {
        public string mac_id { get; set; }
        public int creator_id { get; set; }
        public int id { get; set; }
        public bool is_active { get; set; }
        public int agent_id { get; set; }
        public object[] assigned_users { get; set; }
    }


}

