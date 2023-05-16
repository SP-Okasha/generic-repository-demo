using GRPT.Model.Common;
using GRPT.Model.Dto;
using GRPT.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GRPT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmployees")]
        public async Task<ApiResponseModel> GetAllEmployees()
        {
            return GetResponse(await _employeeService.GetAllEmployees());
        }

        /// <summary>
        /// Get employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetEmployee")]
        public async Task<ApiResponseModel> GetEmployee(int id)
        {
            return GetResponse(await _employeeService.GetEmployee(id));
        }


        /// <summary>
        /// Add new employee record
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddEmployee")]
        public async Task<ApiResponseModel> AddEmployee([FromBody] EmployeeRequestModel request)
        {
            return GetResponse(await _employeeService.AddEmployee(request));
        }

        /// <summary>
        /// Update employee record
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateEmployee")]
        public async Task<ApiResponseModel> UpdateEmployee(EmployeeRequestModel request)
        {
            return GetResponse(await _employeeService.UpdateEmployee(request));
        }

        /// <summary>
        /// Delete employee record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteEmployee")]
        public async Task<ApiResponseModel> DeleteEmployee(int id)
        {
            return GetResponse(await _employeeService.DeleteEmployee(id));
        }

    }
}
