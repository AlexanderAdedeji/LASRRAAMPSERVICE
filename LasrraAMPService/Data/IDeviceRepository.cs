using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LasrraAMPService.Models;

namespace LasrraAMPService.Data
{
    public interface IDeviceRepository
    {
        Task<AMPHttpResponseModel> GetAllAMPSDevices(string enc);
        Task<AMPHttpResponseModel> PostEncForDeviceRegister(string enc);
        Task<AMPHttpResponseModel> PostEncForAssignDeviceToEmployee(string enc);
        Task<AMPHttpResponseModel> PostEncForUnAssignEmployeeFromDevice(string enc);
        Task<AMPHttpResponseModel> PostEncForAMPSActivateDevice(string enc);
        Task<AMPHttpResponseModel> PostEncForAMPSDeActivateDevice(string enc);
        Task<AMPHttpResponseModel> DeleteEncForAMPSDeleteDevice(string enc);


    }
}
