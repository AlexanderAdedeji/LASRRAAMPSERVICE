using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LasrraAMPService.Data;
using LasrraAMPService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LasrraAMPService.Controllers
{
    [Route("lasrraAMP/AgentUser")]
    [ApiController]
    public class AgentUsersController : ControllerBase
    {
        private readonly MockAMPRepository _repository = new MockAMPRepository();



        // registering a new Agent User
        [HttpPost("registerNewAgentUser")]
        public async Task<ActionResult<AMPAuthenticationRequest>> PostRegisterNewAgentUserWithEncryption([FromHeader] string enc)
        {
            var NewAgentUser = await _repository.PostEncForCreateAgentUserRegister(enc);
            return Ok(NewAgentUser);
        }


        [HttpPost("registerNewAgentManager")]
        public async Task<ActionResult<AMPAuthenticationRequest>> PostRegistrationNewAgentUserWithEncryption([FromHeader] string enc)
        {
            var NewAgentManager = await _repository.PostEncForCreateAgentManagerRegister(enc);
            return Ok(NewAgentManager);
        }

        [HttpGet("registerNewAgentManager")]
        public async Task<ActionResult<AMPAuthenticationRequest>> GetAllAMPUsers([FromHeader] string enc)
        {
            var NewAgentManager = await _repository.GetAllAMPUsers(enc);
            return Ok(NewAgentManager);
        }




        //get all agent's managers
        [HttpGet("getAllAgentManagers")]

        public async Task<ActionResult<AMPAuthenticationRequest>> GetAllAgentManager([FromHeader] string enc)
        {
            var AgentManagers = await _repository.GetAllAgentManagers(enc);
            return Ok(AgentManagers);
        }


        //get all agent's managers
        [HttpGet("getAllAgentSupervisors")]

        public async Task<ActionResult<AMPAuthenticationRequest>> GetAllAgentSupervisor([FromHeader] string enc)
        {
            var AgentSupervisors = await _repository.GetAllAgentSupervisors(enc);
            return Ok(AgentSupervisors);
        }











        //Activate AgentUser
        [HttpGet("activateAgentUser")]
        public async Task<ActionResult<AMPUserActivationRequest>> ActivateUser([FromHeader] string enc)
        {
            var ActivatedUser = await _repository. ActivateAgentUser(enc);

            return Ok(ActivatedUser);
        } 





        //DeActivate AgentUser
        [HttpGet("DeactivateAgentUser")]
        public async Task<ActionResult<AMPUserDeActivationRequest>> DeActivateUser([FromHeader] string enc)
        {
            var DeActivatedUser = await _repository. DeActivateAgentUser(enc);

            return Ok(DeActivatedUser);
        }

    }
}
