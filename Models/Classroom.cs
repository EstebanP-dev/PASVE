using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Classroom
    {
        public Classroom()
        {
            Classes = new HashSet<Class>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public Guid FkBranch { get; set; }
        public bool? Active { get; set; }

        public virtual Branch FkBranchNavigation { get; set; } = null!;
        public virtual ICollection<Class> Classes { get; set; }
    }
}
