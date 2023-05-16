using System;
using System.Collections.Generic;

namespace GRPT.Repository.Database
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DeptName { get; set; } = null!;
        public string DeptCode { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
