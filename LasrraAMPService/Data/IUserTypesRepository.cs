using LasrraAMPService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LasrraAMPService.Data
{
   public  interface IUserTypesRepository
    {
        Task<AMPHttpResponseModel> GetAllAMPSUserTypes(string enc);
    }
}
