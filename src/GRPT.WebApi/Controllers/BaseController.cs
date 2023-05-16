using GRPT.Model.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GRPT.WebApi.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Get the response in the consistant object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceResponse"></param>
        /// <returns></returns>
        public ApiResponseModel GetResponse<T>(ServiceResponse<T> serviceResponse)
        {
            return new ApiResponseModel(
                serviceResponse.HasValidationError ? HttpStatusCode.Conflict : serviceResponse.Exception != null ? HttpStatusCode.InternalServerError : HttpStatusCode.OK,
                serviceResponse.Message,
                serviceResponse.Data
                );
        }
    }
}
