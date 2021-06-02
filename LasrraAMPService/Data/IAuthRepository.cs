using LasrraAMPService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LasrraAMPService.Data
{
   public  interface IAuthRepository
    {
        AMPAuthenticationRequest PostAMPSUSerLogin(string email, string password);
        Task<AMPHttpResponseModel> PostEncForUserLogin(string enc);
        Task<AMPHttpResponseModel> PostEncForCreateAgentUserRegister(string enc);
        Task<bool> UpdateUserRole(AMPHttpResponseModel response, string Apikey, string token);
    }
}
