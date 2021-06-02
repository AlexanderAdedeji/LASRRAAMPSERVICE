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
    [Route("lasrraAMP/Users")]
    [ApiController]
    public class AllAMPUsersController : ControllerBase
    {
        private readonly MockAMPRepository _repository = new MockAMPRepository();



        [HttpGet("getAllUsers")]

        public async Task<ActionResult<AMPUsers>> GetAllUsers([FromHeader] string enc)
        {
            var AllUsers = await _repository.GetAllAMPUsers(enc);
            return Ok(AllUsers);
        }

        //public async Task<ActionResult<AMPAuthenticationRequest>> GetAllAgentManager([FromHeader] string enc)
        //{
        //    var AgentManagers = await _repository.GetAllAgentManagers(enc);
        //    return Ok(AgentManagers);
        //}



        //// Get list of all Agents
        //[HttpGet("getAllAgents")]
        //public async Task<ActionResult<AMPAgents>> GetAllAgents([FromHeader] string enc)
        //{
        //    var AllAgents = await _repository.GetAllAMPSAgents(enc);
        //    return Ok(AllAgents);

        //}


    }
}
