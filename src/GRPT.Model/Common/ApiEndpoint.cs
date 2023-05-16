using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPT.Model.Common
{
    public static class ApiEndpoint
    {
        private const string _prefix = "/api";
        public static class EmployeeApiEndPoints
        {
            private const string Controller = "Employee";
            public const string GetAllEmployees = $"{_prefix}/{Controller}/GetEmployees";
            public const string GetEmployeeById = $"{_prefix}/{Controller}/GetEmployee";
            public const string AddEmployee = $"{_prefix}/{Controller}/AddEmployee";
            public const string UpdateEmployee = $"{_prefix}/{Controller}/UpdateEmployee";
            public const string DeleteEmployee = $"{_prefix}/{Controller}/DeleteEmployee";
        }

        public static class DataList
        {
            private const string Controller = "Common";
            public const string Employees = $"{_prefix}/{Controller}/GetEmployeeDataList";
            public const string Departments = $"{_prefix}/{Controller}/GetDepartmentDataList";

        }

    }
}
