using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Career
    {
        public Career()
        {
            SubjectsCareers = new HashSet<SubjectsCareer>();
            UsersCareers = new HashSet<UsersCareer>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Semesters { get; set; }
        public Guid FkDirector { get; set; }
        public Guid FkDepartmet { get; set; }
        public bool? Active { get; set; }

        public virtual Department FkDepartmetNavigation { get; set; } = null!;
        public virtual User FkDirectorNavigation { get; set; } = null!;
        public virtual ICollection<SubjectsCareer> SubjectsCareers { get; set; }
        public virtual ICollection<UsersCareer> UsersCareers { get; set; }
    }
}
