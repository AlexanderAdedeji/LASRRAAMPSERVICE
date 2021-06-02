using LasrraAMPService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LasrraAMPService.Data
{
    public interface IAgentsRepository
    {
        Task<AMPHttpResponseModel> GetAllAMPSAgents(string enc);
        Task<AMPHttpResponseModel> PostEncForCreateAgentRegister(string enc);
        Task<AMPHttpResponseModel> GetAMPSAgentFullDetails(string enc);
        //AMPAgents GetSingleAMPSAgents(string AgentId);


    }
}
