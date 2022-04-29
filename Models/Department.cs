using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Department
    {
        public Department()
        {
            BranchesDepartments = new HashSet<BranchesDepartment>();
            Careers = new HashSet<Career>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<BranchesDepartment> BranchesDepartments { get; set; }
        public virtual ICollection<Career> Careers { get; set; }
    }
}
