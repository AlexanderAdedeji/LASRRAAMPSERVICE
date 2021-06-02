using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LasrraAMPService.Data;
using LasrraAMPService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LasrraAMPService.Controllers
{
    [Route("lasrraAMP/UserTypes")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        private readonly MockAMPRepository _repository = new MockAMPRepository();

        [HttpGet("getAllUserTypes")]
        public async Task<ActionResult<AMPUserTypes>> GetAllUserTypes([FromHeader] string enc)
        {
            var AllUserTypes = await _repository.GetAllAMPSUserTypes(enc);
            return Ok(AllUserTypes);
        }
    }
}
