using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Branch
    {
        public Branch()
        {
            BranchesDepartments = new HashSet<BranchesDepartment>();
            Classrooms = new HashSet<Classroom>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid FkCity { get; set; }
        public Guid FkBusiness { get; set; }
        public bool? Active { get; set; }

        public virtual Business FkBusinessNavigation { get; set; } = null!;
        public virtual City FkCityNavigation { get; set; } = null!;
        public virtual ICollection<BranchesDepartment> BranchesDepartments { get; set; }
        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}
