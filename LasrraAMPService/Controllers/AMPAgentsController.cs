using LasrraAMPService.Data;
using LasrraAMPService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LasrraAMPService.Controllers
{
    [Route("lasrraAMP/Agents")]
    [ApiController]
    public class AMPAgentsController : ControllerBase
    {
        private readonly MockAMPRepository _repository = new MockAMPRepository();

        // Get list of all Agents
        [HttpGet("getAllAgents")]
        public async Task<ActionResult<AMPAgents>> GetAllAgents([FromHeader] string enc)
        {
            var AllAgents = await _repository.GetAllAMPSAgents(enc);
            return Ok(AllAgents);
        }


        [HttpGet("getAllAgentUsers")]
        public async Task<ActionResult<AMPAgents>> GetAllAgentUsers([FromHeader] string enc)
        {
            var AllAgentUsers = await _repository.GetAllAMPSAgentUsers(enc);
            return Ok(AllAgentUsers);
        }




        ////Get Agent's Full Details
        [HttpGet("getAgentFullDetails")]
        public async Task<ActionResult<AMPAgents>> GetAgentFullDetails([FromHeader] string enc)
        {
            var AgentFullDetail = await _repository.GetAMPSAgentFullDetails(enc);
            return Ok(AgentFullDetail);
        }







        //// Get A single Agents
        //[HttpGet("getAsSingleAgents")]
        //public ActionResult<AMPAgents> GetSingleAgent(string AgentId)
        //{
        //    var SingleAgents = _repository.GetSingleAMPSAgents(AgentId);
        //    return Ok(SingleAgents);
        //}













        // Registering a new Agent
        [HttpPost("registerNewAgent")]
        public async Task<ActionResult<AMPAuthenticationRequest>> PostRegisterNewAgentWithEncryption([FromHeader] string enc)
        {
            var Agent = await _repository.PostEncForcreateAgentRegister(enc);
            return Ok(Agent);
        }




    }
}
