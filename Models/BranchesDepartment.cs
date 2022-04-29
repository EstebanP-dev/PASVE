using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class BranchesDepartment
    {
        public Guid FkBranch { get; set; }
        public Guid FkDepartment { get; set; }
        public bool? Active { get; set; }

        public virtual Branch FkBranchNavigation { get; set; } = null!;
        public virtual Department FkDepartmentNavigation { get; set; } = null!;
    }
}
