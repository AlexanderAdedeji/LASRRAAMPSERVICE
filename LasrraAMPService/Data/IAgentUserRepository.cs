using LasrraAMPService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LasrraAMPService.Data
{
    public interface IAgentUserRepository
    {
        Task<AMPHttpResponseModel> ActivateAgentUser(string enc);
        Task<AMPHttpResponseModel> DeActivateAgentUser(string enc);

        Task<AMPHttpResponseModel> GetAllAgentManager(string enc);

        Task<AMPHttpResponseModel> GetAllAgentSupervisor(string enc);


        Task<AMPHttpResponseModel> PostEncForCreateAgentUserRegister(string enc);



    }
}
