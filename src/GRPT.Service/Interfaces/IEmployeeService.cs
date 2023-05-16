using GRPT.Model.Common;
using GRPT.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPT.Service.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get all employee records
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse<IEnumerable<EmployeeResponseModel>>> GetAllEmployees();

        /// <summary>
        /// Get employee record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ServiceResponse<EmployeeResponseModel>> GetEmployee(int id);

        /// <summary>
        /// Add new employee record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Task<ServiceResponse<EmployeeResponseModel>> AddEmployee(EmployeeRequestModel employee);

        /// <summary>
        /// Update employee record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Task<ServiceResponse<EmployeeResponseModel>> UpdateEmployee(EmployeeRequestModel employee);


        /// <summary>
        /// Delete employee record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ServiceResponse<bool>> DeleteEmployee(int id);
    }
}
