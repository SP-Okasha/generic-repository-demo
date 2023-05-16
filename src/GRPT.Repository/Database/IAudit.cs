using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPT.Repository.Database
{
    public interface IAudit
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public partial class ApplicationUser : IAudit { }
    public partial class ApplicationRole : IAudit { }
    public partial class Department : IAudit { }
    public partial class Employee : IAudit { }
}
