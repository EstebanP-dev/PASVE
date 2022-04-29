using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Project
    {
        public Project()
        {
            Installments = new HashSet<Installment>();
            ProjectsClassesUsers = new HashSet<ProjectsClassesUser>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Active { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual ICollection<Installment> Installments { get; set; }
        public virtual ICollection<ProjectsClassesUser> ProjectsClassesUsers { get; set; }
    }
}
