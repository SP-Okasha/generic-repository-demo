using System;
using System.Collections.Generic;

namespace GRPT.Repository.Database
{
    public partial class ApplicationUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int RoleRid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ApplicationRole RoleR { get; set; } = null!;
        public virtual Employee? Employee { get; set; }
    }
}
