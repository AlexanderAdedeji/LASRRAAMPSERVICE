
using System.Collections.Generic;


namespace LasrraAMPService.Models
{
    public class AMPUsers
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string lasrra_id { get; set; }
        public bool is_active { get; set; }
        public bool is_superuser { get; set; }
        public User_Type user_type { get; set; }
        public object created_by_id { get; set; }
        public object agent_id { get; set; }
    }
}


