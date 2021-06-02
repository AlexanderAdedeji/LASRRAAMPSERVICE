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
    [Route("lasrraAMP/Devices")]
    [ApiController]
    public class AMPDevicesController : ControllerBase
    {
        private readonly MockAMPRepository _repository = new MockAMPRepository();

        // Get list of all Devices

        [HttpGet("getAllDevices")]
        public async Task<ActionResult<AMPDevices>> GetAllDevices([FromHeader] string enc)
        {
            var AllDevices = await _repository.GetAllAMPSDevices(enc);
            return Ok(AllDevices);
        }

        //Create Device
        [HttpPost("createDevices")]
        public async Task<ActionResult<AMPDevices>>CreateAllDevices([FromHeader] string enc)
        {
            var AllDevices = await _repository.PostAMPSCreateDevice(enc);
            //var Devices = "ALL DEVICES SHOULD WORK";
            return Ok(AllDevices);
        }



        //Assign Device to employee

        [HttpPost("assignDevice")]
        public async Task<ActionResult<AMPAssignDeviceToEmployeeRequest>>AssignDevices([FromHeader] string enc)
        {
            var AssignDevice = await _repository.PostEncForAssignDeviceToEmployee(enc);

            return Ok(AssignDevice);
        }   





        //UnAssign EMployee from Device
        
        [HttpPost("unAssignEmployeeFromDevice")]
        public async Task<ActionResult<AMPUnAssignEmployeeFromDeviceRequest>>unAssignDevices([FromHeader] string enc)
        {
            var unAssignDevice = await _repository.PostEncForUnAssignEmployeeFromDevice(enc);

            return Ok(unAssignDevice);
        }











        //Activate Device
        [HttpPost("activateDevice")]
        public async Task<ActionResult<AMPActivateDeviceRequest>>ActivateDevices([FromHeader] string enc)
        {
            var ActivatedDevice = await _repository.PostEncForAMPSActivateDevice(enc);
     
            return Ok(ActivatedDevice);
        } 
           
        //DeActivate Device
        [HttpPost("DeactivateDevice")]
        public async Task<ActionResult<AMPDeActivateDeviceRequest>>DeActivateDevices([FromHeader] string enc)
        {
            var DeActivatedDevice = await _repository.PostEncForAMPSDeActivateDevice(enc);
     
            return Ok(DeActivatedDevice);
        } 


        [HttpDelete("DeleteDevice")]
        public async Task<ActionResult<AMPDeleteDeviceRequest>>DeleteDevice([FromHeader] string enc)
        {
            var DeleteDevice = await _repository.DeleteEncForAMPSDeleteDevice(enc);
     
            return Ok(DeleteDevice);
        } 
        
        






    }
}





































//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using LasrraAMPService.Data;
//using LasrraAMPService.Models;
//namespace LasrraAMPService.Controllers
//{
//    [Route("lasrraAMP/Devices")]
//    [ApiController]
//    public class AMPDevicesController : ControllerBase
//    {
//        private readonly IDeviceRepository _repository;
//        public AMPDevicesController(IDeviceRepository repository)
//        {
//            _repository = repository;
//        }
//        //public void test()
//        //{
//       //     _repository.GetAllAMPSDevices;
//        //}


//        [HttpPost("devices")]
//        public async Task<ActionResult<AMPAuthenticationRequest>> PostRegisterNewAgentUserWithEncryption([FromHeader] string enc)
//        {
//            var devices = await _repository.GetAllAMPSDevices(enc);
//            return Ok(devices);
//        }


//        [HttpGet("getAllDevices")]
//        public async Task<ActionResult<AMPDevices>> GetAllDevices([FromHeader] string enc)
//        {
//            var AllDevices = await _repository.GetAllAMPSDevices(enc);
//            return Ok(AllDevices);
//        }




//        [HttpPost("register")]
//        public async Task<ActionResult<AMPAuthenticationRequest>> PostRegisterNewDeviceWithEncryption([FromHeader] string enc)
//        {
//            var Auth = await _repository.PostEncForDeviceRegister(enc);
//            return Ok(Auth);
//        }
//    }
//}
