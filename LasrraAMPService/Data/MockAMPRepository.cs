using LasrraAMPService.Models;
using LasrraAMPService.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using LasrraAMPService.Services.httpService;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;

namespace LasrraAMPService.Data
{
    public class MockAMPRepository : 
        IAuthRepository, IAgentsRepository,
        IAgentUserRepository,
        IDeviceRepository,IUserTypesRepository
    {
        // public  IConfiguration Configuration ;
        AesService _aesService = new AesService();
        IConfigurationRoot configuration;
        string Apikey;
        public  MockAMPRepository()
        {
             IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
             configuration = builder.Build();
             Apikey = configuration["Apikey"].ToString();

        }





        // All available agents methods
        public async Task<AMPHttpResponseModel> GetAllAMPSAgents(string enc)
        {            
            AMPAuthenticationRequest data = JsonConvert.DeserializeObject<AMPAuthenticationRequest>(_aesService.Decrypt(enc));
            var url = configuration["Url:Agents:GetAllAgents"].ToString();

            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;
        }

        //all avalable agent's managers
        public async Task<AMPHttpResponseModel> GetAllAgentManagers(string enc)
        {
            AMPAuthenticationRequest data = JsonConvert.DeserializeObject<AMPAuthenticationRequest>(_aesService.Decrypt(enc));
            var url = configuration["Url:AgentUsers:GetAllAgentManagers"].ToString();
            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;
        }

        public async Task<AMPHttpResponseModel> GetAllAgentSupervisors(string enc)
        {
            AMPAuthenticationRequest data = JsonConvert.DeserializeObject<AMPAuthenticationRequest>(_aesService.Decrypt(enc));
            var url = configuration["Url:AgentUsers:GetAllAgentSupervisors"].ToString();
            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;
        }





        //Alex's trial for all available devices

        public async Task<AMPHttpResponseModel> GetAllAMPSDevices(string enc)
        {
            var GetAllDevices = configuration["Url:Devices:GetAllDevices"].ToString();
            var url = GetAllDevices;
            AMPAuthenticationRequest data = JsonConvert.DeserializeObject<AMPAuthenticationRequest>(_aesService.Decrypt(enc));
            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;

        }




        //Alex's trial for get all user types
        public async Task<AMPHttpResponseModel>GetAllAMPSUserTypes(string enc)
        {
            var GetAllUserTypes = configuration["Url:UserTypes:GetAllUserTypes"].ToString();
            var url = GetAllUserTypes;
            AMPAuthenticationRequest data = JsonConvert.DeserializeObject<AMPAuthenticationRequest>(_aesService.Decrypt(enc));
            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;

        }








        //Alex's trial for creating devices

        public async Task<AMPHttpResponseModel> PostAMPSCreateDevice(string enc)
        {
            AMPCreateNewDeviceRequest data = JsonConvert.DeserializeObject<AMPCreateNewDeviceRequest>(_aesService.Decrypt(enc));
            var url = configuration["Url:Devices:CreateDevice"].ToString();

            var res = await new AMPHttp().PostRequest(data, url, data.token, Apikey);

            return res;
        }








        //Alex Trial for Assigning Device To Employees
        public async Task<AMPHttpResponseModel> PostEncForAssignDeviceToEmployee(string enc)
        {
            AMPAssignDeviceToEmployeeRequest data = JsonConvert.DeserializeObject<AMPAssignDeviceToEmployeeRequest>(_aesService.Decrypt(enc));
           var assignDevices = configuration["Url:Devices:AssignDevicetoEmployees"].ToString();
            var url = assignDevices + data.device_id +"/" + data.employee_id;
            var res = await new AMPHttp().PostRequest(data, url, data.token, Apikey);
            return res;
        }









        //Alex Trial for unAssigning Device To Employees
        public async Task<AMPHttpResponseModel> PostEncForUnAssignEmployeeFromDevice(string enc)
        {
            AMPUnAssignEmployeeFromDeviceRequest data = JsonConvert.DeserializeObject<AMPUnAssignEmployeeFromDeviceRequest>(_aesService.Decrypt(enc));
            var unAssignDevices = configuration["Url:Devices:unAssignEmployeesFromDevice"].ToString();
            var url = unAssignDevices + data.device_id +"/" +data.employee_id;

            var res = await new AMPHttp().PostRequest(data, url, data.token, Apikey);

            return res;
        }




        //Alex Trial for Activating Device
        public async Task<AMPHttpResponseModel> PostEncForAMPSActivateDevice(string enc)
        {
            AMPActivateDeviceRequest data = JsonConvert.DeserializeObject<AMPActivateDeviceRequest>(_aesService.Decrypt(enc));      
            var activateDevice= configuration["Url:Devices:ActivateDevice"].ToString();
            var url = activateDevice + data.device_id;
            var res = await new AMPHttp().PostRequest(data, url, data.token, Apikey);
            return res;
        }



           
        //Alex Trial for Activating Agent User
        public async Task<AMPHttpResponseModel> ActivateAgentUser(string enc)
        {
            AMPUserActivationRequest data = JsonConvert.DeserializeObject<AMPUserActivationRequest>(_aesService.Decrypt(enc));      
            var activateUser= configuration["Url:AgentUsers:ActivateUser"].ToString();
            var url = activateUser + data.userId;
            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;
        } 
        
        //Alex Trial for DeActivating Agent User
        public async Task<AMPHttpResponseModel> DeActivateAgentUser(string enc)
        {
            AMPUserDeActivationRequest data = JsonConvert.DeserializeObject<AMPUserDeActivationRequest>(_aesService.Decrypt(enc));      
            var DeactivateUser= configuration["Url:AgentUsers:DeActivateUser"].ToString();
            var url = DeactivateUser + data.userId;
            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;
        }







        //Alex Trial for De-Activating Device
       public async Task<AMPHttpResponseModel> PostEncForAMPSDeActivateDevice(string enc)
        {
            AMPDeActivateDeviceRequest data = JsonConvert.DeserializeObject<AMPDeActivateDeviceRequest>(_aesService.Decrypt(enc));         
            var DeactivateDevice= configuration["Url:Devices:DeActivateDevice"].ToString();
            var url = DeactivateDevice + data.device_id;
            var res = await new AMPHttp().PostRequest(data, url, data.token, Apikey);
            return res;
        }





             
        //Alex Trial for Deleting Device
       public async Task<AMPHttpResponseModel> DeleteEncForAMPSDeleteDevice(string enc)
        {
            AMPDeleteDeviceRequest data = JsonConvert.DeserializeObject<AMPDeleteDeviceRequest>(_aesService.Decrypt(enc));         
            var DeleteDevice= configuration["Url:Devices:DeleteDevice"].ToString();
            var url = DeleteDevice + data.device_id;
            var res = await new AMPHttp().DeleteRequest(data, url, data.token, Apikey);

            return res;
        }
            






        //Alex's Trial for get all agent users
        public async Task<AMPHttpResponseModel> GetAllAMPSAgentUsers(string enc)
        {
            //var userId = configuration["Url:AgentUsers:userId"].ToString();
            var GetAllAgentUsers = configuration["Url:AgentUsers:GetAllAgentOfficers"].ToString();
           // var GetAllAgentUsersCont = configuration["Url:AgentUsers:GetAllAgentUsersCont"].ToString();
            var url = GetAllAgentUsers;
            AMPAuthenticationRequest data = JsonConvert.DeserializeObject<AMPAuthenticationRequest>(_aesService.Decrypt(enc));
            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;
        }



        //Alex's Trial for get all Users
        public async Task<AMPHttpResponseModel> GetAllAMPUsers(string enc)
        {
            var GetAllUsers = configuration["Url:Users:GetAllUsers"].ToString();
            var url = GetAllUsers;
            AMPAuthenticationRequest data = JsonConvert.DeserializeObject<AMPAuthenticationRequest>(_aesService.Decrypt(enc));
            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;
        }









        //Alex's trial for single Agent
        public async Task<AMPHttpResponseModel> GetAMPSAgentFullDetails(string enc)
        {
            var getAgentFullDetails = configuration["Url:Agents:AgentFullDetails"].ToString();
            
            AMPGetAgentFullDetailsRequest data = JsonConvert.DeserializeObject<AMPGetAgentFullDetailsRequest>(_aesService.Decrypt(enc));
            var url = getAgentFullDetails + data.agent_id;
            var res = await new AMPHttp().GetRequest(url, data.token);
            return res;
        }











        //    try
        //    {
        //        var res = await new AMPHttp().GetRequest(url, data.token);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        AMPHttpResponseModel error = new AMPHttpResponseModel();
        //        error.error = ex.ToString();
        //        return error;
        //    }

        //}


        //// Single Agent Repository
        //public AMPAgents GetSingleAMPSAgents(string AgentId)
        //{
        //    var UserDetails = new AMPAgents();
        //    UserDetails.user_type.Add("name", "paint.exe");
        //    UserDetails.user_type.Add("id", "0");
        //    var User = new AMPAgents
        //    {
        //        FirstName = "tayo",
        //        LastName = "omo",
        //        Address = " 29 , immn tnii",
        //        Phone = "08099887766",
        //        Id = 1233,
        //        email = "newT@test.com",
        //        lasrra_id = "LA1234567890",
        //        is_active = true,
        //        is_superuser = false,
        //        created_by_id = 1,
        //        agent_id = 1234,
        //        user_type = UserDetails.user_type


        //    };
        //    return UserDetails;

        //}

   
        public AMPAuthenticationRequest PostAMPSUSerLogin(string Username, string Password)
        {
            var login = new AMPAuthenticationRequest()
            {
                email = Username,
                password = Password
            };
            return login;
        }

        #region user login and registration

        // login
        public async Task<AMPHttpResponseModel> PostEncForUserLogin(string enc)
        {
            AMPAuthenticationRequest data = JsonConvert.DeserializeObject<AMPAuthenticationRequest>(_aesService.Decrypt(enc));
            var url = configuration["Url:AUthentication:Login"].ToString();
           
            var res = await new AMPHttp().PostRequest(data,url,data.token, Apikey);
         
            //responses.email = res[0];
            //  var value =  AutoMapper.Mapper.Map<AMPAuthenticationResponse, object>(res);
            return res;
        }




        //agent  registration
        public async Task<AMPHttpResponseModel> PostEncForcreateAgentRegister(string enc)
        {
            AMPAgents data = JsonConvert.DeserializeObject<AMPAgents>(_aesService.Decrypt(enc));
            var url = configuration["Url:AUthentication:RegisterAgent"].ToString();
            var res = await new AMPHttp().PostRequest(data, url, data.token, Apikey);
        
            return res;
        }


        //agent employee registration
        public async Task<AMPHttpResponseModel> PostEncForCreateAgentUserRegister(string enc)
        {
            AMPNewAgentUserRegistration data = JsonConvert.DeserializeObject<AMPNewAgentUserRegistration>(_aesService.Decrypt(enc));
            var url = configuration["Url:AUthentication:RegisterAgentEmployee"].ToString();
            var res = await new AMPHttp().PostRequest(data, url, data.token, Apikey);
            bool update = await UpdateUserRole(res, Apikey, data.token);
            return res;
        }


        //agent manager registration
        public async Task<AMPHttpResponseModel> PostEncForCreateAgentManagerRegister(string enc)
        {
            AMPNewAgentUserRegistration data = JsonConvert.DeserializeObject<AMPNewAgentUserRegistration>(_aesService.Decrypt(enc));
            var url = configuration["Url:AUthentication:RegisterAgentManager"].ToString();
            var res = await new AMPHttp().PostRequest(data, url, data.token, Apikey);
            bool update = await UpdateUserRole(res, Apikey, data.token);
            return res;
        }


        //Update user role
        //agent employee registration
        public async Task<bool> UpdateUserRole(AMPHttpResponseModel response,   string Apikey, string token)
        {
            
            var url = configuration["Url:AUthentication:RegisterAgentEmployee"].ToString();
            var res = await new AMPHttp().PostRequest(response, url, Apikey, token);
            if (res.Status == System.Net.HttpStatusCode.OK) { };
            return false;
        }

        Task<AMPHttpResponseModel> IDeviceRepository.GetAllAMPSDevices(string enc)
        {
            throw new System.NotImplementedException();
        }

        Task<AMPHttpResponseModel> IDeviceRepository.PostEncForDeviceRegister(string enc)
        {
            throw new System.NotImplementedException();
        }

        Task<AMPHttpResponseModel> IAgentUserRepository.ActivateAgentUser(string enc)
        {
            throw new NotImplementedException();
        }

        Task<AMPHttpResponseModel> IAgentUserRepository.DeActivateAgentUser(string enc)
        {
            throw new NotImplementedException();
        }

        Task<AMPHttpResponseModel> IAgentUserRepository.GetAllAgentManager(string enc)
        {
            throw new NotImplementedException();
        }

        Task<AMPHttpResponseModel> IAgentUserRepository.PostEncForCreateAgentUserRegister(string enc)
        {
            throw new NotImplementedException();
        }
        Task<AMPHttpResponseModel> IAgentUserRepository.GetAllAgentSupervisor(string enc)
        {
            throw new NotImplementedException();
        }

        public Task<AMPHttpResponseModel> PostEncForCreateAgentRegister(string enc)
        {
            throw new NotImplementedException();
        }






        #endregion
    }
}
