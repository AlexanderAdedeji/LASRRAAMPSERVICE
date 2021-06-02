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
  //  [Route("api/[controller]")]
    [Route("lasrraAMP/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly AMPAuthenticationRequest _user;

        public AuthenticationController(IAuthRepository repository,
                                       AMPAuthenticationRequest User)// dependency injection
        {
            _repository = repository;
            _user = User;
        }

       
        // Get lassraAMP/Authentication
        [HttpPost]
        public async Task<ActionResult<AMPAuthenticationRequest>> PostUserLoginWithEncryption([FromHeader]  string enc)
        {
            var Auth = await _repository.PostEncForUserLogin(enc);
            return Ok(Auth);
        }

        //[HttpPost("register")]
        //public async Task<ActionResult<AMPAuthenticationRequest>> PostRegisterNewAgentUserWithEncryption([FromHeader] string enc)
        //{
        //    var Auth = await _repository.PostEncForCreateAgentUserRegister(enc);
        //    return Ok(Auth);
        //}


    }
}
