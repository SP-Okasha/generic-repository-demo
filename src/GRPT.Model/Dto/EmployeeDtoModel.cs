using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPT.Model.Dto
{

    public class EmployeeDtoModel
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public int DeptId { get; set; }
        public bool IsActive { get; set; }
    }


    public class EmployeeResponseModel : EmployeeDtoModel
    {
        public string ManagerName { get; set; }
        public string DeptName { get; set; }
    }


    public class EmployeeRequestModel :EmployeeDtoModel
    {
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
