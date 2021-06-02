using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using LasrraAMPService.Models;

namespace LasrraAMPService.Services.httpService
{
    public class AMPHttp
    {
        private static readonly HttpClient client = new HttpClient();
        private  AMPHttpResponseModel _AMPHttpResponseModel = new AMPHttpResponseModel();
    
         string httpResponse;
        string BaseUrl;
        IConfigurationRoot configuration;
        public AMPHttp()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            configuration = builder.Build();
            BaseUrl = configuration["Url:BaseUrl"].ToString();
        }

        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };


        public async Task<AMPHttpResponseModel> GetRequest(string url, string token)
        {

            client.DefaultRequestHeaders.Clear();
           if (token != null) client.DefaultRequestHeaders.Add("Authorization", token);
            // client.DefaultRequestHeaders.Add("X-API-Key", Apikey);
            var Fullurl = BaseUrl + url;
            try {
                using (var response = await client.GetAsync(Fullurl))
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    _AMPHttpResponseModel.Response = res.ToString();
                    _AMPHttpResponseModel.Status = response.StatusCode;

                    return _AMPHttpResponseModel;
                    
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                _AMPHttpResponseModel.error = ex.ToString();
                return _AMPHttpResponseModel;
            }
        }

        public async Task<AMPHttpResponseModel> PostRequest(object data, string url, string token,string Apikey)
        {
            var serializedRequest = JsonConvert.SerializeObject(data);
            client.DefaultRequestHeaders.Clear();


            var requestBody = new StringContent(serializedRequest);
            requestBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");
           
            client.DefaultRequestHeaders.Add("X-API-Key", Apikey);
           // if (token != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
           if (token != null) client.DefaultRequestHeaders.Add("Authorization", token);

            var Fullurl = BaseUrl + url;
            try
            {
                using (var response = await client.PostAsync(Fullurl, requestBody))
                {
                    var res = response.Content.ReadFromJsonAsync<object>().Result;
                    httpResponse = res.ToString();
                    //httpResponse = JsonConvert.DeserializeObject(t);
                    _AMPHttpResponseModel.Response = httpResponse;
                    //return response;
               
                    _AMPHttpResponseModel.Status = response.StatusCode;
                    return _AMPHttpResponseModel;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                _AMPHttpResponseModel.error = ex.ToString();
                return _AMPHttpResponseModel;

            }
          
        }   
        public async Task<AMPHttpResponseModel> DeleteRequest(object data, string url, string token,string Apikey)
        {
            var serializedRequest = JsonConvert.SerializeObject(data);
            client.DefaultRequestHeaders.Clear();


            var requestBody = new StringContent(serializedRequest);
            requestBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");
           
            client.DefaultRequestHeaders.Add("X-API-Key", Apikey);
           // if (token != null) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
           if (token != null) client.DefaultRequestHeaders.Add("Authorization", token);

            var Fullurl = BaseUrl + url;
            try
            {
                using (var response = await client.DeleteAsync(Fullurl))
                {
                    var res = response.Content.ReadFromJsonAsync<object>().Result;
                    httpResponse = res.ToString();
                    //httpResponse = JsonConvert.DeserializeObject(t);
                    _AMPHttpResponseModel.Response = httpResponse;
                    //return response;
               
                    _AMPHttpResponseModel.Status = response.StatusCode;
                    return _AMPHttpResponseModel;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                _AMPHttpResponseModel.error = ex.ToString();
                return _AMPHttpResponseModel;

            }
          
        }
    }
}
