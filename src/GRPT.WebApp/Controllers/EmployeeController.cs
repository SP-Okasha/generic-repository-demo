using GRPT.Model.Common;
using GRPT.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GRPT.WebApp.Controllers
{
    public class EmployeeController : BaseController
    {

        public EmployeeController(IOptions<ApplicationSettingsModel> options) : base(options) { }


        public IActionResult Index()
        {
            return View();
        }

        #region Employee CRUD
        /// <summary>
        /// Get all employees records
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetEmployees()
        {
            return GetResult<IEnumerable<EmployeeResponseModel>>(await SendRequestAsync(ApiEndpoint.EmployeeApiEndPoints.GetAllEmployees));
        }

        public async Task<JsonResult> GetEmployeeById(int id)
        {
            return GetResult<EmployeeResponseModel>(await SendRequestAsync($"{ApiEndpoint.EmployeeApiEndPoints.GetEmployeeById}?id={id}"));
        }

        public async Task<JsonResult> AddEmployee(EmployeeRequestModel request)
        {
            return GetResult<EmployeeResponseModel>(await SendRequestAsync(ApiEndpoint.EmployeeApiEndPoints.AddEmployee, Helper.Utility.HttpActions.Post, request));
        }


        public async Task<JsonResult> UpdateEmployee(EmployeeRequestModel request)
        {
            return GetResult<EmployeeResponseModel>(await SendRequestAsync(ApiEndpoint.EmployeeApiEndPoints.UpdateEmployee, Helper.Utility.HttpActions.Put, request));
        }


        public async Task<JsonResult> DeleteEmployee(int id)
        {
            return GetResult<EmployeeResponseModel>(await SendRequestAsync($"{ApiEndpoint.EmployeeApiEndPoints.DeleteEmployee}?id={id}", Helper.Utility.HttpActions.Delete));
        }

        #endregion

    }
}
