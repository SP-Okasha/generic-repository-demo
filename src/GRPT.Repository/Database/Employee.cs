using System;
using System.Collections.Generic;

namespace GRPT.Repository.Database
{
    public partial class Employee
    {
        public Employee()
        {
            InverseManager = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string EmpName { get; set; } = null!;
        public string EmpCode { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public int DeptId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Department Dept { get; set; } = null!;
        public virtual ApplicationUser IdNavigation { get; set; } = null!;
        public virtual Employee? Manager { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }
    }
}
