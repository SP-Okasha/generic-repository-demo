using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GRPT.Model.Common
{
    public class ApiResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public ApiResponseModel(HttpStatusCode code, string message, dynamic data = null)
        {
            StatusCode = code;
            Message = message;
            Data = data;
        }
    }
}
