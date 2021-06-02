using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LasrraAMPService.Models
{
    public class AMPHttpResponseModel
    {
        public System.Net.HttpStatusCode Status { get; set; }
        public string Response { get; set; }
        public string error { get; set; }
    }
}
