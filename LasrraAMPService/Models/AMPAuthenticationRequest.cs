using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LasrraAMPService.Models
{
    public class AMPAuthenticationRequest
    {
        public string email { get; set; }
        public string password { get; set; }
        public string token { get; set; }

    } 
    public class AMPUserActivationRequest
    {

        public string token { get; set; }
        public string userId { get; set; }

    } 
    public class AMPUserDeActivationRequest
    {

        public string token { get; set; }
        public string userId { get; set; }

    } 


    public class AMPGetAgentFullDetailsRequest
    {

        public string token { get; set; }
        public string agent_id { get; set; }

    }  
    public class AMPCreateNewDeviceRequest
    {

        public string token { get; set; }
        public string mac_id { get; set; }
        public string agent_id { get; set; }

    }  
    public class AMPActivateDeviceRequest
    {

        public string token { get; set; }
        public string device_id { get; set; }
       

    }  
    public class AMPDeleteDeviceRequest
    {

        public string token { get; set; }
        public string device_id { get; set; }
       

    } 
    
    public class AMPDeActivateDeviceRequest
    {

        public string token { get; set; }
        public string device_id { get; set; }
    } 


    public class AMPAssignDeviceToEmployeeRequest
    {
        public string token { get; set; }
        public string employee_id { get; set; }
        public string device_id { get; set; }
       
    }  


    public class AMPUnAssignEmployeeFromDeviceRequest
    {

        public string token { get; set; }
        public string employee_id { get; set; }
        public string device_id { get; set; }
       

    }








}
