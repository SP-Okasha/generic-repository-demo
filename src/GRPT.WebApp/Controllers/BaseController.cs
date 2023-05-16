using GRPT.Helper;
using GRPT.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using static GRPT.Helper.Utility;

namespace GRPT.WebApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly ApplicationSettingsModel _applicationSettings;
        private readonly HttpClient _client;
        public BaseController(IOptions<ApplicationSettingsModel> options)
        {
            _applicationSettings = options.Value;
            _client = new HttpClient();
        }

        protected async Task<ApiResponseModel> SendRequestAsync(string endpoint, HttpActions action = HttpActions.Get, dynamic requestBody = null)
        {
            HttpResponseMessage responseMessage = action switch
            {
                HttpActions.Get => await GetAsync(endpoint, _applicationSettings.ApiBaseUrl),
                HttpActions.Post => await PostAsync(endpoint, requestBody, _applicationSettings.ApiBaseUrl),
                HttpActions.Put => await PutAsync(endpoint, requestBody, _applicationSettings.ApiBaseUrl),
                HttpActions.Delete => await DeleteAsync(endpoint, _applicationSettings.ApiBaseUrl),
                _ => new HttpResponseMessage()
            };


            var result = await responseMessage.Content.ReadAsStringAsync();

            ApiResponseModel data = result.ToObject<ApiResponseModel>();
            if (data == null && responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                data = new ApiResponseModel(System.Net.HttpStatusCode.Unauthorized, "Session Expired!, Please login again to continue!");

            return data;
        }

        /// <summary>
        /// Get request to the API
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="apiBaseAddress"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> GetAsync(string endPoint, string apiBaseAddress)
        {
            return await _client.GetAsync(apiBaseAddress + endPoint);
        }



        /// <summary>
        /// Post request to the API
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="requestBody"></param>
        /// <param name="apiBaseAddress"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> PostAsync(string endpoint, dynamic requestBody, string apiBaseAddress)
        {
            var content = new StringContent(Utility.ToJson(requestBody), Encoding.UTF8, "application/json");
            return await _client.PostAsync(apiBaseAddress + endpoint, content);
        }



        /// <summary>
        /// Put request to the API
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="requestBody"></param>
        /// <param name="apiBaseAddress"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> PutAsync(string endpoint, dynamic requestBody, string apiBaseAddress)
        {
            var content = new StringContent(Utility.ToJson(requestBody), Encoding.UTF8, "application/json");
            return await _client.PutAsync(apiBaseAddress + endpoint, content);
        }


        /// <summary>
        /// Delete request to the API
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="apiBaseAddress"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> DeleteAsync(string endpoint, string apiBaseAddress)
        {
            return await _client.DeleteAsync(apiBaseAddress + endpoint);
        }

        /// <summary>
        /// Convert API JSON data to readable model class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        protected JsonResult GetResult<T>(ApiResponseModel response)
        {
            dynamic data = null;
            if (response.Data != null)
                if (response.Data is bool)
                    data = (bool)response.Data;
                else
                    data = JsonConvert.DeserializeObject<T>(response.Data.ToString());

            return Json(new
            {
                response.StatusCode,
                response.Message,
                Data = data
            });
        }
    }
}
