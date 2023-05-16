using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPT.Model.Common
{
    /// <summary>
    /// Generic response to return the consistant object from service to controller
    /// </summary>
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public Exception? Exception { get; set; }
        public string Message { get; set; }
        public bool IsSuccess => !HasValidationError && Exception == null;
        public bool HasValidationError { get; set; }


        /// <summary>
        /// Contrcutor to pass the data and appropriate message
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="hasValidationError"></param>
        public ServiceResponse(T data, string message)
        {
            Data = data;
            Message = message;
            HasValidationError = false;
            Exception = null;
        }


        /// <summary>
        /// Contructor to pass the exception and message
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>

        public ServiceResponse(Exception exception, string message)
        {
            Data = default;
            Exception = exception;
            Message = message;
        }

        /// <summary>
        /// Return the validation error/success message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="hasValidationError"></param>
        public ServiceResponse(string message, bool hasValidationError=true)
        {
            Data = default;
            Exception = null;
            Message = message;
            HasValidationError = hasValidationError;
        }
    }
}
